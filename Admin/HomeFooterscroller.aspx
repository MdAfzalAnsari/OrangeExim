<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="HomeFooterscroller.aspx.cs" Inherits="Admin_HomeFooterscroller" %>

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
        <div class="clear h20"></div>
        <div class="products">            
            <div class="prod_categories"> 
            <div class="status">
                <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="addpro"><a href="scrollerimg.aspx">Add New Scroller Images</a></div>
               <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Manage Footer Scroller</strong></span></div>
                <asp:GridView ID="scrollergrid" runat="server" AutoGenerateColumns="False"  OnRowCommand="scrolldelete" GridLines="Horizontal" BorderWidth="0" ShowHeader="false"
                     Width="100%">
                                              
                    <Columns>                    
                        <asp:TemplateField ItemStyle-BorderWidth="0">
                        <ItemTemplate>    
                        <%--OnRowCommand="slidedelete"--%>                                                                             
                                 <%# Imagebind(Eval("scroller_id").ToString(), Eval("scrollerimage").ToString())%>                                                        
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete"> 
                            <ItemTemplate>  
                            <%--<a class="edibtn" href="<%--AddProductDetails.aspx?productname=<%#Eval("slideimage") %>&productid=<%#Eval("slide_id") %>" title="Edit">EDIT</a>                                --%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>  
                                <asp:LinkButton class="edibtn" ID="DeleteProduct" runat="server" CommandName="Del" CommandArgument='<%#Eval("scroller_id") %>' >Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                                
                    </Columns>
                </asp:GridView>                            
            </div>
        </div>
</form>
</div>
</div>
</asp:Content>