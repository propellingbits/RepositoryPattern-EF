using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;


[assembly: DegreeOfParallelism(4)]

namespace Validation.Tests
{

    [TestFixture(), Parallelizable()]
    public class AddressIllegalCharactersValidatorTest
    {

        [Test(), Author("Ranju")]
        public void IllegalAddressBeginningWithInvalidAlpha()
        {
            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "&Addressline1";

            ValidationResults r = validator.Validate(invalidstring);

            Assert.IsFalse(r.IsValid);
        }


        [Test(), Author("Ranju")]
        public void Validaddress()
        {
            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "AddressLine1 # And";

            ValidationResults r = validator.Validate(invalidstring);

            Assert.IsTrue(r.IsValid);
        }

        [Test(), Author("Ranju")]
        public void ValidForwardSlashAddress()
        {
            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "AddressLine1/and";

            ValidationResults r = validator.Validate(invalidstring);

            Assert.IsTrue(r.IsValid);
        }

        [Test(), Author("Ranju")]
        public void ValidHyphenAddress()
        {
            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "AddressLine1-and";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsTrue(r.IsValid);
        }

        [Test(), Author("Ranju")]
        public void InvalidValidHyphenAddress()
        {
            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "AddressLine1 - and";

            ValidationResults r = validator.Validate(invalidstring);

            Assert.IsFalse(r.IsValid);
        }


        [Test(), Author("Ranju")]
        public void IllegalAddressEndingWithAlpha()
        {

            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "Addressline1&";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test(), Author("Ranju")]
        public void IllegalAddressBeginingWithDoubleSpace()
        {
            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "  Addressline1";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test(), Author("Ranju")]
        public void IllegalAddressBeginingWithSpace()
        {

            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = " Addressline1";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }



        [Test(), Author("Ranju")]
        public void IllegalAddressConsecutiveSpace()
        {

            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "127  East";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }


        [Test(), Author("Ranju")]
        public void IllegalAddressWithInValidCharacter()
        {

            AddressIllegalCharactersValidator validator = new AddressIllegalCharactersValidator();
            const string invalidstring = "Easter Bunny's international";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

    }
}