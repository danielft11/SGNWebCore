using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Cliente : Pessoa
    {
        [DisplayName("Tipo Cliente")]
        public TipoCliente TipoCliente { get; set; }
        public string CNPJ { get; set; }

        [DisplayName("Razão Social")]
        [StringLength(300, ErrorMessage = "Este campo pode possuir no máximo 300 caracteres.")]
        public string RazaoSocial { get; set; }

        [DisplayName("Inscrição Estadual")]
        public string InscEstadual { get; set; }

        [DisplayName("Observações")]
        [StringLength(300, ErrorMessage = "Este campo pode possuir no máximo 300 caracteres.")]
        public string Observacoes { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; }

        public Cliente AtualizarCliente(Cliente model, Cliente cliente) 
        {
            cliente.Nome = model.Nome;
            cliente.CPF = model.CPF;
            cliente.RG = model.RG;
            cliente.Sexo = model.Sexo;
            cliente.CelPrincipal = model.CelPrincipal;
            cliente.Cel2 = model.Cel2;
            cliente.Telefone = model.Telefone;
            cliente.Email = model.Email;
            cliente.Endereco.Logradouro = model.Endereco.Logradouro;
            cliente.Endereco.Numero = model.Endereco.Numero;
            cliente.Endereco.Complemento = model.Endereco.Complemento;
            cliente.Endereco.Bairro = model.Endereco.Bairro;
            cliente.Endereco.Cidade = model.Endereco.Cidade;
            cliente.Endereco.Estado = model.Endereco.Estado;
            cliente.Endereco.CEP = model.Endereco.CEP;
            cliente.TipoCliente = model.TipoCliente;
            cliente.CNPJ = model.CNPJ;
            cliente.RazaoSocial = model.RazaoSocial;
            cliente.InscEstadual = model.InscEstadual;
            cliente.Observacoes = model.Observacoes;

            return cliente;
        }

    }

    public enum TipoCliente
    {
        Pessoa_Fisica,
        Pessoa_Juridica
    }

}
