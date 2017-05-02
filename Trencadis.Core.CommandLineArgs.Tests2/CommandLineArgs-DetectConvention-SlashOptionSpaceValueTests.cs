using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trencadis.Core.CommandLineArgs.Tests2
{
  [TestClass]
  public class CommandLineArgs_DetectConvention_SlashOptionSpaceValueTests
  {
    #region Happy Path

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_happy_case_scenario()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "option1Value", "/option2Name", "option2Value", "/option3Name", "option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    #endregion

    #region Missing option value

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_value_on_first_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "/option2Name", "option2Value", "/option3Name", "option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_value_on_middle_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "option1Value", "/option2Name", "/option3Name", "option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_value_on_last_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "option1Value", "/option2Name", "option2Value", "/option3Name");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_value_on_all_params()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "/option2Name", "/option3Name");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    #endregion

    #region Missing option name

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_name_on_first_param()
    {
      var convention = CommandLineArgs.DetectConvention("option1Value", "/option2Name", "option2Value", "/option3Name", "option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_name_on_middle_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "option1Value", "option2Value", "/option3Name", "option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_SlashPrefixed_for_missing_option_name_on_last_param()
    {
      var convention = CommandLineArgs.DetectConvention("/option1Name", "option1Value", "/option2Name", "option2Value", "option3Value");

      Assert.AreEqual(ArgOptionsConvention.SlashPrefixed, convention);
    }

    #endregion
  }
}
