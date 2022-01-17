//Every time, all from first variant are available, but are invisible. They are turn on using checkbox who toogle attribute display-none. If we can add second 
//or more otpion code using JS function




//This code add new kitchen variant
//Begin code
function addKitchenVariant() {

    //Check how many variant exist in this moment
    var numberKitchenVariant = document.querySelectorAll('#kitchenConfigure').length;

    if (numberKitchenVariant != 0) {

        document.getElementById("numberOfKitchenOption").innerHTML = numberKitchenVariant + 1;
    }

    var kitchenNameArray = new Array();
    var kitchenPriceArray = new Array();
    var kitchenDescriptionArray = new Array();

    for (i = 2; i <= numberKitchenVariant; i++) {

        //Create array where we save temp input value (we must save it, since they are reset when we add new variant)
        var thiskitchenName = "kitchenName" + i;
        var thiskitchenPrice = "kitchenPrice" + i;
        var thiskitchenDescription = "kitchenDescription" + i;


        kitchenNameArray[i] = document.getElementById(thiskitchenName).value;
        kitchenPriceArray[i] = document.getElementById(thiskitchenPrice).value;
        kitchenDescriptionArray[i] = document.getElementById(thiskitchenDescription).value;

    }


    //Add new variant
    document.getElementById('placeToKitchenVariant').innerHTML += `
    <div class="col-xl-12" style="margin-bottom:2em"><div class="separator separator-solid"></div>
    <h3 class="text-dark-25" style="margin-top:2rem !important; margin-bottom:-1rem !important">`+ (numberKitchenVariant + 1) + `. Additional kitchen variant</h3></div>
	
	<div class="col-xl-6" id="kitchenConfigure">
		
                                    <div class="form-group">
										
                                        <label>Option name</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="kitchenName`+ (numberKitchenVariant + 1) + `" name="ApartmentOption[` + (numberKitchenVariant) + `].OptionName" asp-for="ApartmentOption[` + (numberKitchenVariant) + `].OptionName"  oninput="sendToFinalStep(this)" placeholder="Option name" value="" />
                                        <span class="form-text text-muted">Please enter kitchen option name.</span>
                                    </div>
                                </div>
                                <div class="col-xl-6">
								
                                    <div class="form-group">
									
                                        <label>Option price</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="kitchenPrice`+ (numberKitchenVariant + 1) + `" name="ApartmentOption[` + (numberKitchenVariant) + `].Price" asp-for="ApartmentOption[` + (numberKitchenVariant) + `].Price" oninput="sendToFinalStep(this)"placeholder="Option price" value="" />
                                        <span class="form-text text-muted">Please enter kitchen option price.</span>
                                    </div>
								</div>

								
								<div class="col-xl-12">
                                    <div class="form-group">
                                        <label>Option description</label>
										<textarea class="form-control form-control-solid form-control-lg" id="exampleTextarea" id="kitchenDescription`+ (numberKitchenVariant + 1) + `" rows="4" name="ApartmentOption[` + (numberKitchenVariant) + `].OptionDescription" asp-for="ApartmentOption[` + (numberKitchenVariant) + `].OptionDescription" oninput="sendToFinalStep(this)"></textarea>
										 <span class="form-text text-muted">Please enter option description.</span>
                                    </div>
								</div>
								<div class="col-xl-12">
									<div class="form-group">
										<label>Option visualisation</label>
										<div class="custom-file">
											
											<input type="file" class="custom-file-input" id="customFile" multiple/>
											<label class="custom-file-label" for="customFile">Choose file</label>
											<span class="form-text text-muted" >Please upload option visualisation.</span>
										</div>
								</div>
								</div>
                                

	`;


    //Set data from array to input field
    for (i = 2; i <= numberKitchenVariant; i++) {

        var thiskitchenName = "kitchenName" + i;
        var thiskitchenPrice = "kitchenPrice" + i;
        var thiskitchenDescription = "kitchenDescription" + i;


        document.getElementById(thiskitchenName).value = kitchenNameArray[i];
        document.getElementById(thiskitchenPrice).value = kitchenPriceArray[i];
        document.getElementById(thiskitchenDescription).value = kitchenDescriptionArray[i];

    }


    //This code add kitchen otion details to final step. This code check how many option we have and add only iine new variant (don't reset earlier row)
    for (i = numberKitchenVariant; i <= numberKitchenVariant; i++) {
        document.getElementById('kitchenOptionRest').innerHTML += `

    <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="headingTwo`+ (i + 11) + `" id="customKitchenOption">
    <div class="card">
        <div class="card-header" id="headingTwo`+ (i + 11) + `" id="customKitchenOption">
            <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseKitchen`+ (i + 11) + `" style="padding: 0px;">
                <span class="svg-icon svg-icon-primary">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                            <polygon points="0 0 24 0 24 24 0 24"></polygon>
                            <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                            <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                        </g>
                    </svg>
                </span>
                <div class="card-label pl-4" style="font-size: 13px !important;
                font-weight: 400;
                font-family: Poppins, Helvetica, 'sans-serif';
                color: #3F4254 !important;
                padding-left: 0.2rem !important;"><b>`+ (i + 1) + `. Kitchen variant</b></div>
            </div>
        </div>
        <div id="configureCollapseKitchen`+ (i + 11) + `" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#headingTwo` + (i + 11) + `">
            <div>Option name: <span id="kitchenName`+ (i + 1) + `Final"></span></div>
            <div>Option price: <span id="kitchenPrice`+ (i + 1) + `Final"></span></div>
            <div>Option description: <span id="kitchenDescription`+ (i + 1) + `Final"></span></div>
        </div>
    </div>
</div>`}
}


