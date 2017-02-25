//using System;
//using System.Linq;
//using MbUnit.Framework;


//[TestFixture(), Parallelizable()]
//public class ReferenceTableValueValidatorTests
//{

//    private const string TableName = "FakeTable";
//    private const string KeyDoesntExist = "KeyDoesntExist";
//    private const string KeyExists = "KeyExists";
//    private const string ResultFound = "AnyNonEmptyString";

//    private const string NoResultFound = "";

//    [Test()]
//    [ExpectedArgumentException("tableName is nothing or empty.")]
//    public void ReferenceTableValueValidatorCtor_NullTableName_ThrowsArgumentNullException()
//    {
//        ReferenceTableValueValidator validator = new ReferenceTableValueValidator(null);
//    }


//    [Test()]

//    public void ReferenceTableValueValidatorCtor_NonEmptyTableName_DefaultMessageTemplateIsDefault()
//    {
//        ReferenceTableValueValidator validator = new ReferenceTableValueValidator(TableName);
//        string defaultMessageTemplate = Reflector.GetProperty(validator, "DefaultMessageTemplate").ToString();

//        Assert.AreEqual("The key '{0}' does not exist on reference table '{1}'.", defaultMessageTemplate);

//    }

//    [Test()]

//    public void Validate_KeyExists_ValidationResultsIsValid()
//    {
//        //the Ref Table Utility
//        var itascaRefTableUtilityMock = MockRepository.GenerateStub<IReferenceTable>();
//        itascaRefTableUtilityMock.Stub(() => itascaRefTableUtilityMock.GetRefTableDisplayValue(TableName, null, KeyExists)).Return(ResultFound);

//        //the validator itself
//        ReferenceTableValueValidator validator = new ReferenceTableValueValidator(TableName);
//        ReferenceTableValueValidator_Accessor.AttachShadow(validator);
//        ReferenceTableValueValidator_Accessor.ItascaRefTableUtility = itascaRefTableUtilityMock;


//        var validationResults = validator.Validate(KeyExists);


//        Assert.IsTrue(validationResults.Count == 0);
//        Assert.IsTrue(validationResults.IsValid);

//    }

//    [Test()]

//    public void Validate_KeyDoesntExist_ValidationResultsIsInvalid()
//    {
//        // the Ref Table Utility
//        var itascaRefTableUtilityMock = MockRepository.GenerateStub<IReferenceTable>();
//        itascaRefTableUtilityMock.Stub(() => itascaRefTableUtilityMock.GetRefTableDisplayValue(TableName, null, KeyDoesntExist)).Return(NoResultFound);

//        // the validator itself
//        ReferenceTableValueValidator validator = new ReferenceTableValueValidator(TableName);
//        ReferenceTableValueValidator_Accessor.AttachShadow(validator);
//        ReferenceTableValueValidator_Accessor.ItascaRefTableUtility = itascaRefTableUtilityMock;


//        var validationResults = validator.Validate(KeyDoesntExist);


//        Assert.IsTrue(validationResults.Count == 1);
//        Assert.IsFalse(validationResults.IsValid);
//        string actualMessage = validationResults.Single(x => (x.Validator) is ReferenceTableValueValidator).Message;
//        Assert.AreEqual(string.Format("The key '{0}' does not exist on reference table '{1}'.", KeyDoesntExist, TableName), actualMessage, StringComparison.InvariantCultureIgnoreCase);

//    }


//}
