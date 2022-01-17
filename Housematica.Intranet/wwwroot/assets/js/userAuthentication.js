function login() {
    var email = $("input[data-field='loginEmail']").val();
    var password = $("input[data-field='loginPassword']").val();


    //Sprawdzamy czy email oraz hasło nie jest puste
    switch (email) {
        case null:
        case "":
            $("input[data-field='loginEmail']").addClass("is-invalid");
            $("div[data-form='loginEmail'] > .invalid-feedback").text("Adres email nie może być pusty");
            if (password == "") {
                $("input[data-field='loginPassword']").addClass("is-invalid");
                $("div[data-form='loginPassword'] > .invalid-feedback").text("Hasło nie może być puste");
            } else {
                $("input[data-field='loginPassword']").removeClass("is-invalid");
            }
            return;
        default:
            $("input[data-field='loginEmail']").removeClass("is-invalid");
            switch (password) {
                case null:
                case "":
                    $("input[data-field='loginPassword']").addClass("is-invalid");
                    $("div[data-form='loginPassword'] > .invalid-feedback").text("Hasło nie może być puste");
                    return;
                default:
                    $("input[data-field='loginPassword']").removeClass("is-invalid");

            };

    }

    $("button[buton-type='loginButton']").addClass("display-none");
    $("button[buton-type='loaderButton']").removeClass("display-none");

    //Jeśli email i hasło nie są puste wysyłamy email i hasło do metody odpowiedzialnej za logowanie
    $.ajax({
        type: "POST",
        url: '../Authentication/Login',
        data: { email: email, password: password },
        dataType: "json",
        success: function (data) {
            if (data == true) {
                $("button[buton-type='loginButton']").removeClass("display-none");
                $("button[buton-type='loaderButton']").addClass("display-none");
                swal.fire({
                    text: "Zalogowano pomyślnie, za chwilę nastąpi przekierowanie na stronę główną",
                    icon: "success",
                    buttonsStyling: false,
                    confirmButtonText: "Strona główna",
                    customClass: {
                        confirmButton: "btn font-weight-bold btn-light-primary"
                    },
                    timer: 2000
                }).then(function () {
                    location.replace("/Home/Index");
                });
            } else {
                $("button[buton-type='loginButton']").removeClass("display-none");
                $("button[buton-type='loaderButton']").addClass("display-none");
                swal.fire({
                    text: "Wygląda na to, że wpisano nieprawidłowe dane logowania",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "Próbuję ponownie!",
                    customClass: {
                        confirmButton: "btn font-weight-bold btn-light-primary"
                    }
                    //Po zamknięciu alertu resetowane są dane w inputach
                }).then(function () {

                    $("input[data-field='loginPassword']").val("");
                });
            }
        },
        error: function () { alert('Niesukces'); },
    });
}