//This function add first kitchen option details in final step
//Start function
function addKitchenFirstOptionInFinalStep() {
    document.getElementById("kitchenOptionFirst").innerHTML += `

    <div id="placeToKitchenVariantFinal">
   
        <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="accordionExample8" id="customKitchenOption">
        
        
        <div class="card">
            <div class="card-header" id="headingTwo7" id="customKitchenOption">
                <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseKitchen" style="padding: 0px;">
                    <span class="svg-icon svg-icon-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <polygon points="0 0 24 0 24 24 0 24"></polygon>
                                <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                                <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                            </g>
                        </svg>
                    </span>
                    <div class="card-label pl-4" style="font-size: 13px !important;
                    font-weight: 400;
                    font-family: Poppins, Helvetica, 'sans-serif';
                    color: #3F4254 !important;
                    padding-left: 0.2rem !important;"><b>1. Kitchen variant</b></div>
                </div>
            </div>
            <div id="configureCollapseKitchen" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#accordionExample8" >
                <div>Option name: <span id="kitchenName1Final"></span></div>
                <div>Option price: <span id="kitchenPrice1Final"></span></div>
                <div>Option description: <span id="kitchenDescription1Final"></span></div>
                
              
                
            </div>
        </div>
    
    
    
    </div>
    </div>
    
        `;
}
//End function



//This function add first configure kitchen option
//Begin function
function showKitchenOptions() {

    if ($("#kitchenCheckbox").is(':checked')) {
        $("#kitchenConfigure").removeClass("display-none");
        $("#kitchenOptionRest").removeClass("display-none");
        $("#kitchenOptionFirst").removeClass("display-none");
        //This function add first kitchen option details in final step

        //This function check in final step exist first option, if not create then
        if ($('#kitchenOptionFirst').children().length < 1) {
            addKitchenFirstOptionInFinalStep();
        }




        //This function check how many kitchen option exist (when set checkbox checked) and send it to final step
        var numberKitchenVariant = document.querySelectorAll('#kitchenConfigure').length;

        if (numberKitchenVariant != 0) {
            document.getElementById("numberOfKitchenOption").innerHTML = numberKitchenVariant;
        }
    }

    else {
        //This function check how many kitchen option exist (when set checkbox checked) and dend it to final step
        $("#kitchenConfigure").addClass("display-none");
        $("#kitchenOptionRest").addClass("display-none");
        $("#kitchenOptionFirst").addClass("display-none");
        document.getElementById("numberOfKitchenOption").innerHTML = "none option";



    }

}
//End function






