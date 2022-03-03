#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        public int RegionID { get; set; }

        [Required (ErrorMessage = "Region description is required.")]
        [StringLength(50, ErrorMessage = "Region description is maximum of 50 characters.")]
        public string RegionDescription { get; set; }
    }
}
