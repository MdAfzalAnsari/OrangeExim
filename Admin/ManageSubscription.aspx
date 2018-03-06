<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageSubscription.aspx.cs" Inherits="Admin_ManageSubscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="Stylesheet" href="css/admin.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="templato_full">
    <div id="templatemo_main">
        <form id="Form1" runat="server">
            <div class="products">  
                <div class="pathdiv">      
                    <asp:SiteMapPath ID="SiteMapPath1" class="path" runat="server">
                    </asp:SiteMapPath>               
                </div>      
                <div class="prod_categories"> 
                <div class="ChangePassword" id="Updatehead" style="background-color:#C0C0C0;margin: 4px auto;padding: 3px;text-align: left;" runat="server">
                    <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label>
                </div>
                <div style="text-align:center;"><span style="font-size:21px;color:Maroon;font-family:Californian FB;"><strong>Manage Subscription</strong></span></div>
                <asp:GridView ID="subscription1" runat="server" AutoGenerateColumns="False" 
                        BorderWidth="0px" OnRowCommand="Unsubscribe" GridLines="Horizontal" PagerStyle-CssClass="paging"
                        Width="100%" HeaderStyle-BorderColor="Maroon" OnPageIndexChanging="GridViewgallery_PageIndexChanging"
                        HeaderStyle-CssClass="headtable"  HeaderStyle-Width="100%" AllowPaging="true" PageSize="5" CellPadding="6"> 
                        <Columns>                        
                             <asp:BoundField  DataField="subscribe_email" HeaderText="Registered Email"  ItemStyle-CssClass="productretrive"/>    
                             <asp:TemplateField>
                                <ItemTemplate>  
                                    <asp:LinkButton class="edibtn" ID="DeleteProduct" runat="server" CommandName="Del" CommandArgument='<%#Eval("subscribe_id") %>' >Unsubscribe</asp:LinkButton>                                
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

