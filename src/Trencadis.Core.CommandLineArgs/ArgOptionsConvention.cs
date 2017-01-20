namespace Trencadis.Core.CommandLineArgs
{
  /// <summary>
  /// Enumerates supported styles of defining options and their values
  /// </summary>
  public enum ArgOptionsConvention
  {
    /// <summary>
    /// The parser should try to autodetect the style used (to one of the below styles).
    /// </summary>
    AutoDetect = 0,

    /// <summary>
    /// Option names are not specified, the arguments being treated as values,
    /// e.g.: option1 option2 option3
    /// </summary>
    NoOptionNames,

    /// <summary>
    /// The option names are prefixed with a minus sign ("-") and the option values follow immediately,
    /// e.g.: -option1Name option1Value -option2Name option2Value
    /// </summary>
    MinusPrefixed,

    /// <summary>
    /// The option names are prefixed with a slash sign ("/") and the option values follow immediately,
    /// e.g.: /option1Name option1Value /option2Name option2Value
    /// </summary>
    SlashPrefixed,

    /// <summary>
    /// A colon sign delimits the option name and the option value,
    /// e.g.: option1Name:option1Value option2Name:option2Value
    /// </summary>
    OptionColonValue,

    /// <summary>
    /// An equal sign delimits the option name and the option value,
    /// e.g.: option1Name=option1Value option2Name=option2Value
    /// </summary>
    OptionEqualValue,

    /// <summary>
    /// The option names are prefixed with a minus sign ("-") and a colon sign (":") delimits the option name and the option value,
    /// e.g.: -option1Name:option1Value -option2Name:option2Value
    /// </summary>
    MinusOptionColonValue,

    /// <summary>
    /// The option names are prefixed with a minus sign ("-") and an equal sign ("=") delimits the option name and the option value,
    /// e.g.: -option1Name=option1Value -option2Name=option2Value
    /// </summary>
    MinusOptionEqualValue,

    /// <summary>
    /// The option names are prefixed with a slash sign ("/") and a colon sign (":") delimits the option name and the option value,
    /// e.g.: /option1Name:option1Value /option2Name:option2Value
    /// </summary>
    SlashOptionColonValue,

    /// <summary>
    /// The option names are prefixed with a slash sign ("/") and an equal sign ("=") delimits the option name and the option value,
    /// e.g.: /option1Name=option1Value /option2Name=option2Value
    /// </summary>
    SlashOptionEqualValue

    
  }
}
