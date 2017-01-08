app.service("APIService", function ($http) {
    this.getEmployees = function () {
        var url = 'api/Data';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    this.saveEmployee = function (sub) {
        return $http({
            method: 'post',
            data: sub,
            url: 'api/Data'
        });
    }
    this.updateEmployee = function (sub) {
        return $http({
            method: 'put',
            data: sub,
            url: 'api/Data'
        });
    }
    this.deleteEmployee = function (subID) {
        var url = 'api/Data/' + subID;
        return $http({
            method: 'delete',
            data: subID,
            url: url
        });
    }
});