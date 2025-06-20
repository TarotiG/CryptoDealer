using System;

public static class LogService
{
  public static void LogInfo(string message)
  {
    Console.WriteLine($"[INFO] -  {message}");
  }

  public static void LogError(string message)
  {
    Console.WriteLine($"ERROR: {message}");
  }
}