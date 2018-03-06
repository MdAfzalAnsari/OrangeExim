<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Admin_ForgotPasswors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="templato_full">
<div id="templatemo_main">
    <form id="Formforgot" runat="server">
                <span>
                    <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
                </span>
                <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Forgot Password</strong></span></div>
                <table class="Adminprofile" style="width:auto;">                    
                        <tr>
                            <td><asp:Label ID="enteremail" runat="server" Text="Enter Email ID:" style="display:block;"></asp:Label></td>
                            <td><asp:TextBox ID="Enter_Email" runat="server" ValidationGroup="forgotgroup"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ValidationGroup="forgotgroup" ID="emailfg" runat="server" ErrorMessage="*" ControlToValidate="Enter_Email"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td style="width:150px;">
                            <asp:Label ID="Label1" runat="server" Text="Security Question:" style="display:block;"></asp:Label></td>
                            <td><asp:TextBox ID="question" runat="server" Enabled="false"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label2" runat="server" Text="Security Answer:" style="display:block;"></asp:Label></td>
                            <td><asp:TextBox ID="answer" runat="server" ValidationGroup="forgotgroup"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ValidationGroup="forgotgroup" ID="Requiredanswer" runat="server" ErrorMessage="*" ControlToValidate="answer"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                            <div style="margin:0 auto 0 120px;">
                                        <asp:Button ID="forgotpass" runat="server" Text="Submit" CssClass="btn" OnClick="getpassword" ValidationGroup="forgotgroup"/>
                            </div> 
                            </td>
                       </tr>                                                                                           
                </table>
    </form>
</div>
</div>
</asp:Content>

