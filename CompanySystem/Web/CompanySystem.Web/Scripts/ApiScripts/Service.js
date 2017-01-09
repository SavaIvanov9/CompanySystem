app.service("APIService", function ($http) {
    this.getEmployees = function () {
        var url = 'http://localhost:55075/data/get';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    this.saveEmployee = function (emp) {
        return $http({
            method: 'post',
            data: emp,
            url: 'http://localhost:55075/data/post'
        });
    }
    this.updateEmployee = function (emp) {
        return $http({
            method: 'put',
            data: emp,
            url: 'http://localhost:55075/data/put'
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