<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" 

CodeFile="Category.aspx.cs" Inherits="Admin_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="templatemo_main">
    <form id="form1" runat="server">
   
    <asp:GridView ID="GridView1" runat="server" CssClass="category_grid grid" CellPadding="4" 
        OnRowCommand="DeleteRow" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <AlternatingRowStyle BackColor="White" />  
        <Columns>
            <asp:BoundField DataField="category_id" HeaderText="Category ID" 
                SortExpression="category_id" />
            <asp:BoundField DataField="category_name" HeaderText="Category Name" 
                SortExpression="category_name" />
            <asp:BoundField DataField="category_image" HeaderText="Category Image" 
                SortExpression="category_image" />
            <asp:TemplateField HeaderText="Delete">
             <ItemTemplate>
                    <asp:LinkButton ID="delbutton" runat="server"  
                        CommandArgument='<%#Eval("category_id")%>' CommandName="Del" 
                        ClientIDMode="Static" ForeColor="Blue">Delete</asp:LinkButton>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="editbutton" runat="server"  
                        CommandArgument='<%#Eval("category_id")%>' CommandName="Edit" 
                        ClientIDMode="Static" ForeColor="Blue">Edit</asp:LinkButton>
                </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />        
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OrangeConnectionString %>" 
        SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
    </form>

</div>
</asp:Content>