app.controller('scCatalogCtrl', function ($scope, catalog) {
    $scope.model = { id: 1, name: "Giuseppe" };
    $scope.products = [{ id: 1, name: "Giu" }, { id: 2, name: "Giu2" }];
    $scope.catalog = catalog.query();

    $scope.categories = ['Sedia', 'Lume'];
    $scope.category = { selected: 'all' };

    $scope.filterPrice = 0;
    $scope.filter = { name: "all" };
    $scope.filters = ["Sedia", "Tavolino", "Lume"];
    $scope.selection = [];
    $scope.filterFunction = function (element) {
        if ($scope.filter.name == "all" || $scope.filter.name == "") return true;
        else {
            var ret = false;
            angular.forEach($scope.selection, function (filter) {
                if (element._name.indexOf(filter) > -1) ret = true;
            });
            return ret;
            //return element._name.indexOf($scope.filter.name) > -1 ? true : false;
            //return element._name.indexOf($scope.filters[0]) > -1 ||
            //       element._name.indexOf($scope.filters[1]) > -1 ||
            //       element._name.indexOf($scope.filters[2]) > -1 ? true : false;
        }

    };

    $scope.priceRange = [0, 200];
 

    $scope.toggleSelection = function toggleSelection(name) {
        $scope.filter.name = name;
        var idx = $scope.selection.indexOf(name);

        // is currently selected
        if (idx > -1) {
            $scope.selection.splice(idx, 1);
        }

            // is newly selected
        else {
            $scope.selection.push(name);
        }
    };



    $scope.my = { favorite: ""};
    $scope.filterPrice = function (element) {
        return element._price > $scope.priceRange[0] && element._price < $scope.priceRange[1] ? true : false;
    };

});

