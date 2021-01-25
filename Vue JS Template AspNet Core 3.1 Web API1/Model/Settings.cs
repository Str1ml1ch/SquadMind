using System.Collections.Generic;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model
{
    public class Settings
    {
        public int SettingsId { get; set; }
        public string SettingsName { get; set; }
        public ICollection<RoleSettings> RoleSettingses { get; set; }
    }
}
