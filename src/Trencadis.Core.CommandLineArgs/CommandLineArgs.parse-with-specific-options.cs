using System.Collections.Generic;

namespace Trencadis.Core.CommandLineArgs
{
  public static partial class CommandLineArgs
  {
    /// <summary>
    /// Parses the command line args and returns a dictionary containing pairs of (argument-name, argument-value).
    /// </summary>
    /// <param name="options">The parsing options.</param>
    /// <param name="args">The arguments which were received from command line.</param>
    /// <returns>A dictionary containing pairs of (argument-name, argument-value).</returns>
    public static IDictionary<string, string> ParseWithOptions(ParseOptions options, params string[] args)
    {
      var result = new Dictionary<string, string>();

      if ((args == null) || (args.Length == 0))
      {
        return result;
      }

      if (options == null)
      {
        options = new ParseOptions();
      }

      if (string.IsNullOrWhiteSpace(options.DefaultArgBaseName))
      {
        options.DefaultArgBaseName = DefaultArgName;
      }

      for (int i = 0; i < args.Length; i++)
      {
        var argName = $"{options.DefaultArgBaseName}{i}";
        var argValue = args[i];

        if (argValue.StartsWith("-")) // Unix-like options
        {
          argName = argValue.Substring(1);
          if (i + 1 < args.Length)
          {
            var assumedArgValue = args[i + 1];
            if (!assumedArgValue.StartsWith("-"))
            {
              argValue = assumedArgValue;
              i++;
            }
            else
            {
              // next argument is another option
              argValue = default(string);
            }
          }
          else
          {
            // end of args array, option value ommitted
            argValue = default(string);
          }
        }

        result.Add(argName, argValue);
      }

      return result;
    }
  }
}
