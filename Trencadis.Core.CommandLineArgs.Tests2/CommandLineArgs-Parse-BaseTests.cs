using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trencadis.Core.CommandLineArgs.Tests2
{
  [TestClass]
  public class CommandLineArgs_Parse_Base_Tests
  {
    [TestMethod]
    public void Test_that_ParseCommandLineArgs_returns_emtpy_dictionary_for_null_args()
    {
      var parsedArgs = CommandLineArgs.Parse(null);

      Assert.IsNotNull(parsedArgs);
      Assert.AreEqual(0, parsedArgs.Count);
    }

    [TestMethod]
    public void Test_that_ParseCommandLineArgs_returns_emtpy_dictionary_for_empty_args_array()
    {
      var parsedArgs = CommandLineArgs.Parse(new string[0]);

      Assert.IsNotNull(parsedArgs);
      Assert.AreEqual(0, parsedArgs.Count);
    }
  }
}
