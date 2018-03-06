//For Profile Pic
$(document).ready(function(){
  $("#jquer").click(function(){
    $("#slide").slideToggle("slow");
  });
});

//For SIde Image Arrow
$(document).ready(function(){
		  $("#rightIcon").click(function(){
			$("#side").fadeToggle("slow");
		  });
		});
		
//Zoom Effect on paragraph		
$(document).ready(function() {
    $(".leftone").click(function(evt) {
        $(this).zoomTo();
    });
});		
		
//Changing color in paragraph on hover		
$(document).ready(function() {
$(".leftone").hover(function(){
        
    });
$(".leftone").mouseleave(function(){
        $(".p_left").css("color","#616161");
    });
});			