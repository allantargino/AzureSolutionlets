<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImageTagging.Default" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=yes" />
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/jquery-1.12.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <title>Image Tagging</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <script type="text/javascript">
              // It is important to place this JavaScript code after ScriptManager1
              var xPos, yPos;
              var prm = Sys.WebForms.PageRequestManager.getInstance();

              function BeginRequestHandler(sender, args) {
                if ($get('<%=Page.ClientID%>') != null) {
                  // Get X and Y positions of scrollbar before the partial postback
                  xPos = $get('<%=Page.ClientID%>').scrollLeft;
                  yPos = $get('<%=Page.ClientID%>').scrollTop;
                }
             }

             function EndRequestHandler(sender, args) {
                 if ($get('<%=Page.ClientID%>') != null) {
                   // Set X and Y positions back to the scrollbar
                   // after partial postback
                   $get('<%=Page.ClientID%>').scrollLeft = xPos;
                   $get('<%=Page.ClientID%>').scrollTop = yPos;
                 }
             }

            function submitButton(event) {
                // Enter Button
                if (event.which == 13) {
                    $('#btnSearch').trigger('click');                                        
                }

                return false;
            }

             prm.add_beginRequest(BeginRequestHandler);
             prm.add_endRequest(EndRequestHandler);
         </script>
        
        <div class="header">
            <div class="imageHeaderDiv">
                <asp:Label ID="lblLogin" runat="server" CssClass="loginLabel" Text="entrar:" />
                <asp:Button ID="btnLogout" runat="server" CssClass="logoutButton" OnClick="btnLogout_Click" Visible="false" Text="(sair)" />
                <asp:ImageButton ID="ibtnAuthenticate" runat="server" CssClass="imageHeader" ImageUrl="~/images/FlickrLogo.png" OnClick="ibtnAuthenticate_Click" />
            </div>
        </div>
        <div class="subHeader"></div>

        <div class="row logo">
            <asp:Image runat="server" ImageUrl="~/images/Logo.png" />
        </div>

        <div class="row">
            <div class="col-lg-2 searchBox">
                <div class="input-group">                    
                    <input id="SearchTermTextBox" runat="server" type="text" class="form-control" placeholder="Buscar na galeria" />
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button" id="btnSearch" runat="server" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-search searchIcon" aria-hidden="true"></span></button>                        
                    </span>                        
                </div>
            </div>
        </div>

        <div class="title">
            <label>GALERIA DE IMAGEM</label>
        </div>

        <section class="photos">            
            <asp:UpdatePanel ID="gallery" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="rptImages_ItemDataBound">
                        <ItemTemplate>
                                    <asp:UpdatePanel ID="galleryItem" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>                    
                                    <asp:Panel ID="gridItem" CssClass="gridItem" runat="server">
                                        <asp:Image CssClass="photoImg" ID="itemImage" runat="server" ImageUrl='<%#DataBinder.Eval(((IDataItemContainer)Container).DataItem, "URL")%>' Height="242" Width="200" />
                                        <div class="caption">
                                            <asp:Image ID="itemWordsLoading" ImageUrl="~/images/Loading.gif" runat="server" ImageAlign="Middle" CssClass="loading" />
                                            <asp:Label ID="itemWords" CssClass="imageWords" runat="server" Text='<%#DataBinder.Eval(((IDataItemContainer)Container).DataItem, "Words")%>' />
                                        </div>                                    
                                        <asp:Timer ID="thumbnailTimer" Interval="1" runat="server" OnTick="thumbnailTimer_Tick" />
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="thumbnailTimer" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>                 
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch"/>
                </Triggers>
            </asp:UpdatePanel>                        
        </section>
    </form>
    <div class="bottomDiv">
        <div class="bottomLeft">
            <asp:Label runat="server" Text="Desenvolvido por:" CssClass="bottomLabel" />
            <a href="http://www.eldorado.org.br" target="_blank">
                <asp:Image runat="server" ImageUrl="~/images/EldoradoLogo.png" CssClass="bottomImage" />
            </a>
        </div>
        <div class="divider">
        </div>
        <div class="bottomRight">
            <a href="https://www.microsoft.com/cognitive-services" target="_blank">
                <asp:Label runat="server" Text="Powered by Microsoft Cognitive Services" CssClass="bottomLabel" />
            </a>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);

            $(window).scroll(function () {
                vertScroll = $(window).scrollTop();
            });
        });

        function InitializeRequest(sender, args) {
            vertScroll = $(window).scrollTop();
        }

        function EndRequest(sender, args) {

            if (typeof (vertScroll) != 'undefined') {
                $(window).scrollTop(vertScroll);
            }
        }
    </script>
</body>
</html>
