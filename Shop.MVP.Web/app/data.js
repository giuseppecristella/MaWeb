//app.value('currentUser', currentUser);

//app.value('followedInstructors', [
//  { id: 1, name: 'Professor Snape' },
//  { id: 2, name: 'Professor McGonagall' },
//  { id: 3, name: 'Professor Dumbledore' }
//]);

app.factory('catalog', function($resource) {
	return $resource('/CatalogDataService.svc/products');
})