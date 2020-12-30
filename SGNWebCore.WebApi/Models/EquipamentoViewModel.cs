using Domain.Models;
using Domain.Models.ViewModels;
using SGNWebCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Models.ViewModels
{
    public class EquipamentosGet
    {
        public EquipamentosGet()
        {
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumSerie { get; set; }
        public string Descricao { get; set; }
        public int TipoEquipamentoId { get; set; }
        public string TipoEquipamentoNome { get; set; }
        public int? ClienteId { get; set; }
        public string ClienteNome { get; set; }

    }

    public class EquipamentosAddEdit
    {
        public EquipamentosAddEdit()
        {

        }

        public EquipamentosAddEdit(IList<ClientesGet> clientes, IList<TipoEquipamento> tiposEquipamentos)
        {
            Clientes = clientes;
            TiposEquipamentos = tiposEquipamentos;
        }

        public int Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumSerie { get; set; }

        public string Descricao { get; set; }

        public int TipoEquipamentoId { get; set; }

        [DisplayName("Tipo")]

        public string TipoEquipamentoNome { get; set; }

        public int? ClienteId { get; set; }
        [DisplayName("Cliente")]

        public string ClienteNome { get; set; }

        public IList<ClientesGet> Clientes { get; set; }

        public IList<TipoEquipamento> TiposEquipamentos { get; set; }

        public Equipamento AtualizarEquipamento(EquipamentosAddEdit model, Equipamento equipamento)
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

public static class EquipamentoViewModelExtensions
{
    public static EquipamentosGet ToEquipamentosGet(this Equipamento entity)
    {
        var equiptoGet = new EquipamentosGet();

        equiptoGet.Id = entity.Id;
        equiptoGet.Marca = entity.Marca;
        equiptoGet.Modelo = entity.Modelo;
        equiptoGet.NumSerie = entity.NumSerie;
        equiptoGet.Descricao = entity.Descricao;
        equiptoGet.TipoEquipamentoId = entity.TipoEquipamentoId;
        equiptoGet.TipoEquipamentoNome = entity.TipoEquipamento.Nome;
        
        if (entity.Cliente != null) 
        {
            equiptoGet.ClienteId = entity.Cliente.Id;
            equiptoGet.ClienteNome = entity.Cliente.Nome;
        }
        return equiptoGet;
           
    }

    public static Equipamento ToEquipamento(this EquipamentosAddEdit model)
    {
        return
            new Equipamento
            {
                Marca = model.Marca,
                Modelo = model.Modelo,
                NumSerie = model.NumSerie,
                Descricao = model.Descricao,
                TipoEquipamentoId = model.TipoEquipamentoId,
                ClienteId = model.ClienteId
            };
    }

}