//This code add new bathroom variant
//Begin code
function addBathroomVariant() {

    //Check how many variant exist in this moment
    var numberBathroomVariant = document.querySelectorAll('#bathroomConfigure').length;

    if (numberBathroomVariant != 0) {

        document.getElementById("numberOfBathroomOption").innerHTML = numberBathroomVariant + 1;
    }

    var bathroomNameArray = new Array();
    var bathroomPriceArray = new Array();
    var bathroomDescriptionArray = new Array();

    for (i = 2; i <= numberBathroomVariant; i++) {

        //Create array where we save temp input value (we must save it, since they are reset when we add new variant)
        var thisBathroomName = "bathroomName" + i;
        var thisBathroomPrice = "bathroomPrice" + i;
        var thisBathroomDescription = "bathroomDescription" + i;


        bathroomNameArray[i] = document.getElementById(thisBathroomName).value;
        bathroomPriceArray[i] = document.getElementById(thisBathroomPrice).value;
        bathroomDescriptionArray[i] = document.getElementById(thisBathroomDescription).value;

    }


    //Add new variant
    document.getElementById('placeToBathroomVariant').innerHTML += `
    <div class="col-xl-12" style="margin-bottom:2em"><div class="separator separator-solid"></div>
    <h3 class="text-dark-25" style="margin-top:2rem !important; margin-bottom:-1rem !important">`+ (numberBathroomVariant + 1) + `. Additional bathroom variant</h3></div>
    </div>
	
	<div class="col-xl-6" id="bathroomConfigure">
		
                                    <div class="form-group">
										
                                        <label>Option name</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="bathroomName`+ (numberBathroomVariant + 1) + `" name="ApartmentOption[10` + (numberBathroomVariant) + `].OptionName" asp-for="ApartmentOption[10` + (numberBathroomVariant) + `].OptionName" oninput="sendToFinalStep(this)" placeholder="Option name" value="" />
                                        <span class="form-text text-muted">Please enter bathroom option name.</span>
                                    </div>
                                </div>
                                <div class="col-xl-6">
								
                                    <div class="form-group">
									
                                        <label>Option price</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="bathroomPrice`+ (numberBathroomVariant + 1) + `"  name="ApartmentOption[10` + (numberBathroomVariant) + `].Price" asp-for="ApartmentOption[10` + (numberBathroomVariant) + `].Price" oninput="sendToFinalStep(this)"placeholder="Option price" value="" />
                                        <span class="form-text text-muted">Please enter bathroom option price.</span>
                                    </div>
								</div>

								
								<div class="col-xl-12">
                                    <div class="form-group">
                                        <label>Option description</label>
										<textarea class="form-control form-control-solid form-control-lg" id="exampleTextarea" id="bathroomDescription`+ (numberBathroomVariant + 1) + `" rows="4" name="ApartmentOption[10` + (numberBathroomVariant) + `].OptionDescription" asp-for="ApartmentOption[10` + (numberBathroomVariant) + `].OptionDescription" oninput="sendToFinalStep(this)"></textarea>
										 <span class="form-text text-muted">Please enter bathroom option description.</span>
                                    </div>
								</div>
								<div class="col-xl-12">
									<div class="form-group">
										<label>Option visualisation</label>
										<div class="custom-file">
											
											<input type="file" class="custom-file-input" id="customFile" multiple/>
											<label class="custom-file-label" for="customFile">Choose file</label>
											<span class="form-text text-muted" >Please upload option visualisation.</span>
										</div>
								</div>
								</div>
                                

	`;


    //Set data from array to input field
    for (i = 2; i <= numberBathroomVariant; i++) {

        var thisBathroomName = "bathroomName" + i;
        var thisBathroomPrice = "bathroomPrice" + i;
        var thisBathroomDescription = "bathroomDescription" + i;


        document.getElementById(thisBathroomName).value = bathroomNameArray[i];
        document.getElementById(thisBathroomPrice).value = bathroomPriceArray[i];
        document.getElementById(thisBathroomDescription).value = bathroomDescriptionArray[i];

    }


    //This code add bathroom otion details to final step. This code check how many option we have and add only iine new variant (don't reset earlier row)
    for (i = numberBathroomVariant; i <= numberBathroomVariant; i++) {
        document.getElementById('bathroomOptionRest').innerHTML += `

    <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="headingTwo`+ (i + 11) + `" id="customBathroomOption">
    <div class="card">
        <div class="card-header" id="headingTwo`+ (i + 11) + `" id="customBathroomOption">
            <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseBathroom`+ (i + 11) + `" style="padding: 0px;">
                <span class="svg-icon svg-icon-primary">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                            <polygon points="0 0 24 0 24 24 0 24"></polygon>
                            <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                            <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                        </g>
                    </svg>
                </span>
                <div class="card-label pl-4" style="font-size: 13px !important;
                font-weight: 400;
                font-family: Poppins, Helvetica, 'sans-serif';
                color: #3F4254 !important;
                padding-left: 0.2rem !important;"><b>`+ (i + 1) + `. Bathroom variant</b></div>
            </div>
        </div>
        <div id="configureCollapseBathroom`+ (i + 11) + `" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#headingTwo` + (i + 11) + `">
            <div>Option name: <span id="bathroomName`+ (i + 1) + `Final"></span></div>
            <div>Option price: <span id="bathroomPrice`+ (i + 1) + `Final"></span></div>
            <div>Option description: <span id="bathroomDescription`+ (i + 1) + `Final"></span></div>
        </div>
    </div>
</div>`}
}