function register() {

    //Przypisujemy dane z pól formularza do zmiennych
    var licenseId = $("input[data-field='licenseId']").val();
    var name = $("input[data-field='registerName']").val();
    var surname = $("input[data-field='registerSurname']").val();
    var email = $("input[data-field='registerEmail']").val();
    var password = $("input[data-field='registerPassword']").val();
    var cpassword = $("input[data-field='registerConfirmPassword']").val();
    var policy = $("input[data-field='registerPolicy']").is(":checked");

    //Tworzymy zmienne które będą przechowywać wartość true lub false w zależności od stanu poprawności pola
    var nameValidate;
    var surnameValidate;
    var emailValidate;
    var passwordValidate;
    var cpasswordValidate;
    var policyValidate;

    //START: Walidacja pól
    if (name == "") {
        $("input[data-field='registerName']").addClass("is-invalid");
        $("div[data-form='registerName'] > .invalid-feedback").text("Imię nie może być puste");
        nameValidate = false;
    } else {
        $("input[data-field='registerName']").removeClass("is-invalid");
        nameValidate = true;
    }

    if (surname == "") {
        $("input[data-field='registerSurname']").addClass("is-invalid");
        $("div[data-form='registerSurname'] > .invalid-feedback").text("Nazwisko nie może być puste");
        surnameValidate = false;
    } else {
        $("input[data-field='registerSurname']").removeClass("is-invalid");
        surnameValidate = true;
    }

    if (email == "") {
        $("input[data-field='registerEmail']").addClass("is-invalid");
        $("div[data-form='registerEmail'] > .invalid-feedback").text("Adres email nie może być pusty");
        emailValidate = false;
    } else {
        $("input[data-field='registerEmail']").removeClass("is-invalid");
        emailValidate = true;
    }

    if (password == "") {
        $("input[data-field='registerPassword']").addClass("is-invalid");
        $("div[data-form='registerPassword'] > .invalid-feedback").text("Hasło nie może być puste");
        passwordValidate = false;
    } else {
        $("input[data-field='registerPassword']").removeClass("is-invalid");
        passwordValidate = true;
    }

    if (cpassword == "") {
        $("input[data-field='registerConfirmPassword']").addClass("is-invalid");
        $("div[data-form='registerConfirmPassword'] > .invalid-feedback").text("Hasło nie może być puste");
        cpasswordValidate = false;
    } else if (password != cpassword) {
        $("input[data-field='registerConfirmPassword']").addClass("is-invalid");
        $("div[data-form='registerConfirmPassword'] > .invalid-feedback").text("Hasła muszą być takie same");
        cpasswordValidate = false;
    } else {
        $("input[data-field='registerConfirmPassword']").removeClass("is-invalid");
        cpasswordValidate = true;
    }

    if (policy == false) {
        $("div[data-form='registerPolicy'] > .invalid-feedback").text("Aby założyć konto zaakceptuj regulamin");
        policyValidate = false;
    } else {
        $("div[data-form='registerPolicy'] > .invalid-feedback").text("");
        policyValidate = true;
    }
    //KONIEC: Walidacja pól



    //Sprawdzamy czy wszystkie statusy weryfikacji są true, jeśli tak wykonujemy zapytanie do metody C# i tworzymy konto
    if (surnameValidate == true & nameValidate == true & emailValidate == true && passwordValidate == true && cpasswordValidate == true && policyValidate == true) {
        $("button[buton-type='registerButton']").addClass("display-none");
        $("button[buton-type='loaderRegisterButton']").removeClass("display-none");
        $.ajax({
            type: "POST",
            dataType: "json",
            url: '../Authentication/Register',
            data: { name: name, surname: surname, email: email, password: password, IdLicense: licenseId },
            success: function (data) {
                if (data !== null) {
                    sendEmail(data, email);
                    $("button[buton-type='registerButton']").removeClass("display-none");
                    $("button[buton-type='loaderRegisterButton']").addClass("display-none");
                    swal.fire({
                        text: "Pomyślnie utworzono konto, teraz możesz zalogować się do seriwsu",
                        icon: "success",
                        buttonsStyling: false,
                        confirmButtonText: "Zaloguj się",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        },
                        timer: 2000
                    }).then(function () {
                        location.replace("/Home/Index");
                        
                       
                    });
                } else {
                    $("button[buton-type='registerButton']").removeClass("display-none");
                    $("button[buton-type='loaderRegisterButton']").addClass("display-none");
                    swal.fire({
                        text: "Nastąpił błąd podczas rejestracji. Spróbuj ponownie",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Próbuję ponownie!",
                        customClass: {
                            confirmButton: "btn font-weight-bold btn-light-primary"
                        }
                        //Po zamknięciu alertu resetowane są dane w inputach
                    }).then(function () {
                        $("input[data-field='loginEmail']").val("");
                        $("input[data-field='loginPassword']").val("");
                    });
                }
            },
            error: function () { alert('Niesukces'); },

        })
    }
}




