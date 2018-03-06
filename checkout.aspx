<%@ Page Title="CheckOut" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout" ClientIDMode="Static"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

function payformsbt(){
    var payform = document.getElementById("payform");
    payform.submit();
}

</script>
<div class="templato_full">    
   
    <div id="templatemo_main" runat="server">    	
        <div class="checkoutpage">CheckOut Products</div>
        <div class="checkoutcontent">
        <div class="checkoutdetails"><ul class=""><li class="">Item</li><li class="">Qty</li><li class="">Price</li><li class="delete" style="width:auto;">Delete</li></ul></div>
                   
                       <div id="Mycart2" class="checkcart" runat="server"><%--<%= bindc() %>--%>                 
                       </div>  
                       <div class="checkouttotalclass">Total</div><div class="checkoutprice" id="totalprice" runat="server"></div>
                       <div id="discount" runat="server">Discount</div>
                       
                  
                   
                       <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="paypal">
                        <%--<input type="hidden" name="cmd" value="_cart"/>
                        <input type="hidden" name="business" value="afzal@globalerainc.com"/>
                        <input type="hidden" name="add" value="1"/>
                        <input type="hidden" name="upload" value="1"/>                    
                        <input type="submit" name="submit" value="submitt"/>
                        --%>
                    
                        </form>
                    
       
        <div class="payment">
                        
    
        </div> 
        <div class="checkoutpage">Payment Details</div>
        <div class="paymentDetails">
            <div class="paypalleft"> Paypal</div>
            <asp:Image ID="Image1" runat="server" ImageUrl="images/amex.png"/>
            <asp:Image ID="Image2" runat="server" ImageUrl="images/visa.png"/>
            <asp:Image ID="Image3" runat="server" ImageUrl="images/maestro.jpg"/>
            <asp:Image ID="Image4" runat="server" ImageUrl="images/mastercard.png"/>
            <div class="paypalcheck">
                
                <asp:RadioButton ID="paypalmethod" runat="server" GroupName="paymentselect"/>
            </div>
            <div class="clear h20 bord"></div>
            <div class="clear h20"></div>
            <div class="clear h20"></div>
            <div class="clear h20"></div>
            <div class="clear h20"></div>
            <div class="paypalleftcash"> Cash On Delivery</div>
            <div class="paypalcheck">                
                <asp:RadioButton ID="codmethod" runat="server" GroupName="paymentselect"/>
                <span class="codspan">Check For Cash on Delivery Availability</span>
                <asp:TextBox ID="pincode"  runat="server" placeholder="Enter Pincode" CssClass="pincodeinput"/>
                 <asp:UpdatePanel ID="cashpanel" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="codavail" runat="server" Text="Check" OnClick="check_availability" CssClass="checkbutton"/>
                        <asp:Label ID="codnotify" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                 </asp:UpdatePanel>
            </div>

        </div>
        <div class="clear h40"></div>
        <div class="checkoutpage">Billing And Shipment Details</div>
        <div class="billdata">
        <div class="cod">
            <h3 class="shipmentdiv">Billing Details</h3>
            <asp:TextBox ID="Billing_name" runat="server" placeholder="Enter Name" CssClass="inputtext" ValidationGroup="checkout"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredBilling_name" ValidationGroup="checkout"
                                 ControlToValidate="Billing_name" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/><br/><br/>
            <asp:TextBox ID="Billing_email" runat="server" placeholder="Enter Email" CssClass="inputtext" ValidationGroup="checkout"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredBilling_email" ValidationGroup="checkout"
                                 ControlToValidate="Billing_email" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/>
            <asp:RegularExpressionValidator CssClass="" ID="EmailRegular" runat="server" ErrorMessage="Invalid Email ID" ControlToValidate="Billing_email"
                                ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="checkout"></asp:RegularExpressionValidator>                     
                                 <br/><br/>
            <asp:TextBox ID="Billing_address" TextMode="multiline" ValidationGroup="checkout" CssClass="inputtext" runat="server" placeholder="Enter Address"/>
            <asp:RequiredFieldValidator ID="RequiredBilling_address" ValidationGroup="checkout"
                                 ControlToValidate="Billing_address" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/><br/><br/>
            <asp:TextBox ID="Billing_mobile" runat="server" placeholder="Enter MobileNo" CssClass="inputtext" ValidationGroup="checkout"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredBilling_mobile" ValidationGroup="checkout"
                                 ControlToValidate="Billing_mobile" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/>
            <asp:RegularExpressionValidator ID="RegularBilling_mobilee1" runat="server" ControlToValidate="Billing_mobile" ValidationGroup="checkout"
                    ErrorMessage="Enter 10 Digits" ValidationExpression="\d{10}" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                 <br/><br/>
            <asp:UpdatePanel ID="updatedetails" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            
                            <td><asp:DropDownList ID="ddlCountries" ValidationGroup="checkout" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "Country_Changed" CssClass="drop">
                                </asp:DropDownList>
                            </td>
                            <td>
                                 <asp:RequiredFieldValidator ID="CompareddlCountries" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlCountries" ValidationGroup="checkout"></asp:RequiredFieldValidator>
                                
                            </td>
                        </tr>
                        <tr height="18"></tr>
                        <tr>
                           
                            <td>
                                <asp:DropDownList ID="ddlStates" runat="server" ValidationGroup="checkout" AutoPostBack = "true" OnSelectedIndexChanged = "State_Changed" CssClass="drop">
                                </asp:DropDownList>
                            </td>
                            <td>
                                 <%--<asp:CompareValidator
                                    ID="CompareddlStates" runat="server" ControlToValidate="ddlStates" ValidationGroup="checkout"
                                    ErrorMessage="*" Operator="Equal"
                                    ValueToCompare="Select State"
                                    ForeColor="Red" SetFocusOnError="true">
                                    </asp:CompareValidator>--%>
                                    <asp:RequiredFieldValidator ID="CompareddlStates" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlStates" ValidationGroup="checkout"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr height="18"></tr>
                        <tr>
                            
                            <td>
                                <asp:DropDownList ID="ddlCities" runat="server" CssClass="drop" ValidationGroup="checkout">
                                </asp:DropDownList>
                            </td>
                            <td>
                                 <%--<asp:CompareValidator
                                    ID="CompareddlCities" runat="server" ControlToValidate="ddlCities" ValidationGroup="checkout"
                                    ErrorMessage="*" Operator="Equal"
                                    ValueToCompare="Select City"
                                    ForeColor="Red" SetFocusOnError="true">
                                  </asp:CompareValidator>--%>
                                  <asp:RequiredFieldValidator ID="CompareddlCities" runat="server" ErrorMessage="*" Text="*" InitialValue="0" ControlToValidate="ddlCities" ValidationGroup="checkout"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr height="18"></tr>
                    </table>
                </ContentTemplate>
                <triggers>
                   <asp:AsyncPostBackTrigger ControlID="ddlCountries"  EventName="SelectedIndexChanged" />
                   <asp:AsyncPostBackTrigger ControlID="ddlStates"  EventName="SelectedIndexChanged" />                   
                </triggers>
            </asp:UpdatePanel>
            <asp:TextBox ID="Billing_zipcode" runat="server" placeholder="Zipcode" CssClass="inputtext" ValidationGroup="checkout"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredBilling_zipcode" ValidationGroup="checkout"
                                 ControlToValidate="Billing_zipcode"  
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatormobile_no" runat="server" ControlToValidate="Billing_zipcode" ValidationGroup="checkout"
                    ErrorMessage="Invalid Zipcode" ValidationExpression="\d{6}" SetFocusOnError="true"></asp:RegularExpressionValidator>
        </div>
        <div class="codbill">
            <h3 class="shipmentdiv">Shipment Details</h3>
            <asp:UpdatePanel ID="Updatel1" runat="server" EnableViewState="true">
                <ContentTemplate>
            <asp:CheckBox ID="checkoutcheck" runat="server" CssClass="checkoutcheck" OnCheckedChanged="setsameaddress"  AutoPostBack="true"/><span class="sameadd">Same as Billing Details</span>
            <br />
            <%--</ContentTemplate>--%>
                <%--<triggers>
                   
                 <asp:AsyncPostBackTrigger ControlID="checkoutcheck"  EventName="CheckedChanged" />
                </triggers>--%>
            <%--</asp:UpdatePanel>--%>
            <div style="clear:both;height:26px;"></div> 
            <asp:TextBox ID="shippingname" runat="server" placeholder="Enter Name" CssClass="inputtext" ValidationGroup="checkout"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Requiredshippingname" ValidationGroup="checkout"
                                 ControlToValidate="shippingname" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/><br/><br/><br/>
            <asp:TextBox ID="shippingaddress" TextMode="multiline" CssClass="inputtext" runat="server" placeholder="Enter Address" ValidationGroup="checkout"/>
            <asp:RequiredFieldValidator ID="Requiredshippingaddress" ValidationGroup="checkout"
                                 ControlToValidate="shippingaddress" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/><br/><br/>
            <asp:TextBox ID="shipmobile" runat="server" placeholder="Enter MobileNo" CssClass="inputtext" ValidationGroup="checkout"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="Requiredshipmobile" ValidationGroup="checkout"
                                 ControlToValidate="shipmobile" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/>
            <asp:RegularExpressionValidator ID="RegularExpressionshipmobile" runat="server" ControlToValidate="shipmobile" ValidationGroup="checkout"
                    ErrorMessage="Enter 10 Digits" ValidationExpression="\d{10}" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                 <br/><br/>
           <%-- <asp:UpdatePanel ID="Update" runat="server">
                <ContentTemplate>--%>
                    <table>
                        <tr>
                            
                            <td><asp:DropDownList ID="shippingddlCountries" runat="server" ValidationGroup="checkout" AutoPostBack = "true" OnSelectedIndexChanged = "shippingCountry_Changed" CssClass="drop">
                                </asp:DropDownList>
                            </td>
                            <td>
                                 <%--<asp:CompareValidator
                                    ID="val14" runat="server" ControlToValidate="shippingddlCountries" ValidationGroup="checkout"
                                    ErrorMessage="*" Operator="Equal"
                                    ValueToCompare="Select Country"
                                    ForeColor="Red" SetFocusOnError="true">
                                    </asp:CompareValidator>--%>

                                    <asp:RequiredFieldValidator ID="val14" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="shippingddlCountries" ValidationGroup="checkout"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr height="18"></tr>
                        <tr>
                           
                            <td>
                                <asp:DropDownList ID="shippingddlStates" ValidationGroup="checkout" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "shippingState_Changed" CssClass="drop">
                                </asp:DropDownList>
                            </td>
                            <td>
                                 <%--<asp:CompareValidator
                                    ID="CompareshippingddlStates" runat="server" ControlToValidate="shippingddlStates" ValidationGroup="checkout"
                                    ErrorMessage="*" Operator="Equal"
                                    ValueToCompare="Select State"
                                    ForeColor="Red" SetFocusOnError="true">
                                    </asp:CompareValidator>--%>

                                    <asp:RequiredFieldValidator ID="CompareshippingddlStates" runat="server" ErrorMessage="*"  InitialValue="0" ControlToValidate="shippingddlStates" ValidationGroup="checkout"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr height="18"></tr>
                        <tr>
                            
                            <td>
                                <asp:DropDownList ID="shippingddlCities" runat="server" CssClass="drop" ValidationGroup="checkout">
                                </asp:DropDownList>
                            </td>
                            <td>
                                 <%--<asp:CompareValidator
                                    ID="CompareshippingddlCities" runat="server" ControlToValidate="shippingddlCities" ValidationGroup="checkout"
                                    ErrorMessage="*" Operator="Equal"
                                    ValueToCompare="Select City"
                                    ForeColor="Red" SetFocusOnError="true">
                                    </asp:CompareValidator>
