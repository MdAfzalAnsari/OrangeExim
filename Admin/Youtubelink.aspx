<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="Youtubelink.aspx.cs" Inherits="Admin_Youtubelink" %>

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
        <div class="clear h20"></div> 
        <div class="products">            
            <div class="slide_style">
            <div class="ChangePassword" id="Updatehead" style="background-color:#C0C0C0" runat="server"><span>
                    <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label></span></div>
            <table class="Adminprofile" style="width:500px;">                                        
                    <tr>
                        <td><asp:Label ID="Label7" runat="server" Text="Update You Tube Link:" style=""></asp:Label></td>
                        <td><asp:TextBox ID="youlink" runat="server" ValidationGroup="changepass"></asp:TextBox>
                            
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="linkk" runat="server" ErrorMessage="*" ControlToValidate="youlink" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                                        
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;padding-bottom:30px;width:auto;">
                            <asp:Button ID="Button1" runat="server" Text="Upload Link" CssClass="btn" style="width:auto;"
                                onclick="update_link" ValidationGroup="changepass"/>
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