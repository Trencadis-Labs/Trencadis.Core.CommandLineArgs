using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trencadis.Core.CommandLineArgs
{
  /// <summary>
  /// Helper class for parsing command line arguments
  /// </summary>
  public static class CommandLineArgs
  {
    private const string DefaultArgName = "Arg";

    private static readonly Regex SlashOptionEqualValueRegex = new Regex(@"\/(.*)=(.*)");

    private static readonly Regex SlashOptionColonValueRegex = new Regex(@"\/(.*):(.*)");

    private static readonly Regex MinusOptionEqualValueRegex = new Regex(@"-(.*)=(.*)");

    /// <summary>
    /// Detects the styles of defining options and their values from the input arguments.
    /// </summary>
    /// <param name="args">The arguments which were received from command line.</param>
    /// <returns>The <see cref="ArgOptionsConvention"/> value.</returns>
    public static ArgOptionsConvention DetectConvention(params string[] args)
    {
      if ((args == null) || (args.Length == 0))
      {
        return ArgOptionsConvention.AutoDetect;
      }

      foreach (var entry in args)
      {
        if (SlashOptionEqualValueRegex.IsMatch(entry))
        {
          return ArgOptionsConvention.SlashOptionEqualValue;
        }

        if (SlashOptionColonValueRegex.IsMatch(entry))
        {
          return ArgOptionsConvention.SlashOptionColonValue;
        }

        if (MinusOptionEqualValueRegex.IsMatch(entry))
        {
          return ArgOptionsConvention.MinusOptionEqualValue;
        }

      }


      return ArgOptionsConvention.AutoDetect;
    }

    /// <summary>
    /// Parses the command line args and returns a dictionary containing pairs of (argument-name, argument-value).
    /// </summary>
    /// <param name="args">The arguments which were received from command line.</param>
    /// <returns>A dictionary containing pairs of (argument-name, argument-value).</returns>
    public static IDictionary<string, string> Parse(params string[] args)
    {
      return CommandLineArgs.ParseWithOptions(options: null, args: args);
    }

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