//This function add first bathroom option details in final step
//Start function
function addBathroomFirstOptionInFinalStep() {
    document.getElementById("bathroomOptionFirst").innerHTML += `

    <div id="placeToBathroomVariantFinal">
        <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="accordionExample8" id="customBathroomOption">
        
        
        <div class="card">
            <div class="card-header" id="headingTwo7" id="customBathroomOption">
                <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseBathroom" style="padding: 0px;">
                    <span class="svg-icon svg-icon-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <polygon points="0 0 24 0 24 24 0 24"></polygon>
                                <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                                <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                            </g>
                        </svg>
                    </span>
                    <div class="card-label pl-4" style="font-size: 13px !important;
                    font-weight: 400;
                    font-family: Poppins, Helvetica, 'sans-serif';
                    color: #3F4254 !important;
                    padding-left: 0.2rem !important;"><b>1. Bathroom variant</b></div>
                </div>
            </div>
            <div id="configureCollapseBathroom" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#accordionExample8" >
                <div>Option name: <span id="bathroomName1Final"></span></div>
                <div>Option price: <span id="bathroomPrice1Final"></span></div>
                <div>Option description: <span id="bathroomDescription1Final"></span></div>
                
              
                
            </div>
        </div>
    
    
    
    </div>
    </div>
    
        `;
}
//End function



//This function add first configure bathroom option
//Begin function
function showBathroomOptions() {
    if ($("#bathroomCheckbox").is(':checked')) {
        $("#bathroomConfigure").removeClass("display-none");
        $("#bathroomOptionRest").removeClass("display-none");
        $("#bathroomOptionFirst").removeClass("display-none");
        //This function add first bathroom option details in final step

        //This function check in final step exist first option, if not create then
        if ($('#bathroomOptionFirst').children().length < 1) {
            addBathroomFirstOptionInFinalStep();
        }




        //This function check how many bathroom option exist (when set checkbox checked) and send it to final step
        var numberBathroomVariant = document.querySelectorAll('#bathroomConfigure').length;

        if (numberBathroomVariant != 0) {
            document.getElementById("numberOfBathroomOption").innerHTML = numberBathroomVariant;
        }
    }

    else {
        //This function check how many bathroom option exist (when set checkbox checked) and dend it to final step
        $("#bathroomConfigure").addClass("display-none");
        $("#bathroomOptionRest").addClass("display-none");
        $("#bathroomOptionFirst").addClass("display-none");
        document.getElementById("numberOfBathroomOption").innerHTML = "none option";



    }

}
//End function









