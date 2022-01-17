var optionsPrice = {oldMieszkanie:0, mieszkanie:0, oldUklad:0, uklad:0, oldKuchnia:0, kuchnia:0, oldPokoje:0, pokoje:0, oldLazienka:0, lazienka:0, oldWykonczenia:0, wykonczenia:0};

$('#inline-popups').magnificPopup({
  delegate: 'a',
  removalDelay: 500, //delay removal by X to allow out-animation
  callbacks: {
    beforeOpen: function() {
       this.st.mainClass = this.st.el.attr('data-effect');
    }
  },
  midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
});

$('#popup-configurationKey').magnificPopup({
    delegate: 'a',
    removalDelay: 500, //delay removal by X to allow out-animation
    callbacks: {
        beforeOpen: function () {
            this.st.mainClass = this.st.el.attr('data-effect');
        }
    },
    midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
});

$('#popup-load-configuration').magnificPopup({
    delegate: 'a',
    removalDelay: 500, //delay removal by X to allow out-animation
    callbacks: {
        beforeOpen: function () {
            this.st.mainClass = this.st.el.attr('data-effect');
        }
    },
    midClick: true // allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source.
});


const slider = document.querySelector('.items');
let isDown = false;
let startX;
let scrollLeft;

slider.addEventListener('mousedown', (e) => {
  isDown = true;
  startX = e.pageX - slider.offsetLeft;
  scrollLeft = slider.scrollLeft;
});
slider.addEventListener('mouseleave', () => {
  isDown = false;
});
slider.addEventListener('mouseup', () => {
  isDown = false;
});
slider.addEventListener('mousemove', (e) => {
  if(!isDown) return;
  e.preventDefault();
  const x = e.pageX - slider.offsetLeft;
  const walk = (x - startX) * 1; //scroll-fast
  slider.scrollLeft = scrollLeft - walk;

});


function setActiveModyficationType(e){
  
  if(checkFirstChecked()==false){
    return
  };
  //Zmiana napisu na przycisku podsumowywującym w zależności od aktywnej karty opcji (jeśli wybrana jest osotatnia karta opcji napis i funkcja przycisku zmienia się)
  if( $(e).is($(".align-self-center .col:last-child span"))){
    $(".summary-button-text").text("PODSUMOWANIE");
    $(".summary-button-text").attr("id", "summary");
  }else{
    $(".summary-button-text").text("DALEJ");
    $(".summary-button-text").attr("id", "next");
  }
  
  //Otwarcie karty z opcjami jeśli jest zamknięta
  openOptions();

   $(".active-nav-element").addClass("inactive-nav-element");
   $(".nav-element").removeClass("active-nav-element");
   e.classList.add("active-nav-element");

 
   $(".options-element").removeClass("options-element-active");
   $("div[data-options-element='"+e.getAttribute("data-modification-type")+"']").addClass("options-element-active");
}




function selectMieszkanie(e, IdApartment, ApartmentName) {
    

    $(".selected-mieszkanie-id").text(IdApartment);
  if($(e).hasClass("selected-mieszkanie")){
    return;
  }
    updatePriceTable();
    optionsPrice.uklad = $(e).attr("data-option-price");
  updatePrice();

  $("span[data-title='mieszkanie']").text($(e).attr("data-option-name"));
  $(".mieszkanie-item").removeClass("unselected-mieszkanie");
  $(".selected-mieszkanie").addClass("unselected-mieszkanie");
  $(".mieszkanie-item").removeClass("selected-mieszkanie");
    e.classList.add("selected-mieszkanie");
    loadContent(IdApartment, ApartmentName);
}

function selectUklad(e, idUklad){


    $(".selected-uklad-id").text(idUklad);
    if($(e).hasClass("selected-uklad")){
      return;
    }
    updatePriceTable();
    optionsPrice.uklad =  $(e).attr("data-option-price");
    updatePrice();
  
    $("p[data-title='uklad']").text($(e).attr("data-option-name"));
    $(".uklad-item").removeClass("unselected-uklad");
    $(".selected-uklad").addClass("unselected-uklad");
    $(".uklad-item").removeClass("selected-uklad");
    e.classList.add("selected-uklad");

  }


