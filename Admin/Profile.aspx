<%@ Page Title="" Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Admin_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="css/admin.css" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <link href="css/jquery.akordeon.css" rel="stylesheet" type="text/css" />
    <link href="css/demo.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.akordeon.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#buttons').akordeon();            
        });
    </script>    
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
        <div class="demo-wrapper">
        <div class="ChangePassword" id="Updatehead" style="background-color:#C0C0C0;margin: 4px auto;padding: 3px;text-align: left;
            width: 898px;" runat="server">
            <asp:Label ID="statuslabel" runat="server" Text=""></asp:Label></div>
            <div class="clear h20"></div>
             <div class="akordeon" id="buttons">   
                <div class="akordeon-item expanded">
                        <div class="akordeon-item-head">
                            <div class="akordeon-item-head-container">
                                <div class="akordeon-heading">
                                    Change Password
                                </div>
                            </div>
                        </div>
                    <div class="akordeon-item-body">
                        <div class="akordeon-item-content">
                            <div class="ChangePassword"><span>Change Password</span></div>
                                <table class="Adminprofile">                    
                                    <tr>
                                        <td><asp:Label ID="Label8" runat="server" Text="Old Password:"></asp:Label></td>
                                        <td><asp:TextBox ID="Old_Password" runat="server" TextMode="Password" ValidationGroup="changepass"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="Old_Password" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label9" runat="server" Text="New Password:"></asp:Label></td>
                                        <td><asp:TextBox ID="New_Password" runat="server" TextMode="Password" ValidationGroup="changepass"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="New_Password" ValidationGroup="changepass"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label10" runat="server" Text="Retype Password:"></asp:Label></td>
                                        <td><asp:TextBox ID="Retype_Password" runat="server" TextMode="Password" ValidationGroup="changepass"></asp:TextBox></td>
                                        <td>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Matching" ControlToCompare="New_Password" ControlToValidate="Retype_Password" ValidationGroup="changepass"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="Retype_Password" ValidationGroup="changepass"></asp:RequiredFieldValidator>
            
                                        </td>
                                    </tr>                                        
                                    </table>
                                    <table class="Adminprofile">
                                    <tr>
                                        <td></td>
                                        <td>
                                        <div style="margin:0 auto 0 -59px;">
                                                    <asp:Button ID="Button5" runat="server" Text="Change" CssClass="btn" 
                                                      onclick="changepassword"   ValidationGroup="changepass"/>
                                        </div> 
                                        </td>
                                     </tr>
                                    </table>
                        </div>
                    </div>
                </div>
                <div class="akordeon-item">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Admin Profile
                        </div>
                    </div>
                </div>
                <div class="akordeon-item-body">
                    <div class="akordeon-item-content">
                        <div class="ChangePassword"><span>Profile</span></div>
                        <table class="Adminprofile">                    
                            <tr>
                                <td><asp:Label ID="loginid" runat="server" Text="Login ID:"></asp:Label></td>
                                <td><asp:TextBox ID="logID" runat="server" Text="admin" Enabled="false"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="logID" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="Email_ID" runat="server" Text="Email ID:"></asp:Label></td>
                                <td><asp:TextBox ID="Email" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Email" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator CssClass="subscibevalidate" ID="Regulara" runat="server" ErrorMessage="Invalid Email ID" ControlToValidate="Email"
                                        ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="subscribe"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                    <%--<tr>
                        <td><asp:Label ID="contact_person" runat="server" Text="Contact Person:"></asp:Label></td>
                        <td><asp:TextBox ID="contact" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="contact" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                        </td>
                    </tr> --%>
                            <tr>
                                <td><asp:Label ID="Label1" runat="server" Text="Office Address:"></asp:Label></td>
                                <td><textarea rows="3" class="area" id="contentarea" runat="server"></textarea></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="contentarea" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="mobileno" runat="server" Text="Mobile No:"></asp:Label></td>
                                <td><asp:TextBox ID="Mobile_No" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="Mobile_No" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                    <%--<tr>
                        <td><asp:Label ID="Label2" runat="server" Text="City:"></asp:Label></td>
                        <td><asp:TextBox ID="City" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="City" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Pincode:"></asp:Label></td>
                        <td><asp:TextBox ID="Pincode" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="Pincode" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Phone:"></asp:Label></td>
                        <td><asp:TextBox ID="Phone" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="Phone" ValidationGroup="contactdata"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                                 
                </table>
                 <table class="Adminprofile">
                    <td></td>
                    <td>
                        <div style="float:left;margin:0 auto 0 -59px;padding-bottom:30px;">
                                <asp:Button ID="update" runat="server" Text="Update" CssClass="btn" ValidationGroup="contactdata"
                                    onclick="update_Click"/>
                        </div> 
                    </td>
                 </table>
                    </div>
                </div>
            </div>
                <div class="akordeon-item">
                    <div class="akordeon-item-head">
                        <div class="akordeon-item-head-container">
                            <div class="akordeon-heading">
                                Update Logo
                            </div>
                        </div>
                    </div>
                    <div class="akordeon-item-body">
                        <div class="akordeon-item-content">
                            <div class="ChangePassword"><span>Update Logo</span></div>
                    <table class="Adminprofile" style="width:750px;">                                        
                    <tr>
                        <td><asp:Label ID="Label7" runat="server" Text="Change Logo:" style="position:absolute;margin-left:80px;"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="LogoUpload" runat="server" CssClass="btnupload" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="LogoUpload" ValidationGroup="Logo"></asp:RequiredFieldValidator>
                        </td>
                        <td><span></span></td>
                    </tr>                                        
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;margin:0 auto 0 280px;padding-bottom:30px;">
                            <asp:Button ID="Button1" runat="server" Text="Update Logo" CssClass="btn" 
                                onclick="update_logo" ValidationGroup="Logo"/>
                        </div>
                    </td>
                    </tr>       
                    </table>
                        </div>
                    </div>
                </div>
                <div class="akordeon-item">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Update Catalog
                        </div>
                    </div>
                </div>
                <div class="akordeon-item-body">
                    <div class="akordeon-item-content">
                        <div class="ChangePassword"><span>Update Catalog</span></div>
                    <div style="text-align:center;"><span style="font-size:16px;color:Maroon;font-family:Californian FB;"><strong>Please Upload only .pdf or .doc file</strong></span></div>                  
                    <table class="Adminprofile" style="width:750px;">                                        
                    <tr>
                        <td><asp:Label ID="Label5" runat="server" Text="Change Catalog File:" style="position:absolute;margin-left:80px;"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="CatalogUpload" runat="server" CssClass="btnupload" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="LogoUpload" ValidationGroup="catalog"></asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                    </tr>                                        
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;margin:0 auto 0 280px;padding-bottom:30px;">
                            <asp:Button ID="Button2" runat="server" Text="Update Catalog" CssClass="btn" 
                                onclick="update_Catalog" ValidationGroup="catalog"/>
                        </div>
                    </td>
                    </tr>       
                    </table>
                    </div>
                </div>
            </div>
                <div class="akordeon-item">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Update Google Map Link
                        </div>
                    </div>
                </div>
                <div class="akordeon-item-body">
                <div class="akordeon-item-content">
                    <div class="ChangePassword"><span>Update Google Map Link</span></div>
                    <div style="text-align:center;"><span style="font-size:16px;color:Maroon;font-family:Californian FB;"><strong>Please Update Correct Google Link</strong></span></div>                  
                    <table class="Adminprofile">                                        
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Change Link:" style="position:relative;margin-left:80px;display:block;width:106px;"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="googlelink" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="googlelink" ValidationGroup="googlelinks"></asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                    </tr>                                        
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;padding-bottom:30px;">
                            <asp:Button ID="Button3" runat="server" Text="Update Link" CssClass="btn" 
                                onclick="update_link" ValidationGroup="googlelinks"/>
                        </div>
                    </td>
                    </tr>       
                    </table>
                   </div>
                </div>
            </div>
                <div class="akordeon-item">
                <div class="akordeon-item-head">
                    <div class="akordeon-item-head-container">
                        <div class="akordeon-heading">
                            Change Security Question
                        </div>
                    </div>
                </div>
                <div class="akordeon-item-body">
                    <div class="akordeon-item-content">
                        <div class="ChangePassword"><span>Change Security Question</span></div>
                    
                    <table class="Adminprofile">                                        
                     <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Security Question:" style="position:relative;margin-left:56px;display:block;width:131px;"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="question" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="question" ValidationGroup="security"></asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Answer:" style="position:relative;margin-left:80px;display:block;width:106px;"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="answer" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="answer" ValidationGroup="security"></asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                    </tr>                                          
                    <tr>
                    <td></td>
                    <td>
                        <div style="float:left;padding-bottom:30px;">
                            <asp:Button ID="Button4" runat="server" Text="Update" CssClass="btn" 
                                onclick="update_security" ValidationGroup="security"/>
                        </div>
                    </td>
                    </tr>       
                    </table>
                    </div>
                </div>
            </div>
            </div>                                                             
                
                 
                    

                    

                    
                 </div>
            </div>
    </form>
</div>
</div>
</asp:Content>

