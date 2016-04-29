//-----------------------------------------------------------------------
// <copyright file="FlickrManager.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <author>Instituto de Pesquisas Eldorado</author>
//-----------------------------------------------------------------------

namespace ImageTagging
{
    using System;
    using System.Configuration;
    using System.Web;
    using FlickrNet;

    /// <summary>
    /// Class responsible for managing authentication Flickr API
    /// </summary>
    public class FlickrManager
    {
        /// <summary>
        /// Gets API Key
        /// </summary>
        private static string ApiKey
        {
            get { return ConfigurationManager.AppSettings["FlickrApiKey"]; }
        }

        /// <summary>
        /// Gets Shared secret
        /// </summary>
        private static string SharedSecret
        {
            get { return ConfigurationManager.AppSettings["FlickrSharedSecret"]; }
        }

        /// <summary>
        /// Get instance of Flickr class
        /// </summary>
        /// <returns>The Flickr class</returns>
        public static Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        /// <summary>
        /// Gets Flickr authenticated instance class
        /// </summary>
        /// <returns>The Flickr class</returns>
        public static Flickr GetAuthInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret);
            if (OAuthToken != null)
            {
                f.OAuthAccessToken = OAuthToken.Token;
                f.OAuthAccessTokenSecret = OAuthToken.TokenSecret;
            }
            return f;
        }

        /// <summary>
        /// Gets or sets OAuth token
        /// </summary>
        public static OAuthAccessToken OAuthToken
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["OAuthToken"] == null)
                {
                    return null;
                }
                var values = HttpContext.Current.Request.Cookies["OAuthToken"].Values;
                return new OAuthAccessToken
                {
                    FullName = values["FullName"],
                    Token = values["Token"],
                    TokenSecret = values["TokenSecret"],
                    UserId = values["UserId"],
                    Username = values["Username"]
                };
            }
            set
            {
                // Stores the authentication token in a cookie which will expire in 1 hour
                var cookie = new HttpCookie("OAuthToken")
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                };

                if (value != null)
                {
                    cookie.Values["FullName"] = value.FullName;
                    cookie.Values["Token"] = value.Token;
                    cookie.Values["TokenSecret"] = value.TokenSecret;
                    cookie.Values["UserId"] = value.UserId;
                    cookie.Values["Username"] = value.Username;
                    HttpContext.Current.Response.AppendCookie(cookie);
                }
                else
                {                    
                    HttpContext.Current.Response.Cookies.Remove("OAuthToken");
                    HttpContext.Current.Request.Cookies.Remove("OAuthToken");
                }
            }
        }
    }
}