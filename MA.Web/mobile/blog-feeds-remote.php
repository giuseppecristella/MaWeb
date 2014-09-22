<?php
ob_start();
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET, OPTIONS");
header("Access-Control-Allow-Headers: X-PINGOTHER");
header("Access-Control-Max-Age: 1728000");

	    
		$url = "http://dvadesetdva.wordpress.com/feed/";
		$rss = simplexml_load_file($url);
		if($rss) {
		    $items = $rss->channel->item;
		    foreach($items as $item) {
	    ?>
            <div class="white-content-box">
		<div class="blog-article">
			<div class="article-header">
			  <p class="title"><?=$item->title?></p>
			  <p class="info"><?=date("d M Y", strtotime($item->pubDate))?> <span>(<?=$item->children("dc", true)?>)</span></p>
			</div>
			<div class="article-body">
			  <div class="text">
			    <?=$item->description?>
			  </div>
			</div>
			<div class="article-footer">
			  <a detail-url="<?=urlencode($item->link)?>" href="blog-detail.html" onclick="readOn(this)" data-transition="slide" class="button button2 left">Read On</a>
			  <div class="social right">
			    <span class="st_fblike_hcount"></span>
			    <span class="st_twitter_hcount"></span>
			  </div>
			  <div class="clear"></div>
			</div>
		</div>
            </div>
	    <img src="images/shadow.png" />
			<?}?>
		<?}?>
		<?php
			$output = ob_get_clean();
			echo "document.getElementById('blog-posts').innerHTML = ('" . str_replace("\n", " ", $output) . "');";
		?>