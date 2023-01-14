using Microsoft.Extensions.Primitives;
using Test_SEC_P.DAL.DL;
using Test_SEC_P.Models;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;

namespace Test_SEC_P.Helper
{
    public class Util
    {
        public static bool BetweenDate(DateTime date, DateTime StartDate, DateTime EndDate)
        {
            if (StartDate <= date && date <= EndDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime Date(DateTime date)
        {
            DateTime dateNow;
            if (date.Year < 2000)
            {
                dateNow = Convert.ToDateTime(date.AddYears(543));
                return dateNow;
            }
            else if (date.Year > 3000)
            {
                dateNow = Convert.ToDateTime(date.AddYears(-543));
                return dateNow;
            }
            return date;
        }
        public static string ConvertDatetime(DateTime date)
        {
            string c_date = date.ToString("dd/MM/yyyy HH:mm:ss");
            return c_date;
        }
        public static DateTime ConvertStringDateFormatSAP(string date)
        {
            string iString = date;
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            DateTime oDate = DateTime.ParseExact(iString, "yyyyMMdd", Culture);
            return oDate;
        }
        public static DateTime ConvertStringDate(string date)
        {
            string iString = date;
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            DateTime oDate = DateTime.ParseExact(iString, "dd/MM/yyyy", Culture);
            return oDate;
        }
        public static string ConvertStringDateToString(string date)
        {
            DateTime tempDate = Convert.ToDateTime(date);
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            var oDate = tempDate.ToString("dd/MM/yyyy", Culture);
            return oDate;
        }
        public static string ConvertDateToString(DateTime? date)
        {
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            var oDate = date.HasValue ? (date.Value.ToString("dd/MM/yyyy", Culture)) : "";
            return oDate;
        }
        public static TimeSpan ConvertStringTime(string date)
        {
            string iString = date;
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            TimeSpan oDate = TimeSpan.ParseExact(iString, "hh:mm:ss", Culture);
            return oDate;
        }
        public static string ConvertGetTime(DateTime date)
        {
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            string oDate = date.ToString("hh:mm:ss", Culture);
            return oDate;
        }
        public static List<string> SplitText(string data)
        {
            List<string> listData = new List<string>(data.Split(','));
            return listData;
        }
        public static string JoinText(List<string> data)
        {
            string JoinData = string.Join(",", data.ToArray());
            return JoinData;
        }
        public static string JoinTextSearch(List<string> data)
        {
            string JoinData = string.Join(" , ", data.ToArray());
            return JoinData;
        }
        public static int GetMonthsDifference(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime) return GetMonthsDifference(endTime, startTime);

            var monthDiff = Math.Abs((endTime.Year * 12 + (endTime.Month - 1)) - (startTime.Year * 12 + (startTime.Month - 1)));

            if (startTime.AddMonths(monthDiff) > endTime || endTime.Day < startTime.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }
        public static int GetDayDifference(DateTime startTime, DateTime endTime)
        {
            TimeSpan span = endTime.Subtract(startTime);
            var dayDiff = span.Days;

            return dayDiff;
        }

        public static string GetMethodName([CallerMemberName] string caller = null)
        {
            return caller;
        }

        public static string InjectionClear(string sql)
        {
            sql = sql.Replace("1=1", "");
            sql = sql.Replace("1 =1", "");
            sql = sql.Replace("1= 1", "");
            sql = sql.Replace("1 = 1", "");
            sql = sql.Replace("DROP TABLE", "");
            sql = sql.Replace("TRUNCATE TABLE", "");
            return sql;
        }

        public static string GetToken(HttpContext context)
        {
            if (context != null && !string.IsNullOrEmpty(context.Request.Headers.Authorization))
            {
                return context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            }
            else
            {
                return string.Empty;
            }
        }

        //public static UserModel GetUserInfo(HttpContext context)
        //{
        //    string token = GetToken(context);
        //    var handler = new JwtSecurityTokenHandler();
        //    UserModel user = new UserModel();
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        var jwtSecurityToken = handler.ReadJwtToken(token);

        //        user.UserRoleID = Convert.ToInt32(jwtSecurityToken.Claims.First(claim => claim.Type == "UserRole").Value);
        //        user.Username = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;
        //        user.UserRoleName = jwtSecurityToken.Claims.First(claim => claim.Type == "UserRoleName").Value;
        //    }
        //    return user;
        //}
    }
}
