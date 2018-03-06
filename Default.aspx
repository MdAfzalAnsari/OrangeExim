<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Orange Exim Pvt Ltd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/skdslider.css" />      
    <script src="js/skdslider.js" type="text/javascript"></script>    
    <script src="js/skdslider.min.js" type="text/javascript"></script>   
    
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#demo').skdslider({ 'delay': 5000, 'fadeSpeed': 2000, 'showNextPrev': true, 'showPlayButton': true, 'autoStart': true });
            //jQuery('#demo1').skdslider({ 'delay': 5000, 'fadeSpeed': 2000, 'autoStart': true, 'pauseOnHover': true });
        });     
    </script>
      
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="fb-root"></div>
    <script>        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));</script>
    <%--<form id="Form1" runat="server">    --%>
    <div class="clear h20"></div>   
    <%--<div id="templatemo_slider">--%>
    	 <%--<div class="slider-wrapper theme-default">--%>
            <div id="demo" class="skdslider"  runat="server">
            <ul id="ulslide" runat="server">
                <%--<img src="images/slider/slide-1.jpg" alt="" />
                <img src="images/slider/slide-2.jpg" alt="" title="" />
                <img src="images/slider/slide-3.png" alt="" />
                <img src="images/slider/slide-4.jpg" alt="" title="" />--%>
                <%--<asp:Image ID="slider" runat="server" ImageUrl=""/>--%>
            </ul>
            </div>            
        <%--</div>--%>
        
    <%--</div>--%>
    <div class="templato_full">   
    <div id="templatemo_main">    	
        <div class="clear h20"></div>
        <div class="clear h20"></div>
        <div class="half2 left tv">          
		  <div class="frame" id="youtubelink" runat="server">
		 	 <div>&nbsp;</div><%--<h3><span></span></h3> 	 --%>
	     </div>
        </div>
        <div class="half right para" style="">
         <div class="xx"><h4><span class="Abcom">About Company</span></h4></div>
		    <p class="info" id="com_info" runat="server"><%--Orange Exim Pvt. Ltd., An ISO-9001-2008 Company and Water Quality Association 
            Rajkot Certified, formed in 1998 by experienced water treatment technocrats and engineering 
            professionals to apply new technology of ADVANCE ION-EXCHANGE, MEMBRANE AND ULTRA FILTRATION 
            to industrial and domestic processing, water and waste water purification and pollution control. 
            All its products are marketed by Orange Exim Pvt. Ltd.does design, develop & install water and 
            waste water purification system.Orange Exim Pvt. Ltd. undertakes turnkey Renovation, Retrofitting & 
            upgrading Water & Waste water treatment System to its optimum efficiency.
            THE PHILOSOPHY: Refining the science of water treatment………. At Orange Exim Pvt. Ltd., we aim not to 
            sale merely products but to offer total package: The product, the application expertise and comprehensive sales & 
            service support. Making water treatment pay…….. Orange Exim Pvt. Ltd. offers cost effective solution that go 
            beyond technology. Be it Water and Waste Water Treatment or Pollution Control. Water treatment is no more 
            expensive at Orange Exim Pvt. Ltd.--%>
            </p> 
            <asp:Button href="" CssClass="more1" style="font-size:10px;float:left;border: 1px solid;border-radius:4px;color: #0067CE;" id="readpara" runat="server" OnClick="showdata" Text="Read More" Visible="false" UseSubmitBehavior="false"/>
         </div>
        <div class="clear"></div>		
		<div id="gallery1">		
            <div class="col one_fourth gallery_box" >
                <div class="img_frame1 img_frame_14 img_nom" id="thumbs" runat="server">
                <%--<span class="clip">                
                 </span> --%>
                   <%--<h4>
                   <strong class="Prodhead">
                   Domestic R.O System</strong><br/></h4>--%>
                </div>
                <p class="thumbparag" id="thumb_para" runat="server"></p>
                <asp:HyperLink ID="gallerylink0" runat="server" CssClass="more" style="font-size:10px;">Products</asp:HyperLink>
                <%--<a href="gallery.aspx" class="more" style="font-size:10px;" id="gallerylink0" runat="server">Products</a>--%>
            </div>
            <div class="col one_fourth gallery_box ">
                <div class="img_frame1 img_frame_14 img_nom" id="thumbs2" runat="server">
                <%--<span class="clip im2">                
                 </span> --%>
                    <%--<h4><strong class="Prodhead">
                    Industrial R.O System</strong><br/></h4>--%>
                </div>                
                <p class="thumbparag" id="thumb_para2" runat="server">
                </p>
                <asp:HyperLink ID="gallerylink1" runat="server" CssClass="more" style="font-size:10px;">Products</asp:HyperLink>
                <%--<a href="gallery.aspx?cat=Industrial Appliances" class="more" style="font-size:10px;" id="gallerylink1" runat="server" >Products</a>--%>
            </div>
            <div class="col one_fourth gallery_box">
                <div class="img_frame1 img_frame_14 img_nom" id="thumbs3" runat="server">
               <%-- <span class="clip im3">                
                 </span> 
                   <h4><strong class="head">
                   Home Appliances</strong><br/></h4>--%>
                </div>            
                <p class="thumbparag" id="thumb_para3" runat="server"> </p>
                <asp:HyperLink ID="gallerylink2" runat="server" CssClass="more" style="font-size:10px;">Products</asp:HyperLink>
                <%--<a href="gallery.aspx?cat=Home Appliances" class="more" style="font-size:10px;" id="gallerylink2" runat="server">Products</a>--%>
            </div>
		</div>	
        <div class="col one_fourth11">
            <h4 style="color:#333;text-align:center;text-decoration:underline;">Products Gallery</h4>
            <ul class="footer_gallery" id="footer_feature" runat="server">
            	<%--<li><a href="images/product/5.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/slide-1.jpg" alt="image 6" class="feature"/></a></li>--%>
                <%--<li><a href="images/product/industrial.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/111.jpg" alt="image 7" class=""/></a></li>
                <li><a href="images/product/9.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/extra.jpg" alt="image 8" class=""/></a></li>
				<li><a href="images/product/17.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/171.jpg" alt="image 9" class=""/></a></li>
				<li><a href="images/product/3.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/33.jpg" alt="image 10" class=""/></a></li>
                <li><a href="images/product/5.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/slide-1.jpg" alt="image 6" class=""/></a></li>
				<li><a href="images/product/4.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/44.jpg" alt="image 6" class=""/></a></li>
				<li><a href="images/product/18.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/188.jpg" alt="image 6" class=""/></a></li>				
				<li><a href="images/product/22.jpg"  rel="lightbox[portfolio]">
                <img src="images/product/222.jpg" alt="image 6" class=""/></a></li>--%>
            </ul>
            <div class="clear"></div>

            <a href="gallery.aspx" class="more" id="sizemore" style="position:relative;float:left;margin-top:0px;">Products</a>
        </div>
       <%-- <div class="fb-like-box clickshow" data-href="http://www.facebook.com/pages/Orange-exim-Pvtltd/362893907126427" data-height="200" data-colorscheme="light" data-show-faces="true" data-header="true" data-stream="false" data-show-border="true"></div>--%>
        
       
        <ul id="carousel" class="elastislide-list" runat="server">
					<%--<li><img class="imgslide" src="Image/1.jpg" alt=""/></li>
					<li><img class="imgslide" src="Image/2.png"/></li>
					<li><img class="imgslide" src="Image/3.png"/></li>
					<li><img class="imgslide" src="Image/4.jpg"/></li>
					<li><img class="imgslide" src="Image/5.png"/></li>
                    <li><img class="imgslide" src="Image/6.jpg"/></li>
					<li><img class="imgslide" src="Image/7.png"/></li>
					<li><img class="imgslide" src="Image/8.png"/></li>
					<li><img class="imgslide" src="Image/9.png"/></li>
					<li><img class="imgslide" src="Image/10.png"/></li>
					<li><img class="imgslide" src="Image/11.png"/></li>				--%>					
		</ul>			
		<script type="text/javascript" src="js/jquery.elastislide.js"></script> 
		<script type="text/javascript">			
			$( '#carousel' ).elastislide();			
		</script>
    </div>
    </div>        
    <%--</form>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

</asp:Content>

