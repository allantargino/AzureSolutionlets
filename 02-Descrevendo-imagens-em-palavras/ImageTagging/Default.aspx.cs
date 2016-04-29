//-----------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <author>Instituto de Pesquisas Eldorado</author>
//-----------------------------------------------------------------------

namespace ImageTagging
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using FlickrNet;
    using System.Threading.Tasks;
    /// <summary>
    /// Default Page class
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        #region Getters and Setters

        /// <summary>
        /// List of items (images)
        /// </summary>
        public List<Item> ItemList
        {
            get
            {
                return (List<Item>)ViewState["ItemList"];
            }

            set
            {
                ViewState["ItemList"] = value;
            }
        }

        /// <summary>
        /// List of search items
        /// </summary>
        public List<Item> SearchItemList
        {
            get
            {
                return (List<Item>)ViewState["SearchItemList"];
            }

            set
            {
                ViewState["SearchItemList"] = value;
            }
        }

        #endregion Getters and Setters

        #region Protected Methods

        /// <summary>
        /// Load page with query string of Flickr and get logged user
        /// </summary>        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verify if query string contains authentication values
                if (Request.QueryString["oauth_verifier"] != null && Session["RequestToken"] != null)
                {
                    Flickr flickr = FlickrManager.GetInstance();
                    OAuthRequestToken requestToken = Session["RequestToken"] as OAuthRequestToken;
                    try
                    {
                        OAuthAccessToken accessToken = flickr.OAuthGetAccessToken(requestToken, Request.QueryString["oauth_verifier"]);
                        FlickrManager.OAuthToken = accessToken;
                    }
                    catch (OAuthException)
                    {
                        Debug.Write("[ERROR] - Error to get Flickr access token.");
                    }
                }

                // Verify if not post back
                if (!Page.IsPostBack)
                {
                    SetLogged();
                }                
            }
            catch (System.Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro ao carregar as fotos.');", true);
            }     
        }

        /// <summary>
        /// Flickr login button clicked
        /// </summary>        
        protected void ibtnAuthenticate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Flickr flickr = FlickrManager.GetInstance();
                OAuthRequestToken token = flickr.OAuthGetRequestToken(Request.Url.AbsoluteUri);

                Session["RequestToken"] = token;

                string url = flickr.OAuthCalculateAuthorizationUrl(token.Token, AuthLevel.Read);
                Response.Redirect(url);
            }
            catch (System.Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro ao fazer login.');", true);
            }
        }

        /// <summary>
        /// Method responsible for displaying images according to the search term
        /// </summary>        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // If search term is empty show all images
            if (SearchTermTextBox.Value.Length == 0)
            {
                rptImages.DataSource = ItemList;
                rptImages.DataBind();
            }
            else
            {
                string searchTerm = SearchTermTextBox.Value.Trim();

                // Get the images containing the search term
                SearchItemList = this.ItemList.Where(item => !string.IsNullOrEmpty(item.Words) && item.Words.Contains(searchTerm)).ToList();

                rptImages.DataSource = SearchItemList;
                rptImages.DataBind();
            }

            this.gallery.Update();
        }

        /// <summary>
        /// Flickr logout
        /// </summary>        
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                FlickrManager.OAuthToken = null;
                SetLogged();
            }
            catch (System.Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro ao fazer logout.');", true);
            }
        }

        protected async void thumbnailTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.Timer timer = sender as System.Web.UI.Timer;

                if (timer != null)
                {
                    timer.Enabled = false;
                }

                await SetPhotoCategories(timer.Parent as Panel);
            }
            catch (System.Exception) { }
        }

        protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                Item item = (Item)e.Item.DataItem;

                if (!string.IsNullOrEmpty(item.Words))
                {
                    Timer thumbnailTimer = (Timer)e.Item.FindControl("thumbnailTimer");
                    thumbnailTimer.Enabled = false;

                    Image itemLoading = (Image)e.Item.FindControl("itemWordsLoading");
                    itemLoading.Visible = false;
                }
            }
            catch (System.Exception) { }
        }

        #endregion Protected Methods        

        #region Private Methods

        /// <summary>
        /// Method responsible for getting and analyzing images
        /// </summary>
        private void GetPhotostream()
        {
            try
            {
                // Public  user Id for this sample
                string userId = ConfigurationManager.AppSettings["FlickrDefaultKey"];
                int photosPerPage = int.Parse(ConfigurationManager.AppSettings["FlickrPhotoPerPage"]);

                Flickr flickr = FlickrManager.GetAuthInstance();
                PhotoCollection photos;

                if (FlickrManager.OAuthToken != null)
                {
                    userId = FlickrManager.OAuthToken.UserId;
                    photos = flickr.PeopleGetPublicPhotos(userId, 0, photosPerPage, SafetyLevel.None, PhotoSearchExtras.PathAlias);
                }
                else
                {
                    // If not logged, get photos from public group
                    photos = flickr.GroupsPoolsGetPhotos(userId, 0, photosPerPage);
                }

                var list = photos.ToList();

                ItemList = new List<Item>();

                if (list != null && list.Count > 0)
                {
                    foreach (var photo in list)
                    {
                        Item item = new Item();
                        item.URL = photo.LargeUrl;

                        ItemList.Add(item);
                    }
                }

                rptImages.DataSource = ItemList;
                rptImages.DataBind();
            }
            catch (System.Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro ao carregar as fotos.');", true);
            }
        }

        /// <summary>
        /// Set the photo categories
        /// </summary>
        /// <param name="imagePanel">The panel that contains the photo</param>
        /// <returns></returns>
        private async Task SetPhotoCategories(Panel imagePanel)
        {
            Image itemImage = (Image)imagePanel.FindControl("itemImage");
            Image itemLoading = (Image)imagePanel.FindControl("itemWordsLoading");
            Label itemWords = (Label)imagePanel.FindControl("itemWords");

            itemLoading.Visible = false;

            var item = ItemList.Where(i => i.URL.Equals(itemImage.ImageUrl)).FirstOrDefault();

            if (item != null && string.IsNullOrEmpty(item.Words))
            {
                string[] tags = await ComputerVision.GetCategories(item.URL);
                item.Words = StringUtils.ConvertStringArrayToString(tags);
                itemWords.Text = item.Words;
            }

            if (item == null || String.IsNullOrEmpty(item.Words))
            {
                itemWords.Text = "Não foi possível obter as categorias da imagem";
            }
        }

        /// <summary>
        /// Method responsible for checking if there is a logged in user and adjust the layout for this
        /// </summary>
        private void SetLogged()
        {            
            bool isLogged = FlickrManager.OAuthToken != null;            

            btnLogout.Visible = isLogged;
            ibtnAuthenticate.Enabled = !isLogged;

            if (isLogged)
            {
                lblLogin.Text = FlickrManager.OAuthToken.FullName;
            }
            else
            {
                lblLogin.Text = "entrar:";
            }

            GetPhotostream();
        }

        #endregion Private Methods                        
    }    
}