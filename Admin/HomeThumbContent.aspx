<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="HomeThumbContent.aspx.cs" Inherits="Admin_HomeThumbContent" %>

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
            <div class="about_style">
            <div class="update" id="Updatehead" style="background-color:#C0C0C0" runat="server"><span>
                <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label></span>
            </div>
           <%-- OnRowCommand="deleteabout"Thumbdetails--%>
           <div style="border-bottom:1px solid #800000;"><span style="font-size:21px;color:#800000;font-family:Californian FB;"><strong>Manage Home Thumb Images</strong></span></div>
           <asp:GridView ID="Thumbdetails" runat="server" AutoGenerateColumns="False" BorderWidth="0" GridLines="Horizontal"
                     Width="100%" HeaderStyle-BorderColor="#800000" HeaderStyle-CssClass="headtable" HeaderStyle-BorderWidth="0" ShowHeader="false">
                   
                    <Columns>
                        <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Imagebind(Eval("thum_image").ToString(), Eval("thumb_name").ToString())%>                                                                 
                                    </ItemTemplate>
                        </asp:TemplateField>                    
                    
                        <asp:TemplateField>
                                    <ItemTemplate>
                                         <a href="managethumbdetail.aspx?id=<%#Eval("id") %>" title="Edit">EDIT</a>
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

