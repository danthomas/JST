app.factory('httpInterceptorService', function (globalService) {

    return {
        response: function (response) {

            globalService.setMessage(
                 [
                  {
                      "messageType": "Confirmation",
                      "text": "Woohoooo."
                  }
                 ]
            );

            return response;
        }
    };
});