using System.Globalization;

namespace DevBr.Core.Tools.Dates
{
    public static class DayMonthYear
    {
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static int NumberDay(this DateTime dateEnd, DateTime dateStart)
        {
            return dateEnd.Subtract(dateStart).Days;
        }

        public static string DiaDaSemana(this DateTime date)
        {
            CultureInfo ptbr = new CultureInfo("pt-BR", false);
            string dateFormatString = ptbr.DateTimeFormat.GetDayName(date.DayOfWeek);

            return dateFormatString;
        }

        public static string DataPorExtenso(this DateTime date)
        {
            CultureInfo ptbr = new CultureInfo("pt-BR", false);
            string dateFormatString = ptbr.DateTimeFormat.LongDatePattern;

            return date.ToString(dateFormatString, new CultureInfo("pt-BR"));
        }
    }
}
