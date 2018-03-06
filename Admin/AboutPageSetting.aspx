<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="AboutPageSetting.aspx.cs" Inherits="Admin_PageSetting" ClientIDMode="Static" %>

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
    <div class="products">            
            <div class="" style="width:800px;margin:0 auto;">
            <div class="update" id="Updatehead" style="background-color:#C0C0C0" runat="server">
                <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="addpro"><a href="manageaboutpage.aspx">Manage About Us Page</a></div>
                <asp:GridView ID="aboutdetails" runat="server" AutoGenerateColumns="False"  Width="100%" OnRowCommand="deleteabout"
                    DataSourceID="aboutdata" BackColor="White" BorderColor="#800000" GridLines="Horizontal" ShowFooter="false"
                    BorderStyle="None"  CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="Abouthead" HeaderText="About Head" 
                            SortExpression="Abouthead" />
                        <asp:BoundField DataField="About" HeaderText="About Description" SortExpression="About" ControlStyle-CssClass="aboutdescb" ControlStyle-ForeColor="#4a4a4a"/>
                        <asp:TemplateField>
                                <ItemTemplate>
                                     <a href="manageaboutpage.aspx?id=<%#Eval("about_id") %>" title="Edit">EDIT</a>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>                                     
                                     <asp:LinkButton ID="deleteaboutcategory" runat="server" CommandName="Del" CommandArgument='<%#Eval("about_id") %>'>Delete</asp:LinkButton>

                                </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#FF5914" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#1a1a1a" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />

                </asp:GridView>
                <asp:SqlDataSource ID="aboutdata" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OrangeConnectionString %>" 
                    SelectCommand="SELECT * FROM [about_us]"></asp:SqlDataSource>
                    <div class="clear h20"></div>
            
            </div>
    </div>
    </form>
</div>
</div>
</asp:Content>

