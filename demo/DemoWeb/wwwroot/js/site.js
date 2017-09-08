// Write your Javascript code.
var sendDemoCode = function (btnElement, api) {
    //console.log(api);
    var resultPanel = $(btnElement).parent().siblings(".apiresult");
    var resultElement = $(resultPanel).find(" div > .search-result");
    
    
    $(resultPanel).show();
    $.get(api, function (data, status) {
        $(resultElement).html('');
        //$(resultElement).text(data);
        var editor = ace.edit($(resultElement)[0]);
        var session = editor.getSession();
        editor.setTheme("ace/theme/sqlserver");
        session.setMode("ace/mode/json");
        session.setValue(js_beautify(data));
        //$(resultElement).ace({ theme: 'twilight', lang: 'json' });
        //$(resultElement).text(js_beautify(data));
        //$(resultPanel).show();
    }, "text");
};