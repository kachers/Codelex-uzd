using System.Runtime.Serialization;

namespace UserData.Models.Enums
{
    public enum SubscriptionTerm
    {
        Annual,
        [EnumMember(Value = "Payment in advance")]
        PaymentInAdvance,
        Monthly,
        [EnumMember(Value = "Full Subscription")]
        FullSubscription
    }
}
