app.service("APIService", function ($http) {
    this.getEmployees = function () {
        var url = 'http://localhost:55075/api/employees/alldata';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    this.saveEmployee = function (emp) {
        return $http({
            method: 'post',
            data: emp,
            url: 'http://localhost:55075/api/employees/submitdata'
        });
    }
    this.updateEmployee = function (emp) {
        return $http({
            method: 'put',
            data: emp,
            url: 'http://localhost:55075/api/employees/updatedata'
        });
    }
    this.deleteEmployee = function (employeeId) {
        var url = 'http://localhost:55075/api/employees/deletedata' + employeeId;
        return $http({
            method: 'delete',
            data: employeeId,
            url: url
        });
    }
});