using System.Configuration;

namespace Wired.SlackErrors.Module.Configuration
{
    public class ChannelElementCollection : ConfigurationElementCollection
    {
        public ChannelElement this[int index]
        {
            get { return (ChannelElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ChannelElement moduleElement)
        {
            BaseAdd(moduleElement);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ChannelElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ChannelElement)element).Name;
        }

        public void Remove(ChannelElement serviceConfig)
        {
            BaseRemove(serviceConfig.Name);
        }
    }
}