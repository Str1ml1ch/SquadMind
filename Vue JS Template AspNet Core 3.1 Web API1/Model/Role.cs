using System.Collections.Generic;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
