using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.AppServices.ValidatorsMetadata
{
    public static class PublicHolidayRules
    {
        //official public holidays in Germany
        //New Year's Day 1 Januar
        //Good Friday Easter Sunday - 2d
        //Easter Monday	Easter Sunday + 1d
        //International Workers' Day 1 May
        //Ascension Day Easter Sunday + 39d
        //Whit Monday Easter Sunday + 50d			
        //German Unity Day 3 October
        //Christmas Day 25 December
        //St Stephen's Day 26 December

        public static bool IsPublicHoliday(DateTime date)
        {
            if (IsNewYearDay(date) || IsGoodFriday(date) || IsEasterMonday(date) || IsLabourDay(date) || IsAscensionDay(date) || IsWhitMonday(date)
                || IsGermanyUnityDay(date) || IsChristmasDay(date) || IsStStephenDay(date))
                return true;

            return false;
        }

        private static bool IsNewYearDay(DateTime date)
        {
             DateTime NewYearDay = DateTime.Now;
             bool tmpNewYear = DateTime.TryParse("01/01/" + date.Year, out NewYearDay);

             if (date == NewYearDay)
                 return true;
             return false;
        }

        private static bool IsGoodFriday(DateTime date)
        {
            DateTime EasterSunday = GetEasterSunday(date.Year);
            DateTime GoodFriday = EasterSunday.AddDays(-2);

            if (date == GoodFriday)
                return true;
            return false;
        }

        private static bool IsEasterMonday(DateTime date)
        {
            DateTime EasterSunday = GetEasterSunday(date.Year);
            DateTime EasterMonday = EasterSunday.AddDays(1);

            if (date == EasterMonday)
                return true;
            return false;
        }

        private static bool IsLabourDay(DateTime date)
        {
             DateTime LabourDay = DateTime.Now;
             bool tmpLabourDay = DateTime.TryParse("01/05/" + date.Year, out LabourDay);

             if (date == LabourDay)
                 return true;
             return false;
        }

        private static bool IsAscensionDay(DateTime date)
        {
            DateTime EasterSunday = GetEasterSunday(date.Year);
             DateTime AscensionDay = EasterSunday.AddDays(39);

             if (date == AscensionDay)
                 return true;
             return false;
        }

        private static bool IsWhitMonday(DateTime date)
        {
            DateTime EasterSunday = GetEasterSunday(date.Year);
            DateTime WhitMonday = EasterSunday.AddDays(50);

            if (date == WhitMonday)
                return true;
            return false;
        }

        private static bool IsGermanyUnityDay(DateTime date)
        {
            DateTime GermanyUnityDay = DateTime.Now;
            bool tmpGermanyUnityDay = DateTime.TryParse("03/10/" + date.Year, out GermanyUnityDay);

            if (date == GermanyUnityDay)
                return true;
            return false;
        }

        private static bool IsChristmasDay(DateTime date)
        {
            DateTime ChristmasDay = DateTime.Now;
            bool tmpChristmasDay = DateTime.TryParse("25/12/" + date.Year, out ChristmasDay);

            if (date == ChristmasDay)
                return true;
            return false;
        }

        private static bool IsStStephenDay(DateTime date)
        {
            DateTime StStephenDay = DateTime.Now;
            bool tmpStStephenDay = DateTime.TryParse("26/12/" + date.Year, out StStephenDay);

            if (date == StStephenDay)
                return true;
            return false;
        }
        
        private static DateTime GetEasterSunday(int yearToCheck)
        {
            int y = yearToCheck;
            int a = y % 19;
            int b = y / 100;
            int c = y % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            DateTime dtEasterSunday = new DateTime(yearToCheck, month, day);
            return dtEasterSunday;
        }
    }
}