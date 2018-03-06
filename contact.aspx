<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" EnableViewState="false" CodeFile="contact.aspx.cs" Inherits="contact" Title="Contact Us" %>
<%@ Register Src="NBCaptcha.ascx" TagName="NBCaptcha" TagPrefix="NB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <%--<form id="Form1" runat="server">    --%>
    
    <div class="templato_full">
    <%--style="border: 0.5px solid #FFB685;height:752px;box-shadow: 0px 0px 3px 1px #FFB685;margin-top: 11px !important;"--%>
    <div id="templatemo_main">    	
        <h2 class="conhead">Contact Form</h2>
         <div class="col two-third">                  
         <div class="clear h40"></div>
            <div id="contact_form">
            <div class="clear h20"></div>             
                <!--<input id="author1" type="text" class="input_field" name="author1" placeholder="Name:"/>-->
                <div class="clear h20"></div>
                    <asp:TextBox ID="author" runat="server" CssClass="input_field"    placeholder="Name:" ValidationGroup="contactfield"/><asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorauthor" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="author" ValidationGroup="contactfield"></asp:RequiredFieldValidator>                               
                    <div class="clear h20"></div>
                    <asp:TextBox ID="email_id" runat="server" CssClass="input_field" placeholder="Email:" ValidationGroup="contactfield"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatoremail_id" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="email_id" ValidationGroup="contactfield"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator CssClass="" ID="EmailRegularValidator" runat="server" ErrorMessage="Invalid Email ID" ControlToValidate="email_id"
                      SetFocusOnError="true" ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="contactfield"></asp:RegularExpressionValidator>
                    <div class="clear h20"></div>                       
                    <asp:TextBox ID="mobile_no" runat="server" CssClass="input_field"   placeholder="Mobile No:" ValidationGroup="contactfield" MaxLength="10"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatormobile_no" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="mobile_no" ValidationGroup="contactfield"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatormobile_no" runat="server" ControlToValidate="mobile_no" ValidationGroup="contactfield"
                    ErrorMessage="Invalid number" ValidationExpression="\d{10}" SetFocusOnError="true"></asp:RegularExpressionValidator>
                    <div class="clear h20"></div>
                    <textarea id="text" name="messagefield" rows="0" cols="0" class="required" placeholder="Message:" runat="server" ValidationGroup="contactfield"></textarea><asp:RequiredFieldValidator
                        ID="RequiredFieldValidatortext" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="text" ValidationGroup="contactfield"></asp:RequiredFieldValidator> 
                  	<div class="clear h20"></div>
                    <NB:NBCaptcha ID="NBCaptcha1" runat="server" />
                    <asp:TextBox ID="txtCaptchaText" runat="server" CssClass="txtInput" placeholder="Enter Captcha Here" ValidationGroup="contactfield"></asp:TextBox>
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="true"></asp:Label>                                        
                    <asp:Button ID="btnSubmitCaptcha" CssClass="submit_btn left" runat="server" onclick="btnSubmitCaptcha_Click" Text="Submit" ValidationGroup="contactfield" />                    
                    <div class="clear:both"></div>
                  	<input type="reset" class="reset" name="reset" id="reset" value="Reset" />                 
            </div> 
		</div>
         
         <div class="col one_third no_margin_right">
         	<h3 class="condetail">Contact Information</h3>
            <h4 class="off">Office Address</h4>
			<span class="detail">Orange Exim Pvt. Ltd.<br/>
			<%--106, 1st Floor, Four Plus Complex,<br/>
			Opp. Vikas Medical Store , Astron Chowk,<br/>
			Sardarnagar Main Road, Rajkot, Gujarat<br/>--%>
                <asp:GridView ID="GridView1" runat="server" CssClass="contactgrid"  Showheader="false"
                 AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField ItemStyle-BorderWidth="0">
                        <ItemTemplate>  
                                                                               
                                 <%# (Eval("address").ToString())%>                        
                                
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>			 
			<span class="mob"><u>Mobile No :</u></span><br/><%--8000115534, 9909915534--%> 
                <asp:Label ID="adminmobile" runat="server" Text=""></asp:Label><br/>
			<span class="phone"><u>Phone No :</u></span><br/><asp:Label ID="adminphone" runat="server" Text=""></asp:Label><br/>
			<strong>Email:</strong>
<%--            <asp:HyperLink ID="emaillink" runat="server" NavigateUrl="mailto:orangeeximpvtltd@gmail.com"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></asp:HyperLink>
--%>             <a id="emaillink" runat="server"><asp:Label ID="adminemail" runat="server" Text=""></asp:Label></a><br/>
			</span>
                
			</div>
            
            
            <div class="imap" id="googleframe" runat="server"><span></span>
               <%--<iframe class="mapp" width="960" height="240" frameborder="0" scrolling="no" marginheight="0" runat="server" id="googlehref"
               marginwidth="0" src="https://maps.google.co.in/maps/ms?msid=206224799552546320570.0004df1bd5faec9cefdbd&amp;msa=0&amp;ie=UTF8&amp;ll=22.291486,70.789287&amp;spn=0.0014,0.002642&amp;t=m&amp;iwloc=0004df1bd9936700387e8&amp;output=embed">
               </iframe>--%>
            </div>
			   <br/><small><a id="googlelink" runat="server" class="largmap" href="" target="_blank" style="color:#0000FF;text-align:left">View Larger Map</a></small>
         </div>
         </div>
        <div class="clear"></div> 
    
   <%-- </form>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

</asp:Content>