function sendEmail(data, email) {
    Email.send({
        Host: "smtp.atma.com.pl",
        Username: "testatma",
        Password: "Haslo321!",
        To: email,
        From: "test@atma.com.pl",
        Subject: "Housematica - Potwierdzenie rezerwacji",
        Body: `
    
    <div class="rcmBody">
        <center>
            <table align="center" border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" id="bodyTable">
                <tbody><tr>
                    <td align="center" valign="top" id="bodyCell">
                        <span style="color: #FFFFFF; display: none; font-size: 0px; height: 0px; visibility: hidden; width: 0px">You're almost ready to get started!</span>
                        
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tbody><tr>
                                <td align="center" bgcolor="#3246d3" valign="top" id="templateHeader" style="background-color: #3246d3; padding-right: 30px; padding-left: 30px">
                                    
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 400px" class="emailContainer">
                                        <tbody><tr>
                                            <td align="center" valign="top" id="logoContainer" style="padding-top: 40px; padding-bottom: 40px">
                                                <img alt="Housematica" src="https://zapodaj.net/images/ea955135f881f.png" height="63" width="60" style="color: #FFFFFF; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 12px; font-weight: 400; letter-spacing: -1px; padding: 0; margin: 0; text-align: center">
                                            </td>
                                        </tr>
                                    </tbody></table>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#3246d3" valign="top" id="headerContainer" style="background-color: #3246d3; padding-right: 30px; padding-left: 30px">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody><tr>
                                            <td align="center" valign="top">
                                                
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 640px" class="emailContainer">
                                                    <tbody><tr>
                                                        <td align="center" valign="top">
                                                            <table align="center" bgcolor="#FFFFFF" border="0" cellpadding="0" cellspacing="0" width="100%" id="headerTable" style="background-color: #FFFFFF; border-collapse: separate; border-top-left-radius: 4px; border-top-right-radius: 4px">
                                                                <tbody><tr>
                                                                    <td align="center" valign="top" width="100%" style="padding-top: 40px; padding-bottom: 0">&nbsp;</td>
                                                                </tr>
                                                            </tbody></table>
                                                        </td>
                                                    </tr>
                                                </tbody></table>
                                                
                                            </td>
                                        </tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" id="templateBody">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody><tr>
                                            <td align="center" valign="top">
                                                
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 700px" class="emailContainer">
                                                    <tbody><tr>
                                                        <td align="right" valign="top" width="30" class="mobileHide">
                                                            <img src="http://cdn-images.mailchimp.com/template_images/tr_email/arrow.jpg" width="30" style="display: block">
                                                        </td>
                                                        <td valign="top" width="100%" style="padding-right: 70px; padding-left: 40px" id="bodyContainer">
                                                            <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tbody><tr>
                                                                    <td align="left" valign="top" id="bodyContent" style="padding-bottom: 40px">
                                                                        <h1 style="color: #606060; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 30px; font-style: normal; font-weight: 600; line-height: 42px; letter-spacing: normal; margin: 0; padding: 0; text-align: center">Jeszcze tylko jeden krok...</h1>
                                                                        <h1 style="color: #606060; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 15px; font-style: normal; font-weight: 400; line-height: 42px; letter-spacing: normal; margin: 0; padding: 0; text-align: center">Kliknij poniższy przycisk aby aktywować swoje konto</h1>
                                                                    
                                                                    
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding-bottom: 5px" valign="top">
                                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody><tr>
                                                                                <td align="center" valign="middle">
                                                                                    
                                                                                    <a href="https://pensive-einstein.188-34-164-7.plesk.page/Authentication/Activate/`+ data + `"  style="background-color: #3246d3; border-collapse: separate; border-top: 20px solid #3246d3; border-right: 20px solid #3246d3; border-bottom: 20px solid #3246d3; border-left: 20px solid #3246d3; border-radius: 3px; color: #FFFFFF; display: inline-block; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 600; letter-spacing: .3px; text-decoration: none" target="_blank" rel="noreferrer">Aktywuj konto</a>
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </tbody></table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-bottom: 40px">
                                                                        <p style="color: #929292; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-weight: 400; line-height: 42px; letter-spacing: normal; margin: 0; padding: 0; text-align: center">(Potwierdź że ten adres należy do Ciebie)</p>
                                                                    </td>
                                                                </tr>
                                                            </tbody></table>
                                                        </td>
                                                    </tr>
                                                </tbody></table>
                                                
                                            </td>
                                        </tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" id="templateFooter" style="padding-right: 30px; padding-left: 30px">
                                    
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 640px" class="emailContainer">
                                        <tbody><tr>
                                            <td valign="top" id="footerContent" style="border-top: 2px solid #F2F2F2; color: #484848; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 12px; font-weight: 400; line-height: 24px; padding-top: 40px; padding-bottom: 20px; text-align: center">
                                                <p style="color: #484848; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 12px; font-weight: 400; line-height: 24px; padding: 0; margin: 0; text-align: center">© 2021 Housematica<sup>®</sup>, wszystkie prawa zastrzeżone.<br>Lwowska 74 • 33-335 Nowy Sącz • Małopolska, Polska</p>
                                             </td>
                                        </tr>
                                    </tbody></table>
                                    
                                </td>
                            </tr>
                        </tbody></table>
                        
                    </td>
                </tr>
            </tbody></table>
        </center>
  
</div>
`,
    }
    );
}
