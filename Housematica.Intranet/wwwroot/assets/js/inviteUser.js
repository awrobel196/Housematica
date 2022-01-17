FormValidation.formValidation(
    document.getElementById('kt_form_1'),
    {
        fields: {
            email: {
                validators: {
                    notEmpty: {
                        message: 'Adres email jest wymagany'
                    },
                    emailAddress: {
                        message: 'Podaj poprawny adres email'
                    }
                }
            },

            
        },

        plugins: {
            trigger: new FormValidation.plugins.Trigger(),
            // Bootstrap Framework Integration
            bootstrap: new FormValidation.plugins.Bootstrap(),
            // Validate fields when clicking the Submit button
            submitButton: new FormValidation.plugins.SubmitButton(),
            // Submit the form when all fields are valid
            defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
        }
    }
);



function invite() {
    

    var email = $("#inviteEmail").val();
    var licenseId = $("#licenseId").val();
    $(".invite-button").addClass("display-none");
    $(".loading-button").removeClass("display-none");
    Email.send({
        Host: "smtp.atma.com.pl",
        Username: "testatma",
        Password: "Haslo321!",
        To: email,
        From: "test@atma.com.pl",
        Subject: "Housematica - zaproszenie do zespołu",
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
                                                                        <h1 style="color: #606060; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 30px; font-style: normal; font-weight: 600; line-height: 42px; letter-spacing: normal; margin: 0; padding: 0; text-align: center">Twój znajomy zaprosił Cię do Housematica</h1>
                                                                        <h1 style="color: #606060; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 15px; font-style: normal; font-weight: 400; line-height: 42px; letter-spacing: normal; margin: 0; padding: 0; text-align: center">Kliknij poniższy przycisk aby dołączyć do jego zespołu</h1>
                                                                    
                                                                    
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding-bottom: 5px" valign="top">
                                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody><tr>
                                                                                <td align="center" valign="middle">
                                                                                    
                                                                                    <a href="https://portal.housematica.pl/Authentication/Invite/`+ licenseId + `"  style="background-color: #3246d3; border-collapse: separate; border-top: 20px solid #3246d3; border-right: 20px solid #3246d3; border-bottom: 20px solid #3246d3; border-left: 20px solid #3246d3; border-radius: 3px; color: #FFFFFF; display: inline-block; font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 600; letter-spacing: .3px; text-decoration: none" target="_blank" rel="noreferrer">Dołącz do zespołu</a>
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </tbody></table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-bottom: 40px">
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
    }).then(function () {
        $(".closeInviteModal").click();
        swal.fire({
            title: "Zaproszenie zostało wysłane",
            text: "Gry Twój znajomy przyjmie zaproszenie zobaczysz go na liście zespołu ",
            icon: "success",
            buttonsStyling: false,
            showCloseButton: true,
            customClass: {
                confirmButton: "display-none"
            },
            timer: 5000
        });
        var email = $("#inviteEmail").val();
        $("#inviteEmail").val("");
        $(".loading-button").addClass("display-none");
        $(".invite-button").removeClass("display-none");
       

       
    }
        
      
    );

}





