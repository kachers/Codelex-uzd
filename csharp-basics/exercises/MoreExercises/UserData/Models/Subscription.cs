using Newtonsoft.Json;
using UserData.Models.Enums;

namespace UserData.Models
{
    public class Subscription
    {
        public string Plan { get; set; }
        public SubscriptionStatus Status { get; set; }
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
        public SubscriptionTerm Term { get; set; }
    }
}
