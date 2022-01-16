using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.Common.Models
{
    [Table("sys_user_info")]
    public class SysUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("id")]
        public int id { get; set; }
        //[Column("user_name")]
        public string UserName { get; set; }
        //[Column("password")]
        public string Password { get; set; }
        //[Column("user_icon")]
        public string UserIcon { get; set; }
        //[Column("real_name")]
        public string RealName { get; set; }

        [NotMapped]
        public List<MenuInfo> Menus { get; set; }
    }
}
