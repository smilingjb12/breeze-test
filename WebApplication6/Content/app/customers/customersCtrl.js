var app = angular.module('app');

app.controller('CustomersCtrl', function ($scope, entityManager, breeze) {
    $scope.companies = null;
    var manager = entityManager.newManager();
    var query = breeze.EntityQuery
        .from('Customers');

    manager.executeQuery(query)
        .then(function (data) {
            $scope.customers = data.results;
        })
        .catch(function (error) {
            alert(error);
        });

    $scope.save = function () {
        manager.saveChanges()
            .then(function () {
                alert('saved successfully!');
            })
            .catch(function (error) {
                alert('error while saving data: ' + error);
            });
    };

    $scope.removeCustomer = function(customer) {
        customer.entityAspect.setDeleted();
        $scope.customers.splice($scope.customers.indexOf(customer), 1);
    };

    $scope.addNewCustomer = function() {
        var newCustomer = manager.createEntity('Customer');
        $scope.customers.push(newCustomer);
    };
});