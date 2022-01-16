using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Common.Models
{
    [Table("roles")]
    public class RoleInfo
    {
        [Key]
        [Column("role_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Column("role_name")]
        public string RoleName { get; set; }

        [Column("state")]
        [DefaultValue(1)]
        public int State { get; set; }

    }
}
