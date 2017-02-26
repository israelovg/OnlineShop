function Utils() {
    var waitWindowCount = 0;
    $(document).ready(function () {
        $(".pnlWait").dialog({
            modal: true,
            autoOpen: false,
            width: 260,
            open: function (event, ui) { /*$(".pnlWait").find(".ui-dialog-titlebar-close").hide();*/ }
        });
        $(".pnlSystemError").dialog({
            modal: true,
            autoOpen: false,
            height: 150,
            width: 200,
            open: function (event, ui) { /*$(".pnlWait").find(".ui-dialog-titlebar-close").hide();*/ }
        });
    });
    this.showWait = function () {
        waitWindowCount++;
        $(".pnlWait").dialog("open");
        $(".pnlWait").siblings('div.ui-dialog-titlebar').remove();
    }
    this.showSystemError = function () {
        $(".pnlSystemError").dialog("open");
    }
    this.closeWait = function () {
        waitWindowCount--;
        if (waitWindowCount == 0)
            $(".pnlWait").dialog("close");
    }
    this.closeWaitOnError = function () {
        waitWindowCount=0;
            $(".pnlWait").dialog("close");
    }
    // get queryString value by key
    this.queryStringValueByKey = function (parameter) {
        var loc = location.search.substring(1, location.search.length);
        var param_value = false;
        var params = loc.split("&");
        for (i = 0; i < params.length; i++) {
            param_name = params[i].substring(0, params[i].indexOf('='));
            if (param_name == parameter) {
                param_value = params[i].substring(params[i].indexOf('=') + 1)
            }
        }
        if (param_value) {
            return param_value;
        }
        else {
            return false; //Here determine return if no parameter is found
        }
    }
    this.replaceQueryString = function (url, param, value) {
        var preURL = "";
        var postURL = "";
        var newURL = "";
        var start = url.indexOf(param + "=");
        if (start > -1) {
            var end = url.indexOf("=", start);
            preURL = url.substring(0, end) + "=" + value;

            var startRest = url.indexOf("&", start);
            postURL = "";
            if (startRest > -1) {
                postURL = url.substring(startRest);
            }
        }
        else {
            var delimeter = "";
            preURL = url;
            if (url.indexOf("?") > 0)
                delimeter = '&';
            else
                delimeter = '?';

            postURL = delimeter + param + "=" + value;
        }
        newURL = preURL + postURL;
        var index = newURL.indexOf('id=', 0);
        if (index > -1) {
            var Nurl = newURL.substring(0, index);
            var EUrl = newURL.substr(index, newURL.length - index);
            var eIndex = EUrl.indexOf('&', 0);
            if (eIndex > -1)
                EUrl = EUrl.substr(eIndex, EUrl.length - eIndex);
            //newURL = newURL.substring();   
            newURL = Nurl + EUrl;
        }
        return newURL;
    }
    this.checkdate = function (value) {
        try {
            var returnval = false;
            //Detailed check for valid date ranges
            var monthfield = value.split("/")[1]
            var dayfield = value.split("/")[0]
            var yearfield = value.split("/")[2]
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
            if ((dayobj.getMonth() + 1 != monthfield.replace(/^0+(?=\d\.)/, '')) || (dayobj.getDate() != dayfield.replace(/^0+(?=\d\.)/, '')) || (dayobj.getFullYear() != yearfield.replace(/^0+(?=\d\.)/, ''))) {
                // alert("Invalid Day, Month, or Year range detected. Please correct and submit again.")
            }
            else
                returnval = true


            return returnval
        }
        catch (err) {
            return false;
        }
    }
}
var utils = new Utils();