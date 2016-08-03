using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wired.SlackErrors.Module
{
    internal class Message
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; } = "Website Errors";

        [JsonProperty("attachments")]
        public IEnumerable<Attachment> Attachments { get; set; }
    }
}