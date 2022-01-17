"use strict";
// Class definition
var KTKBootstrapTouchspin = function () {

    // Private functions
    var demos = function () {
        // minimum setup
        $('#kondygnacje_touchspin, #kt_touchspin_2_1').TouchSpin({
            buttondown_class: 'btn btn-secondary',
            buttonup_class: 'btn btn-secondary',

            min: 1,
            max: 20,
            step: 1,
            decimals: 0,
            boostat: 5,
            maxboostedstep: 10,
        });

        $('#kt_repeater_1').repeater({
            initEmpty: false,

            defaultValues: {
                'text-input': 'foo'
            },

            show: function () {
                $(this).slideDown();
            },

            hide: function (deleteElement) {
                $(this).slideUp(deleteElement);
            }
        });

     
    }

    return {
        // public functions
        init: function () {
            demos();
        }
    };
}();

jQuery(document).ready(function () {
    KTKBootstrapTouchspin.init();
});