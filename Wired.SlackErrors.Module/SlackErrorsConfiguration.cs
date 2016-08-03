using System.Configuration;

namespace Wired.SlackErrors.Module
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

        [ConfigurationProperty("postUrl", IsRequired = true)]
        public string PostUrl
        {
            get { return (string)this["postUrl"]; }
            set { this["postUrl"] = value; }
        }
    }
}