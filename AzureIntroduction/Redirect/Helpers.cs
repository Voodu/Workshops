using System;
using System.Collections.Generic;
using System.Linq;

namespace Redirect
{
    public static class Helpers
    {
        public static Uri PickNextMeeting(Dictionary<DateTime, Uri> meetings)
        {
            var now = TimeZoneInfo.ConvertTime(DateTime.Now,
                                               TimeZoneInfo
                                                   .FindSystemTimeZoneById("Central European Standard Time"));
            var week = TimeSpan.FromDays(7);
            try
            {
                var picked = meetings.First(x => now < x.Key && now + week > x.Key);
                return picked.Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Dictionary<DateTime, Uri> GetData()
        {
            return new Dictionary<DateTime, Uri>
            {
                {
                    new DateTime(2019, 03, 26, 2, 50, 00),
                    new Uri("https://placekitten.com/200/300")
                },
                {
                    new DateTime(2019, 03, 26, 2, 51, 00),
                    new Uri("https://placekitten.com/300/200")
                },
                {
                    new DateTime(2019, 03, 26, 2, 52, 00),
                    new Uri("https://placekitten.com/300/300")
                }
            };
        }
    }
}
