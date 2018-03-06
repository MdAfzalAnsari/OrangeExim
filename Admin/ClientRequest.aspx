<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ClientRequest.aspx.cs" Inherits="Admin_ClientRequest" %>

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
        <form id="Form1" action="" method="post" runat="server"> 
            <div class="products">  
            <div class="prod_categories">
            <div class="ChangePassword" id="Updatehead" style="background-color:#C0C0C0;" runat="server">
            <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
            
            </div>
            <div class="status">
                <asp:Label ID="asa" runat="server" Text=""></asp:Label>
            </div>   
            <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Manage Client Request</strong></span></div>
            <div class="clear h20"></div>
            <asp:GridView ID="client" runat="server" AutoGenerateColumns="False" BorderWidth="0px" Width="100%" GridLines="Horizontal"
                    HeaderStyle-BorderColor="Maroon"  RowStyle-BorderColor="Maroon" CellPadding="5" OnRowCommand="Deletecategory"
                    HeaderStyle-CssClass="headtable" ShowHeader="true" > 
                    <Columns>
                        <%--<asp:BoundField  DataField="contact_person" HeaderText="Person" ShowHeader="true"/>--%>
                        <asp:TemplateField HeaderText="Person Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="productretrive" Text='<%#Eval("contact_person") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" CssClass="productretrive" Text='<%#Eval("email_id") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact no">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" CssClass="productretrive" Text='<%#Eval("phone_no") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client Message" HeaderStyle-CssClass="headtablemessage">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" CssClass="productretrive" Text='<%#Eval("message") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>  
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Del" CommandArgument='<%#Eval("contact_id") %>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                    <RowStyle BorderColor="#800000"/>

            </asp:GridView>   
            </div>   
            </div>
        </form>
    </div>
</div>
</asp:Content>

