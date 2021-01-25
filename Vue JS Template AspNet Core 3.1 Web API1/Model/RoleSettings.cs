namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model
{
    public class RoleSettings
    {
        public int UserId { get; set; }
        public int SettingsId { get; set; }
        public User User { get; set; }
        public Settings Settings { get; set; }
        public bool IsEnable { get; set; }
    }
}
