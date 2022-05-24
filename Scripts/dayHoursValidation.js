//handler validazione ore dello stesso giorno
(function () {
    var dayLimit = parseFloat($('.limiteoregiorno').text());
    var errorDays = [];

    function handler(evt) {
        var hours = {};
        var error;
        _.reduce($('.righe'), function (res, el, key) {
            var value = $(el).find('.datapicker').val();
            if (value) {
                if (!res.hasOwnProperty(value)) res[value] = 0;
                res[value] = parseFloat(res[value]) + parseFloat($(el).find('.check_qta').val());
            }
            return res

        }, hours);

        _.each(hours, function (el, key) {
            var index = errorDays.indexOf(key);
            if (el > dayLimit && index == -1) {
                errorDays.push(key);
            } else if (el <= dayLimit && index != -1) {
                _.remove(errorDays, function (el) { return el == key });
            }
        });

        if (errorDays.length) {
            _.each($('.tasto-registra'), function (el) { $(el).attr('error', true) });
            error = true;
        } else {
            _.each($('.tasto-registra'), function (el) { $(el).attr('error', false) });
            error = false;
        }

        if (evt) evt.stopPropagation();
        return error;
    }

    $('.check_qta').bind('change blur', handler);
    $(document).bind("DOMContentLoaded", handler);
    $('.datapicker').bind('change blur', handler);

    $('.tasto-registra').bind('click', function (evt) {
        var res = handler();
        if ($(evt.target).attr('error') == "true" && res) {

            var msg = "Nelle seguenti date è stato caricato un numero di ore errato:<br>";
            _.each(errorDays, function (el) {
                msg += "<font color=red>" + el + "</font><br>";
            });
            msg += "Le ore non verranno caricate fino a che il problema non sarà risolto."

            $("#lblmessaggiopopup").html(msg);
            $('#modal-form').modal('show');
            evt.stopImmediatePropagation();
            return false;
        }
    });
})()