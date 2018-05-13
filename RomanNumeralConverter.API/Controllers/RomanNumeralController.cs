using RomanNumeralConverter.API.Models;
using System.Web.Http;

namespace RomanNumeralConverter.API.Controllers
{
    public class RomanNumeralController : ApiController
    {
        /// <summary>
        /// Gets the roman characters from a decimal number
        /// </summary>
        /// <param name="number">a number of the decimal system</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api2/RomanNumeral/GetRomanNumeral/{number:int}", Name = "GetRomanNumeral", Order = 0)]
        //[Route("test/{number:int}", Name = "GetRomanNumeral", Order = 0)]
        public RomanCharacterModel Get(int number)
        {
            return CreateRomanCharacter(number);
        }

        public RomanCharacterModel CreateRomanCharacter(int number)
        {
            var romanCharacter = new RomanCharacterModel()
            {
                RomanString = ConvertBySubtraction.Convert(number)
            };
            return romanCharacter;
        }
    }
}