using System.Text.RegularExpressions;

namespace Trencadis.Core.CommandLineArgs
{
  /// <summary>
  /// Helper class for parsing command line arguments
  /// </summary>
  public static partial class CommandLineArgs
  {
    private const string DefaultArgName = "Arg";

    private static readonly Regex SlashOptionEqualValueRegex = new Regex(@"\/(.*)=(.*)");

    private static readonly Regex SlashOptionColonValueRegex = new Regex(@"\/(.*):(.*)");

    private static readonly Regex MinusOptionEqualValueRegex = new Regex(@"-(.*)=(.*)");

    private static readonly Regex MinusOptionColonValueRegex = new Regex(@"-(.*):(.*)");

    private static readonly Regex OptionEqualValueRegex = new Regex(@"(.*)=(.*)");

    private static readonly Regex OptionColonValueRegex = new Regex(@"(.*):(.*)");

    private static readonly Regex SlashOptionSpaceValueRegex = new Regex(@"\/(.*)\s([^\/].*)");

    private static readonly Regex MinusOptionSpaceValueRegex = new Regex(@"-(.*)\s([^-].*)");

    private static readonly Regex MinusOptionAllRegex = new Regex(@"-(.*)");

    private static readonly Regex SlashOptionAllRegex = new Regex(@"\/(.*)");
  }
}
