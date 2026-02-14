using System.ComponentModel.DataAnnotations;

namespace ELKH.ViewModels
{
    public class AssignRoleVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        public string RoleName { get; set; }

        public List<RoleVM> Roles { get; set; }
    }

}
