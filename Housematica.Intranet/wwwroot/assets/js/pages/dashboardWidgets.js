"use strict";

var month = {
    1: "Styczen",
    2: "Luty",
    3: "Marzec",
    4: "Kwiecien",
    5: "Maj",
    6: "Czerwiec",
    7: "Lipiec",
    8: "Sierpien",
    9: "Wrzesien",
    10: "Pazdziernik",
    11: "Listopad",
    12: "Grudzien",
}
// Class definition
var KTWidgets = function () {
    // Private properties



    var _initChartsWidget1 = async function () {
        console.log(1);
        var element = document.getElementById("kt_charts_widget_1_chart");
        var d = new Date();
        var n = d.getMonth();
        var n1 = n + 1;

        var n2 = n1 - 1;
        var n3 = n1 - 2;
        var n4 = n1 - 3;
        var n5 = n1 - 4;
        var n6 = n1 - 5;

        if (n2 < 1) {
            n2 = 12;
            n3 = 12 - 1;
            n4 = 12 - 2;
            n5 = 12 - 3;
            n6 = 12 - 4;
        }


        if (n3 < 1) {
            n3 = 12;
            n4 = 12 - 1;
            n5 = 12 - 2;
            n6 = 12 - 3;
        }


        if (n4 < 1) {
            n4 = 12;
            n5 = 12 - 1;
            n6 = 12 - 2;
        }


        if (n5 < 1) {
            n5 = 12;
            n6 = 12 - 1;
        }


        if (n6 < 1) {
            n6 = 12;
        }



        console.log(License);

        var views;
        var uviews;

        $.ajax({
            type: "POST",
            url: '../../api/StatsControler/GetViews/' + License + '',
            async: false,
            dataType: "json",
            success: function (data) {
                views = {
                    1: data.January,
                    2: data.February,
                    3: data.March,
                    4: data.April,
                    5: data.May,
                    6: data.June,
                    7: data.July,
                    8: data.August,
                    9: data.September,
                    10: data.October,
                    11: data.November,
                    12: data.December
                }

            },
            error: function () { alert('Niesukces1'); },
        });

        $.ajax({
            type: "POST",
            url: '../../api/StatsControler/GetUViews/' + License + '',
            async: false,
            dataType: "json",
            success: function (data) {
                uviews = {
                    1: data.January,
                    2: data.February,
                    3: data.March,
                    4: data.April,
                    5: data.May,
                    6: data.June,
                    7: data.July,
                    8: data.August,
                    9: data.September,
                    10: data.October,
                    11: data.November,
                    12: data.December
                }
                console.log(uviews);

            },
            error: function () { alert('Niesukces2'); },
        });




        if (!element) {
            return;
        }

        var options = {
            series: [{
                name: 'Wyswietlenia',
                data: [views[n6], views[n5], views[n4], views[n3], views[n2], views[n1]]
            }, {
                name: 'Unikalne wyswietlenia',
                data: [uviews[n6], uviews[n5], uviews[n4], uviews[n3], uviews[n2], uviews[n1]]
            }],
            chart: {
                type: 'bar',
                height: 350,
                toolbar: {
                    show: false
                }
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: ['30%'],
                    endingShape: 'rounded'
                },
            },
            legend: {
                show: false
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                show: true,
                width: 2,
                colors: ['transparent']
            },
            xaxis: {
                categories: [month[n6], month[n5], month[n4], month[n3], month[n2], month[n1]],
                axisBorder: {
                    show: false,
                },
                axisTicks: {
                    show: false
                },
                labels: {
                    style: {
                        colors: KTApp.getSettings()['colors']['gray']['gray-500'],
                        fontSize: '12px',
                        fontFamily: KTApp.getSettings()['font-family']
                    }
                }
            },
            yaxis: {
                labels: {
                    style: {
                        colors: KTApp.getSettings()['colors']['gray']['gray-500'],
                        fontSize: '12px',
                        fontFamily: KTApp.getSettings()['font-family']
                    }
                }
            },
            fill: {
                opacity: 1
            },
            states: {
                normal: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                hover: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                active: {
                    allowMultipleDataPointsSelection: false,
                    filter: {
                        type: 'none',
                        value: 0
                    }
                }
            },
            tooltip: {
                style: {
                    fontSize: '12px',
                    fontFamily: KTApp.getSettings()['font-family']
                },
                y: {
                    formatter: function (val) {
                        return val
                    }
                }
            },
            colors: ['#3246d3', KTApp.getSettings()['colors']['gray']['gray-200']],
            grid: {
                borderColor: KTApp.getSettings()['colors']['gray']['gray-200'],
                strokeDashArray: 4,
                yaxis: {
                    lines: {
                        show: true
                    }
                }
            }
        };

        var chart = new ApexCharts(element, options);
        chart.render();
    }

    var _initChartsWidget2 = async function () {
        console.log(2);
        var element = document.getElementById("kt_charts_widget_2_chart");
        var d = new Date();
        var n = d.getMonth();
        var n1 = n + 1;

        var n2 = n1 - 1;
        var n3 = n1 - 2;
        var n4 = n1 - 3;
        var n5 = n1 - 4;
        var n6 = n1 - 5;

        if (n2 < 1) {
            n2 = 12;
            n3 = 12 - 1;
            n4 = 12 - 2;
            n5 = 12 - 3;
            n6 = 12 - 4;
        }


        if (n3 < 1) {
            n3 = 12;
            n4 = 12 - 1;
            n5 = 12 - 2;
            n6 = 12 - 3;
        }


        if (n4 < 1) {
            n4 = 12;
            n5 = 12 - 1;
            n6 = 12 - 2;
        }


        if (n5 < 1) {
            n5 = 12;
            n6 = 12 - 1;
        }


        if (n6 < 1) {
            n6 = 12;
        }



        console.log(License);

        var click;


        $.ajax({
            type: "POST",
            url: '../../api/StatsControler/GetTotalConfiguration/' + License + '',
            async: false,
            dataType: "json",
            success: function (data) {
                click = {
                    1: data.January,
                    2: data.February,
                    3: data.March,
                    4: data.April,
                    5: data.May,
                    6: data.June,
                    7: data.July,
                    8: data.August,
                    9: data.September,
                    10: data.October,
                    11: data.November,
                    12: data.December
                }

            },
            error: function () { alert('Niesukces1'); },
        });






        if (!element) {
            return;
        }

        var options = {
            series: [{
                name: 'Wyswietlenia',
                data: [click[n6], click[n5], click[n4], click[n3], click[n2], click[n1]]
            }],
            chart: {
                type: 'bar',
                height: 350,
                toolbar: {
                    show: false
                }
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: ['30%'],
                    endingShape: 'rounded'
                },
            },
            legend: {
                show: false
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                show: true,
                width: 2,
                colors: ['transparent']
            },
            xaxis: {
                categories: [month[n6], month[n5], month[n4], month[n3], month[n2], month[n1]],
                axisBorder: {
                    show: false,
                },
                axisTicks: {
                    show: false
                },
                labels: {
                    style: {
                        colors: KTApp.getSettings()['colors']['gray']['gray-500'],
                        fontSize: '12px',
                        fontFamily: KTApp.getSettings()['font-family']
                    }
                }
            },
            yaxis: {
                labels: {
                    style: {
                        colors: KTApp.getSettings()['colors']['gray']['gray-500'],
                        fontSize: '12px',
                        fontFamily: KTApp.getSettings()['font-family']
                    }
                }
            },
            fill: {
                opacity: 1
            },
            states: {
                normal: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                hover: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                active: {
                    allowMultipleDataPointsSelection: false,
                    filter: {
                        type: 'none',
                        value: 0
                    }
                }
            },
            tooltip: {
                style: {
                    fontSize: '12px',
                    fontFamily: KTApp.getSettings()['font-family']
                },
                y: {
                    formatter: function (val) {
                        return val
                    }
                }
            },
            colors: ['#3246d3', KTApp.getSettings()['colors']['gray']['gray-200']],
            grid: {
                borderColor: KTApp.getSettings()['colors']['gray']['gray-200'],
                strokeDashArray: 4,
                yaxis: {
                    lines: {
                        show: true
                    }
                }
            }
        };

        var chart = new ApexCharts(element, options);
        chart.render();
    }



    var _initMixedWidget18 = async function () {
        console.log(3);

        var element = document.getElementById("kt_mixed_widget_18_chart");
        var height = parseInt(KTUtil.css(element, 'height'));



        if (!element) {
            return;
        }

        var options = {
            series: [numberLicence],
            chart: {
                height: height,
                type: 'radialBar',
                offsetY: 0
            },
            plotOptions: {
                radialBar: {
                    startAngle: -90,
                    endAngle: 90,

                    hollow: {
                        margin: 0,
                        size: "70%"
                    },
                    dataLabels: {
                        showOn: "always",
                        name: {
                            show: true,
                            fontSize: "13px",
                            fontWeight: "700",
                            offsetY: -5,
                            color: KTApp.getSettings()['colors']['gray']['gray-500']
                        },
                        value: {
                            color: KTApp.getSettings()['colors']['gray']['gray-700'],
                            fontSize: "30px",
                            fontWeight: "700",
                            offsetY: -40,
                            show: true
                        }
                    },
                    track: {
                        background: KTApp.getSettings()['colors']['theme']['light']['primary'],
                        strokeWidth: '100%'
                    }
                }
            },
            colors: ['#3246d3', KTApp.getSettings()['colors']['theme']['base']['primary']],
            stroke: {
                lineCap: "round",
            },
            labels: ["Zuzytych zasobow"]
        };

        var chart = new ApexCharts(element, options);
        chart.render();
    }


   





    // Public methods
    return {
        init: function () {
            // General Controls

            _initChartsWidget1();
            _initChartsWidget2();
            
            _initMixedWidget18();

           
        }
    }
}();

// Webpack support
if (typeof module !== 'undefined') {
    module.exports = KTWidgets;
}

jQuery(document).ready(function () {
    KTWidgets.init();
});
