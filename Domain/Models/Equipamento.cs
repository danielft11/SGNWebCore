using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Equipamento : ModeloBase
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [DisplayName("Número de Série")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string NumSerie { get; set; }

        [DisplayName("Descrição")]
        [StringLength(100, ErrorMessage = "Este campo pode possuir no máximo 100 caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Tipo")]
        public int TipoEquipamentoId { get; set; }
 
        public TipoEquipamento TipoEquipamento { get; set; }

        public int? ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
