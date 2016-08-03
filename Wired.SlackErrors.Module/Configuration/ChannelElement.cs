using System.Configuration;

namespace Wired.SlackErrors.Module.Configuration
{
    public class ChannelElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("postUrl", IsRequired = true)]
        public string PostUrl
        {
            get { return (string)this["postUrl"]; }
            set { this["postUrl"] = value; }
        }

        [ConfigurationProperty("typeFilter", IsRequired = false)]
        public string TypeFilter
        {
            get { return (string)this["typeFilter"]; }
            set { this["typeFilter"] = value; }
        }

        [ConfigurationProperty("traceFilter", IsRequired = false)]
        public string TraceFilter
        {
            get { return (string)this["traceFilter"]; }
            set { this["traceFilter"] = value; }
        }
    }
}