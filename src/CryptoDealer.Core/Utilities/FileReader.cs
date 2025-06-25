using System;
using System.IO;

public class FileReader
{
  private readonly string _apiFile = "C:\\Users\\tyron\\Source\\Repos\\CryptoDealer\\src\\CryptoDealer.Core\\api.dat";

  public string? ReadApiKey()
  {
    foreach (string line in File.ReadLines(_apiFile, System.Text.Encoding.UTF8))
    {
      string[] parts = line.Split(';');
      if (parts[0] == "API_KEY")
      {
        return parts[1];
      }
    }
    return null;
  }

  public string? ReadApiSecret()
  {
    foreach (string line in File.ReadLines(_apiFile))
    {
      string[] parts = line.Split(';');
      if (parts[0] == "API_SECRET")
      {
        return parts[1];
      }
    }
    return null;
  }
}