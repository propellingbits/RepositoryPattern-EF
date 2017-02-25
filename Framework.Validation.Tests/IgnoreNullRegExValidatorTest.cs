using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Validation.Tests
{

    [TestFixture(), Parallelizable()]
    public class IgnoreNullRegExValidatorTest
    {
        [Test(), Author("Ranju")]

        public void NullFaxNumber_RegEx_Isvalid()
        {

            IgnoreNullRegexValidator validator = new IgnoreNullRegexValidator("^\\s*-?\\s*(\\d{3}|\\(\\s*\\d{3}\\s*\\))\\s*-?\\s*\\d{3}\\s*-?\\s*\\d{4}$");
            const string invalidstring = "";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsTrue(r.IsValid);
        }

        [Test(), Author("Ranju")]

        public void FaxNumber_RegEx_Isvalid()
        {

            IgnoreNullRegexValidator validator = new IgnoreNullRegexValidator("^\\s*-?\\s*(\\d{3}|\\(\\s*\\d{3}\\s*\\))\\s*-?\\s*\\d{3}\\s*-?\\s*\\d{4}$");
            const string invalidstring = "7175625689";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsTrue(r.IsValid);
        }

        [Test(), Author("Ranju")]

        public void FaxNumber_RegEx_IsInvalid()
        {

            IgnoreNullRegexValidator validator = new IgnoreNullRegexValidator("^\\s*-?\\s*(\\d{3}|\\(\\s*\\d{3}\\s*\\))\\s*-?\\s*\\d{3}\\s*-?\\s*\\d{4}$");
            const string invalidstring = "77175625689";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test(), Author("Ranju")]

        public void FaxNumberMoreThan10_RegEx_IsInvalid()
        {

            IgnoreNullRegexValidator validator = new IgnoreNullRegexValidator("^\\s*-?\\s*(\\d{3}|\\(\\s*\\d{3}\\s*\\))\\s*-?\\s*\\d{3}\\s*-?\\s*\\d{4}$");
            const string invalidstring = "18009088998";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test(), Author("Ranju")]

        public void FaxNumber10_RegEx_Isvalid()
        {

            IgnoreNullRegexValidator validator = new IgnoreNullRegexValidator("^\\s*-?\\s*(\\d{3}|\\(\\s*\\d{3}\\s*\\))\\s*-?\\s*\\d{3}\\s*-?\\s*\\d{4}$");
            const string invalidstring = "8009088998";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsTrue(r.IsValid);
        }



    }
}