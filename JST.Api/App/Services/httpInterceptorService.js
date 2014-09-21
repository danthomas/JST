app.factory('httpInterceptorService', function (globalService) {

    return {
        response: function (response) {
            globalService.setMessage(response.data.messages);

            return response;
        }
    };
});