using System.Runtime.Serialization;

public enum TimeFrame
{
  [EnumMember(Value = "1m")]
  OneMinute,

  [EnumMember(Value = "5m")]
  FiveMinutes,

  [EnumMember(Value = "15m")]
  FifteenMinutes,

  [EnumMember(Value = "30m")]
  ThirtyMinutes,

  [EnumMember(Value = "1h")]
  OneHour,

  [EnumMember(Value = "2h")]
  TwoHours,

  [EnumMember(Value = "4h")]
  FourHours,

  [EnumMember(Value = "6h")]
  SixHours,

  [EnumMember(Value = "12h")]
  TwelveHours,

  [EnumMember(Value = "1d")]
  OneDay,

  [EnumMember(Value = "1w")]
  OneWeek,

  [EnumMember(Value = "1M")]
  OneMonth
}