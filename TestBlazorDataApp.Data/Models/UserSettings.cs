using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace TestBlazorDataApp.Data
{
    public class UserSettings : Entity
    {
        [Required]
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }


        [Required]
        public virtual User User { get; set; }
    }

    public partial class Configurator
    {
        public void UserSettings()
        {
        }
    }
}