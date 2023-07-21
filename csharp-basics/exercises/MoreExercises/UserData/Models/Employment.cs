using Newtonsoft.Json;

namespace UserData.Models
{
    public class Employment
    {
        public string Title { get; set; }
        [JsonProperty("key_skill")]
        public string KeySkill { get; set; }
    }
}