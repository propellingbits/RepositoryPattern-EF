using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Validation.Tests
{

    [TestFixture(), Parallelizable()]
    public class CityIllegalCharactersValidatorTest
    {

        [Test()]
        public void IllegalCityNameBeginningWithInvalidAlpha()
        {

            CityIllegalCharactersValidator validator = new CityIllegalCharactersValidator();
            const string invalidstring = "&CityName";

            ValidationResults r = validator.Validate(invalidstring);

            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void IllegalCityNameContainsInvalidCharacters()
        {

            CityIllegalCharactersValidator validator = new CityIllegalCharactersValidator();
            const string invalidstring = "City-Name";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]

        public void IllegalCityNameContainsValidCharacters()
        {

            CityIllegalCharactersValidator validator = new CityIllegalCharactersValidator();
            const string invalidstring = "Name";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsTrue(r.IsValid);
        }

        [Test()]

        public void IllegalCityNameBeginningWithSpace()
        {

            CityIllegalCharactersValidator validator = new CityIllegalCharactersValidator();
            const string invalidstring = " Hoboken";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]

        public void IllegalCityNameWithConsecutiveSpace()
        {

            CityIllegalCharactersValidator validator = new CityIllegalCharactersValidator();
            const string invalidstring = "City  Name";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

    }
}