let equipamentoId;
let botoesArray = document.getElementsByClassName("botoes");
let index_botaoConfirmaExclusao = document.querySelector('#index_botaoConfirmaExclusao');
let infoModalTitulo = document.querySelector('#index_InfoModalTitle');
let infoModalTexto = document.querySelector('#index_InfoModalText');
let index_botaoFecharModalInformacoes = document.querySelector('#index_botaoFecharModalInformacoes');

for (var i = 0; i < botoesArray.length; i++) {
    botoesArray[i].addEventListener('click', passarIdEquipamentoParaExclusao, false);
}

index_botaoConfirmaExclusao.addEventListener("click", function () {
    $.ajax({
        url: '/Equipamento/RemoverViaAjax',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(equipamentoId),
        success: function (data) {
            if (data.status === "00") {
                $('#index_InfoModal').modal('show');
                infoModalTitulo.textContent = 'Sucesso';
                infoModalTexto.textContent = data.message;
            }
            else {
                $('#index_InfoModal').modal('show');
                infoModalTitulo.textContent = 'Falhou';
                infoModalTexto.textContent = data.message;
            }
        },
        error: function (error) {
            infoModalTitulo.textContent = 'Falha ao ao processar a requisição.';
            infoModalTexto.textContent = 'Erro: ' + error.status.toString() + ' - ' + error.statusText.toString() + '.';
            $('#index_InfoModal').modal('show');

        }

    });
});

index_botaoFecharModalInformacoes.addEventListener("click", function () {
    $('#index_InfoModal').modal('hide');
    window.location.reload();
});

function passarIdEquipamentoParaExclusao() {
    equipamentoId = this.dataset.id;
    $('#index_ModalExclusao').modal('show');
}