function deleteItem(controller, id) {
    console.log(controller);
    console.log(id);
    Swal.fire({
        title: "Czy chcesz usunąć projekt?",
        text: "Tej operacji nie można cofnąć!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Tak, usuń!",
        cancelButtonText: "Nie, powrót!",
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {

            $.ajax(
                {
                    type: 'POST',
                    dataType: 'JSON',
                    url: '../../Projects/DeleteConfirmed',
                    data: {
                        id: id,
                    },
                    success: function () {
                        console.log("true");
                    },
                    error: function () {
                        console.log("false");
                    },

                });

            Swal.fire(
                "Gratulacje!",
                "Rezerwacja została pomyślnie usunięta",
                "success"
            ).then(function () {
                $("div[data-item=project_" + id + "]").addClass("display-none");
            });

            // result.dismiss can be "cancel", "overlay",
            // "close", and "timer"
        } else if (result.dismiss === "cancel") {
            Swal.fire(
                "Anulowano",
                "Rezerwacja nie została usunięta",
                "error"
            )
        }
    });
}