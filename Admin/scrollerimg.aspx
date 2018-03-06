<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="scrollerimg.aspx.cs" Inherits="Admin_scrollerimg" %>

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
<form id="Form1" runat="server">       
        <div class="products">            
            <div class="slide_style">
            <table class="Adminprofile" style="width:500px;">                                        
                    <tr>
                        <td><asp:Label ID="Label7" runat="server" Text="Add Scroller:" style=""></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="ScrollerUpload" runat="server" CssClass="btnupload" style="width:auto;"/>
                        </td>
                        <td><span>Please Upload backgroundless image  of .png format only</span></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ScrollerUpload"></asp:RequiredFieldValidator></td>
                    </tr>                                        
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;padding-bottom:30px;width:auto;">
                            <asp:Button ID="Button1" runat="server" Text="Upload Scroller Image" CssClass="btn" style="width:auto;"
                                onclick="update_scroller"/>
                        </div>
                    </td>
                    </tr>       
            </table>
            </div>
        </div>
</form>
</div>
</div>
</asp:Content>



