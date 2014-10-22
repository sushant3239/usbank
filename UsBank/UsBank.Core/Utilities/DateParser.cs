using System;
using System.Globalization;

namespace UsBank.Core.Utilities
{
   public class DateParser
    {
       public static string Parse(DateTime dt)
       {
           try
           {
               return dt.ToString("dd/mm/yyyy");
               //return DateTime.ParseExact(dt.ToString()
               //    ,"dd/mm/yyyy"
               //    , CultureInfo.InvariantCulture
               //    , DateTimeStyles.AssumeLocal);
           }
           catch
           {
               return String.Empty;
           }
       }
    }
}
