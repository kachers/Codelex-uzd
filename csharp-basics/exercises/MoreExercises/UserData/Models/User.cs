using Newtonsoft.Json;
using UserData.Models.Enums;

namespace UserData.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Password { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Gender Gender { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("social_insurance_number")]
        public string SocialInsuranceNumber { get; set; }
        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        public Employment Employment { get; set; }
        public Address Address { get; set; }
        [JsonProperty("credit_card")]
        public CreditCard CreditCard { get; set; }
        public Subscription Subscription { get; set; }
    }
}
