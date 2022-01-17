
//Begin function
//This function add new apartment variant
function addApartmentVariant() {

    //Check number of room variants
    var numberOfVariant = document.querySelectorAll('#variant').length;

    //Create array for save current data from variants field in array
    var apartmentAreaArray = new Array();
    var balconyAreaArray = new Array();
    var numberRoomArray = new Array();
    var roomArray = new Array();
    var areaRoomArray = new Array();
    var numberLivingRoomArray = new Array();
    var apartmentPriceArray = new Array();

    //Save data from variants field to table (if i can't do this, when i add new variant data from old variant was delted)
    if (numberOfVariant > 1) {
        for (i = 2; i <= numberOfVariant; i++) {

            var thisApartmentAreaName = "apartmentArea" + i;
            var thisBalconyAreaName = "balconyArea" + i;
            var thisNumberRoomName = "numberRooms" + i;
            var thisNumberLivingRoomName = "numberLivingRoom" + i;
            var thisApartmentPriceName = "apartmentPrice" + i;


            apartmentAreaArray[i] = document.getElementById(thisApartmentAreaName).value;
            balconyAreaArray[i] = document.getElementById(thisBalconyAreaName).value;
            numberRoomArray[i] = document.getElementById(thisNumberRoomName).value;
            numberLivingRoomArray[i] = document.getElementById(thisNumberLivingRoomName).value;
            apartmentPriceArray[i] = document.getElementById(thisApartmentPriceName).value;


            //One apartment variant can have some room variant -> in this code add all rooms from one variant to two dimensional table
            areaRoomArray[i] = [];
            roomArray[i] = [];
            for (k = 1; k <= numberRoomArray[i]; k++) {
                var thisRoomList = i + "roomName" + k;
                var thisRoomArea = i + "roomArea" + k;

                areaRoomArray[i][k] = document.getElementById(thisRoomArea).value;
                roomArray[i][k] = document.getElementById(thisRoomList).value;
            }
        }
    }


    //Add new variant to HTML code
    document.getElementById('placeToVariant').innerHTML += `
        <div class="separator separator-solid"></div>
	    <div id="variant" style="margin-top: 2em">
		    <h3 class="text-dark-25">`+ (numberOfVariant + 1) + `. Additional apartment variant</h3>
            <div class="row" >

		    <div class="col-xl-6">
                <div class="form-group">
                    <label>Apartment area</label>
                    <input type="text" class="form-control form-control-solid form-control-lg" id="apartmentArea`+ (numberOfVariant + 1) + `" asp-for="ApartmentVariants[` + (numberOfVariant + 1) + `].ApartmentArea" placeholder="Apartment area" value=""  />
                    <span class="form-text text-muted">Please enter standard apartment area (in m<sup>2</sup>).</span>
                </div>
            </div>


            <div class="col-xl-6">
                <div class="form-group">
                    <label>Balcony/garden area</label>
                    <input type="text" class="form-control form-control-solid form-control-lg" id="balconyArea`+ (numberOfVariant + 1) + `" asp-for="ApartmentVariants[` + (numberOfVariant + 1) + `].BalconyArea" placeholder="Balcon/garden area" value="" />
                    <span class="form-text text-muted">Please enter standard balcony area (in m<sup>2</sup>).</span>
                </div>
            </div>
            </div>

        <div class="row">
            <div class="col-xl-6">
                <div class="form-group">
                    <label>Number of rooms</label>
                    <input min="0" type="number" class="form-control form-control-solid form-control-lg" name="numberRooms`+ (numberOfVariant + 1) + `" placeholder="Number rooms" id="` + (numberOfVariant + 1) + `" onwheel="return false;" onkeyup="addRooms(this.id)" onclick="addRooms(this.id)" />
                     <span class="form-text text-muted">Please enter number of rooms.</span>
                 </div>
            </div>

            <div class="col-xl-6">
                <div class="form-group">
                    <label>Number of living room</label>
                    <input type="number" min="0"
                    onwheel="return false;" class="form-control form-control-solid form-control-lg" id="numberLivingRoom`+ (numberOfVariant + 1) + `" id="roomNumber" asp-for="ApartmentVariants[` + (numberOfVariant + 1) + `].NumberOfLivingRoom" placeholder="Number living room" value="" />
                    <span class="form-text text-muted" >Please enter number of living room.</span>
                </div>
            </div>
        </div>
		</div>
                        

        <div class="row" id="placeToHtml`+ (numberOfVariant + 1) + `">
                              
                               
        </div>
                            
        <div class="row">
            <div class="col-xl-6">
                <div class="form-group">
                    <label>Apartment price</label>
                    <input type="text" class="form-control form-control-solid form-control-lg" id="apartmentPrice`+ (numberOfVariant + 1) + `" id="roomNumber" asp-for="ApartmentVariants[` + (numberOfVariant + 1) + `].ApartmentPrice" placeholder="Apartment price" value="" />
                    <span class="form-text text-muted" >Please enter apartment price.</span>
				</div>
			</div>
								
			<div class="col-xl-6">
                <div class="form-group">
                    <label>File Browser</label>
					<div class="custom-file">
						<input type="file" class="custom-file-input" id="customFile" multiple name="standard3dFile"/>
						<label class="custom-file-label" for="customFile">Choose file</label>
						<span class="form-text text-muted" >Please upload 3d model file.</span>
					</div>
                </div>
			</div>
            </div>
    </div>`;

    //This code complement variant input with data from Array
    if (numberOfVariant > 1) {
        for (i = 2; i <= numberOfVariant; i++) {

            var thisApartmentAreaName = "apartmentArea" + i;
            var thisBalconyAreaName = "balconyArea" + i;
            var thisNumberRoomName = "numberRooms" + i;
            var thisNumberLivingRoomName = "numberLivingRoom" + i;
            var thisApartmentPriceName = "apartmentPrice" + i;

            document.getElementById(thisApartmentAreaName).value = apartmentAreaArray[i];
            document.getElementById(thisBalconyAreaName).value = balconyAreaArray[i];
            document.getElementById(thisNumberRoomName).value = numberRoomArray[i];
            document.getElementById(thisNumberLivingRoomName).value = numberLivingRoomArray[i];
            document.getElementById(thisApartmentPriceName).value = apartmentPriceArray[i];

            for (j = 1; j <= numberRoomArray[i]; j++) {
                var thisRoomList = i + "roomName" + j;
                document.getElementById(thisRoomList).value = roomArray[i][j];
            }

            for (j = 1; j <= numberRoomArray[i]; j++) {
                var thisRoomList = i + "roomArea" + j;
                document.getElementById(thisRoomList).value = areaRoomArray[i][j];
            }
        }
    }

    //Go to Final Step and insert apartment variant detail
    updateFinalStep(numberOfVariant);
}
//End function


