jQuery.noConflict()(function($){
$(document).ready(function() {
		$("#nav-shadow li").hover(function() {
			var e = this;
		    $(e).find("a").stop().animate({ marginTop: "-14px" }, 250, function() {
		    	$(e).find("a").animate({ marginTop: "-10px" }, 250);
		    });
		    $(e).find("img.shadow").stop().animate({ width: "80%", height: "20px", marginLeft: "8px", opacity: 0.25 }, 250);
		},function(){
			var e = this;
		    $(e).find("a").stop().animate({ marginTop: "4px" }, 250, function() {
		    	$(e).find("a").animate({ marginTop: "0px" }, 250);
		    });
		    $(e).find("img.shadow").stop().animate({ width: "100%", height: "27px", marginLeft: "0", opacity: 1 }, 250);
		});
					
	});
	});
//FULLWIDTH BACKGROUND JQUERY CODE
jQuery.noConflict()(function($){
$(document).ready(function() {
	$.backstretch("images/fullwidth-bg.jpg");
  	});
});







// ===============
// Slider function
// ===============
function slider(){

	//Main slider
	$('#flexcarousel').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: false,
    slideshow: false,
    itemWidth: 188,
    //itemMargin: 5 ,
    asNavFor: '#flexslider'
  });
   
  $('#flexslider').flexslider({
    animation: "slide",
    controlNav: true,
    animationLoop: true,
    slideshow: true,
	slideshowSpeed: 5000,
	animationSpeed: 600,
    sync: "#flexcarousel"
  });
  
  // Thubnail
  $('#flexcarousel-product').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: false,
    slideshow: false,
    itemWidth: 115,
    asNavFor: "#flexslider-product"
  });
  
  $('#flexslider-product').flexslider({
    animation: "slide",
    controlNav: true,
    animationLoop: true,
    slideshow: false,
    sync: "#flexcarousel-product"
  });

  // Brands
  $('#flexcarousel-brands').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: true,
    slideshow: false,
    itemWidth: 180,
  });
}






/***************************************************
		CYCLE SLIDER
***************************************************/
jQuery.noConflict()(function($){
$(document).ready(function() {
    $('#cycle-slider').cycle({
		fx:     'scrollDown', 
		prev:    '#prev',
        next:    '#next',
		easing: 'bounceout',
		 pause:   0,
		 timeout: 0,
           
		delay:  -2000   
	});
	
	});
});

/***************************************************
		CYCLE SLIDER
***************************************************/
jQuery.noConflict()(function($){
$(document).ready(function() {
$('#sliderClients').cycle({
		fx:     'scrollLeft', 
		prev:    '#prev',
        next:    '#next',
		 pause:   0, 
		timeout: 0, 		
		delay:  -2000   
	});
	
	});
});
jQuery.noConflict()(function($){
$(document).ready(function() { 
	$('a.preview').each(function() {
        $(this).removeAttr('data-rel').attr('rel', 'prettyPhoto');
});
})
});
/***************************************************
	    THUMB PORTFOLIO HOVER
***************************************************/
jQuery(document).ready(function($) {
	$(".portfolio-item-thumb").hover(function(){
		$(this).find(".item-links").stop(true, true).animate({ opacity: 'show' }, 400);
	}, function() {
		$(this).find(".item-links").stop(true, true).animate({ opacity: 'hide' }, 400);		
	});
});	
jQuery.noConflict()(function($){
$(document).ready(function() {
 $('#slider3').nivoSlider({
 pauseTime:5000,
 pauseOnHover:false
 }); 
 });
});
jQuery.noConflict()(function($){
$(document).ready(function() {
 $('#slider4').nivoSlider({
 pauseTime:5000,
 pauseOnHover:false,
 controlNavThumbs:true
 });
 });
 });
