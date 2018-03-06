<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageSlides.aspx.cs" Inherits="Admin_ManageSlides" %>

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
            <div class="prod_categories"> 
            <div class="status" style="font-weight:600;">
                <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="addpro"><a href="sliderImage.aspx">Add New Slider Images</a></div>
               <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Manage Slides</strong></span></div>
                <asp:GridView ID="Slidergrid" runat="server" AutoGenerateColumns="False"  OnRowCommand="slidedelete" GridLines="Horizontal" BorderWidth="0" ShowHeader="false"
                     Width="100%" BorderColor="#800000">
                                              
                    <Columns>                    
                        <asp:TemplateField ItemStyle-BorderWidth="0" >
                        <ItemTemplate>    
                        <%--OnRowCommand="slidedelete"--%>                                                                             
                                 <%# Imagebind(Eval("slide_id").ToString(), Eval("slideimage").ToString())%>                                                        
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit"> 
                            <ItemTemplate>  
                            <a class="edibtn" href="sliderImage.aspx?slide_id=<%#Eval("slide_id") %>" title="Edit">EDIT</a>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>  
                                <asp:LinkButton class="edibtn" ID="DeleteProduct" runat="server" CommandName="Del" CommandArgument='<%#Eval("slide_id") %>' >Delete</asp:LinkButton>
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

