// Write your Javascript code.
function formOnFail(error) {
    if (error == 500) {
        toastr.error(error.responseText);
    }
}

