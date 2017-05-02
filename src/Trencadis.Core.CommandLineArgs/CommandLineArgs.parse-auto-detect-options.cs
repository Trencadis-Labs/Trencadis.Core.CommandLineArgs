using System.Collections.Generic;

namespace Trencadis.Core.CommandLineArgs
{
  public static partial class CommandLineArgs
  {
    /// <summary>
    /// Parses the command line args and returns a dictionary containing pairs of (argument-name, argument-value).
    /// </summary>
    /// <param name="args">The arguments which were received from command line.</param>
    /// <returns>A dictionary containing pairs of (argument-name, argument-value).</returns>
    public static IDictionary<string, string> Parse(params string[] args)
    {
      return CommandLineArgs.ParseWithOptions(options: null, args: args);
    }
  }
}
