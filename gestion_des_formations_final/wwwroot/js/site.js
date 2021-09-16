
function ViewAjaxCallModal(lien, idvue) {

    var vuemodaldiv = idvue + 'Div'; // le modal body doit obligatoirement finir avec le mot Div
    $(vuemodaldiv).load(lien, function () {
        $(idvue).modal("show");
    });
}
