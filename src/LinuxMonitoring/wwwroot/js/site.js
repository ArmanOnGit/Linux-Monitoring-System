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

$(document).ready(function () {
    function fetchNetworkData() {
        $.ajax({
            url: '/Monitoring/GetNetworkData',
            type: 'GET',
            success: function (response) {
                if (response.success) {
                    $('#networkList').empty();
                    $('#networkList').append('<li>Interfaces bandwidth usage:</li><br><br>');

                    response.networkData.forEach((data, index) => {
                        if (index !== 0) {
                            $('#networkList').append(`<li>${data}</li>`);
                        }
                    });
                } else {
                    $('#networkList').html(`<li>Error: ${response.error}</li>`);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                let errorMessage = `An error occurred: ${textStatus} - ${errorThrown}`;
                $('#networkList').html(`<li>${errorMessage}</li>`);
            }
        });
    }

    $('#refreshNetworkButton').click(fetchNetworkData);

    fetchNetworkData();
});

$(document).ready(function () {
    function fetchDiskData() {
        $.ajax({
            url: '/Monitoring/GetDiskData',
            type: 'GET',
            success: function (response) {
                if (response.success) {
                    $('#diskList').empty();
                    let diskData = response.diskData.split('*');
                    $('#diskList').append(`<li>${diskData[0]}</li><br><br>`);

                    let diskDetails = diskData[1].split('|-');
                    $('#diskList').append('<li class="DiskPanel"> <br><br><br>');
                    diskDetails.forEach((item, index) => {
                        if (index !== 0) {
                            $('#diskList li:last').append(`${item}<br>`);
                        }
                    });
                    $('#diskList').append('</li>');                    
                } else {
                    $('#diskList').html(`<li>Error: ${response.error}</li>`);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                let errorMessage = `An error occurred: ${textStatus} - ${errorThrown}`;
                $('#diskList').html(`<li>${errorMessage}</li>`);
            }
        });
    }

    $('#refreshDiskButton').click(fetchDiskData);

    fetchDiskData();
});


$(document).ready(function () {
    function fetchMemoryData() {
        $.ajax({
            url: '/Monitoring/GetMemoryData',
            type: 'GET',
            success: function (response) {
                if (response.success) {
                    $('.memoryList').empty();

                    let memoryData = response.memoryData.split('*');
                    $('.memoryList').append(`<li>${memoryData[0]}</li><br><br>`);

                    let cachedMemoryData = response.cachedMemoryData.split('*');
                    $('.memoryList').append(`<li>${cachedMemoryData[0]}</li>`);

                    let swapMemoryData = response.swapMemoryData.split('*');
                    $('.memoryList').append(`<li>${swapMemoryData[0]}</li>`);
                } else {
                    $('.memoryList').html(`<li>Error: ${response.error}</li>`);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                let errorMessage = `An error occurred: ${textStatus} - ${errorThrown}`;
                $('.memoryList').html(`<li>${errorMessage}</li>`);
            }
        });
    }

    $('#refreshMemoryButton').click(fetchMemoryData);

    fetchMemoryData();
});
