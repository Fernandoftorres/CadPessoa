using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TimeZoneConverter;

namespace CadSage.Domain.Core.Helpers
{
    public static class DateHelper
    {
        public static DateTime ChangeTimeZone(this DateTime data, string timeZoneId)
        {

            DateTime utcTime = data.ToUniversalTime();
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeInfo);
        }
    }
}
