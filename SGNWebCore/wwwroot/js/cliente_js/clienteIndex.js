let clienteId;
let botoesArray = document.getElementsByClassName("botoes");
let index_botaoConfirmaExclusao = document.querySelector('#index_botaoConfirmaExclusao');
let infoModalTitulo = document.querySelector('#index_InfoModalTitle');
let infoModalTexto = document.querySelector('#index_InfoModalText');
let index_botaoFecharModalInformacoes = document.querySelector('#index_botaoFecharModalInformacoes');
var mr = new MessageResponse();

for (var i = 0; i < botoesArray.length; i++) {
    botoesArray[i].addEventListener('click', exibirModalExclusaoCliente, false);
}

index_botaoConfirmaExclusao.addEventListener("click", excluirClienteViaAjax);

index_botaoFecharModalInformacoes.addEventListener("click", fecharModalInformacoes);

function exibirModalExclusaoCliente() {
    clienteId = this.dataset.id;
    $('#index_ModalExclusao').modal('show');
}

function excluirClienteViaAjax() {
    $.ajax({
        url: '/Cliente/RemoverViaAjax',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(clienteId),
        success: function (data) {
            if (data.status === "00") {
                infoModalTitulo.textContent = 'Sucesso';
                infoModalTexto.textContent = data.message;
            }
            else {
                infoModalTitulo.textContent = 'Falhou';
                infoModalTexto.textContent = data.message;
            }
        },
        error: function (error) {
            infoModalTitulo.textContent = 'Falha ao ao processar a requisição.';
            infoModalTexto.textContent = 'Erro: ' + error.status.toString() + ' - ' + error.statusText.toString() + '.';
        }

    });
    $('#index_InfoModal').modal('show');
}

function fecharModalInformacoes() {
    $('#index_InfoModal').modal('hide');
    window.location.reload();
}

//outra forma de obter o clienteId
//clienteId = this.getAttribute("data-id");










