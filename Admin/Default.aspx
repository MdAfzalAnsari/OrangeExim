<%@ Page Title="Orange" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Index" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="" class="" style="padding:10px;" >
<form runat="server" method="post">
    <div class="loginform">
        <div class="loginhead"><span class="logspan"><strong>Login</strong></span></div>
        <div class="logintable">
        <table runat="server">
            <tr>
            <td><strong>Login ID:</strong></td><td><asp:TextBox ID="adminusername" runat="server" placeholder="Enter User Id" /></td>
            
            
            </tr>
            <tr>
            <td><strong>Password:</strong></td><td><asp:TextBox ID="adminpassword" runat="server" placeholder="Enter Password" TextMode="Password" /></td>
            <td>
            </td>
            </tr>
            <tr><td>
                <asp:Button ID="sub_btn" runat="server" Text="Login" CssClass="btn" 
                    onclick="sub_btn_Click"/></td>
            </tr>
            <tr>
            <td></td>
            <td><strong><a href="ForgotPassword.aspx">Forgot Password?</a></strong></td>
            </tr>
        </table>
        </div>
    </div>
    <div class="validatetext">
         <asp:RequiredFieldValidator ID="requireduser" runat="server" ErrorMessage="Enter Username" ControlToValidate="adminusername" CssClass="requireduser" ForeColor="#7D1900"></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="requiredpassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="adminpassword" CssClass="requiredpassword" ForeColor="#7D1900"></asp:RequiredFieldValidator>
        <asp:Label ID="currentstate" runat="server"  CssClass="productretrive"></asp:Label>
    </div>

    <div class="clear h40"></div>
    
</form>
</div>
</asp:Content>


