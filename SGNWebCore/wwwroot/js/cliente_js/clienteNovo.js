//Script para validar CEP. Referência: https://viacep.com.br/exemplo/jquery/
$(document).ready(function () {

    function Limpa_Endereco() {
        $("#logradouro").val("");
        $("#bairro").val("");
        $("#cidade").val("");
        $("#estado").val("");
        $("#numero").val("");
        $("#complemento").val("");
    }

    //Quando o campo CEP perde o foco.
    $('#CEP').blur(function () {
        var cep = $('#CEP').val().replace(/\D/g, ''); //remoção dos dígitos do campo CEP.
        var url = "//viacep.com.br/ws/" + cep + "/json/?callback=?";

        if (cep !== "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida se o formato do CEP está de acordo com a expressão regular.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#logradouro").val("...");
                $("#bairro").val("...");
                $("#cidade").val("...");
                $("#estado").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON(url, function (dados) {
                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#logradouro").val(dados.logradouro);
                        $("#bairro").val(dados.bairro);
                        $("#cidade").val(dados.localidade);
                        $("#estado").val(dados.uf);
                    }
                    else {
                        //CEP pesquisado não foi encontrado.
                        Limpa_Endereco();
                        alert("CEP não encontrado.");
                    }
                });
            }
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            Limpa_Endereco();
        }
    });
});