function loadContent(IdApartment, ApartmentName) {
    loadUklad(IdApartment);
    loadKuchnia(IdApartment, ApartmentName);
    loadPokoje(IdApartment, ApartmentName);
    loadLazienki(IdApartment, ApartmentName);
    loadWykonczenia(IdApartment, ApartmentName);
   
}

var numeracja = ['Pierwszy', 'Drugi', 'Trzeci', 'Czwarty', 'Piąty', 'Szósty'];

function loadUklad(IdApartment) {
    $.ajax({
        type: "POST",
        url: '../../Projects/loadUklad',
        data: { IdApartment: IdApartment },
        async: false,
        dataType: "json",
        success: function (data) {
            $(".ukladPlace").html("");
            for (var i = 0; i < data.length; i++) {
                var html = `   <div class="col uklad-item" onclick="selectUklad(this, `+data[i].IdApartmentVariants+`); changeScene(` + data[i].IdApartmentVariants + `)" data-option-price="`+data[i].ApartmentPrice+`" data-option-name="Wariant pierwszy">
                        <p class="header">Wariant `+ numeracja[i]+`</p>
                        <p class="title">Ilość pomieszczeń</p>
                        <p class="value">`+ data[i].Rooms.length+`</p>
                        <p class="title">Ilość pokoii</p>
                        <p class="value">`+data[i].NumberOfLivingRoom+`</p>
                    </div>`;
                $(".ukladPlace").append(html);
            }
        },
        error: function () { alert('Niesukces'); },
    });


}


function loadKuchnia(IdApartment, ApartmentName) {
    $.ajax({
        type: "POST",
        url: '../../Projects/loadKuchnia',
        data: { IdApartment: IdApartment },
        async: false,
        dataType: "json",
        success: function (data) {
            $(".kuchniaPlace").html("");
            for (var i = 0; i < data.length; i++) {
                var html = `<div class="col">
                        <span class="kuchnia-outer " onclick="selectKuchnia(this)" data-option-price="`+ data[i].Price + `" data-option-name="` + data[i].OptionName + `">
                            <span class="kuchnia-inner" style="background-image: url('http://ftp.quirky-curie.188-34-164-7.plesk.page/cdn/`+ IdProject + `/` + ApartmentName + `/KitchenOption` + (i + 1) +`/source.jpg');"><span class="display-none">
                               `+data[i].OptionName+`
                            </span>
                        </span>
                        </span>
                    </div>
                `;
                $(".kuchniaPlace").append(html);
            }
        },
        error: function () { alert('Niesukces'); },
    });
}


function loadPokoje(IdApartment, ApartmentName) {
    $.ajax({
        type: "POST",
        url: '../../Projects/loadPokoje',
        data: { IdApartment: IdApartment },
        async: false,
        dataType: "json",
        success: function (data) {
            $(".pokojePlace").html("");
            for (var i = 0; i < data.length; i++) {
                var html = `<div class="col">
                        <span class="pokoje-outer " onclick="selectPokoje(this)" data-option-price="`+ data[i].Price + `" data-option-name="` + data[i].OptionName + `">
                            <span class="pokoje-inner" style="background-image: url('http://ftp.quirky-curie.188-34-164-7.plesk.page/cdn/`+ IdProject + `/` + ApartmentName + `/RoomsOption` + (i + 1) + `/source.jpg');"><span class="display-none">
                               `+ data[i].OptionName + `
                            </span>
                        </span>
                        </span>
                    </div>
                `;
                $(".pokojePlace").append(html);
            }
        },
        error: function () { alert('Niesukces'); },
    });
}

function loadLazienki(IdApartment, ApartmentName) {
    $.ajax({
        type: "POST",
        url: '../../Projects/loadLazienki',
        data: { IdApartment: IdApartment },
        async: false,
        dataType: "json",
        success: function (data) {
            $(".lazienkiPlace").html("");
            for (var i = 0; i < data.length; i++) {
                var html = `<div class="col">
                        <span class="lazienka-outer " onclick="selectLazienka(this)" data-option-price="`+ data[i].Price + `" data-option-name="` + data[i].OptionName + `">
                            <span class="lazienka-inner" style="background-image: url('http://ftp.quirky-curie.188-34-164-7.plesk.page/cdn/`+ IdProject + `/` + ApartmentName + `/BathroomOption` + (i + 1) + `/source.jpg');"><span class="display-none">
                               `+ data[i].OptionName + `
                            </span>
                        </span>
                        </span>
                    </div>
                `;
                $(".lazienkiPlace").append(html);
            }
        },
        error: function () { alert('Niesukces'); },
    });
}



function loadWykonczenia(IdApartment, ApartmentName) {
    $.ajax({
        type: "POST",
        url: '../../Projects/loadWykonczenia',
        data: { IdApartment: IdApartment },
        async: false,
        dataType: "json",
        success: function (data) {
            $(".wykonczeniaPlace").html("");
            for (var i = 0; i < data.length; i++) {
                var html = ` 
                    <div class="col">
                        <span class="dot" onclick="selectWykonczenia(this)" data-option-price="`+ data[i].Price + `" data-option-name="` + data[i].OptionName + `"
                              style="background-image: url('http://ftp.quirky-curie.188-34-164-7.plesk.page/cdn/`+ IdProject + `/` + ApartmentName + `/DoorWindowVariant` + (i + 1) + `/source.jpg');"></span>
                    </div>
                `;
                $(".wykonczeniaPlace").append(html);
            }
        },
        error: function () { alert('Niesukces'); },
    });
}