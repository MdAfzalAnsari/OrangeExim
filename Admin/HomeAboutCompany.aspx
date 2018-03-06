<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="HomeAboutCompany.aspx.cs" Inherits="Admin_HomeAboutCompany" %>

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
        <div class="clear h20"></div>
    <form id="Form1" runat="server">
            <div class="products">            
                <div class="prod_categories">
                <div class="ChangePassword" id="Updatehead" style="background-color:#C0C0C0" runat="server"><span>
                    <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label></span></div>
                    <div class="clear h20"></div>
                <div class="ChangePassword"><span>Home About Company Details</span></div>
                <table class="Adminprofile">                    
                    <tr>
                        <td style="width:143px;display:block;"><asp:Label ID="Thumbe" runat="server" Text="Change About Content:"></asp:Label></td>
                        <td><textarea rows="5" class="area" id="about_content" runat="server" ValidationGroup="changepass"></textarea></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="about_content1" runat="server" ErrorMessage="*" ControlToValidate="about_content" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                                        
                    <tr>
                    <td></td>
                    <td>
                    <div style="margin:0 auto 0 120px;">
                                <asp:Button ID="changecontent" runat="server" Text="Edit About Content" CssClass="btn" 
                                    onclick="EditContent" ValidationGroup="changepass"/>
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

