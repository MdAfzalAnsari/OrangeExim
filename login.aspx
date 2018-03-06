<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" CodeFile="login.aspx.cs" Inherits="login" Title="Orange Exim Pvt Ltd" EnableViewState="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="Admin/css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear h20"></div>   
    <div class="templato_full">
        <div id="templatemo_main">

                  <div class="loginform">
        <div class="loginhead"><span class="logspan"><strong>Login</strong></span></div>
        <div class="logintable">
        <table id="Table1" runat="server">
            <tr>
            <td><strong>Login ID:</strong></td><td><asp:TextBox ID="cust_username" runat="server" placeholder="Enter User Id" /></td>
            
            
            </tr>
            <tr>
            <td><strong>Password:</strong></td><td><asp:TextBox ID="cust_password" runat="server" placeholder="Enter Password" TextMode="Password" /></td>
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
         <asp:RequiredFieldValidator ID="requireduser" runat="server" ErrorMessage="Enter Username" ControlToValidate="cust_username" CssClass="requireduser" ForeColor="#7D1900"></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="requiredpassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="cust_password" CssClass="requiredpassword" ForeColor="#7D1900"></asp:RequiredFieldValidator>
        <asp:Label ID="currentstate" runat="server"  CssClass="productretrive"></asp:Label>
    </div>

            <div class="clear h40"></div>
        </div>
    </div>

</div>
</asp:Content>