//This code add new rooms variant
//Begin code
function addRoomsVariant() {

    //Check how many variant exist in this moment
    var numberRoomsVariant = document.querySelectorAll('#roomsConfigure').length;

    if (numberRoomsVariant != 0) {

        document.getElementById("numberOfRoomsOption").innerHTML = numberRoomsVariant + 1;
    }

    var roomsNameArray = new Array();
    var roomsPriceArray = new Array();
    var roomsDescriptionArray = new Array();

    for (i = 2; i <= numberRoomsVariant; i++) {

        //Create array where we save temp input value (we must save it, since they are reset when we add new variant)
        var thisRoomsName = "roomsName" + i;
        var thisRoomsPrice = "roomsPrice" + i;
        var thisRoomsDescription = "roomsDescription" + i;


        roomsNameArray[i] = document.getElementById(thisRoomsName).value;
        roomsPriceArray[i] = document.getElementById(thisRoomsPrice).value;
        roomsDescriptionArray[i] = document.getElementById(thisRoomsDescription).value;

    }


    //Add new variant
    document.getElementById('placeToRoomsVariant').innerHTML += `
	<div class="col-xl-12" style="margin-bottom:2em"><div class="separator separator-solid"></div>
    <h3 class="text-dark-25" style="margin-top:2rem !important; margin-bottom:-1rem !important">`+ (numberRoomsVariant + 1) + `. Additional rooms variant</h3></div>
    </div>
	
	<div class="col-xl-6" id="roomsConfigure">
		
                                    <div class="form-group">
										
                                        <label>Option name</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="roomsName`+ (numberRoomsVariant + 1) + `" name="ApartmentOption[20` + (numberRoomsVariant) + `].OptionName" asp-for="ApartmentOption[20` + (numberRoomsVariant) + `].OptionName" oninput="sendToFinalStep(this)" placeholder="Option name" value="" />
                                        <span class="form-text text-muted">Please enter rooms option name.</span>
                                    </div>
                                </div>
                                <div class="col-xl-6">
								
                                    <div class="form-group">
									
                                        <label>Option price</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" namide="roomsPrice`+ (numberRoomsVariant + 1) + `" name="ApartmentOption[20` + (numberRoomsVariant) + `].Price"  asp-for="ApartmentOption[20` + (numberRoomsVariant) + `].Price" oninput="sendToFinalStep(this)"placeholder="Option price" value="" />
                                        <span class="form-text text-muted">Please enter rooms option price.</span>
                                    </div>
								</div>

								
								<div class="col-xl-12">
                                    <div class="form-group">
                                        <label>Option description</label>
										<textarea class="form-control form-control-solid form-control-lg" id="exampleTextarea" id="roomsDescription`+ (numberRoomsVariant + 1) + `" rows="4" name="ApartmentOption[20` + (numberRoomsVariant) + `].OptionDescription" asp-for="ApartmentOption[20` + (numberRoomsVariant) + `].OptionDescription" oninput="sendToFinalStep(this)"></textarea>
										 <span class="form-text text-muted">Please enter rooms option description.</span>
                                    </div>
								</div>
								<div class="col-xl-12">
									<div class="form-group">
										<label>Option visualisation</label>
										<div class="custom-file">
											
											<input type="file" class="custom-file-input" id="customFile" multiple/>
											<label class="custom-file-label" for="customFile">Choose file</label>
											<span class="form-text text-muted" >Please upload option visualisation.</span>
										</div>
								</div>
								</div>
                                

	`;


    //Set data from array to input field
    for (i = 2; i <= numberRoomsVariant; i++) {

        var thisRoomsName = "roomsName" + i;
        var thisRoomsPrice = "roomsPrice" + i;
        var thisRoomsDescription = "roomsDescription" + i;


        document.getElementById(thisRoomsName).value = roomsNameArray[i];
        document.getElementById(thisRoomsPrice).value = roomsPriceArray[i];
        document.getElementById(thisRoomsDescription).value = roomsDescriptionArray[i];

    }


    //This code add rooms otion details to final step. This code check how many option we have and add only iine new variant (don't reset earlier row)
    for (i = numberRoomsVariant; i <= numberRoomsVariant; i++) {
        document.getElementById('roomsOptionRest').innerHTML += `

    <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="headingTwo`+ (i + 11) + `" id="customRoomsOption">
    <div class="card">
        <div class="card-header" id="headingTwo`+ (i + 11) + `" id="customRoomsOption">
            <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseRooms`+ (i + 11) + `" style="padding: 0px;">
                <span class="svg-icon svg-icon-primary">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                            <polygon points="0 0 24 0 24 24 0 24"></polygon>
                            <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                            <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                        </g>
                    </svg>
                </span>
                <div class="card-label pl-4" style="font-size: 13px !important;
                font-weight: 400;
                font-family: Poppins, Helvetica, 'sans-serif';
                color: #3F4254 !important;
                padding-left: 0.2rem !important;"><b>`+ (i + 1) + `. Rooms variant</b></div>
            </div>
        </div>
        <div id="configureCollapseRooms`+ (i + 11) + `" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#headingTwo` + (i + 11) + `">
            <div>Option name: <span id="roomsName`+ (i + 1) + `Final"></span></div>
            <div>Option price: <span id="roomsPrice`+ (i + 1) + `Final"></span></div>
            <div>Option description: <span id="roomsDescription`+ (i + 1) + `Final"></span></div>
        </div>
    </div>
</div>`}
}


