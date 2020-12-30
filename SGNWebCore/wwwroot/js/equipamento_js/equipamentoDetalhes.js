let detalhes_botaoExcluir = document.querySelector("#detalhes_botaoExcluir");

detalhes_botaoExcluir.addEventListener("click", function (event) {
    event.preventDefault();
    $('#detalhes_ModalExclusao').modal('show');
});

$('#detalhes_botaoConfirmaExclusao').click(function () {
    $('form').attr('action', '/Equipamento/Remover');
    $('form').submit();
});