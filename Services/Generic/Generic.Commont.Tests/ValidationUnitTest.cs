using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generic‎.Common‎t.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //#region " ICN validation"
        //[TestMethod]
        //public void EmptyIsICNValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsICNValid(""));
        //}

        //[TestMethod]
        //public void IsICNValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsICNValid("123456V1234567890"));
        //}

        //[TestMethod]
        //public void IsICNValidLowerCaseVTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsICNValid("123456v1234567890"));
        //}

        //[TestMethod]
        //public void IsICNValidNotLongEnoughVTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsICNValid("123456V123456789"));
        //}

        //#endregion " ICN validation"

        //#region " DFN validation"

        //[TestMethod]
        //public void EmptyIsDFNValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDFNValid(""));
        //}

        //[TestMethod]
        //public void IsDFNValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDFNValid("123456123456789234"));
        //}

        //[TestMethod]
        //public void IsDFNValidNotLongEnoughVTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDFNValid("123456V123456789"));
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void NullIsDFNValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDFNValid(null));
        //}

        //[TestMethod]
        //public void NullIsDFNNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDFNNotNullAndValid(null));
        //}

        //[TestMethod]
        //public void IsDFNNotNullAndValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDFNNotNullAndValid("123456123456789234"));
        //}

        //[TestMethod]
        //public void IsDFNNotNullAndValidNotLongEnoughVTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDFNNotNullAndValid("123456V123456789"));
        //}

        //#endregion " DFN validation"

        //#region " SSN validation"

        //[TestMethod]
        //public void EmptyIsSSNValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsSSNValid(""));
        //}

        //[TestMethod]
        //public void IsSSNValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsSSNValid("123456125"));
        //}

        //[TestMethod]
        //public void IsSSNValidWithPTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsSSNValid("123456125p"));
        //}

        //[TestMethod]
        //public void IsSSNValidNotLongEnoughVTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsSSNValid("123456V123456789"));
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void NullIsSSNValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsSSNValid(null));
        //}

        //[TestMethod]
        //public void NullIsSSNNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsSSNNotNullAndValid(null));
        //}

        //[TestMethod]
        //public void IsSSNNotNullAndValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsSSNNotNullAndValid("123456125"));
        //}

        //[TestMethod]
        //public void IsSSNNotNullAndValidWithPTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsSSNNotNullAndValid("123456125P"));
        //}

        //[TestMethod]
        //public void IsSSNNotNullAndValidNotLongEnoughVTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsSSNNotNullAndValid("123456V123456789"));
        //}

        //#endregion " SSN validation"

        //#region " Name validation"
       
        //[TestMethod]
        //public void EmptyIsNameNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsNameNotNullAndValid(""));
        //}

        //[TestMethod]
        //public void NullIsNameNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsNameNotNullAndValid(null));
        //}

        //[TestMethod]
        //public void IsNameNotNullAndValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsNameNotNullAndValid("Miller"));
        //}

        //[TestMethod]
        //public void IsNameNotNullAndValidBadNameTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsNameNotNullAndValid("Miller323"));
        //}

        //#endregion " Name validation"

        //#region " Date validation"

        //[TestMethod]
        //public void EmptyIsDateValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateValid(""));
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void NullIsDateValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateValid(null));
        //}

        //[TestMethod]
        //public void IsDateValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDateValid("20140731000000"));
        //}

        //[TestMethod]
        //public void IsDateValidOneDigitShortOfExpectedFormatTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateValid("2014073100000"));
        //}

        //[TestMethod]
        //public void IsDateValidBadDateTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateValid("07/31/201"));
        //}

        //[TestMethod]
        //public void IsDateValidBadDateSomeTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateValid("07/31/2014 ace"));
        //}

        //[TestMethod]
        //public void IsDateValidBadDateAllTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateValid("adsbccccccccccc"));
        //}

        //[TestMethod]
        //public void EmptyIsDateNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateNotNullAndValid(""));
        //}

        //[TestMethod]
        //public void NullIsDateNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateNotNullAndValid(null));
        //}

        //[TestMethod]
        //public void IsDateNotNullAndValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDateNotNullAndValid("20140731000000"));
        //}

        //[TestMethod]
        //public void IsDateNotNullAndValidOneDigitShortOfExpectedFormatTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateNotNullAndValid("2014073100000"));
        //}

        //[TestMethod]
        //public void IsDateNotNullAndValidBadDateTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateNotNullAndValid("07/31/201"));
        //}

        //[TestMethod]
        //public void IsDateNotNullAndValidBadDateSomeTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateNotNullAndValid("07/31/2014 ace"));
        //}

        //[TestMethod]
        //public void IsDateNotNullAndValidBadDateAllTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateNotNullAndValid("adsbccccccccccc"));
        //}




        //#endregion " Date validation"
        
        //#region " DOB Date validation"

        //[TestMethod]
        //public void EmptyIsDateOfBirthValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid(""));
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void NullIsDateOfBirthValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid(null));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid8CharactersTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDateOfBirthValid("20140731"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid8WithInvalidCharactersTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("2014073a"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid7CharactersTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("2014073"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid9CharactersTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("201407314"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid19CharactersTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDateOfBirthValid("20140731000000-0000"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid19WithInvalidCharactersTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("20140731000000-000a"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid18CharactersTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("20140731000000-000"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValid20CharactersTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("20140731000000-00000"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValidOneDigitShortOfExpectedFormatTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("2014073100000"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValidBadDateTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("07/31/201"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValidBadDateSomeTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("07/31/2014 ace"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthValidBadDateAllTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthValid("adsbccccccccccc"));
        //}

        //[TestMethod]
        //public void EmptyIsDateOfBirthNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthNotNullAndValid(""));
        //}

        //[TestMethod]
        //public void NullIsDateOfBirthNotNullAndValidTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthNotNullAndValid(null));
        //}

        //[TestMethod]
        //public void IsDateOfBirthNotNullAndValidTestMethod()
        //{
        //    Assert.IsTrue(Validation.IsDateNotNullAndValid("20140731000000"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthNotNullAndValidOneDigitShortOfExpectedFormatTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthNotNullAndValid("2014073100000"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthNotNullAndValidBadDateTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthNotNullAndValid("07/31/201"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthNotNullAndValidBadDateSomeTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthNotNullAndValid("07/31/2014 ace"));
        //}

        //[TestMethod]
        //public void IsDateOfBirthNotNullAndValidBadDateAllTextTestMethod()
        //{
        //    Assert.IsFalse(Validation.IsDateOfBirthNotNullAndValid("adsbccccccccccc"));
        //}

        //#endregion " DOB Date validation"
    }
}
