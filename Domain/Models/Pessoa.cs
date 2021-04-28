using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public abstract class Pessoa : ModeloBase
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public string Sexo { get; set; }

        [DisplayName("Celular Principal")]
        public string CelPrincipal { get; set; }

        [DisplayName("Celular 2")]
        public string Cel2 { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("E-mail")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        public bool ShouldSerializeEnderecoId()
        {
            return false;
        }

    }
}
