﻿namespace ShiftTrackerUI
{
    internal class Helpers
    {
        internal static string GetDuration(string startTime, string endTime)
        {
            var parsedStartTime = DateTime.Parse(startTime);
            var parsedEndTime = DateTime.Parse(endTime);
            TimeSpan duration = (parsedEndTime < parsedStartTime) ? parsedEndTime.AddDays(1) - parsedStartTime : parsedEndTime - parsedStartTime;
            var stringDuration = duration.ToString();
            return stringDuration;
        }
    }
}
