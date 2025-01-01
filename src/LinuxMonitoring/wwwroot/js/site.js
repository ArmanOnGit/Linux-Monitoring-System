// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    function fetchSystemInfo() {
        $.ajax({
            url: '/Monitoring/GetSystemInfo',
            type: 'GET',                  
            success: function (response) {
                if (response.success) {
                        $('#systemInfoList').empty();
                    response.systemInfo.forEach((info, index) => {
                        $('#systemInfoList').append(`<li>${info}</li>`);
                        if (index === 0) $('#systemInfoList').append('<br><br>');
                    });
                } else {
                    $('#systemInfoList').html(`<li>Error: ${response.error}</li>`);
                }
            },
            error: function () {
                $('#systemInfoList').html('<li>An error occurred while fetching system info.</li>');
            }
        });
    }

    $('#SysInfo-refresh').click(fetchSystemInfo);

    fetchSystemInfo();
});