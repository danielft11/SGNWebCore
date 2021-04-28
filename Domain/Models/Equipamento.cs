using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Equipamento : ModeloBase
    {
        public Equipamento()
        {

        }
        public Equipamento(IList<Cliente> clientes, IList<TipoEquipamento> tiposEquipamentos)
        {
            Clientes = clientes;
            TiposEquipamentos = tiposEquipamentos;
        }

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

        [NotMapped]
        public IList<Cliente> Clientes { get; set; }

        [NotMapped]
        public IList<TipoEquipamento> TiposEquipamentos { get; set; }

        public Equipamento AtualizarEquipamento(Equipamento model, Equipamento equipamento)
        {
            equipamento.Marca = model.Marca;
            equipamento.Modelo = model.Modelo;
            equipamento.NumSerie = model.NumSerie;
            equipamento.Descricao = model.Descricao;
            equipamento.TipoEquipamentoId = model.TipoEquipamentoId;
            equipamento.ClienteId = model.ClienteId;
            
            return equipamento;

        }
    }
}
