app.controller('APIController', function ($scope, APIService) {
    getAll();
    function getAll() {
        var servCall = APIService.getEmployees();
        servCall.then(function (d) {
            $scope.employees = d;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.');
        });
    }
    $scope.saveEmployees = function () {
        var sub = {
            MailID: $scope.mailid,
            SubscribedDate: new Date()
        };
        var saveEmployees = APIService.saveEmployees(sub);
        saveEmployees.then(function (d) {
                getAll();
            },
            function(error) {
                console.log('Oops! Something went wrong while saving the data.');
            });
    };
    $scope.makeEditable = function (obj) {
        obj.target.setAttribute("contenteditable", true);
        obj.target.focus();
    };
    $scope.updEmployee = function (employee, eve) {
        employee.Id = eve.currentTarget.innerText;
        var upd = APIService.updateSubscriber(employee);
        upd.then(function(d) {
                getAll();
            },
            function(error) {
                console.log('Oops! Something went wrong while updating the data.');
            });
    };
    $scope.dltEmployee = function (subID) {
        var dlt = APIService.deleteEmployee(subID);
        dlt.then(function(d) {
                getAll();
            },
            function(error) {
                console.log('Oops! Something went wrong while deleting the data.');
            });
    };
});