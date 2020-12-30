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

    }

    public enum TipoCliente
    {
        Pessoa_Fisica,
        Pessoa_Juridica
    }

}
