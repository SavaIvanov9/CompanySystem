app.service("APIService", function ($http) {
    this.getEmployees = function () {
        var url = 'http://localhost:55075/data/get';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    this.saveEmployee = function (employee) {
        return $http({
            method: 'post',
            data: employee,
            url: 'http://localhost:55075/data/post'
        });
    }
    this.updateEmployee = function (employee) {
        var url = 'http://localhost:55075/data/put/' + employee;
        return $http({
            method: 'put',
            data: employee,
            url: url
        });
    }
    this.deleteEmployee = function (employeeId) {
        var url = 'http://localhost:55075/data/delete/' + employeeId;
        return $http({
            method: 'delete',
            data: employeeId,
            url: url
        });
    }
});