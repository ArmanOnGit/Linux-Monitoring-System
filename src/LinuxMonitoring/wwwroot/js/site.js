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

$(document).ready(function () {
    function fetchSystemTime() {
        $.ajax({
            url: '/Monitoring/GetSystemTime', 
            type: 'GET',                     
            success: function (response) {
                if (response.success) {
                    $('#timeList').empty();
                    response.systemTime.forEach((time, index) => {
                        $('#timeList').append(`<li>${time}</li>`);
                        if (index === 0) $('#timeList').append('<br><br>');
                    });
                } else {
                    $('#timeList').html(`<li>Error: ${response.error}</li>`);
                }
            },
            error: function () {
                $('#timeList').html('<li>An error occurred while fetching system time.</li>');
            }
        });
    }

    $('#refreshTimeButton').click(fetchSystemTime);

    fetchSystemTime();
});

$(document).ready(function () {
    function fetchSystemUptime() {
        $.ajax({
            url: '/Monitoring/GetSystemUptime', 
            type: 'GET',            
            success: function (response) {
                if (response.success) {
                    $('#uptimeList').empty();
                    response.systemUptime.forEach((uptime, index) => {
                        $('#uptimeList').append(`<li>${uptime}</li>`);
                        if (index === 0) $('#uptimeList').append('<br><br>');
                    });
                } else {
                    $('#uptimeList').html(`<li>Error: ${response.error}</li>`);
                }
            },
            error: function () {
                $('#uptimeList').html('<li>An error occurred while fetching system uptime.</li>');
            }
        });
    }

    $('#refreshUptimeButton').click(fetchSystemUptime);

    fetchSystemUptime();
});
