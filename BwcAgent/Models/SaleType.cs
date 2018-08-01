using BwcAgent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BwcAgent.Models
{
    public class SaleType
    {
        public SaleType(SaleTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public SaleType()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal BaseCommission { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Target { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TargetPeriod { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal IncreaseIfTargetMet { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Maximum { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal RestToBase { get; set; }
    }
}
