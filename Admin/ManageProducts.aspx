<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Admin_AddProducts" ClientIDMode="Static"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="templato_full">
<div id="templatemo_main">
<form runat="server">
        <div class="products">  
        <div class="pathdiv">      
            <asp:SiteMapPath ID="SiteMapPath1" class="path" runat="server">
            </asp:SiteMapPath>               
        </div>      
            <div class="prod_categories"> 
            <div class="status"><%--onselectedindexchanged="GridView1_SelectedIndexChanged"--%><%--Checked='<%#(Eval("featured") == 0 ? false : true) %>'--%>
                <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="addpro"><a href="AddProductDetails.aspx">Add New Products</a></div>                           
               <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Manage Products</strong></span></div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" OnRowCommand="productdelete" GridLines="Horizontal" PagerStyle-CssClass="paging"
                        DataKeyNames="product_id" Width="100%" 
                    HeaderStyle-BorderColor="Maroon" OnPageIndexChanging="GridViewgallery_PageIndexChanging"
                        HeaderStyle-CssClass="headtable" ShowHeader="false" 
                    HeaderStyle-Width="100%" AllowPaging="true" PageSize="7" 
                    > 
                        
                                                                  
                    <Columns>                               
                        <asp:TemplateField>
                        <HeaderTemplate >
                           <asp:Label Text="Featured Item" runat="server"/>
                        </HeaderTemplate>
                            <ItemTemplate>                                   
                                <asp:CheckBox ID="chkview" runat="server" Checked='<%# Convert.ToBoolean(Eval("featured"))%>' AutoPostBack="true" OnCheckedChanged="chkview_CheckedChanged"/>                                                                                                            
                                <%--<label for="chkview"></label>  --%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-BorderWidth="0" >
                        <%--<HeaderTemplate >
                           <asp:Label ID="Label1" Text="Product Image" runat="server"/>
                        </HeaderTemplate>         --%>               
                            <ItemTemplate >                                                                                 
                                <%# Imagebind(Eval("product_id").ToString(), Eval("product_image").ToString(), Eval("product_name").ToString())%>                                                        
                            </ItemTemplate>
                        <ItemStyle BorderWidth="0px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField> 
                            <ItemTemplate>  
                            <a class="edibtn" href="AddProductDetails.aspx?productname=<%#Eval("product_name") %>&productid=<%#Eval("product_id") %>" title="Edit" >EDIT</a>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>  
                                <asp:LinkButton class="edibtn" ID="DeleteProduct" runat="server" CommandName="Del" CommandArgument='<%#Eval("product_id") %>' >Delete</asp:LinkButton>
                                <asp:HiddenField ID="hide" Value='<%#Eval("product_id") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>       
                                                 
                    </Columns>
                    
                <HeaderStyle BorderColor="Maroon" BorderWidth="0px" CssClass="headtable"></HeaderStyle>
                    
                </asp:GridView>                
                <div class="clear h20" ></div>
                <div style=""><span style="font-size:16px;color:Maroon;font-family:Californian FB;"><strong>Select CheckBox to Make Product Featured Appear on Home Page Photo Gallery</strong></span></div>
                <div style=""><span style="font-size:16px;color:Maroon;font-family:Californian FB;"><strong>Only Top 9 Images selected through checkbox Will be Displayed in  Photo Gallery</strong></span></div>
               <%-- <asp:Button ID="Butt" runat="server" Text="Set Featured" OnClick="setfeatured" UseSubmitBehavior="false" CssClass="btn"/> --%>                             
            </div>
        </div>        
        </form>
    </div>
    </div>
</asp:Content>

