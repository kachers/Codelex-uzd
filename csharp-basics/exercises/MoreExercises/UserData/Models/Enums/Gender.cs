using System.Runtime.Serialization;

namespace UserData.Models.Enums
{
    public enum Gender
    {
        Male,
        Female,
        Agender,
        Polygender,
        Genderfluid,
        Bigender,
        Genderqueer,
        [EnumMember(Value = "Non-binary")]
        NonBinary
    }
}
