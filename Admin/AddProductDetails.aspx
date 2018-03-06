<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="AddProductDetails.aspx.cs" Inherits="Admin_home" %>

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
    <div class="main" style="width:42%;margin: 0px auto;">
    <div class="procat"><span class="add_pro-head">Add Product Details</span></div>
    <div class="status">
        <asp:Label ID="statuslabel" runat="server" Text="Label"></asp:Label>
    </div>    
        <form id="form1" runat="server">    
        <table width="400px;">        
        <tr>
        <td class="table" style="width:200px;">Product Name:</td>
        <td><asp:TextBox ID="product_name"  runat="server" placeholder="Enter Product Name" style="width:200px;" class="table"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="product_name"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
        <td class="table">Product Code:</td>
        <td><asp:TextBox ID="product_code"  runat="server" placeholder="Enter Product Code" style="width:200px;" class="table"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="product_code"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td class="table">Product Image</td>
        <td>
            <asp:FileUpload ID="UploadProImage" runat="server" class="btnupload"  /></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="UploadProImage"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td class="table">Product Category</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="droplist"
                DataSourceID="SqlDataSource1" DataTextField="category_name" 
                DataValueField="category_name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OrangeConnectionString %>" 
                SelectCommand="SELECT [category_name] FROM [category]"></asp:SqlDataSource>
        </td>
        </tr>
        <tr>
        <td class="table">Product Price:</td>
        <td><asp:TextBox ID="propricee"  runat="server" placeholder="Enter Product Price" style="width:200px;" class="table"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldpropricee" runat="server" ErrorMessage="*" ControlToValidate="propricee"></asp:RequiredFieldValidator></td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorpropricee" runat="server" ControlToValidate="propricee" ValidationGroup="contactfield"
                    ErrorMessage="Enter price" ValidationExpression="^([0-9]{1,12})$" SetFocusOnError="true"></asp:RegularExpressionValidator>
        </tr>  
        <tr>
        <td class="table">
            <asp:Button ID="sub_btn" runat="server" Text="Submit" class="btn" 
                onclick="SaveData" /></td>
        </tr>       
        </table>
        </form>
    </div>
    </div>
    </div>
</asp:Content>


