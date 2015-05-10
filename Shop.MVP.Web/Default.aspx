<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shop.Web.Mvp.Default" %>


<asp:Content ID="cMain" ContentPlaceHolderID="cpMain" runat="server">
    <div class="main-content home-2">

        <div class="container">

            <section class="home-2-features inner-top-xs">
                <div class="row">
                    <div class="col-md-6 col-sm-12  feature-block">
                        <a href="categories-grid.html" class="media features">
                            <div class="media-left">
                                <div class="image">
                                    <img width="300" height="300" class="lazy-load media-object img-responsive" src="../assets/images/blank.gif" data-echo="../assets/images/products/feature1.jpg" alt="">
                                </div>
                            </div>
                            <div class="media-body media-middle">
                                <div class="section text-center">
                                    <h5 class="name">john williams</h5>
                                    <h3 class="tagline">perfection</h3>
                                </div>
                            </div>
                        </a>
                        <!-- /.media -->

                        <a href="categories-grid.html" class="media features">
                            <div class="media-body media-middle">
                                <div class="section text-center">
                                    <h5 class="name">sunglasses</h5>
                                    <h3 class="tagline">summer 2015</h3>
                                </div>
                            </div>
                            <div class="media-right">
                                <div class="image">
                                    <img width="300" height="300" class="lazy-load media-object img-responsive" src="../assets/images/blank.gif" data-echo="../assets/images/products/feature2.jpg" alt="">
                                </div>
                            </div>
                        </a>
                        <!-- /.media -->
                    </div>
                    <!-- /.feature-block -->

                    <div class="col-md-6 col-sm-12 feature-block big-image hidden-sm">
                        <a href="categories-grid.html">
                            <img width="570" height="600" class="img-responsive lazy-load" src="../assets/images/blank.gif" data-echo="../assets/images/products/feature3.jpg" alt="">
                            <div class="centered-caption">
                                <div class="banner-text text-center">
                                    <h4 class="banner-title">clothing</h4>
                                    <h2 class="tagline">sharp styles</h2>
                                </div>
                            </div>
                        </a>
                    </div>
                    <!-- /.feature-block -->
                </div>
                <!-- /.row -->
            </section>
            <!-- /.home-2-features -->
            <div class="product-tab-ver2">
                <div role="tabpanel">
                    <!-- Nav tabs -->
                    <div class="tab-nav-holder">
                        <ul class="nav nav-tabs uppercase" role="tablist">
                            <li role="presentation" class="active"><a href="#just-arrived" aria-controls="just-arrived" role="tab" data-toggle="tab">prodotti in primo piano</a></li>
                        </ul>
                    </div>
                    <div class="tab-content inner-top-xs">
                        <div role="tabpanel" class="tab-pane active" id="just-arrived">
                            <div class="row grid-view">
                                <div class="col-md-4 col-sm-6 col-lg-3 col-xs-12 product-holder">
                                    <div class="product">
                                        <div class="image">
                                            <a href="product-simple.html">
                                                <img class="img-responsive" width="258" src="../assets/images/blank.gif" data-echo="../assets/images/products/12.jpg" alt=""></a>
                                        </div>
                                        <!-- .image -->
                                        <div class="product-info m-t-20 text-center">
                                            <a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i>Quick view</a>
                                            <ul class="color-picker clearfix">
                                                <li class="selected">
                                                    <input checked="checked" class="le-radio group black" type="radio" value="g1-0" name="rgroup-0"></li>
                                                <li>
                                                    <input class="le-radio group gray" type="radio" value="g1-1" name="rgroup-0"></li>
                                                <li>
                                                    <input class="le-radio group brown" type="radio" value="g1-2" name="rgroup-0"></li>
                                            </ul>
                                            <!-- .color-picker -->
                                            <h5 class="name uppercase"><a href="product-simple.html">Contrast Shoulder Path</a></h5>
                                            <div class="product-price">
                                                <ins><span class="amount">$110</span></ins>
                                            </div>
                                            <!-- .product-price -->
                                            <div class="buttons-holder m-t-20">
                                                <div class="add-cart-holder">
                                                    <a title="Add to cart" href="checkout.html" class="cart-button btn btn-primary">
                                                        <span>Add to bag</span>
                                                    </a>
                                                </div>
                                                <!-- .add-cart-holder -->
                                                <div class="add-wishlist-holder">
                                                    <a href="checkout.html" title="Wishlist" class="wishlist-button uppercase">
                                                        <span class="icon icon-wishlist"></span>add to wishlist
											</a>
                                                </div>
                                                <!-- .add-wishlist-holder -->
                                            </div>
                                            <!-- .buttons-holder -->
                                        </div>
                                        <!-- .product-info -->
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-lg-3 col-xs-12 product-holder">
                                    <div class="product">
                                        <div class="image">
                                            <a href="product-simple.html">
                                                <img class="img-responsive" width="258" src="../assets/images/blank.gif" data-echo="../assets/images/products/9.jpg" alt=""></a>
                                        </div>
                                        <!-- .image -->
                                        <div class="product-info m-t-20 text-center">
                                            <a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i>Quick view</a>
                                            <ul class="color-picker clearfix">
                                                <li class="selected">
                                                    <input checked="checked" class="le-radio group black" type="radio" value="g1-0" name="rgroup-1"></li>
                                                <li>
                                                    <input class="le-radio group brown" type="radio" value="g1-1" name="rgroup-1"></li>
                                            </ul>
                                            <!-- .color-picker -->
                                            <h5 class="name uppercase"><a href="product-simple.html">Slim Short Pants</a></h5>
                                            <div class="product-price">
                                                <ins><span class="amount">$119</span></ins>
                                            </div>
                                            <!-- .product-price -->
                                            <div class="buttons-holder m-t-20">
                                                <div class="add-cart-holder">
                                                    <a title="Add to cart" href="checkout.html" class="cart-button btn btn-primary">
                                                        <span>Add to bag</span>
                                                    </a>
                                                </div>
                                                <!-- .add-cart-holder -->
                                                <div class="add-wishlist-holder">
                                                    <a href="checkout.html" title="Wishlist" class="wishlist-button uppercase">
                                                        <span class="icon icon-wishlist"></span>add to wishlist
											</a>
                                                </div>
                                                <!-- .add-wishlist-holder -->
                                            </div>
                                            <!-- .buttons-holder -->
                                        </div>
                                        <!-- .product-info -->
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-lg-3 col-xs-12 product-holder">
                                    <div class="product">
                                        <div class="image">
                                            <a href="product-simple.html">
                                                <img class="img-responsive" width="258" src="../assets/images/blank.gif" data-echo="../assets/images/products/7.jpg" alt=""></a>
                                        </div>
                                        <!-- .image -->
                                        <div class="product-info m-t-20 text-center">
                                            <a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i>Quick view</a>
                                            <ul class="color-picker clearfix">
                                                <li class="selected">
                                                    <input checked="checked" class="le-radio group brown" type="radio" value="g1-0" name="rgroup-2"></li>
                                                <li>
                                                    <input class="le-radio group dark-gray" type="radio" value="g1-1" name="rgroup-2"></li>
                                            </ul>
                                            <!-- .color-picker -->
                                            <h5 class="name uppercase"><a href="product-simple.html">Flocked Print Sweatshirt</a></h5>
                                            <div class="product-price">
                                                <ins><span class="amount">$140</span></ins>
                                            </div>
                                            <!-- .product-price -->
                                            <div class="buttons-holder m-t-20">
                                                <div class="add-cart-holder">
                                                    <a title="Add to cart" href="checkout.html" class="cart-button btn btn-primary">
                                                        <span>Add to bag</span>
                                                    </a>
                                                </div>
                                                <!-- .add-cart-holder -->
                                                <div class="add-wishlist-holder">
                                                    <a href="checkout.html" title="Wishlist" class="wishlist-button uppercase">
                                                        <span class="icon icon-wishlist"></span>add to wishlist
											</a>
                                                </div>
                                                <!-- .add-wishlist-holder -->
                                            </div>
                                            <!-- .buttons-holder -->
                                        </div>
                                        <!-- .product-info -->
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-lg-3 col-xs-12 product-holder">
                                    <div class="product">
                                        <div class="image">
                                            <a href="product-simple.html">
                                                <img class="img-responsive" width="258" src="../assets/images/blank.gif" data-echo="../assets/images/products/10.jpg" alt=""></a>
                                        </div>
                                        <!-- .image -->
                                        <div class="product-info m-t-20 text-center">
                                            <a class="quick-view uppercase" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="icon icon-more-colors-product"></i>Quick view</a>
                                            <ul class="color-picker clearfix">
                                                <li class="selected">
                                                    <input checked="checked" class="le-radio group blue" type="radio" value="g1-0" name="rgroup-3"></li>
                                                <li>
                                                    <input class="le-radio group orange" type="radio" value="g1-1" name="rgroup-3"></li>
                                            </ul>
                                            <!-- .color-picker -->
                                            <h5 class="name uppercase"><a href="product-simple.html">South Beach Vest</a></h5>
                                            <div class="product-price">
                                                <ins><span class="amount">$57</span></ins>
                                            </div>
                                            <!-- .product-price -->
                                            <div class="buttons-holder m-t-20">
                                                <div class="add-cart-holder">
                                                    <a title="Add to cart" href="checkout.html" class="cart-button btn btn-primary">
                                                        <span>Add to bag</span>
                                                    </a>
                                                </div>
                                                <!-- .add-cart-holder -->
                                                <div class="add-wishlist-holder">
                                                    <a href="checkout.html" title="Wishlist" class="wishlist-button uppercase">
                                                        <span class="icon icon-wishlist"></span>add to wishlist
											</a>
                                                </div>
                                                <!-- .add-wishlist-holder -->
                                            </div>
                                            <!-- .buttons-holder -->
                                        </div>
                                        <!-- .product-info -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="load-more-holder text-center">
            <a href="categories-grid.html" class="btn btn-default load-more">Catalogo Completo</a>
        </div>

        <section class="wide-banners clearfix wow fadeIn">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-4">
                        <div class="wide-banner cnt-strip">
                            <a href="catalog.html">
                                <div class="image lazy-load">
                                    <img width="370" height="245" src="../assets/images/blank.gif" data-echo="../assets/images/brands/w2.jpg" class="img-responsive" alt="">
                                </div>
                                <div class="strip text-center">
                                    <h5>over 40s</h5>
                                    <h3>free delivery</h3>
                                </div>
                            </a>
                        </div>
                        <!-- /.wide-banner-->
                    </div>
                    <!-- /.col -->

                    <div class="col-md-4 col-sm-4">
                        <div class="wide-banner cnt-strip">
                            <a href="catalog.html">
                                <div class="image lazy-load">
                                    <img width="370" height="245" src="../assets/images/blank.gif" data-echo="../assets/images/brands/w1.jpg" class="img-responsive" alt="">
                                </div>
                                <div class="strip text-center">
                                    <div class="strip-inner">
                                        <h5>get up to</h5>
                                        <h1>40% off</h1>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <!-- /.wide-banner-->
                    </div>
                    <!-- /.col -->

                    <div class="col-md-4 col-sm-4">
                        <div class="wide-banner cnt-strip">
                            <a href="catalog.html">
                                <div class="image lazy-load">
                                    <img width="370" height="245" src="../assets/images/blank.gif" data-echo="../assets/images/brands/w3.jpg" class="img-responsive" alt="">
                                </div>
                                <div class="strip text-center">
                                    <div class="strip-inner">
                                        <h5>we care</h5>
                                        <h3>world shipping</h3>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <!-- /.wide-banner-->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </section>
        <!-- /.wide-banners -->

        <section class="container subscription wow fadeIn">
            <form class="form-inline form-subscribe text-center">
                <span class="form-subtitle">Ricevi le nostre offerte</span>
                <h3 class="form-title">Iscriviti alla Newsletter</h3>
                <div class="form-group">
                    <label for="email-subscribe" class="sr-only">Email</label>
                    <input type="email" class="form-control" id="email-subscribe" placeholder="Inserisci il tuo indirizzo e-mail">
                    <button type="submit" class="btn btn-primary btn-subscribe">Iscriviti</button>
                </div>
            </form>
            <!-- /.form-subscribe -->
        </section>
        <!-- /.subscription -->
    </div>












    <%--    <div class="container" ng-app="app">
        <div ng-controller="scCatalogCtrl">
            {{ model.name }}
            <div ng-repeat="product in products">
                Name: {{product.name}}
                
            </div>
            <br/>
            
            <div ng-repeat="p in catalog1">
                Name: {{p._name}}
                
            </div>
        </div>
    </div>--%>
</asp:Content>
