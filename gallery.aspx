<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="MasterPage.master" CodeFile="gallery.aspx.cs" Inherits="gallery" Title="" EnableViewState="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    window.onload = function () {
        var seconds = 3;
        setTimeout(function () {
            document.getElementById("<%=cartadd.ClientID %>").style.display = "none";
        }, seconds * 1000);
    };
</script>    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%-- <form id="Form1" runat="server">--%>
    
    <div class="clear h20"></div>   
    <div class="templato_full">
    <div id="templatemo_main">
    <div class="statusorder"  id="cartadd" runat="server">Successfully Added to cart</div>
    <div id="product_type" runat="server"></h2></div>
        <div class="clear h40"></div>
    	<div id="gallery">
            <div class="col one_gallery gallery_box" id="product" runat="server">
                <asp:GridView ID="GridViewgallery" runat="server" AllowPaging="true" PageSize="8" ShowHeader="false" OnPageIndexChanging="GridViewgallery_PageIndexChanging"
                AutoGenerateColumns="False"  PagerStyle-CssClass="paging">                
                    <Columns>
                    <asp:TemplateField>    
                    <ItemTemplate>             
                            <%--<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post">
                            <input type="hidden" name="business" value="afzal-facilitator@globalerainc.com">
                            <input type="hidden" name="cmd" value="_xclick">
                            <input type="hidden" name="item_name" value='<%# Eval("product_name") %>'>
                            <input type="hidden" name="item_number" value="123">
                            <input type="hidden" name="amount" value='<%# Eval("product_price") %>'>
                            
                            <input class="paypalimg" type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_cart_SM.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
                            <img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
                            </form>                                          --%>
                            <%# binddata(Eval("product_name").ToString(), Eval("product_image").ToString())%>
                            <form name="cart" method="post" action="savecart.aspx">
                            <%--<asp:HiddenField ID="HiddenField1" runat="server" Value="azsdasd"/>--%>
                                  <input type="hidden" name="cartvalues" value='<%# bindcart() %>'/>
                                  <input type="hidden" name="itemid"  value='<%# Eval("product_code")%>' />
                                  <input type="hidden" name="productname" value='<%# Eval("product_name") %>'/>
                                  <input type="hidden" name="qty" value="1" />                                  
                                  <input type="hidden" name="productprice" value='<%# Eval("product_price") %>'/>
                                  <input type="hidden" name="url" value='<%# bindurl()%>' />
                                  <asp:Button ID="cartbutton" runat="server" Text="" PostBackUrl="savecart.aspx" CssClass="cart" ToolTip="Add to cart"/>
                                  
                                  <%--<div class='buynow'>--%><%--<asp:LinkButton ID="LinkButton1" runat="server"  PostBackUrl="savecart.aspx" Text="" />--%>
                                  
                                <%--a onclick="addtocart();" class="cursor"><img border="0" class="left_bt" alt="" src="images/cart.png"></a>
                                  <%--<input type="hidden" name="cartkey" value="" runat="server" id="asa"/>
                                  <input type="hidden" name="itemid" value='<%# Eval("product_code") %>' />
                                  <input type="hidden" name="producturl" value="full_url()" />
                                  <input type="hidden" name="qty" value="1" />--%>
                                
                            <%--</div>--%>
                            </form>
                            
                            
                                                        
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    
                    <PagerSettings Mode="NumericFirstLast"/>

                    <PagerStyle CssClass="paging"></PagerStyle>
                    
                </asp:GridView>
                <%--<div class="img_frame img_frame_15 img_nom"><span></span>
                    <a href="images/portfolio/01-1.jpg" rel="lightbox[new_gallery]">
                    <img src="images/portfolio/01.jpg" alt="Gallery Item 1" /></a>
				<div ><span><a href="#"><h3 class="app">Oxen Axis</h3></a></span></div>
             </div>--%>
            </div>
           
            
		</div>
        <div class="clear"></div>
        <%--<div class="pagging">        
            <ul>
                <li><a href="gallery.aspx" target="_parent">1</a></li>
	            <li><a href="gallerypg2.aspx">2</a></li>                               
            </ul>
        </div> --%>
        <div class="clear"></div>
    
    <div class="clear"></div>
    </div>
    </div>
   <%-- </form>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

</asp:Content>


