<%@ Page Title="User Registration" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Registration_detail.aspx.cs" Inherits="Registration_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="templato_full">
    <div id="templatemo_main">
                <div class="register">
                <div class="registerhead"><span>Registration Details</span></div>
                <table class="profile">                    
                    <tr>
                        <td><asp:Label ID="LabelName" runat="server" Text="First Name:"></asp:Label></td>
                        <td><asp:TextBox ID="First" runat="server" ValidationGroup="changepass"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredField7" runat="server" ErrorMessage="*" ControlToValidate="First" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                        <td><asp:Label ID="lastc" runat="server" Text="Last Name:"></asp:Label></td>
                        <td><asp:TextBox ID="Last" runat="server" ValidationGroup="changepass"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequirValidator1" runat="server" ErrorMessage="*" ControlToValidate="Last" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="LabelEmail" runat="server" Text="Email ID(LoginId):"></asp:Label></td>
                        <td><asp:TextBox ID="loginemail" runat="server" ValidationGroup="changepass"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="loginemail" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="" ID="EmailRegular" runat="server" ErrorMessage="Invalid Email ID" ControlToValidate="loginemail"
                                ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="changepass"></asp:RegularExpressionValidator>
                        </td>                       
                    </tr>
                    <tr>
                        <td><asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label></td>
                        <td><asp:TextBox ID="New_Password" runat="server" TextMode="Password" ValidationGroup="changepass"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFlidator12" runat="server" ErrorMessage="*" ControlToValidate="New_Password" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="LabelRetype" runat="server" Text="Retype Password:"></asp:Label></td>
                        <td><asp:TextBox ID="Retype_Password" runat="server" TextMode="Password" ValidationGroup="changepass"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="ReqValidator13" runat="server" ErrorMessage="*" ControlToValidate="Retype_Password" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Not Matching" ControlToCompare="New_Password" ControlToValidate="Retype_Password" ValidationGroup="changepass"></asp:CompareValidator>
                            
            
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                        <div style="">
                                    <asp:Button ID="Button5" runat="server" Text="Register" CssClass="btn" OnClick="register"
                                           ValidationGroup="changepass"/>
                        </div> 
                        </td>
                        </tr>                                        
                </table>
                </div>
    </div>
</div>
</asp:Content>


