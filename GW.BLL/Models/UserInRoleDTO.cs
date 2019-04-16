using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.BLL.Models
{
    public class UserInRoleDTO
    {
        [Key]
        public int UserInRoleId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(128)]
        public string RoleName { get; set; }
    }
}
