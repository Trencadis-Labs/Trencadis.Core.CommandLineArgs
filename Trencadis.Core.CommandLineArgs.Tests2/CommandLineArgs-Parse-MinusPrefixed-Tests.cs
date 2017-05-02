using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trencadis.Core.CommandLineArgs.Tests2
{
  [TestClass]
  public class CommandLineArgs_Parse_MinusPrefixed_Tests
  {
    [TestMethod]
    public void Test_that_ParseCommandLineArgs_returns_correctly_when_slash_option_delimiter_is_used()
    {
      var parsedArgs = CommandLineArgs.Parse(new[] { "-option1", "option1Val", "-option2", "option2Val" });

      Assert.IsNotNull(parsedArgs);
      Assert.AreEqual(2, parsedArgs.Count);

      Assert.IsTrue(parsedArgs.ContainsKey("option1"));
      Assert.IsTrue(parsedArgs.ContainsKey("option2"));

      Assert.AreEqual("option1Val", parsedArgs["option1"]);
      Assert.AreEqual("option2Val", parsedArgs["option2"]);
    }

    [TestMethod]
    public void Test_that_ParseCommandLineArgs_returns_correctly_when_slash_option_delimiter_is_used_and_we_have_options_with_ommitted_value_on_last_position()
    {
      var parsedArgs = CommandLineArgs.Parse(new[] { "-option1", "option1Val", "-option2" });

      Assert.IsNotNull(parsedArgs);
      Assert.AreEqual(2, parsedArgs.Count);

      Assert.IsTrue(parsedArgs.ContainsKey("option1"));
      Assert.IsTrue(parsedArgs.ContainsKey("option2"));

      Assert.AreEqual("option1Val", parsedArgs["option1"]);
      Assert.AreEqual(default(string), parsedArgs["option2"]);
    }

    [TestMethod]
    public void Test_that_ParseCommandLineArgs_returns_correctly_when_slash_option_delimiter_is_used_and_we_have_options_with_ommitted_value_in_the_middle()
    {
      var parsedArgs = CommandLineArgs.Parse(new[] { "-option1", "-option2", "option2Val" });

      Assert.IsNotNull(parsedArgs);
      Assert.AreEqual(2, parsedArgs.Count);

      Assert.IsTrue(parsedArgs.ContainsKey("option1"));
      Assert.IsTrue(parsedArgs.ContainsKey("option2"));

      Assert.AreEqual(default(string), parsedArgs["option1"]);
      Assert.AreEqual("option2Val", parsedArgs["option2"]);
    }

  }
}
