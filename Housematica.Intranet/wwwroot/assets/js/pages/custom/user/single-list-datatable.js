"use strict";
// Class definition

var KTAppsUsersListDatatable = function () {
	// Private functions

	// demo initializer
	var demo = function () {

		var datatable = $('#kt_datatable').KTDatatable({
			data: {
				saveState: { cookie: false },
			},
			search: {
				input: $('#kt_datatable_search_query'),
				key: 'generalSearch'
			},
			columns: [
				{
					field: 'Status',
					title: 'Status',
					autoHide: false,
					// callback function support for column rendering
					template: function (row) {
						var status = {
							Available: {
								'title': 'Available',
								'class': ' label-light-success'
							},
							Unavailable: {
								'title': 'Unavailable',
								'class': ' label-light-danger'
							},
							Reserved: {
								'title': 'Reserved',
								'class': ' label-light-primary'
							},
							Sold: {
								'title': 'Sold',
								'class': ' label-light-sold'
							},
							Soon: {
								'title': 'Soon',
								'class': ' label-light-info'
							}
						};
						return '<span class="label font-weight-bold label-lg' + status[row.Status].class + ' label-inline">' + status[row.Status].title + '</span>';
					},
				}, {
					field: 'Akcje',
					title: 'Akcje',
					sortable: false,
					width: 125,
					overflow: 'visible',
					textAlign: 'left',
					autoHide: false,
					template: '{{Akcje}}',
				},
			],
		});



		$('#kt_datatable_search_status').on('change', function () {
			datatable.search($(this).val().toLowerCase(), 'Status');
		});



		$('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();

	};

	return {
		// Public functions
		init: function () {
			// init dmeo
			demo();
		},
	};
}();

jQuery(document).ready(function () {
	KTAppsUsersListDatatable.init();
});


