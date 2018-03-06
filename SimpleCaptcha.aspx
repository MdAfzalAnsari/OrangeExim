<%@ Page Language="C#" MasterPageFile="MasterPage.master"   AutoEventWireup="true" CodeFile="SimpleCaptcha.aspx.cs" Inherits="SimpleCaptcha" Title="Orange Exim Pvt Ltd"%>



   <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        </asp:ScriptManagerProxy>
    <div id="templatemo_main">
    
     
    
    <div>
        
                                 
                  
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            
             
            <asp:Label ID="Label1" runat="server" Text="Panel Created"></asp:Label>
            <asp:Button ID="Button2" CssClass="btn11" runat="server" onclick="Button2_Click" Text="Regenerate Code" EnableEventValidation="false"/>
            </ContentTemplate>
            <%--<Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
            </Triggers>--%>
            </asp:UpdatePanel>  
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
            <asp:Image ID="Image2" runat="server" class=""  ImageUrl="images/loading.gif"/> 
            </ProgressTemplate>
            </asp:UpdateProgress>              
        
       
        
    
         
    </div>          

    </div>

   



</asp:Content>


    
