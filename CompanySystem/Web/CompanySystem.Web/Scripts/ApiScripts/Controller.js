app.controller('APIController', function ($scope, APIService) {
    $scope.getAll = function () {
        var servCall = APIService.getEmployees();
        servCall.then(function (d) {
            $scope.employees = d;
        }, function (error) {
            console.log('Something went wrong while fetching the data. ' + error.statusText);
        });
    }

    $scope.getAll();

    $scope.saveEmployee = function () {
        var emp = {
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            Age: $scope.age,
            Email: $scope.email
        };
        var saveEmployee = APIService.saveEmployee(emp);
        saveEmployee.then(function (d) {
            $scope.getAll();
        },
            function (error) {
                console.log('Something went wrong while saving the data. ' + error.statusText);
            });
    };

    $scope.makeEditable = function (obj) {
        obj.target.setAttribute("contenteditable", true);
        obj.target.focus();
    };
    $scope.updateEmployee = function (emp) {
        var employee = emp;
        var upd = APIService.updateEmployee(employee);
        upd.then(function (d) {
            $scope.getAll();
        },
            function (error) {
                console.log('Something went wrong while updating the data.');
            });
    };

    $scope.deleteEmployee = function (employeeId) {
        var dlt = APIService.deleteEmployee(employeeId);
        dlt.then(function (d) {
            $scope.getAll();
        },
            function (error) {
                console.log('Something went wrong while deleting the data. ' + error.statusText);
            });
    };
});