namespace Trencadis.Core.CommandLineArgs
{
  /// <summary>
  /// POCO class, holds the command line parsing options.
  /// </summary>
  public class ParseOptions
  {
    /// <summary>
    /// Gets or sets the option name and value notation convention.
    /// </summary>
    public ArgOptionsConvention Convention { get; set; } = ArgOptionsConvention.AutoDetect;

    /// <summary>
    /// Gets or sets the default argument name to be used when no option names are specified.
    /// </summary>
    public string DefaultArgBaseName { get; set; } = string.Empty;
  }
}