//This function add first rooms option details in final step
//Start function
function addRoomsFirstOptionInFinalStep() {
    document.getElementById("roomsOptionFirst").innerHTML += `

    <div id="placeToRoomsVariantFinal">
        <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="accordionExample8" id="customRoomsOption">
        
        
        <div class="card">
            <div class="card-header" id="headingTwo7" id="customRoomsOption">
                <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseRooms" style="padding: 0px;">
                    <span class="svg-icon svg-icon-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <polygon points="0 0 24 0 24 24 0 24"></polygon>
                                <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                                <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                            </g>
                        </svg>
                    </span>
                    <div class="card-label pl-4" style="font-size: 13px !important;
                    font-weight: 400;
                    font-family: Poppins, Helvetica, 'sans-serif';
                    color: #3F4254 !important;
                    padding-left: 0.2rem !important;"><b>1. Rooms variant</b></div>
                </div>
            </div>
            <div id="configureCollapseRooms" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#accordionExample8" >
                <div>Option name: <span id="roomsName1Final"></span></div>
                <div>Option price: <span id="roomsPrice1Final"></span></div>
                <div>Option description: <span id="roomsDescription1Final"></span></div>
                
              
                
            </div>
        </div>
    
    
    
    </div>
    </div>
    
        `;
}
//End function



//This function add first configure rooms option
//Begin function
function showRoomsOptions() {
    if ($("#roomsCheckbox").is(':checked')) {
        $("#roomsConfigure").removeClass("display-none");
        $("#roomsOptionRest").removeClass("display-none");
        $("#roomsOptionFirst").removeClass("display-none");
        //This function add first rooms option details in final step

        //This function check in final step exist first option, if not create then
        if ($('#roomsOptionFirst').children().length < 1) {
            addRoomsFirstOptionInFinalStep();
        }




        //This function check how many rooms option exist (when set checkbox checked) and send it to final step
        var numberRoomsVariant = document.querySelectorAll('#roomsConfigure').length;

        if (numberRoomsVariant != 0) {
            document.getElementById("numberOfRoomsOption").innerHTML = numberRoomsVariant;
        }
    }

    else {
        //This function check how many rooms option exist (when set checkbox checked) and dend it to final step
        $("#roomsConfigure").addClass("display-none");
        $("#roomsOptionRest").addClass("display-none");
        $("#roomsOptionFirst").addClass("display-none");
        document.getElementById("numberOfRoomsOption").innerHTML = "none option";



    }

}
//End function







































