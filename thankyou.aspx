<%@ Page Title="Payment ThankYou" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="templato_full">    
   
    <div id="templatemo_main" runat="server">    	
        <div class="orderdetailpage">Thank You</div>
        <div class="clear h20"></div>
        <div class="orderstate">Cash Order Placed Successfully</div>
        <div class="ordercontent">   
            <div class="ordercontentdetails">     
                <div class="order_head">Order Details</div>
                <div class="orderrow">
                    <div class="ordertitle">Order No.</div>
                    <div class="ordervalue">
                        <asp:Label ID="orderno" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="orderrow">
                    <div class="ordertitle">Payment Type</div>
                    <div class="ordervalue">
                        <asp:Label ID="Payment_Type" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="orderrow">
                    <div class="ordertitle">Payment Status</div>
                    <div class="ordervalue">
                        <asp:Label ID="Payment_Status" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="orderrow">
                    <div class="ordertitle">Order Date</div>
                    <div class="ordervalue">
                        <asp:Label ID="Order_Date" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="orderrow">
                    <div class="ordertitle">Billing Information</div>
                    <div class="ordervalue">
                        <asp:Label ID="Billing_Information" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="orderrow">
                    <div class="ordertitle">Shipping Information</div>
                    <div class="ordervalue">
                        <asp:Label ID="Shipping_Information" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="orderrowdata">
                    <div class="thanksdetailshead"><div class="details">Srno.</div> <div class="details">Item</div> <div class="details">Qty</div> <div class="details">Price</div> <div class="details">Total</div></div>
                    <div class="orderbox"><% =orderbox() %></div>
                </div>
                <div class="orderrow">
                    <div class="ordertitle">Total</div>
                    <div class="ordervalue">
                        <asp:Label ID="totalorderprice" runat="server" Text="" CssClass="t_price"></asp:Label>
                    </div>
                </div>
                <%--<% if (Session["cashmethod"] != null)
                   { %>--%>
                <div class="orderrow" id="totaldiv" runat="server">
                    <div class="ordertitle">Cash On Delivery Charge(For India Only)</div>
                    <div class="ordervalue">
                        <asp:Label ID="Lb1" runat="server" Text="100" CssClass="t_price"></asp:Label>
                    </div>
                </div>
                <%--<%} %>--%>
                <div class="orderrow">
                    <div class="ordertitle">Final Amount</div>
                    <div class="ordervalue">
                        <asp:Label ID="finalamt" runat="server" Text="" CssClass="t_price"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>


