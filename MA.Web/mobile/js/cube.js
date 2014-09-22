$(function(){
var $html = $('html'),
    $body = $('body'),
    $homeGallery = $('#home-gallery', $body),
    $homeCube = $('#homeCube', $homeGallery),
    $cube = $('#cube', $homeCube),
    $cubeRotate = $('#cubeRotate', $cube),
    $cubeImgs = $('#cubeRotate > div', $homeCube),
    $cubeStatus = $('#cubeStatus', $homeGallery),
    $homeTiles = $('#home-tiles', $body), 
    statusIcons = '',
    cubeSupport = false,
    div = document.createElement('div');

if (div.style['WebkitPerspective'] != undefined){
    cubeSupport = true;
    // Check for crappy pre 3.0 android version which return 
    // a false positive for WebkitPerspective support
    var ua = navigator.userAgent;
    if(ua.indexOf("Android") >= 0){
	// var androidversion = parseFloat(ua.slice(ua.indexOf("Android")+8)); 
	// if (androidversion < 3.0){
	//     cubeSupport = false;
	// }
	cubeSupport = false;
    }
}

if(!cubeSupport){
    $cube.add($cubeImgs).attr('style', '');
}else{
    $body.addClass('cube-support');
}

$cubeImgs.each(function(index){
    if(index){
	statusIcons += '<a href="#"></a>';
    }else{
	statusIcons += '<a class="active" href="#"></a>';
    }
});

$cubeStatus.append(statusIcons);

var $cubeStatusLinks = $('#cubeStatus a');

$cubeImgs.click(function(){
    var $link = $(this);
    linkTrack('promo_tile_mobile', $link.attr('data-tracking'));
    if($link.attr('data-ajax') == 'false'){
	window.location = $link.attr('data-href');
    }else{
	$.mobile.changePage($link.attr('data-href'));
    }
});

$html.bind('swipeleft', function(){
    clearInterval(slideInterval);
    var $activeSlide = $cubeImgs.filter('.active'),
    $to;
    
    if($activeSlide.index() == $cubeImgs.length -1){
	$to = $cubeImgs.eq(0);
	changeSlide($activeSlide, $to);
    }else{
	$to = $cubeImgs.eq($activeSlide.index()+1);
	changeSlide($activeSlide, $to);
    }
    linkTrack('mobile_carousel_menu', $to.attr('data-tracking'));
});

$html.bind('swiperight', function(){
    clearInterval(slideInterval);
    var $activeSlide = $cubeImgs.filter('.active'),
    $to;
    if($activeSlide.index() == 0){
	$to = $cubeImgs.eq($cubeImgs.length-1);
	changeSlide($activeSlide, $to);
    }else{
	$to = $cubeImgs.eq($activeSlide.index()-1);
	changeSlide($activeSlide, $to);
    }
    linkTrack('mobile_carousel_menu', $to.attr('data-tracking'));
});

$cubeStatusLinks.click(function(){
    clearInterval(slideInterval);
    var $activeSlide = $cubeImgs.filter('.active'),
    $to = $cubeImgs.eq($(this).index());
    changeSlide($activeSlide, $to);
    linkTrack('mobile_carousel_menu', $to.attr('data-tracking'));
    return false;
});

$(window).resize(function(){
     
     var w = $html.eq(0).width(),
	 h = Math.round(w/1.76),
	 halfw=  Math.round(w / 2);
     $homeCube.add($cube).add($cubeImgs).css({
	 'height': h,
	 'width': w
     });
     if(cubeSupport){
	 h = h + 15;
	 $cube[0].style['webkitPerspective'] = (w*2) + 'px';
	 $('#side1')[0].style['webkitTransform'] = 'rotateY(0deg) translateZ('+halfw+'px) translateY(-50px)';
	 $('#side2')[0].style['webkitTransform'] = 'rotateY(90deg) translateX(-'+halfw+'px) translateZ('+w+'px) translateY(-50px)';
	 $('#side3')[0].style['webkitTransform'] = 'rotateY(180deg) translateZ('+halfw+'px) translateY(-50px)';
	 $('#side4')[0].style['webkitTransform'] = 'rotateY(-90deg) translateX(-'+halfw+'px) translateY(-50px)';
     }
     $homeTiles.css('margin-top', h-3 +'px');
});

var initial_scroll = window.scrollY;

$(document).bind('scroll', function(){
    if(window.scrollY > initial_scroll){
	$homeCube.css('z-index', '50');
	$cubeStatus.css('z-index', '51');
    }
});

$(document).bind('click', function(){
    $homeCube.css('z-index', '50');
    $cubeStatus.css('z-index', '51');
});

var runSlideShow = function(){
    var $activeSlide = $cubeImgs.filter('.active');
    if($activeSlide.index() == $cubeImgs.length -1){
	changeSlide($activeSlide, $cubeImgs.eq(0));
    }else{
	changeSlide($activeSlide, $cubeImgs.eq($activeSlide.index()+1));
    }
}

var changeSlide = function($from, $to){
    //change slideStatus
    $cubeStatusLinks.removeClass('active');
    $cubeStatusLinks.eq($to.index()).addClass('active');
    $from.removeClass('active');
    $to.addClass('active');
    
    if(cubeSupport){
	var current_val = parseInt($cubeRotate[0].style['webkitTransform'].replace('deg)', '').substr(8)),
	    delta = $to.index() - $from.index(),
	    rotation = (delta*90),
	    new_val;
	
	if(($to.index() + $cubeImgs.length - 1) == $from.index()){
	    rotation = 90;
	}
	if(($from.index() + $cubeImgs.length - 1) == $to.index()){
	    rotation = -90;
	}
	new_val = parseInt(current_val) - rotation;
	$cubeRotate[0].style['webkitTransform'] = 'rotateY('+new_val+'deg)';
    }else{
	$from.hide();
	$to.show();
    }
    
}

$(window).resize();
var slideInterval = setInterval(runSlideShow, 3000);
});