jQuery.noConflict()(function($){
$(document).ready(function() {
jQuery('.slideimage').hide();
jQuery('.slide-minicaption').hide();
jQuery('.slide-minicaptiontitle').hide();
jQuery('.accordian-slider-caption').hide();
jQuery('.accordian-slider-captiontitle').hide();
});
});
jQuery.noConflict()(function($){
jQuery(window).bind("load", function() {
jQuery('.slideimage:hidden').fadeIn(800);
jQuery(".kwicks.horizontal li").css('background', '#FFF');
jQuery('.accordian-slider-caption').show();
jQuery('.accordian-slider-captiontitle').show();

jQuery('.kwicks').kwicks({
max : 960,
spacing : 0
});
jQuery(function(){
jQuery(".accordian-slider-caption").fadeTo(1, 0);
jQuery(".slide-minicaption").fadeTo(1, 0.9);
jQuery(".kwicks").each(function () {
jQuery(".kwicks").hover(function() {
jQuery('.accordian-slider-caption').stop().animate({opacity: 0.9, left: '50'}, 900 );

},function(){
jQuery('.accordian-slider-caption').stop().animate({opacity: 0, left: '940'}, 900 );

});
});
});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() {
$(".item-hover").hover(function(){
$(this).find(".portfolio-thumbnail").stop(true, true).animate({ opacity: 'show' }, 1000);
}, function() {
$(this).find(".portfolio-thumbnail").stop(true, true).animate({ opacity: 'hide' }, 1000);
});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() { 
$('a.portfolio-item-preview').each(function() {
 $(this).removeAttr('data-rel').attr('rel', 'prettyPhoto');
});
})
});
jQuery.noConflict()(function($){
$(document).ready(function() {
$('.kwicks').kwicks({
max : 220,
spacing : 5
});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() { 
 var originalFontSize = $('body').css('font-size');
 $(".resetFont").click(function(){
 $('body').css('font-size', originalFontSize);
 });
 $(".increaseFont").click(function(){
 var currentFontSize = $('body').css('font-size');
 var currentFontSizeNum = parseFloat(currentFontSize, 12);
 var newFontSize = currentFontSizeNum+1;
 $('body').css('font-size', newFontSize);
 return false;
 });
 $(".decreaseFont").click(function(){
 var currentFontSize = $('body').css('font-size');
 var currentFontSizeNum = parseFloat(currentFontSize, 12);
 var newFontSize = currentFontSizeNum-1;
 $('body').css('font-size', newFontSize);
 return false;
 });
})
});

jQuery.noConflict()(function($){
$(document).ready(function() { 
 var originalFontSize = $(':header').css('font-size');
 $(".resetFontHeader").click(function(){
 $(':header').css('font-size', originalFontSize);
 });
 $(".increaseFontHeade").click(function(){
 var currentFontSize = $(':header').css('font-size');
 var currentFontSizeNum = parseFloat(currentFontSize, 12);
 var newFontSize = currentFontSizeNum+1;
 $(':header').css('font-size', newFontSize);
 return false;
 });
 $(".decreaseFontHeader").click(function(){
 var currentFontSize = $(':header').css('font-size');
 var currentFontSizeNum = parseFloat(currentFontSize, 12);
 var newFontSize = currentFontSizeNum-1;
 $(':header').css('font-size', newFontSize);
 return false;
 });
})
});
jQuery.noConflict()(function($){
	$(document).ready(function() {
$("#switcher-handle > #handle").toggle
	(
		function()
		{
			$('#switcher-handle').animate({left:'0px'}, {queue:false,duration:200});
			$('#switcher-handle > #handle').addClass('out');
		}
		,function()
		{
			$('#switcher-handle').animate({left:'-182px'}, {queue:false,duration:200});
			$('#switcher-handle > #handle').removeClass('out');
		}
	);
	
	
			});
			});
jQuery.noConflict()(function($){
$(document).ready(function() {
$('#body-font').bind('change', function() {
var font = $(this).val();
 $('p, a ,#main_navigation, span, ul ,li , ol').css('fontFamily', font);
 
});
});
});


jQuery.noConflict()(function($){
$(document).ready(function() {
$('#headings-font').bind('change', function() {
var font = $(this).val();
 $(':header, :header a, a:header, span:header, :header span').css('fontFamily', font);
 
});
});
});
/*-----------------------------------------FONT STYLER ENDS--------------------------------*/
jQuery.noConflict()(function($){	
jQuery("#slider-small").slides({
		preload: true,
		effect: 'fade',
		fadeSpeed: 550,
		play: 3000
		
		});
	});
jQuery.noConflict()(function($){	
	$(document).ready(function() {
	if (jQuery().slides) {
		
		jQuery("#slides").hover( function() {
			jQuery('.slides-nav').fadeIn(400);
		}, function () {
			jQuery('.slides-nav').fadeOut(400);
		});
		
	}
	});	
	});	
/*-----------------SLIDES WITH CAPTION---------------*/
jQuery.noConflict()(function($){	
	$(function(){
			$('#slides').slides({
				effect: 'fade',
				fadeSpeed: 750,
				play: 5000,
				pause: 2500,
				hoverPause: true,
				animationStart: function(current){
					$('.caption').animate({
						
					},100);
					if (window.console && console.log) {
						// example return of current slide number
						console.log('animationStart on slide: ', current);
					};
				},
				animationComplete: function(current){
					$('.caption').animate({
						
					},200);
					if (window.console && console.log) {
						// example return of current slide number
						console.log('animationComplete on slide: ', current);
					};
				},
				slidesLoaded: function() {
					$('.caption').animate({
						
					},200);
				}
			});
		});
		});
jQuery.noConflict()(function($){
$(document).ready(function() {
$(document).ready(function () {
$('#menu').tabify()

});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() {
$('form#contact-form').submit(function() {
$('form#contact-form .error').remove();
var hasError = false;
$('.requiredField').each(function() {
if(jQuery.trim($(this).val()) == '') {
 var labelText = $(this).prev('label').text();
 $(this).parent().append('<div class="error">You forgot to enter your '+labelText+'</div>');
 $(this).addClass('inputError');
 hasError = true;
 } else if($(this).hasClass('email')) {
 var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
 if(!emailReg.test(jQuery.trim($(this).val()))) {
 var labelText = $(this).prev('label').text();
 $(this).parent().append('<div class="error">You entered an invalid '+labelText+'</div>');
 $(this).addClass('inputError');
 hasError = true;
 }
 }
});
if(!hasError) {
$('form#contact-form input.submit').fadeOut('normal', function() {
$(this).parent().append('');
});
var formInput = $(this).serialize();
$.post($(this).attr('action'),formInput, function(data){
$('form#contact-form').slideUp("fast", function() {
$(this).before('<div class="simple-success">Your email was successfully sent. We will contact you as soon as possible.</div>');
});
});
}

return false;

});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() {
 $('#details').cycle({
fx: 'fade', 
 prev: '#prev',
 next: '#next',
speedIn: 800, 
speedOut: 800, 
delay: 7000
 
});

});
});
jQuery.noConflict()(function($){
$(document).ready(function($){
$('ul#filterable a').click(function() {
$(this).css('outline','none');
$('ul#filterable .current').removeClass('current');
$(this).parent().addClass('current');

return false;
});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() { 
 $('.portfolio-img').each(function() {
 $(this).hover(
 function() {
 $(this).stop().animate({ opacity: 0.2 }, 400);
 },
 function() {
 $(this).stop().animate({ opacity: 1.0 }, 700);
 })
 });
});
});

jQuery.noConflict()(function($){
$(document).ready(function() { 
$(".tweet").tweet({
	 username: "trendywebstar",
	 join_text: null,
	 avatar_size: null,
	 count: 2,
	 auto_join_text_default: "we said,", 
	 auto_join_text_ed: "we",
	 auto_join_text_ing: "we were",
	 auto_join_text_reply: "we replied to",
	 auto_join_text_url: "we were checking out",
	 loading_text: "loading tweets..."
 });
});
});
jQuery.noConflict()(function($){
$(document).ready(function() {
 $('#slider-two-third').cycle({
fx:'fade',
speedIn: 1000, 
speedOut: 1000, 
delay: 2000
});
});
});
jQuery.noConflict()(function($){
$(document).ready(function() { 
$("a[rel^='prettyPhoto']").prettyPhoto({opacity:0.80,default_width:500,default_height:344,theme:'light_rounded',hideflash:false,modal:false});
});
});
var arrowimages={down:['', ''], right:['', '']}
var jqueryslidemenu={
animateduration: {over: 200, out: 200},
buildmenu:function(menuid, arrowsvar){
jQuery(document).ready(function($){
$(" #main_navigation a").removeAttr("title");
var $mainmenu=$("#"+menuid+">ul")
var $headers=$mainmenu.find("ul").parent()
$headers.each(function(i){
var $curobj=$(this)
var $subul=$(this).find('ul:eq(0)')
this._dimensions={w:this.offsetWidth, h:this.offsetHeight, subulw:$subul.outerWidth(), subulh:$subul.outerHeight()}
this.istopheader=$curobj.parents("ul").length==1? true : false
$subul.css({top:this.istopheader? this._dimensions.h+"px" : 0})

var $targetul=$(this).children("ul:eq(0)")
this._offsets={left:$(this).offset().left, top:$(this).offset().top}
var menuleft=this.istopheader? 0 : this._dimensions.w
menuleft=(this._offsets.left+menuleft+this._dimensions.subulw>$(window).width())? (this.istopheader? -this._dimensions.subulw+this._dimensions.w : -this._dimensions.w) + 12 : menuleft
if ($targetul.queue().length<=1) 
if(menuleft==0){
$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).removeClass("menu_flip")
}
if(menuleft!=0 && this.istopheader){
$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).addClass("menu_flip")
}else{
$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).removeClass("menu_flip")
}
$curobj.hover(
function(e){
var $targetul=$(this).children("ul:eq(0)")
this._offsets={left:$(this).offset().left, top:$(this).offset().top}
var menuleft=this.istopheader? 0 : this._dimensions.w
menuleft=(this._offsets.left+menuleft+this._dimensions.subulw>$(window).width())? (this.istopheader? -this._dimensions.subulw+this._dimensions.w : -this._dimensions.w) + 12 : menuleft
if ($targetul.queue().length<=1) 
if(menuleft==0){
$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).removeClass("menu_flip").slideDown(jqueryslidemenu.animateduration.over)
}
if(menuleft!=0 && this.istopheader){
$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).addClass("menu_flip").slideDown(jqueryslidemenu.animateduration.over)
}else{
$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).removeClass("menu_flip").slideDown(jqueryslidemenu.animateduration.over)
}
},
function(e){
var $targetul=$(this).children("ul:eq(0)")
$targetul.slideUp(jqueryslidemenu.animateduration.out)
}
) 
})
$mainmenu.find("ul").css({display:'none', visibility:'visible'})
})
}
}
jqueryslidemenu.buildmenu("main_navigation", arrowimages)
jQuery.noConflict()(function($){
jQuery(document).ready(function($){
var 
speed = 700, 
$wall = $('#portfolio').find('.portfolio-container ul')
;
$wall.masonry({
singleMode: true,
itemSelector: '.one-fourth:not(.invis)',
animate: true,
animationOptions: {
duration: speed,
queue: false
}
});
$('#filterable a').click(function(){
var colorClass = '.' + $(this).attr('class');
if(colorClass=='.all') {
$wall.children('.invis')
.toggleClass('invis').fadeIn(speed);
} else { 
$wall.children().not(colorClass).not('.invis')
.toggleClass('invis').fadeOut(speed);
$wall.children(colorClass+'.invis')
.toggleClass('invis').fadeIn(speed);
}
$wall.masonry();
 return false;
});
});
});
jQuery.noConflict()(function($){
jQuery(document).ready(function($){
var 
speed = 700, 
$wall = $('#portfolio').find('.portfolio-container ul')
;
$wall.masonry({
singleMode: true,
itemSelector: '.one-third:not(.invis)',
animate: true,
animationOptions: {
duration: speed,
queue: false
}
});
$('#filterable a').click(function(){
var colorClass = '.' + $(this).attr('class');
if(colorClass=='.all') {
$wall.children('.invis')
.toggleClass('invis').fadeIn(speed);
} else { 
$wall.children().not(colorClass).not('.invis')
.toggleClass('invis').fadeOut(speed);
$wall.children(colorClass+'.invis')
.toggleClass('invis').fadeIn(speed);
}
$wall.masonry();
 return false;
});
});
});
jQuery.noConflict()(function($){
jQuery(document).ready(function($){
var 
speed = 700, 
$wall = $('#portfolio').find('.portfolio-container ul');
$wall.masonry({
singleMode: true,
itemSelector: '.one-half:not(.invis)',
animate: true,
animationOptions: {
duration: speed,
queue: false
}
});
$('#filterable a').click(function(){
var colorClass = '.' + $(this).attr('class');
if(colorClass=='.all') {
$wall.children('.invis')
.toggleClass('invis').fadeIn(speed);
} else { 
$wall.children().not(colorClass).not('.invis')
.toggleClass('invis').fadeOut(speed);
$wall.children(colorClass+'.invis')
.toggleClass('invis').fadeIn(speed);
}
$wall.masonry();
 return false;
});
});
});

jQuery.noConflict()(function($){
jQuery(document).ready(function($){
var 
speed = 700, 
$wall = $('#portfolio').find('.portfolio-container ul');
$wall.masonry({
singleMode: true,
itemSelector: '.one-fifth:not(.invis)',
animate: true,
animationOptions: {
duration: speed,
queue: false
}
});
$('#filterable a').click(function(){
var colorClass = '.' + $(this).attr('class');
if(colorClass=='.all') {
$wall.children('.invis')
.toggleClass('invis').fadeIn(speed);
} else { 
$wall.children().not(colorClass).not('.invis')
.toggleClass('invis').fadeOut(speed);
$wall.children(colorClass+'.invis')
.toggleClass('invis').fadeIn(speed);
}
$wall.masonry();
 return false;
});
});
});