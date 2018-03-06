<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageHome.aspx.cs" Inherits="Admin_ManageHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="templato_full">
<div id="templatemo_main">
    <form id="Form1" runat="server">
        <div class="pathdiv">      
            <asp:SiteMapPath ID="SiteMapPath1" class="path" runat="server">
            </asp:SiteMapPath>               
        </div>
        <div class="products">          
            <%--<div class="about_style" style="width: 560px;text-align:center;">
                <div style="border-bottom:0px solid #800000;padding:15px;"><a href="HomeThumbContent.aspx" class="paging"><span style="font-size:21px;color:#FFFFFF;font-family:Californian FB;"><strong>Manage Home Thumb Images</strong></span></a></div>
                <div style="border-bottom:0px solid #800000;padding:15px;"><a href="Youtubelink.aspx" class="paging"><span style="font-size:21px;color:#FFFFFF;font-family:Californian FB;"><strong>Manage YoutubeLink Images</strong></span></a></div>
                <div style="border-bottom:0px solid #800000;padding:15px;"><a href="HomeAboutCompany.aspx" class="paging"><span style="font-size:21px;color:#FFFFFF;font-family:Californian FB;"><strong>Manage Home About Us Content</strong></span></a></div>
                <div style="border-bottom:0px solid #800000;padding:15px;"><a href="HomeFooterscroller.aspx" class="paging"><span style="font-size:21px;color:#FFFFFF;font-family:Californian FB;"><strong>Manage Home FooterScroller Content</strong></span></a></div>
            </div>  --%>
            <div class="about_style">
                <div class="pro">
                    <div>
                    <a href="HomeThumbContent.aspx"><span class="home_ thumb"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="HomeThumbContent.aspx">Thumb Images</a>
                    </div>
                </div>            
                <div  class="pro">
                    <div>
                        <a href="Youtubelink.aspx"><span class="home_ youtube"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="Youtubelink.aspx">YoutubeLink Link</a>        
                    </div>
                </div>
                <div  class="pro">
                    <div>
                    <a href="HomeAboutCompany.aspx"><span class="home_ aboutus"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="HomeAboutCompany.aspx">Home About Us</a>
                    </div>
                </div>          
                <div  class="pro">
                    <div>
                    <a href="HomeFooterscroller.aspx"><span class="home_ scroller"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="HomeFooterscroller.aspx">Home FooterScroller</a>
                    </div>
                </div>    
            </div>
        </div>
    </form>
</div>
</div>
</asp:Content>

