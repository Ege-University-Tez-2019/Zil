var Util = {};

Util.Ajax = {
    Generic: (url, data, type, dataType, async, beforeSendCallBack, successCallBack, completeCallBack, errorCallBack) => {
        $.ajax({
            url: url,
            data: data,
            dataType: dataType,
            type: type,
            async: async,
            beforeSend: function (item) {
                if (beforeSendCallBack != null) { beforeSendCallBack(item) }
            },
            success: function (item) {
                if (successCallBack != null) { successCallBack(item) }
            }, complete: function (item) {
                if (completeCallBack != null) { completeCallBack(item) }
            }, error: function (item) {
                if (errorCallBack != null) { errorCallBack(item) }
            },
        });
    },
    FormData: (url, data, async, beforeSendCallBack, successCallBack, completeCallBack, errorCallBack) => {
        $.ajax({
            url: url,
            data: data,
            type: "POST",
            processData: false,
            contentType: false,
            async: async,
            beforeSend: function (item) {
                if (beforeSendCallBack != null) { beforeSendCallBack(item) }
            },
            success: function (item) {
                if (successCallBack != null) { successCallBack(item) }
            }, complete: function (item) {
                if (completeCallBack != null) { completeCallBack(item) }
            }, error: function (item) {
                if (errorCallBack != null) { errorCallBack(item) }
            },
        });
    },
    Select: (url, data, type, dataType, async, selectId, value, text, beforeSendCallBack, successCallBack, completeCallBack, errorCallBack) => {
        $.ajax({
            url: url,
            data: data,
            dataType: dataType,
            type: type,
            async: async,
            beforeSend: function (item) {
                if (beforeSendCallBack != null) { beforeSendCallBack(item) }
            },
            success: function (item) {
                if (successCallBack != null) { successCallBack(item) }
                else {
                    $('#' + selectId).find('option').remove().end();
                    item.map(x => {
                        $("#" + selectId).append("<option value='" + x[value] + "'>" + x[text].trim() + "</option>");
                        xLabel = "";
                    });
                }
            }, complete: function (item) {
                if (completeCallBack != null) { completeCallBack(item) }
            }, error: function (item) {
                if (errorCallBack != null) { errorCallBack(item) }
            },
        });
    }
};

Util.Menu = {
    Navigate: (page, id) => {
        let url = "/" + page;

        if (id !== null) {
            url += "/" + id;
        }

        window.location.assign(url);
    }
};