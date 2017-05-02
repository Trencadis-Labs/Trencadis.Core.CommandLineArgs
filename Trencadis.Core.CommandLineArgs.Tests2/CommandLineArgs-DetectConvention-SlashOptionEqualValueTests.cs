using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trencadis.Core.CommandLineArgs.Tests2
{
  [TestClass]
  public class CommandLineArgs_DetectConvention_SlashOptionEqualValueTests
  {
    #region Happy Path

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_happy_case_scenario()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name=option1Value", "/option2Name=option2Value", "/option3Name=option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    #endregion

    #region Missing option value

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_missing_option_value_on_first_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name=", "/option2Name=option2Value", "/option3Name=option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_missing_option_value_on_middle_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name=option1Value", "/option2Name=", "/option3Name=");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_missing_option_value_on_last_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name=option1Value", "/option2Name=option2Value", "/option3Name=");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    #endregion

    #region Missing option name

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_missing_option_name_on_first_param()
    {
      var convention = CommandLineArgs.DetectConvention("/=option1Value", "/option2Name=option2Value", "/option3Name=option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_missing_option_name_on_middle_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name=option1Value", "/=option2Value", "/option3Name=option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashOptionEqualValue_for_missing_option_name_on_last_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name=option1Value", "/option2Name=option2Value", "/=option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashOptionEqualValue, convention);
    }

    #endregion
  }
}
