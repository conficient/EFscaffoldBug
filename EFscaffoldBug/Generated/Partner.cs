using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestDB
{
    public partial class Partner
    {
        public Partner()
        {
            CPSorders = new HashSet<CPSorder>();
        }

        [Key]
        public int PartnerID { get; set; }
        [StringLength(64)]
        public string PartnerName { get; set; }

        [InverseProperty(nameof(CPSorder.CPSchargePartner))]
        public virtual ICollection<CPSorder> CPSorders { get; set; }
    }
}
