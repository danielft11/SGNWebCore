let clienteId = document.querySelector("#hiddenFieldClienteId");
let nomeCliente = document.querySelector("#nomeCliente");
let botaoBuscarCliente = document.querySelector("#btnBuscaCliente");
let arrayBotoesDeSelecao = document.getElementsByClassName("botoesDeSelecao");

botaoBuscarCliente.addEventListener("click", function (event) {
    event.preventDefault();
    $('#clientesModal').modal('show');
});

for (var i = 0; i < arrayBotoesDeSelecao.length; i++) {
    arrayBotoesDeSelecao[i].addEventListener('click', retornarDadosDoClienteSelecionado, false);
}

function retornarDadosDoClienteSelecionado() {
    event.preventDefault();
    clienteId.value = this.dataset.id;
    nomeCliente.value = this.dataset.nome;
    $('#clientesModal').modal('hide');
}

