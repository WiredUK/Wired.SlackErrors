using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wired.SlackErrors.Module
{
    internal class Attachment
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pretext")]
        public string PreText { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; } = "#ff0000";

        [JsonProperty("mrkdwn_in")]
        public IEnumerable<string> MarkdownIn { get; set; } = new [] { "text", "pretext" };
    }
}