//This code add new door and window variant
//Begin code
function addDoorWindowVariant() {

    //Check how many variant exist in this moment
    var numberDoorWindowVariant = document.querySelectorAll('#doorWindowConfigure').length;

    if (numberDoorWindowVariant != 0) {

        document.getElementById("numberOfDoorWindowOption").innerHTML = numberDoorWindowVariant + 1;
    }

    var doorWindowNameArray = new Array();
    var doorWindowPriceArray = new Array();
    var doorWindowDescriptionArray = new Array();

    for (i = 2; i <= numberDoorWindowVariant; i++) {

        //Create array where we save temp input value (we must save it, since they are reset when we add new variant)
        var thisDoorWindowName = "doorWindowName" + i;
        var thisDoorWindowPrice = "doorWindowPrice" + i;
        var thisDoorWindowDescription = "doorWindowDescription" + i;


        doorWindowNameArray[i] = document.getElementById(thisDoorWindowName).value;
        doorWindowPriceArray[i] = document.getElementById(thisDoorWindowPrice).value;
        doorWindowDescriptionArray[i] = document.getElementById(thisDoorWindowDescription).value;

    }


    //Add new variant
    document.getElementById('placeToDoorWindowVariant').innerHTML += `
	<div class="col-xl-12" style="margin-bottom:2em"><div class="separator separator-solid"></div>
    <h3 class="text-dark-25" style="margin-top:2rem !important; margin-bottom:-1rem !important">`+ (numberDoorWindowVariant + 1) + `. Additional door and window variant</h3></div>
    
	
	<div class="col-xl-6" id="doorWindowConfigure">
		
                                    <div class="form-group">
										
                                        <label>Option name</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="doorWindowName`+ (numberDoorWindowVariant + 1) + `"  name="ApartmentOption[30` + (numberDoorWindowVariant) + `].OptionName"  asp-for="ApartmentOption[30` + (numberDoorWindowVariant) + `].OptionName" oninput="sendToFinalStep(this)" placeholder="Option name" value="" />
                                        <span class="form-text text-muted">Please enter door and window option name.</span>
                                    </div>
                                </div>
                                <div class="col-xl-6">
								
                                    <div class="form-group">
									
                                        <label>Option price</label>
                                        <input type="text" class="form-control form-control-solid form-control-lg" id="doorWindowPrice`+ (numberDoorWindowVariant + 1) + `" name="ApartmentOption[30` + (numberDoorWindowVariant) + `].Price" asp-for="ApartmentOption[30` + (numberDoorWindowVariant) + `].Price" oninput="sendToFinalStep(this)"placeholder="Option price" value="" />
                                        <span class="form-text text-muted">Please enter door and window option price.</span>
                                    </div>
								</div>

								
								<div class="col-xl-12">
                                    <div class="form-group">
                                        <label>Option description</label>
										<textarea class="form-control form-control-solid form-control-lg" id="exampleTextarea" rows="4"  id="doorWindowDescription`+ (numberDoorWindowVariant + 1) + `" name="ApartmentOption[30` + (numberDoorWindowVariant) + `].OptionDescription"  asp-for="ApartmentOption[30` + (numberDoorWindowVariant) + `].OptionDescription" oninput="sendToFinalStep(this)"></textarea>
										 <span class="form-text text-muted">Please enter door and window option description.</span>
                                    </div>
								</div>
								<div class="col-xl-12">
									<div class="form-group">
										<label>Option visualisation</label>
										<div class="custom-file">
											
											<input type="file" class="custom-file-input" id="customFile" multiple/>
											<label class="custom-file-label" for="customFile">Choose file</label>
											<span class="form-text text-muted" >Please upload option visualisation.</span>
										</div>
								</div>
								</div>
                                

	`;


    //Set data from array to input field
    for (i = 2; i <= numberDoorWindowVariant; i++) {

        var thisDoorWindowName = "doorWindowName" + i;
        var thisDoorWindowPrice = "doorWindowPrice" + i;
        var thisDoorWindowDescription = "doorWindowDescription" + i;


        document.getElementById(thisDoorWindowName).value = doorWindowNameArray[i];
        document.getElementById(thisDoorWindowPrice).value = doorWindowPriceArray[i];
        document.getElementById(thisDoorWindowDescription).value = doorWindowDescriptionArray[i];

    }


    //This code add dorr and window otion details to final step. This code check how many option we have and add only iine new variant (don't reset earlier row)
    for (i = numberDoorWindowVariant; i <= numberDoorWindowVariant; i++) {
        document.getElementById('doorWindowOptionRest').innerHTML += `

    <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="headingDoorWindow`+ (i + 11) + `" id="customDoorWindowOption">
    <div class="card">
        <div class="card-header" id="headingDoorWindow`+ (i + 11) + `" id="customDoorWindowOption">
            <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseDoorWindow`+ (i + 11) + `" style="padding: 0px;">
                <span class="svg-icon svg-icon-primary">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                            <polygon points="0 0 24 0 24 24 0 24"></polygon>
                            <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                            <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                        </g>
                    </svg>
                </span>
                <div class="card-label pl-4" style="font-size: 13px !important;
                font-weight: 400;
                font-family: Poppins, Helvetica, 'sans-serif';
                color: #3F4254 !important;
                padding-left: 0.2rem !important;"><b>`+ (i + 1) + `. Door and window variant</b></div>
            </div>
        </div>
        <div id="configureCollapseDoorWindow`+ (i + 11) + `" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#headingDoorWindow` + (i + 11) + `">
            <div>Option name: <span id="doorWindowName`+ (i + 1) + `Final"></span></div>
            <div>Option price: <span id="doorWindowPrice`+ (i + 1) + `Final"></span></div>
            <div>Option description: <span id="doorWindowDescription`+ (i + 1) + `Final"></span></div>
        </div>
    </div>
</div>`}
}


