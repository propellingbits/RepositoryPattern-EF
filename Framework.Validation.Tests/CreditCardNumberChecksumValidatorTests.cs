using System;
using System.Linq;
using Framework.Validation.Validators;
using MbUnit.Framework;

namespace Validation.Tests
{

    [TestFixture(), Parallelizable()]
    public class CreditCardNumberChecksumValidatorTests
    {

        [Test()]

        public void CheckDigitIsValid_ValidNumber_ReturnsTrue()
        {
            const string validNumber = "49927398716";
            Assert.IsTrue(CreditCardNumberChecksumValidator_Accessor.CheckDigitIsValid(validNumber));
        }

        [Test()]
        [Row("49927398716")]
        public void CheckDigitIsValid_ValidatedNumbers_ReturnsTrue(string number)
        {
            Assert.IsTrue(CreditCardNumberChecksumValidator_Accessor.CheckDigitIsValid(number));
        }

        [Test()]
        public void CheckDigitIsValid_InvalidNumber_ReturnsFalse()
        {
            const string invalidNumber = "1234567890";
            Assert.IsFalse(CreditCardNumberChecksumValidator_Accessor.CheckDigitIsValid(invalidNumber));

        }

        [Test()]
        public void Validate_NoMessageTemplate_ReturnsDefaultMessage()
        {
            const string invalidNumber = "1234567890";
            CreditCardNumberChecksumValidator validator = new CreditCardNumberChecksumValidator();


            var validationResults = validator.Validate(invalidNumber);


            Assert.IsTrue(validationResults.Count == 1);
            Assert.IsFalse(validationResults.IsValid);

            string actualMessage = validationResults.Single(x => (x.Validator) is CreditCardNumberChecksumValidator).Message;
            Assert.AreEqual(string.Format("NPI number '{0}' does not have valid check digit.", invalidNumber), actualMessage, StringComparison.InvariantCultureIgnoreCase);

        }

        [Test()]
        public void Validate_MessageTemplate_ReturnsCustomMessage()
        {
            const string invalidNumber = "1234567890";
            string customTemplate = "My custom message about my NPI number '{0}'.";
            CreditCardNumberChecksumValidator validator = new CreditCardNumberChecksumValidator(customTemplate);


            var validationResults = validator.Validate(invalidNumber);


            Assert.IsTrue(validationResults.Count == 1);
            Assert.IsFalse(validationResults.IsValid);
            string actualMessage = validationResults.Single(x => (x.Validator) is CreditCardNumberChecksumValidator).Message;
            Assert.AreEqual(string.Format(customTemplate, invalidNumber), actualMessage, StringComparison.InvariantCultureIgnoreCase);

        }

    }
}