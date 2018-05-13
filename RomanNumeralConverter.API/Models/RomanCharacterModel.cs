using System.Runtime.Serialization;

namespace RomanNumeralConverter.API.Models
{
    [DataContract(Name = "Roman_Character")]
    public class RomanCharacterModel
    {
        /// <summary>
        /// The generated string of roman character generated from decimal numbers
        /// </summary>
        [DataMember(Name = "Roman_String", Order = 0, EmitDefaultValue = false)]
        public string RomanString { get; set; }
    }
}