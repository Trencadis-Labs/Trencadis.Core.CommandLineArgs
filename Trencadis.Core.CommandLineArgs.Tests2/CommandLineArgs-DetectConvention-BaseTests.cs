using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trencadis.Core.CommandLineArgs.Tests2
{
  [TestClass]
  public class CommandLineArgs_DetectConvention_BaseTests
  {
    [TestMethod]
    public void Test_that_DetectConvention_returns_auto_detect_for_null_args()
    {
      var convention = CommandLineArgs.DetectConvention(null);

      Assert.AreEqual(ArgOptionsConvention.NoOptionNames, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_auto_detect_for_no_specified_args()
    {
      var convention = CommandLineArgs.DetectConvention();

      Assert.AreEqual(ArgOptionsConvention.NoOptionNames, convention);
    }

    [TestMethod]
    public void Test_that_DetectConvention_returns_auto_detect_for_explicit_empty_args()
    {
      var convention = CommandLineArgs.DetectConvention(new string[0]);

      Assert.AreEqual(ArgOptionsConvention.NoOptionNames, convention);
    }
  }
}
