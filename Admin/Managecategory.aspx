<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="Managecategory.aspx.cs" Inherits="Addcategory" ClientIDMode="Static"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="templato_full">
<div id="templatemo_main">
<form  method="post" runat="server">    
    <div class="pathdiv">      
        <asp:SiteMapPath ID="SiteMapPath1" class="path" runat="server">
        </asp:SiteMapPath>               
    </div>
<div class="products">            
            <div class="prod_categories"> 
            <div class="addpro"><a href="Addcategory.aspx">Add New Category</a></div>
               <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Manage Category</strong></span></div>
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px" Width="100%" GridLines="Horizontal"
                    DataKeyNames="category_id"  HeaderStyle-BorderColor="Maroon" OnRowCommand="Deletecategory" RowStyle-BorderColor="Maroon"
                    HeaderStyle-CssClass="headtable" ShowHeader="false"  ShowFooter="false">                       
                    <HeaderStyle BorderColor="Maroon" CssClass="headtable"></HeaderStyle>

                    <RowStyle BorderColor="#800000"/>                    
                    <Columns>
                        <asp:TemplateField ItemStyle-BorderWidth="0">
                        <ItemTemplate>  
                                                                               
                                 <%# Imagebind(Eval("category_id").ToString(), Eval("category_image").ToString(), Eval("category_name").ToString())%>                        
                                
                        </ItemTemplate>

                        <ItemStyle BorderWidth="0px"></ItemStyle>
                        </asp:TemplateField>
                                
                        <asp:TemplateField>
                            <ItemTemplate>  
                                <asp:LinkButton runat="server" CommandName="Del" CommandArgument='<%#Eval("category_id") %>' ClientIDMode="Static">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>  
                      
                            <a href="Addcategory.aspx?catname=<%#Eval("category_name") %>&catid=<%#Eval("category_id") %>" title="Edit">EDIT</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                                
                    </Columns>
                    
                </asp:GridView>
                <div class="clear h20"></div>              
            </div>
</div>
    
</form>
</div>
</div>
</asp:Content>

