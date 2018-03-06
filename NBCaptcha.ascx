<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NBCaptcha.ascx.cs" Inherits="NBCaptcha" %>
<script type="text/javascript">
function ReloadCaptcha()
{
    document.getElementById("CaptchaID").src = "/OrangeExim/JpegImage.aspx?reloadCaptcha=true&t=" + Math.random();    
}
</script>
<div>    
    <p>
        <img id="CaptchaID" src="JpegImage.aspx" alt="Sorry refresh Page"/>                                    
    </p>
    <input type="button" value="Regenerate" class="btn" title="Click to generate new image" onclick="ReloadCaptcha()" style="float:left;margin-top:5px;" />
    

</div>