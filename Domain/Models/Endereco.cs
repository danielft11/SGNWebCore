using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Endereco : ModeloBase
    {
        [DisplayName("Logradouro")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(6, ErrorMessage = "Este campo pode possuir no máximo 6 caracteres.")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        [StringLength(50, ErrorMessage = "Este campo pode possuir no máximo 50 caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Este campo pode possuir no máximo 20 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(40, ErrorMessage = "Este campo pode possuir no máximo 40 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(2, ErrorMessage = "Este campo pode possuir no máximo 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string CEP { get; set; } 
    }

}
