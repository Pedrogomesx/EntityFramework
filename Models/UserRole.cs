using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{

    public class UserRole
    {
        [ForeignKey("PostId")] public int UserId { get; set; }

        [ForeignKey("PostId")] public int RoleId { get; set; }
    }
}
