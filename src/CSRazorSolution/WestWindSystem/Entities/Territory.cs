﻿#nullable disable
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
    [Table("Territories")]
    public class Territory
    {
        //Need to put in values, this key in DB is not an identity.
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Territory ID is required and limited to 20 characters.")]
        public string TerritoryID { get; set; }

        [Required(ErrorMessage = "Territory description is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Territory description is required and limited to 50 characters.")]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }
    }
}
