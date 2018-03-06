<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="Addcategory.aspx.cs" Inherits="Admin_Addcategory" %>

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
    <div class="main" style="width:52%;margin: 0px auto;">
    <div class="procat"><span class="add_pro-head">Add Category Details</span>  </div>
    <form id="Form1" action="" method="post" runat="server"> 

        <table width="500px;">
            <tr>
            <td class="table">Category Name</td><td>
                <asp:TextBox ID="category_name" runat="server" placeholder="Enter Category Name" CssClass="table"></asp:TextBox></td>
            </tr>
            <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="category_name"></asp:RequiredFieldValidator></td>--%>
            <tr>
            <td class="table">Category Image</td>
                <td>
                    <asp:FileUpload ID="imageUpload1" runat="server" CssClass="btnupload"/>
                </td>
                <%--<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="imageUpload1"></asp:RequiredFieldValidator></td>--%>
            </tr>
            <tr><td>
                <asp:Label ID="status" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td><% if ((Request.QueryString["catname"]) != null)
                   {%><asp:Button ID="save1" runat="server" Text="Edit Category" onclick="Save_category"  CssClass="btn"/><%}else{ %>
                   <asp:Button ID="save" runat="server" Text="Create Category" onclick="Save_category"  CssClass="btn"/><%} %>
                   </td>
            </tr>
            <tr>
            <td class="table">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Category Name" ControlToValidate="category_name"></asp:RequiredFieldValidator>
            </td>
            <td class="table">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Image" ControlToValidate="imageUpload1"></asp:RequiredFieldValidator>
            </td>
            </tr>
        </table>
     </form>
    </div>
    </div>
  </div>
</asp:Content>

