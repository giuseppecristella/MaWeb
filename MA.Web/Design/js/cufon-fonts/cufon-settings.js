function initCufon() {
	Cufon.replace('h1,h2,h3,h4,h5,h6', { fontFamily: 'Museo Sans 500',hover: true });
	Cufon.replace('.caption h4,.buttonwrapper,.frame-content h4',{ fontFamily: 'Museo Sans 500',hover: true });	
	
}

(function($) {
        $(function() {

$(document).ready(function(){
	initCufon();
});

		
          });
    })(jQuery);     
