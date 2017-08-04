$(document).ready(function() {
	Init();
});

//初始化页面
function Init()
{
	$("nav").height($(document).height());

	// Hide alert
	$(".close").click(function(){
		$(this).parent().parent().fadeOut(500);
		$(".content").delay(300).animate({"marginTop" : 0});
	});

	// Mobile navigation
	var toggleFlag = false;
	var clickFlag = false;
	$(".ico-font").click(function(){
		clickFlag = true;
		if(toggleFlag)
		{
			$("nav").animate({"left" : "-215px"});
			$("section.content").animate({ marginLeft: 0, marginRight: 0}, 400);
			$("section.alert").animate({ marginLeft: 0, marginRight: 0}, 400);
			toggleFlag = false;
		}
		else
		{
			$("nav").animate({"left" : 0}, 20);
			$("section.content").animate({ marginLeft: 215, marginRight: -215}, 20);
			$("section.alert").animate({ marginLeft: 215}, 20);
			toggleFlag = true;
		}
	});

	// Clear input fields on focus
	$('.testing .main input').each(function () {
		var default_value = this.value;
		$(this).focus(function(){
		   if(this.value == default_value) {
		           this.value = '';
		   }
		});
		$(this).blur(function(){
		   if(this.value == '') {
		           this.value = default_value;
		   }
		});
	});

	// Sticky sidebar
	
	$(window).bind("load resize", function(){
		if(clickFlag)
		{
			$("nav").removeAttr("style");
			$("section.content").removeAttr("style");
			$("section.alert").removeAttr("style");
			clickFlag = false;
		}
	 });

}