function selectKuchnia(e){

  if($(e).hasClass("kuchnia-outer-active")){
    return;
  }

  updatePriceTable();
  optionsPrice.kuchnia =  $(e).attr("data-option-price");
  updatePrice();

  $("p[data-title='kuchnia']").text($(e).attr("data-option-name"));
  $(".kuchnia-outer i").remove();
  //Ustawia wszystkim kołom podpis jako niewidoczny
  $(".kuchnia-outer .kuchnia-inner span").addClass("display-none");

  //Usuwa klasę inactive która odpowiada za animację wyjścia elementu
  $(".kuchnia-outer").removeClass("kuchnia-outer-inactive");

  //Dudaje aktualnie aktywnemu elementowi klasę odpowiedzialną za animację wyjścia
  $(".kuchnia-outer-active").addClass("kuchnia-outer-inactive");

  //Usuwa klasę aktywności aktualnie aktywnego modelu
  $(".kuchnia-outer").removeClass("kuchnia-outer-active");

  //Dodaje klasę aktywności do klikniętego modelu
  e.classList.add("kuchnia-outer-active");
  $(".kuchnia-outer-active").prepend('<i class="fas fa-check" style="color: white;background-color: #2d95ef; font-size: 1.2vh;padding: 0.8vh;border-radius: 50%;float: right; position: relative;"></i>');

  //Do klikniętego modelu usuwa właściwość display-none pokazując podpis
  $(".kuchnia-outer-active .kuchnia-inner span").removeClass("display-none");
}



function selectLazienka(e){

    if($(e).hasClass("lazienka-outer-active")){
      return;
    }
  
    updatePriceTable();
    optionsPrice.lazienka =  $(e).attr("data-option-price");
    updatePrice();
  
    $("p[data-title='lazienka']").text($(e).attr("data-option-name"));
    $(".lazienka-outer i").remove();
    //Ustawia wszystkim kołom podpis jako niewidoczny
    $(".lazienka-outer .lazienka-inner span").addClass("display-none");
  
    //Usuwa klasę inactive która odpowiada za animację wyjścia elementu
    $(".lazienka-outer").removeClass("lazienka-outer-inactive");
  
    //Dudaje aktualnie aktywnemu elementowi klasę odpowiedzialną za animację wyjścia
    $(".lazienka-outer-active").addClass("lazienka-outer-inactive");
  
    //Usuwa klasę aktywności aktualnie aktywnego modelu
    $(".lazienka-outer").removeClass("lazienka-outer-active");
  
    //Dodaje klasę aktywności do klikniętego modelu
    e.classList.add("lazienka-outer-active");
    $(".lazienka-outer-active").prepend('<i class="fas fa-check" style="color: white;background-color: #2d95ef; font-size: 1.2vh;padding: 0.8vh;border-radius: 50%;float: right; position: relative;"></i>');
  
    //Do klikniętego modelu usuwa właściwość display-none pokazując podpis
    $(".lazienka-outer-active .lazienka-inner span").removeClass("display-none");
  }

function selectPokoje(e){

    if($(e).hasClass("pokoje-outer-active")){
      return;
    }
  
    updatePriceTable();
    optionsPrice.pokoje =  $(e).attr("data-option-price");
    updatePrice();
  

    $("p[data-title='pokoje']").text($(e).attr("data-option-name"));
    $(".pokoje-outer i").remove();
    //Ustawia wszystkim kołom podpis jako niewidoczny
    $(".pokoje-outer .pokoje-inner span").addClass("display-none");
  
    //Usuwa klasę inactive która odpowiada za animację wyjścia elementu
    $(".pokoje-outer").removeClass("pokoje-outer-inactive");
  
    //Dudaje aktualnie aktywnemu elementowi klasę odpowiedzialną za animację wyjścia
    $(".pokoje-outer-active").addClass("pokoje-outer-inactive");
  
    //Usuwa klasę aktywności aktualnie aktywnego modelu
    $(".pokoje-outer").removeClass("pokoje-outer-active");
  
    //Dodaje klasę aktywności do klikniętego modelu
    e.classList.add("pokoje-outer-active");
    $(".pokoje-outer-active").prepend('<i class="fas fa-check" style="color: white;background-color: #2d95ef; font-size: 1.2vh;padding: 0.8vh;border-radius: 50%;float: right; position: relative;"></i>');
  
    //Do klikniętego modelu usuwa właściwość display-none pokazując podpis
    $(".pokoje-outer-active .pokoje-inner span").removeClass("display-none");
  }


  function selectWykonczenia(e){
    if($(e).hasClass("selected-dot")){
      return;
    }
  
    updatePriceTable();
    optionsPrice.wykonczenia =  $(e).attr("data-option-price");
    updatePrice();
  
    $("p[data-title='wykonczenia']").text($(e).attr("data-option-name"));
     $(".dot").removeClass("unselected-dot");
     $(".selected-dot").addClass("unselected-dot");
     $(".selected-dot").html("");
     $(".dot").removeClass("selected-dot");
     e.classList.add("selected-dot");
     $(".selected-dot").html('<i class="fas fa-check" style="color: white;background-color: #2d95ef; font-size: 1.2vh;padding: 0.8vh;border-radius: 50%;float: right;"></i>');
  }


