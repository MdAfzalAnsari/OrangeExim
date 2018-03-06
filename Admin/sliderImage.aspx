<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="sliderImage.aspx.cs" Inherits="Admin_sliderImage" %>

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
            <div class="slide_style">
            <div class="ChangePassword"><span>Upload Slider Images</span></div>
            <div style="text-align:center;"><span style="font-size:16px;color:Maroon;font-family:Californian FB;"><strong>Please Upload Slide of size 960x240px only To maintain resolution</strong></span></div>
            <table class="Adminprofile" style="width:500px;">                                        
                    <tr>
                        <td style="width:150px;"><asp:Label ID="slidefile" runat="server" Text="Add Slides:"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="SlideUpload" runat="server" CssClass="btnupload" style="width:auto;"/>
                        </td>
                        <td><asp:RequiredFieldValidator ID="aboutheadvalidate" runat="server" ErrorMessage="*" ControlToValidate="SlideUpload"></asp:RequiredFieldValidator></td>
                        <td><span></span></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Slider Title"></asp:Label></td>
                        <td><asp:TextBox ID="s_title" runat="server" style="width:230px;"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="s_title"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Slider Details"></asp:Label></td>
                        <td><textarea rows="3" class="area" id="sliderarea" runat="server" style="width:230px;"></textarea></td>                                        
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="sliderarea"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;padding-bottom:30px;width:auto;">
                            <asp:Button ID="Button1" runat="server" Text="Upload Slide" CssClass="btn" style="width:auto;"
                                onclick="update_slide"/>
                        </div>
                    </td>
                    </tr>       
            </table>
            </div>
        </div>
</form>
</div>
</div>
</asp:Content>

