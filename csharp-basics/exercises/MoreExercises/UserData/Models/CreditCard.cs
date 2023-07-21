using Newtonsoft.Json;

namespace UserData.Models
{
    public class CreditCard
    {
        [JsonProperty("cc_number")]
        public string CcNumber { get; set; }
    }
}