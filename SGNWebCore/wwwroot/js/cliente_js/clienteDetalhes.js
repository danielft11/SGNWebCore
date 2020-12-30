let equipamentoId;
let clienteId;
let marca;
let modelo;
let numSerie;
let descricao;
let tipoEquipamentoId;
let tipoEquipamentoNome;
let opcao;

let botoesDetalhesArray = document.getElementsByClassName("botoesDetalhes");
let botoesExcluirArray = document.getElementsByClassName("botoesExcluir");

for (var i = 0; i < botoesDetalhesArray.length; i++) {
    botoesDetalhesArray[i].addEventListener('click', modalDetalhesEquipto, false);
}

for (var j = 0; j < botoesExcluirArray.length; j++) {
    botoesExcluirArray[j].addEventListener('click', modalExclusaoEquipto, false);
}

function novoEquipamento(opc) {
    event.preventDefault();

    opcao = opc;

    limparCampos();

    $('#detalhes_ModalEquipamento').modal('show');

    $.ajax({
        type: "Get",
        url: '/TiposEquipamentos/GetTiposEquipamentosAjax',
        success: function (data) {
            $("#tipoEquipamento").empty();
            $("#tipoEquipamento").append('<option value>Selecione...</option>');
            $.each(data, function (id, option) {
                $("#tipoEquipamento").append('<option value="' + option.id + '">' + option.nome + '</option>');
            });

        },
        error: function (error) {
            alert(error.statusText);
        }
    });
}

function modalExclusaoCliente() {
    event.preventDefault();

    $('#detalhes_ModalExclusao').modal('show');
}

function excluirCliente() {
    event.preventDefault();

    $('form').attr('action', '/Cliente/Remover');
    $('form').submit();
}

function modalExclusaoEquipto() {
    event.preventDefault();
    equipamentoId = this.dataset.id;
    $('#modalExclusaoEquipamento').modal('show');
}

function modalDetalhesEquipto() {
    event.preventDefault();

    opcao = this.dataset.opcao;
    console.log(opcao);
    
    limparCampos();

    equipamentoId = this.dataset.id;
    marca = this.dataset.marca;
    modelo = this.dataset.modelo;
    numSerie = this.dataset.ns;
    descricao = this.dataset.descricao;
    tipoEquipamentoId = this.dataset.tipoequipamentoid;
    tipoEquipamentoNome = this.dataset.tipoequipamentonome;

    $('#marca').val(marca);
    $('#modelo').val(modelo);
    $('#numSerie').val(numSerie);
    $('#descricao').val(descricao);
    $("#tipoEquipamento").append('<option value="' + tipoEquipamentoId + '">' + tipoEquipamentoNome + '</option>');

    $('#detalhes_ModalEquipamento').modal('show');

}

function salvarEquipamento() {
    event.preventDefault();

    var equipamento;

    marca = $('#marca').val();
    modelo = $('#modelo').val();
    numSerie = $('#numSerie').val();
    descricao = $('#descricao').val();
    tipoEquipamentoId = $("#tipoEquipamento").val();
    clienteId = $('#Id').val();

    if (opcao === "inclusao") {

        equipamento = {
            Marca: marca,
            Modelo: modelo,
            NumSerie: numSerie,
            Descricao: descricao,
            TipoEquipamentoId: tipoEquipamentoId,
            ClienteId: clienteId
        };

        $.ajax({
            type: 'Post',
            url: '/Equipamento/NovoEquipamentoAjax',
            contentType: 'application/json',
            data: JSON.stringify(equipamento),

            success: function (response) {
                if (response.status === "00")
                    window.location.reload();
                else
                    alert(response.message);
            },
            error: function (error) {
                alert(error.statusText);
            }

        });
    }
    if (opcao === "edicao") {

        equipamento = {
            Id: equipamentoId,
            Marca: marca,
            Modelo: modelo,
            NumSerie: numSerie,
            Descricao: descricao,
            TipoEquipamentoId: tipoEquipamentoId,
            ClienteId: clienteId
        };

        $.ajax({
            type: 'Post',
            url: '/Equipamento/AtualizarEquipamentoAjax',
            contentType: 'application/json',
            data: JSON.stringify(equipamento),

            success: function (response) {
                if (response.status === "00")
                    window.location.reload();
                else
                    alert(response.message);
            },
            error: function (error) {
                alert(error.statusText);
            }

        });
    }
   
}

function excluirEquipamento() {
    event.preventDefault();
    $.ajax({
        type: 'Post',
        url: '/Equipamento/RemoverViaAjax',
        contentType: 'application/json',
        data: JSON.stringify(equipamentoId),
        success: function (response) {
            alert(response.message);
            window.location.reload();

        },
        error: function (error) {
            alert(error.statusText);
        }

    });
}

function limparCampos() {
    $('#marca').val("");
    $('#modelo').val("");
    $('#numSerie').val("");
    $('#descricao').val("");
    $("#tipoEquipamento").empty();
}




