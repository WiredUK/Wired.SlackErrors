using System.Configuration;

namespace Wired.SlackErrors.Module.Configuration
{
    public class SlackErrorsConfiguration : ConfigurationSection
    {
        public static readonly SlackErrorsConfiguration Settings =
            ConfigurationManager.GetSection("slackErrors") as SlackErrorsConfiguration ?? new SlackErrorsConfiguration();

        [ConfigurationProperty("appName", IsRequired = false)]
        public string ApplicationName
        {
            get
            {
                var appName = (string)this["appName"];
                return string.IsNullOrEmpty(appName) ? "Default Application" : appName;
            }
            set { this["appName"] = value; }
        }

        [ConfigurationProperty("channels", IsDefaultCollection = false, IsRequired = false)]
        [ConfigurationCollection(typeof(ChannelElementCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ChannelElementCollection Channels => (ChannelElementCollection) base["channels"];
    }
}