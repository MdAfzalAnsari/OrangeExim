<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="manageaboutpage.aspx.cs" Inherits="Admin_manageaboutpage" %>

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
            <div class="prod_style">
             <div class="ChangePassword"><span>Change About Us Page Detail</span></div>
             <table class="Adminprofile">                    
                    <tr>
                        <td><asp:Label ID="abt" runat="server" Text="About Heading"></asp:Label></td>
                        <td><asp:TextBox ID="About_Heading" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="aboutheadvalidate" runat="server" ErrorMessage="Enter About Heading" ControlToValidate="About_Heading"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="abtdetails" runat="server" Text="Description:"></asp:Label></td>
                        <td><textarea rows="5" class="area" id="Description" runat="server"></textarea></td>
                        <td>
                            <asp:RequiredFieldValidator ID="TextareaValidator" runat="server" ErrorMessage="Enter About Description" ControlToValidate="Description"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td><asp:Label ID="retype" runat="server" Text="Retype Password:"></asp:Label></td>
                        <td><asp:TextBox ID="Retype_Password" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr> --%>                                       
                </table>
                
                    <div style="float:left;margin:0 auto 0 280px;padding-bottom:30px;">
                    <% if ((Request.QueryString["id"]) != null)
                       {%>
                            <asp:Button ID="update" runat="server" Text="Update" CssClass="btn" OnClick="updatedata"/>
                       <%}
                       else
                       { %>
                            <asp:Button ID="Adddata" runat="server" Text="Add" CssClass="btn" OnClick="Addnewdata"/>
                       <%} %>
                    </div> 
            </div>
    </div>
    </form>
</div>
</div>
</asp:Content>