function summaryClick(e){
  if(e.id=="next"){
   var elementNumber = ($(".active-nav-element").parent().index());
   $(".modyfication-type-col:nth-child("+(elementNumber+2)+") span").click();
 
  }else{
    optionsSlideUp();
    $(".summary-view-model-price").text($(".summary-price-value .main-price").text());
    $( ".summary-view" ).slideDown( "slow" );
    
  }
}

function closeSummaryView(){
  $( ".summary-view" ).slideUp("slow");
}

function openOptions(){
  if ( $( ".options" ).is( ":hidden" ) ) {
    $( ".options" ).slideDown( "slow" );
  }
}


function optionsSlideUp(){
  if ( $( ".options" ).is( ":hidden" ) ) {
    $( ".options" ).slideDown( "slow" );
  } else {
    $( ".options" ).slideUp();
  }
}

function updatePrice(){
  /*Zrobic tabele w ktorej beda zapisywac sie wartości
model|19000
kolor|872
koła|2313
  */

var oldSum = parseInt(optionsPrice.oldMieszkanie) + parseInt(optionsPrice.oldUklad) + parseInt(optionsPrice.oldKuchnia)+parseInt(optionsPrice.oldPokoje) + parseInt(optionsPrice.oldLazienka) + 
parseInt(optionsPrice.oldWykonczenia);
var newSum = parseInt(optionsPrice.mieszkanie) + parseInt(optionsPrice.uklad) + parseInt(optionsPrice.kuchnia)+parseInt(optionsPrice.pokoje) + parseInt(optionsPrice.lazienka) + 
parseInt(optionsPrice.wykonczenia);

var finalPrice = new Intl.NumberFormat('pl-pl', {
  style: 'currency',
  currency: 'PLN',
  maximumFractionDigits: 0
}).format(newSum);

var priceDiffrence = new Intl.NumberFormat('pl-pl', {
  style: 'currency',
  currency: 'PLN',
  maximumFractionDigits: 0
}).format(newSum-oldSum);




$(".summary-price-value span:first-child").text(finalPrice);

if(newSum-oldSum > 0){
  $(".summary-price-value span:last-child").html("<span style='color:green'>+"+priceDiffrence+"</span>");
}else{
  $(".summary-price-value span:last-child").html("<span style='color:red'>"+priceDiffrence+"</span>");
}


$(".summary-price-value span:last-child").removeClass("price-diferrence");
  requestAnimationFrame(()=>{
$(".summary-price-value span:last-child").addClass("price-diferrence");
  });

}


function checkFirstChecked(){
  if ($(".selected-mieszkanie")[0]){
  return true;
} else {
  $("#testButton").click();
  return false;
}
}

function updatePriceTable(){
  optionsPrice.oldMieszkanie = optionsPrice.mieszkanie;
  optionsPrice.oldUklad = optionsPrice.uklad;
  optionsPrice.oldKuchnia = optionsPrice.kuchnia;
  optionsPrice.oldPokoje = optionsPrice.pokoje;
  optionsPrice.oldLazienka = optionsPrice.lazienka;
  optionsPrice.oldWykonczenia = optionsPrice.wykonczenia;
}

function loadConfiguration() {
  
    var configKey = $(".configuration-key-input").val();
    $.ajax({
        type: "POST",
        url: "../../Projects/loadConfiguration",
 
        dataType: "json",
        beforeSend: function () {
            $("#popupLoadConfiguration > .div-button").addClass("display-none");

            $("#popupLoadConfiguration > .div-loader").removeClass("display-none");
        },
        data: { configKey: configKey },
        success: function (data) {
            if (data == "[]") {
                $("#popupLoadConfiguration > .popup-content").text("Podano nieprawidłowy kod konfiguracji");
                $("#popupLoadConfiguration > .popup-content").css("color", "red");
                $("#popupLoadConfiguration > .div-loader").addClass("display-none");
                $("#popupLoadConfiguration > .div-button").removeClass("display-none");
            } else {
                $("#popupLoadConfiguration > .mfp-close").click();
                $("#popupLoadConfiguration > .configuration-key-input").val("");
                $("#popupLoadConfiguration > .popup-content").text("Wpisz swój unikatowy kod konfiguracji");
                $("#popupLoadConfiguration > .popup-content").css("color", "black");
                $("#popupLoadConfiguration > .div-loader").addClass("display-none");
                $("#popupLoadConfiguration > .div-button").removeClass("display-none");
                
            }
        },
       
        error: function (data) {
            alert("Błąd pobierania konfiguracji");
        },

    });
}