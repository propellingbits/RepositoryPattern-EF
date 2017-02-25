using System;
using System.Linq;
using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Configuration;


namespace Validation.Tests
{

    /// <summary>
    ///This is a test class for SsnValidatorTest and is intended
    ///to contain all SsnValidatorTest Unit Tests
    ///</summary>
    [TestFixture()]
    public class SsnValidatorTest
    {

        /// <summary>
        /// To verify ValidatorFormatException.
        /// </summary>
        [Test()]
        public void SsnValidatorFormatException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.FormatInvalid };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "\'123-DE-ASDF\': SSN format is not valid.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }

        /// <summary>
        /// To verify area number.
        /// </summary>
        [Test()]
        public void SsnValidatorAreaNumberException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.AreaNumberInvalid };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "'666-01-1111': The SSN area number '666' is not valid.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }


        /// <summary>
        /// To verify ssn group number
        /// </summary>
        [Test()]
        public void SsnValidatorGroupNumberException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.InvalidGroupAndSerialNumber };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "\'691-02-0000\': The SSN group number \'02\' is not valid.\r\n\'691-02-0000\': The SSN serial number \'0000\' is not valid.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }

        /// <summary>
        /// To verify ssn serial number.
        /// </summary>
        [Test()]
        public void SsnValidatorSerialNumberException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.SerialNumberInvalid };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "\'121-01-0000\': The SSN serial number \'0000\' is not valid.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }



        /// <summary>
        /// ShouldThrowSerialNumberAndAreaNumberException
        /// </summary>
        [Test()]
        public void SsnValidatorShouldThrowSerialNumberAndAreaNumberException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.InvalidAreaAndSerialNumber };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "\'666-01-0000\': The SSN area number \'666\' is not valid.\r\n\'666-01-0000\': The SSN serial number \'0000\' is not valid.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }

        /// <summary>
        /// ShouldThrowSerialNumberAndGroupNumberException
        /// </summary>
        [Test()]
        public void SsnValidatorShouldThrowSerialNumberAndGroupNumberException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.InvalidGroupAndSerialNumber };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "\'691-02-0000\': The SSN group number \'02\' is not valid.\r\n\'691-02-0000\': The SSN serial number \'0000\' is not valid.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }


        /// <summary>
        /// To verify InvalidatedBySsaException
        /// </summary>
        [Test()]
        public void SsnValidatorInvalidatedBySsaException()
        {
            var ssnValidator = new SsnValidator();
            var testObject = new SsnTestObject() { Ssn = TestSsn.InvalidatedBySsa };

            ValidationResults validationRslts = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObject);
            Assert.AreEqual(1, validationRslts.Count);

            ValidationResult result = validationRslts.SingleOrDefault((x) => x.Key == "Ssn" && x.Validator.GetType() == typeof(SsnValidator));
            if (result == null) Assert.Fail("Expected an SsnValidator on property 'Ssn' but did not get one.");

            string expectedMessage = "\'078-05-1120\': The Social Security Administration invalidated this SSN.\r\n";
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [Test()]
        public void Validate_NoMessageTemplate_ReturnsDefaultMessage()
        {
            const string invalidNumber = "1234567890";
            var validator = new SsnValidator();

            var validationResults = validator.Validate(invalidNumber);

            Assert.IsTrue(validationResults.Count == 1);
            Assert.IsFalse(validationResults.IsValid);

            string actualMessage = validationResults.Single(x => (x.Validator) is SsnValidator).Message;
            Assert.AreEqual(string.Format("'{0}': SSN format is not valid.\r\n", invalidNumber), 
                actualMessage, StringComparison.InvariantCultureIgnoreCase);

        }

        [Test()]
        public void Validate_MessageTemplate_IsIgnored()
        {
            const string invalidNumber = "1234567890";
            string customTemplate = "My custom message about my SSN '{0}'.";
            var validator = new SsnValidator(customTemplate);

            var validationResults = validator.Validate(invalidNumber);

            Assert.IsTrue(validationResults.Count == 1);
            Assert.IsFalse(validationResults.IsValid);

            string actualMessage = validationResults.Single(x => (x.Validator) is SsnValidator).Message;
            Assert.AreNotEqual(string.Format(customTemplate, invalidNumber), 
                actualMessage, StringComparison.InvariantCultureIgnoreCase);

        }

        class SsnTestObject
        {
            [SsnValidator]
            public string Ssn { get; set; }
        }

    }
}
