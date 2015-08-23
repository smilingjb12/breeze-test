var app = angular.module('app');

app.controller('AllCtrl', function ($scope, entityManager, breeze) {
    $scope.companies = null;
    var manager = entityManager.newManager();
    var query = breeze.EntityQuery
        .from('Companies')
        .expand('customers.cars');

    manager.executeQuery(query)
        .then(function (data) {
            $scope.companies = data.results;
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

    $scope.addCarTo = function (customer) {
        var newCar = manager.createEntity('Car', { customerId: customer.id });
    };

    $scope.addCompany = function () {
        var newCompany = manager.createEntity('Company');
        $scope.companies.push(newCompany);
    };

    $scope.removeCar = function (car) {
        car.entityAspect.setDeleted();
    };

    $scope.removeCustomer = function (customer) {
        for (var i = customer.cars.length - 1; i >= 0; --i) {
            manager.detachEntity(customer.cars[i]);
        }
        customer.entityAspect.setDeleted();
    };

    $scope.removeCompany = function (company) {
        for (var i = company.customers.length - 1; i >= 0; --i) {
            var customer = company.customers[i];
            for (var j = customer.cars.length - 1; j >= 0; --j) {
                var car = customer.cars[i];
                manager.detachEntity(car);
            }
            manager.detachEntity(customer);
        }
        company.entityAspect.setDeleted();
        $scope.companies.splice($scope.companies.indexOf(company), 1);
    };

    $scope.addCustomerTo = function (company) {
        var newCustomer = manager.createEntity('Customer', { companyId: company.id });
    };
});