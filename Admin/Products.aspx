<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Admin_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" method="post">
<div class="templato_full">
    <div id="templatemo_main">
    <%--<div class="pathdiv">      
        <asp:SiteMapPath ID="SiteMapPath1" class="path" runat="server">
        </asp:SiteMapPath>               
    </div>--%>
        <div style="text-align:center;">
        <h2>Welcome Admin</h2>
        </div>
        <div class="products">            
            <div class="prod_style">
                <div class="pro">
                    <div>
                    <a href="ManageCategory.aspx"><span class="prod_image img3"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="ManageCategory.aspx">Add Category</a>
                    </div>
                </div>            
                <div  class="pro">
                    <div>
                        <a href="ManageProducts.aspx"><span class="prod_image img1"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="ManageProducts.aspx">Manage Products</a>        
                    </div>
                </div>
                <div  class="pro">
                    <div>
                    <a href="PageSetting.aspx"><span class="prod_image img2"></span></a>
                    </div>
                    <div class="thumblink">
                    <a class="" href="PageSetting.aspx">PageWise Settings</a>
                    </div>
                </div>          
            </div>
        
        </div>
    </div>
</div>
</form>
    <%--<div class="prolink">
        
        </div>--%>
</asp:Content>