//This function add first door and window option details in final step
//Start function
function addDoorWindowFirstOptionInFinalStep() {
    document.getElementById("doorWindowOptionFirst").innerHTML += `

    <div id="placeToDoorWindowVariantFinal">
        <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="accordionExample8" id="customDoorWindowOption">
        
        
        <div class="card">
            <div class="card-header" id="headingTwo7" id="customDoorWindowOption">
                <div class="card-title collapsed" data-toggle="collapse" data-target="#configureCollapseDoorWindow" style="padding: 0px;">
                    <span class="svg-icon svg-icon-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <polygon points="0 0 24 0 24 24 0 24"></polygon>
                                <path d="M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z" fill="#000000" fill-rule="nonzero"></path>
                                <path d="M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" transform="translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) "></path>
                            </g>
                        </svg>
                    </span>
                    <div class="card-label pl-4" style="font-size: 13px !important;
                    font-weight: 400;
                    font-family: Poppins, Helvetica, 'sans-serif';
                    color: #3F4254 !important;
                    padding-left: 0.2rem !important;"><b>1. Door and window variant</b></div>
                </div>
            </div>
            <div id="configureCollapseDoorWindow" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#accordionExample8" >
                <div>Option name: <span id="doorWindowName1Final"></span></div>
                <div>Option price: <span id="doorWindowPrice1Final"></span></div>
                <div>Option description: <span id="doorWindowDescription1Final"></span></div>
                
              
                
            </div>
        </div>
    
    
    
    </div>
    </div>
    
        `;
}
//End function



//This function add first configure door and window option
//Begin function
function showDoorWindowOptions() {
    if ($("#doorWindowCheckbox").is(':checked')) {
        $("#doorWindowConfigure").removeClass("display-none");
        $("#doorWindowOptionRest").removeClass("display-none");
        $("#doorWindowOptionFirst").removeClass("display-none");
        //This function add first door and window option details in final step

        //This function check in final step exist first option, if not create then
        if ($('#doorWindowOptionFirst').children().length < 1) {
            addDoorWindowFirstOptionInFinalStep();
        }




        //This function check how many door and window option exist (when set checkbox checked) and send it to final step
        var numberDoorWindowVariant = document.querySelectorAll('#doorWindowConfigure').length;

        if (numberDoorWindowVariant != 0) {
            document.getElementById("numberOfDoorWindowOption").innerHTML = numberDoorWindowVariant;
        }
    }

    else {
        //This function check how many door and window option exist (when set checkbox checked) and dend it to final step
        $("#doorWindowConfigure").addClass("display-none");
        $("#doorWindowOptionRest").addClass("display-none");
        $("#doorWindowOptionFirst").addClass("display-none");
        document.getElementById("numberOfDoorWindowOption").innerHTML = "none option";



    }

}
//End function




