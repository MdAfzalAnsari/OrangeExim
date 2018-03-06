<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="PageSetting.aspx.cs" Inherits="Admin_PageSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="templato_full">
    <div id="templatemo_main">
        <div class="pathdiv">      
            <asp:SiteMapPath ID="SiteMapPath1" class="path" runat="server">
            </asp:SiteMapPath>               
        </div>
        <div style="text-align:center;">
        <h2>Welcome Admin</h2>
        </div>
        <div class="products">            
            <div class="prod_style">
                <div class="pro">
                    <div>
                    <a href="ManageHome.aspx"><span class="prod_image img33"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="ManageHome.aspx">Manage Home</a>
                    </div>
                </div>            
                <div  class="pro">
                    <div>
                        <a href="AboutPageSetting.aspx"><span class="prod_image img11"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="AboutPageSetting.aspx">Manage AboutUs</a>        
                    </div>
                </div>
                <div  class="pro">
                    <div>
                    <a href="ManageSlides.aspx"><span class="prod_image img22"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="ManageSlides.aspx">Slide Settings</a>
                    </div>
                </div>          
            </div>
        
        </div>
    </div>
    </div>
    <%--<div class="prolink">
        
        </div>--%>
</asp:Content>