--%>
                                    <asp:RequiredFieldValidator ID="CompareshippingddlCities" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="shippingddlCities" ValidationGroup="checkout"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr height="18"></tr>
                    </table>
                    <asp:TextBox ID="shipping_zipcode" runat="server" placeholder="Zipcode" CssClass="inputtext" ValidationGroup="checkout"></asp:TextBox>
                    
                                 <asp:RequiredFieldValidator ID="Requiredshipping_zipcode" ValidationGroup="checkout"
                                 ControlToValidate="shipping_zipcode" 
                                 ErrorMessage="*"
                                 Text="*" 
                                 runat="server"/>
                    <asp:RegularExpressionValidator ID="shipping_zipcodeValidato1" runat="server" ControlToValidate="shipping_zipcode" ValidationGroup="checkout"
                    ErrorMessage="Enter 10 Digits" ValidationExpression="\d{6}" SetFocusOnError="true"></asp:RegularExpressionValidator>
                            
                </ContentTemplate>
                <triggers>
                   <asp:AsyncPostBackTrigger ControlID="shippingddlCountries"  EventName="SelectedIndexChanged" />
                   <asp:AsyncPostBackTrigger ControlID="shippingddlStates"  EventName="SelectedIndexChanged" />
                   <asp:AsyncPostBackTrigger ControlID="checkoutcheck"  EventName="CheckedChanged" />            
                </triggers>
            </asp:UpdatePanel>
            
        </div>
        
        <div class="subbtn">
            <asp:CheckBox ID="terms" runat="server" CssClass=""/><span class="termscondition">I Accept Terms And Conditions</span>
            
            <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post"   id="payform">
                            <input type="hidden" name="cmd" value="_xclick"/>
                            <input type="hidden" name="add" value="1"/>
                            <input type="hidden" name="upload" value="1"/>
                            <input type="hidden" name="business" value="afzal-facilitator@globalerainc.com"/>                       
                            <input type="hidden" name="item_name" value='Orange Water Purifiers' />
                            <input type="hidden" name="no_shipping" value='1' />                                                                  
                            <input type="hidden" name="return"  value="http://localhost:90/OrangeExim/thankyoupaypal.aspx"/>
                            <%--<input type="hidden" name="return"  value="http://achieverssecurities.com/demo/thankyoupaypal.aspx"/>--%>
                            <input type="hidden" name="rm" value="2"/>                                       
                            <input type="hidden" name="amount" value='<% =tprice() %>'/>
                            <input type="hidden" name="custom" value='<% =bindordercode() %>'/>                                  
                            <input type="hidden" name="notify_url" value='http://localhost:90/OrangeExim/IPNListener.aspx' />
                            <%--<input type="hidden" name="notify_url" value='http://achieverssecurities.com/demo/IPNListener.aspx' />--%>
                            <%--<input type="submit" name="submit" value="Pay" class="checksbtbutton"/>--%>                                                        
           </form>
           <asp:Button ID="submitbutton" ValidationGroup="checkout" runat="server" Text="Submit" CssClass="checksbtbutton" OnClick="checkoutProcess" UseSubmitBehavior="false"/>
        </div>
        </div>
        </div>
    </div>
</div>      
</asp:Content>




