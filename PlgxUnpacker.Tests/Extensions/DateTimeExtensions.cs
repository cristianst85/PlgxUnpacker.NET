using System;

namespace PlgxUnpacker.Tests.Extensions
{
    internal static class DateTimeExtensions
    {
        internal static DateTime TruncateMilliseconds(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
        }
    }
}
