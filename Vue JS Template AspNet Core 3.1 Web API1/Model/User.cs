using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Signature { get; set; }
        public string Image { get; set; }
        public int RoleIdenty { get; set; }
        [ForeignKey("RoleIdenty")]
        public Role Role { get; set; }
        public ICollection<RoleSettings> RoleSettingses { get; set; }
    }
}
