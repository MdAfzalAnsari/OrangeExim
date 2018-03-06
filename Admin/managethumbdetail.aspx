<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="managethumbdetail.aspx.cs" Inherits="Admin_managethumbdetail" %>

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
                <div class="ChangePassword"><span>Edit Thumb Details</span></div>
                <table class="Adminprofile">                    
                    <tr>
                        <td style="width:143px;display:block;"><asp:Label ID="Thumbe" runat="server" Text="Thumb  Name:"></asp:Label></td>
                        <td><asp:TextBox ID="Thumb_name" runat="server" ValidationGroup="changepass"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="oldpass" runat="server" ErrorMessage="*" ControlToValidate="Thumb_name" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lab2" runat="server" Text="Thumb Description:"></asp:Label></td>
                        <td><textarea rows="3" class="area"  id="Description" runat="server"  ValidationGroup="changepass"></textarea>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="newpass" runat="server" ErrorMessage="*" ControlToValidate="Description" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Thumb Category:"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="droplist"
                                DataSourceID="SqlDataSource1" DataTextField="category_name" 
                                DataValueField="category_name">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:OrangeConnectionString %>" 
                                SelectCommand="SELECT [category_name] FROM [category]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="DropDownList1" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="thumbimg" runat="server" Text="Upload Thumb Image:"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="thumbimageupload" runat="server" /></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="thumbimageupload" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                    <div style="margin:0 auto 0 120px;">
                                <asp:Button ID="changepass" runat="server" Text="Edit Details" CssClass="btn" 
                                    onclick="EditThumb" ValidationGroup="changepass"/>
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