//This funvtion add room when we input room number in input field
//Begin function
function addRooms(element) {
  
    var variableId = "placeToHtml" + element;
    console.log(variableId);
    var roomListvariableId = "finalRoomList" + element;
    var number = $("#" + element).val();

    var variableName = "placeToHtml" + element;
    document.getElementById(variableId).innerHTML = '';
    document.getElementById(roomListvariableId).innerHTML = '';
    for (var i = 0; i < number; i++) {
        document.getElementById(variableId).innerHTML += `
     <div class="col-xl-6">
     <!--begin::Input-->
     <div class="form-group">
         <label>`+ (i + 1) + `. Room name</label>
         <input type="text" class="form-control form-control-solid form-control-lg" id="`+ element + `roomName` + (i + 1) + `"  asp-for="ApartmentVariants[` + element + `].Rooms[` + (i + 1) + `].RoomName" placeholder="Room name"  value="" />
         <span class="form-text text-muted">Please enter room name</span>
     </div>
     <!--end::Input-->
 </div>
 <div class="col-xl-6">
     <!--begin::Input-->
     <div class="form-group">
         <label>`+ (i + 1) + `. Room area</label>
         <input type="text" class="form-control form-control-solid form-control-lg" id="`+ element + `roomArea` + (i + 1) + `"  asp-for="ApartmentVariants[` + element + `].Rooms[` + (i + 1) + `].RoomArea" placeholder="Room area"  value="" />
         <span class="form-text text-muted">Please enter room area (in m<sup>2</sup>)</span>
     </div>
     <!--end::Input-->
 </div>
   `;


        document.getElementById(roomListvariableId).innerHTML += `
     <div>Room name: <span id="`+ element + `roomName` + (i + 1) + `Final"></span>, area: <span id="` + element + `roomArea` + (i + 1) + `Final"></span>m<sup>2</sup></div>`;
    }
}
//End function



//Insert html code in final step where later paste code from input
//Begin function
function updateFinalStep(numberOfVariant) {


    document.getElementById("apartmentVariantList").innerHTML += `
        <div class="accordion accordion-light accordion-light-borderless accordion-svg-toggle" id="accordionExample7">
            <div class="card">
                <div class="card-header" id="headingTwo7">
                    <div class="card-title collapsed" data-toggle="collapse" data-target="#collapse`+ (numberOfVariant + 1) + `" style="padding: 0px;">
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
                padding-left: 0.2rem !important;"><b>`+ (numberOfVariant + 1) + `. Additional apartment variant</b></div>
            </div>
        </div>
    <div id="collapse`+ (numberOfVariant + 1) + `" style="padding-left: 1.8rem !important;" class="collapse text-dark-50" data-parent="#accordionExample7" >
        <div>Apartment area: <span id="apartmentArea`+ (numberOfVariant + 1) + `Final"></span></div>
        <div>Living rooms: <span id="numberLivingRoom`+ (numberOfVariant + 1) + `Final"></span></div>
        <div>Rooms number: <span id="numberRooms`+ (numberOfVariant + 1) + `Final"></span></div>
        <div class="card-body pl-12" id="finalRoomList`+ (numberOfVariant + 1) + `" style="padding-left: 1.7rem !important;">
                
        </div>
        <div>Balcony/garden area: <span id="balconyArea`+ (numberOfVariant + 1) + `Final"></span></div>
        <div>Apartment price: <span id="apartmentPrice`+ (numberOfVariant + 1) + `Final"></span></div>
    </div>
</div>
</div>`;
}
//End function