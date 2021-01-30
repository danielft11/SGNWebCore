using Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGNWebCore.WebApi.Models
{
    public class ClientesGet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Sexo { get; set; }

        [JsonProperty(PropertyName = "Celular principal")]
        public string CelPrincipal { get; set; }

        [JsonProperty(PropertyName = "Celular alternativo")]
        public string Cel2 { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public TipoCliente TipoCliente { get; set; }
        public string CNPJ { get; set; }

        [JsonProperty(PropertyName = "Razao Social")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "Inscricao Estadual")]
        public string InscEstadual { get; set; }

    }

    public class ClienteAddEdit : Pessoa
    {
        [DisplayName("Tipo Cliente")]
        public TipoCliente TipoCliente { get; set; }
        public string CNPJ { get; set; }

        [StringLength(300, ErrorMessage = "Este campo pode possuir no máximo 300 caracteres.")]

        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [DisplayName("Inscrição Estadual")]
        public string InscEstadual { get; set; }

        [StringLength(300, ErrorMessage = "Este campo pode possuir no máximo 300 caracteres.")]

        [DisplayName("Observações")]
        public string Observacoes { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; }

        public Cliente AtualizarCliente(ClienteAddEdit model, Cliente cliente)
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

    public static class ClientesModelExtensions
    {
        public static ClientesGet ToClienteGet(this Cliente cliente)
        {
            return
               new ClientesGet
               {
                   Id = cliente.Id,
                   Nome = cliente.Nome,
                   CPF = cliente.CPF,
                   RG = cliente.RG,
                   Sexo = cliente.Sexo,
                   CelPrincipal = cliente.CelPrincipal,
                   Cel2 = cliente.Cel2,
                   Telefone = cliente.Telefone,
                   Email = cliente.Email,
                   Endereco = cliente.Endereco,
                   CNPJ = cliente.CNPJ,
                   RazaoSocial = cliente.RazaoSocial,
                   InscEstadual = cliente.InscEstadual
               };
        }

        public static Cliente ToCliente(this ClienteAddEdit clienteAddEdit)
        {
            Cliente cliente = new Cliente();

            cliente.Endereco = new Endereco();

            cliente.Nome = clienteAddEdit.Nome;
            cliente.CPF = clienteAddEdit.CPF;
            cliente.RG = clienteAddEdit.RG;
            cliente.Sexo = clienteAddEdit.Sexo;
            cliente.CelPrincipal = clienteAddEdit.CelPrincipal;
            cliente.Cel2 = clienteAddEdit.Cel2;
            cliente.Telefone = clienteAddEdit.Telefone;
            cliente.Email = clienteAddEdit.Email;
            cliente.Endereco.Logradouro = clienteAddEdit.Endereco.Logradouro;
            cliente.Endereco.Numero = clienteAddEdit.Endereco.Numero;
            cliente.Endereco.Complemento = clienteAddEdit.Endereco.Complemento;
            cliente.Endereco.Bairro = clienteAddEdit.Endereco.Bairro;
            cliente.Endereco.Cidade = clienteAddEdit.Endereco.Cidade;
            cliente.Endereco.Estado = clienteAddEdit.Endereco.Estado;
            cliente.Endereco.CEP = clienteAddEdit.Endereco.CEP;
            cliente.TipoCliente = clienteAddEdit.TipoCliente;
            cliente.CNPJ = clienteAddEdit.CNPJ;
            cliente.RazaoSocial = clienteAddEdit.RazaoSocial;
            cliente.InscEstadual = clienteAddEdit.InscEstadual;
            cliente.Observacoes = clienteAddEdit.Observacoes;

            return cliente;
        }

    }

}
