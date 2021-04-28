using System;
using System.ComponentModel;

namespace Domain.Models
{
    public abstract class ModeloBase
    {
        public int Id { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [DisplayName("Data de Alteração")]
        public DateTime DataAlteracao { get; set; } = DateTime.Now;

        public bool ShouldSerializeId() 
        {
            return true;
        }

        public bool ShouldSerializeDataCriacao() 
        {
            return false;
        }

        public bool ShouldSerializeDataAlteracao() 
        {
            return false;
        }
    }
}
