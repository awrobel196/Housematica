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
 //Class definition
var KTWidgets = function () {
     //Private properties

   

    var _initChartsWidget3 = function () {
            var element = document.getElementById("kt_charts_widget_3_chart");
            console.log(currentProjectId);
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





            var views;
            var uviews;

        $.ajax({
            type: "POST",
            url: '../../api/StatsControler/GetCurrentProjectViews/' + currentProjectId + '',
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
                error: function () { alert('Niesukces'); },
            });


            if (!element) {
                return;
            }

            var options = {
                series: [{
                    name: 'Wyswietlenia',
                    data: [views[n6], views[n5], views[n4], views[n3], views[n2], views[n1]]
                }],
                chart: {
                    type: 'area',
                    height: 350,
                    toolbar: {
                        show: false
                    }
                },
                plotOptions: {

                },
                legend: {
                    show: false
                },
                dataLabels: {
                    enabled: false
                },
                fill: {
                    type: 'solid',
                    opacity: 1
                },
                stroke: {
                    curve: 'smooth',
                    show: true,
                    width: 3,
                    colors: ['#3246d3']
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
                    },
                    crosshairs: {
                        position: 'front',
                        stroke: {
                            color: KTApp.getSettings()['#3246d3'],
                            width: 1,
                            dashArray: 3
                        }
                    },
                    tooltip: {
                        enabled: true,
                        formatter: undefined,
                        offsetY: 0,
                        style: {
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
                colors: ['#f4f5ff'],
                grid: {
                    borderColor: KTApp.getSettings()['colors']['gray']['gray-200'],
                    strokeDashArray: 4,
                    yaxis: {
                        lines: {
                            show: true
                        }
                    }
                },
                markers: {
                    size: 5,
                    colors: ['#e5ecff'],
                    strokeColor: ['#3246d3'],
                    strokeWidth: 3
                }
            };

            var chart = new ApexCharts(element, options);
            chart.render();
    }

    


     //Public methods
    return {
        init: function () {
            
            _initChartsWidget3();
           
        }
    }
}();

 //Webpack support
if (typeof module !== 'undefined') {
    module.exports = KTWidgets;
}

jQuery(document).ready(function () {
    KTWidgets.init();
});
