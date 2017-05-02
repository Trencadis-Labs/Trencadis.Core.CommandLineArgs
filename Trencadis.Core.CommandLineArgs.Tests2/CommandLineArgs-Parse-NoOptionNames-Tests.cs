using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Trencadis.Core.CommandLineArgs.Tests2
{
  [TestClass]
  public class CommandLineArgs_Parse_NoOptionNames_Tests
  {
    [TestMethod]
    public void Test_that_ParseCommandLineArgs_returns_index_based_arg_names_when_no_option_notation_is_used()
    {
      var parsedArgs = CommandLineArgs.Parse(new[] { "test", "this", "out" });

      Assert.IsNotNull(parsedArgs);
      Assert.AreEqual(3, parsedArgs.Count);

      Assert.IsTrue(parsedArgs.ContainsKey("Arg0"));
      Assert.IsTrue(parsedArgs.ContainsKey("Arg1"));
      Assert.IsTrue(parsedArgs.ContainsKey("Arg2"));

      Assert.AreEqual("test", parsedArgs["Arg0"]);
      Assert.AreEqual("this", parsedArgs["Arg1"]);
      Assert.AreEqual("out", parsedArgs["Arg2"]);
    }
  }
}
