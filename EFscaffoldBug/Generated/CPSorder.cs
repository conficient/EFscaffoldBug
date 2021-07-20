using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestDB
{
    public partial class CPSorder
    {
        [Key]
        public int CPSorderID { get; set; }
        public int? CPSchargePartnerID { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal? CPSChargePartner { get; set; }

        [ForeignKey(nameof(CPSchargePartnerID))]
        [InverseProperty(nameof(Partner.CPSorders))]
        public virtual Partner CPSchargePartner { get; set; }
    }
}
