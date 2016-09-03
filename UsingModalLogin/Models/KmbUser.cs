using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingModalLogin.Models
{
    [Table("KmbUsersTable")]
    public partial class KmbUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(25, ErrorMessage = "Max. 25 characters."), DisplayName("Name")]
        public string Name { get; set; }

        [StringLength(25, ErrorMessage = "Max. 25 characters."), DisplayName("Surname")]
        public string Surname { get; set; }

        [StringLength(60, ErrorMessage = "Max. 60 characters."),Required(ErrorMessage ="E-Posta boş geçilemez."), DisplayName("E-Mail")]
        public string Email { get; set; }

        [StringLength(25, ErrorMessage = "Max. 25 characters."), Required(ErrorMessage ="Kullanıcı adı boş geçilemez."), DisplayName("Username")]
        public string Username { get; set; }

        [StringLength(25, ErrorMessage = "Max. 25 characters."), Required(ErrorMessage = "Şifre adı boş geçilemez."), DisplayName("Password")]
        public string Password { get; set; }
    }
}
