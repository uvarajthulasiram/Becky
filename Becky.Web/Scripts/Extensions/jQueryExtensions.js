// Add jQuery extension methods.
(function ($) {

    function post(options) {
        var deferred = $.Deferred();

        $.ajax(options).done(function (result) {
            if (result.success === undefined) {
                return deferred.resolve(result);
            } else {
                return result.success ? deferred.resolve(result.data) : deferred.reject(result.data);
            }
        }).fail(function (result) {
            return deferred.reject({ status: result.status, message: result.statusText });
        });

        return deferred;
    }

    $.postJSON = function (url, data) {
        return post({
            url: url,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            cache: false
        });
    };

    $.postFORM = function (form, type) {
        var $form = $(form);
        return post({
            dataType: type || 'json',
            url: $form.attr('action'),
            type: $form.attr('method'),
            data: $form.serialize()
        });
    };

    $.htmlEncode = function (value) { return $('<div/>').text(value).html(); };

})(jQuery);