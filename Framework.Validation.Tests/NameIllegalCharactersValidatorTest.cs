using System;
using System.Linq;
using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Validation.Tests
{

    [TestFixture()]
    public class NameIllegalCharactersValidatorTest
    {

        [Test()]
        public void IllegalNameBeginningWithAlpha()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "&Name";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }


        [Test()]
        public void ValidName()
        {
            var validator = new NameIllegalCharactersValidator();
            const string ValidName = "Name";

            ValidationResults r = validator.Validate(ValidName);

            Assert.IsTrue(r.IsValid);
        }

        [Test()]
        public void IllegalNameEndingWithAlpha()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "Name&";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void IllegalNameBeginingWithDoubleSpace()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "  Name";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void IllegalNameBeginingWithSpace()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = " Name";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void IllegalNameEndingWithSpace()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "Name ";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void IllegalNameConsecutiveSpace()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "Name  me";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }


        [Test()]
        public void IllegalNameBegininingWithSlash()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "/Easter Bunny international";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void IllegalNameEndingWithslash()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "Easter Bunny international/";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsFalse(r.IsValid);
        }

        [Test()]
        public void ValidNameWithslash()
        {

            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator();
            const string invalidstring = "Easter Bunny/international";


            ValidationResults r = validator.Validate(invalidstring);


            Assert.IsTrue(r.IsValid);
        }

        [Test]
        public void Validate_MessageTemplate_ReturnsCustomMessage()
        {
            const string invalidString = "Easter Bunny    International";
            string customTemplate = "My custom message about my Name '{0}'.";
            NameIllegalCharactersValidator validator = new NameIllegalCharactersValidator(customTemplate);

            var r = validator.Validate(invalidString);
            Assert.IsFalse(r.IsValid);

            string actualMessage = r.Single(x => (x.Validator) is NameIllegalCharactersValidator).Message;
            Assert.AreEqual(string.Format(customTemplate, invalidString), actualMessage, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}