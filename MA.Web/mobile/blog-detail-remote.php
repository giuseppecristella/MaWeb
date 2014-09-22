<?php
ob_start();
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET, OPTIONS");
header("Access-Control-Allow-Headers: X-PINGOTHER");
header("Access-Control-Max-Age: 1728000");
		$link = urldecode($_GET['link']);
		if (!$link) die();
		$url = "http://dvadesetdva.wordpress.com/feed/";
		$rss = simplexml_load_file($url);
		if($rss) {
		    $items = $rss->channel->item;
		    foreach($items as $item) {
			if ($item->link != $link)
			    continue;
		?>
		<div class="blog-article">
			<div class="article-header">
			  <p class="title"><?=$item->title?></p>
			  <p class="info"><?=date("d M Y", strtotime($item->pubDate))?> <span>(<?=$item->children("dc", true)?>)</span></p>
			</div>
			<div class="article-body">
			  <div class="text">
			    <?=$item->children("content", true);?>
			  </div>
			</div>
			<div class="article-footer">
			  <a href="#" onclick="history.back();" data-transition="slide" class="back-button button button2 left">Back</a>
			  <div class="clear"></div>
			</div>
		</div>
			<?php }?>
		<?php }?>
		<?php
			$output = ob_get_clean();
			echo "document.getElementById('blog-post').innerHTML = ('" . str_replace("\n", " ", $output) . "');";
		?>