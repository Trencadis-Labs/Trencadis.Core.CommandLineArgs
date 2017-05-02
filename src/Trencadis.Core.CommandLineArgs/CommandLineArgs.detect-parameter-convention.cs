namespace Trencadis.Core.CommandLineArgs
{
  public static partial class CommandLineArgs
  {
    /// <summary>
    /// Detects the styles of defining options and their values from the input arguments.
    /// </summary>
    /// <param name="args">The arguments which were received from command line.</param>
    /// <returns>The <see cref="ArgOptionsConvention"/> value.</returns>
    public static ArgOptionsConvention DetectConvention(params string[] args)
    {
      if ((args == null) || (args.Length == 0))
      {
        return ArgOptionsConvention.NoOptionNames;
      }

      for (int i = 0; i < args.Length; i++)
      {
        var entry = args[i];

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

        if (MinusOptionColonValueRegex.IsMatch(entry))
        {
          return ArgOptionsConvention.MinusOptionColonValue;
        }

        if (OptionEqualValueRegex.IsMatch(entry))
        {
          return ArgOptionsConvention.OptionEqualValue;
        }

        if (OptionColonValueRegex.IsMatch(entry))
        {
          return ArgOptionsConvention.OptionColonValue;
        }

        if (i + 1 < args.Length)
        {
          var nextEntry = args[i + 1];

          var combinedEntries = $"{entry} {nextEntry}";

          if (SlashOptionSpaceValueRegex.IsMatch(combinedEntries))
          {
            return ArgOptionsConvention.SlashPrefixed;
          }

          if (MinusOptionSpaceValueRegex.IsMatch(combinedEntries))
          {
            return ArgOptionsConvention.MinusPrefixed;
          }
        }
      }

      var allEntries = string.Join(" ", args);

      if (SlashOptionAllRegex.IsMatch(allEntries))
      {
        return ArgOptionsConvention.SlashPrefixed;
      }

      if (MinusOptionAllRegex.IsMatch(allEntries))
      {
        return ArgOptionsConvention.MinusPrefixed;
      }

      return ArgOptionsConvention.NoOptionNames;
    }
  }
}
