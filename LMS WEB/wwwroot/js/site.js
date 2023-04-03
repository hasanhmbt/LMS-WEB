function showSuccessAlert(title) {
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.options.fadeOut = 1000;
    toastr.options.timeOut = 2000;
    toastr.success(title);
}