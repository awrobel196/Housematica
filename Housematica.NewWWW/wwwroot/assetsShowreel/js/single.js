$('.condygnation-name').magnificPopup({
    delegate: 'a',
    removalDelay: 550, //delay removal by X to allow out-animation
    callbacks: {
        beforeOpen: function () {

            this.st.mainClass = this.st.el.attr('data-effect');
        }
    },
    midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
});


function loaderAppendHide() {
    $(".loader-append").addClass("display-none");
}

function select(e) {
    $(".element").removeClass("checked");
    console.log(e);
    e.classList.add("checked");
}


function showDetails() {
    $(".right-section").removeClass("right-section-hide");
    $(".right-section").addClass("right-section-show");
    $(".close-section").removeClass("close-section-hide");
 
    map.resize();
   
}

function hideDetails() {
    $(".right-section").addClass("right-section-hide");
    $(".right-section").removeClass("right-section-show");
    $(".close-section").addClass("close-section-hide");
   
    map.resize()
   
    
}