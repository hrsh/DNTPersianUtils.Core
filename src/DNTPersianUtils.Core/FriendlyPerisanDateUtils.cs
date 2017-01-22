﻿using System;
using System.Globalization;

namespace DNTPersianUtils.Core
{
    /// <summary>
    /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
    /// </summary>
    public static class FriendlyPersianDateUtils
    {
        /// <summary>
        /// نمایش فارسی روز دریافتی شمسی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(int persianYear, int persianMonth, int persianDay)
        {
            if (persianYear <= 99)
            {
                persianYear += 1300;
            }

            var strDay = PersianCulture.GetPersianWeekDayName(persianYear, persianMonth, persianDay);
            var strMonth = PersianCulture.PersianMonthNames[persianMonth];
            return $"{strDay} {persianDay} {strMonth} {persianYear}".ToPersianNumbers();
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(this DateTime dt)
        {
            var dateParts = dt.ToPersianYearMonthDay();
            return ToPersianDateTextify(dateParts.Item1, dateParts.Item2, dateParts.Item3);
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(this DateTime? dt)
        {
            return dt == null ? string.Empty : ToPersianDateTextify(dt.Value);
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(this DateTimeOffset dt)
        {
            return ToPersianDateTextify(dt.DateTime);
        }

        /// <summary>
        /// نمایش فارسی روز دریافتی
        /// مانند سه شنبه ۲۱ دی ۱۳۹۵
        /// </summary>
        public static string ToPersianDateTextify(this DateTimeOffset? dt)
        {
            return dt == null ? string.Empty : ToPersianDateTextify(dt.Value.DateTime);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTime info, DateTime comparisonBase)
        {
            return $"{UnicodeConstants.RleChar}{toFriendlyPersianDate(info, comparisonBase).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTime info)
        {
            var comparisonBase = info.Kind.GetNow();
            return $"{UnicodeConstants.RleChar}{toFriendlyPersianDate(info, comparisonBase).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset info, DateTime comparisonBase)
        {
            return $"{UnicodeConstants.RleChar}{toFriendlyPersianDate(info.DateTime, comparisonBase).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset info)
        {
            var comparisonBase = info.DateTime.Kind.GetNow();
            return $"{UnicodeConstants.RleChar}{toFriendlyPersianDate(info.DateTime, comparisonBase).ToPersianNumbers()}";
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTime? info, DateTime comparisonBase)
        {
            return info == null ? string.Empty : ToFriendlyPersianDateTextify(info.Value, comparisonBase);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTime? info)
        {
            if (info == null)
            {
                return string.Empty;
            }
            var comparisonBase = info.Value.Kind.GetNow();
            return ToFriendlyPersianDateTextify(info.Value, comparisonBase);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <param name="comparisonBase">مبنای مقایسه مانند هم اکنون</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset? info, DateTime comparisonBase)
        {
            return info == null ? string.Empty : ToFriendlyPersianDateTextify(info.Value, comparisonBase);
        }

        /// <summary>
        /// نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی
        /// مبنای محاسبه هم اکنون
        /// مانند ۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        /// </summary>
        /// <param name="info">تاریخ ورودی</param>
        /// <returns>نمایش دوستانه</returns>
        public static string ToFriendlyPersianDateTextify(this DateTimeOffset? info)
        {
            if (info == null)
            {
                return string.Empty;
            }
            var comparisonBase = info.Value.DateTime.Kind.GetNow();
            return ToFriendlyPersianDateTextify(info.Value, comparisonBase);
        }

        private static string toFriendlyPersianDate(this DateTime info, DateTime comparisonBase)
        {
            var persianDate = info.ToPersianYearMonthDay();

            //1388/10/22
            var persianYear = persianDate.Item1;
            var persianMonth = persianDate.Item2;
            var persianDay = persianDate.Item3;

            //13:14
            var hour = info.Hour;
            var min = info.Minute;
            var hhMm =
                $"{hour.ToString("00", CultureInfo.InvariantCulture)}:{min.ToString("00", CultureInfo.InvariantCulture)}";

            var date = new PersianCalendar().ToDateTime(persianYear, persianMonth, persianDay, hour, min, 0, 0);
            var diff = date - comparisonBase;
            var totalSeconds = Math.Round(diff.TotalSeconds);
            var totalDays = Math.Round(diff.TotalDays);

            var suffix = " بعد";
            if (totalSeconds < 0)
            {
                suffix = " قبل";
                totalSeconds = Math.Abs(totalSeconds);
                totalDays = Math.Abs(totalDays);
            }

            var dateTimeToday = DateTime.Today;
            var yesterday = dateTimeToday.AddDays(-1);
            var today = dateTimeToday.Date;
            var tomorrow = dateTimeToday.AddDays(1);

            hhMm = $"، ساعت {hhMm}";

            if (today == date.Date)
            {
                // Less than one minute ago.
                if (totalSeconds < 60)
                {
                    return "هم اکنون";
                }

                // Less than 2 minutes ago.
                if (totalSeconds < 120)
                {
                    return $"یک دقیقه{suffix}{hhMm}";
                }

                // Less than one hour ago.
                if (totalSeconds < 3600)
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0} دقیقه",
                        ((int)Math.Floor(totalSeconds / 60))) + suffix + hhMm;
                }

                // Less than 2 hours ago.
                if (totalSeconds < 7200)
                {
                    return $"یک ساعت{suffix}{hhMm}";
                }

                // Less than one day ago.
                if (totalSeconds < 86400)
                {
                    return
                        string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} ساعت",
                        ((int)Math.Floor(totalSeconds / 3600))
                        ) + suffix + hhMm;
                }
            }

            if (yesterday == date.Date)
            {
                return $"دیروز {PersianCulture.GetPersianWeekDayName(persianYear, persianMonth, persianDay)}{hhMm}";
            }

            if (tomorrow == date.Date)
            {
                return $"فردا {PersianCulture.GetPersianWeekDayName(persianYear, persianMonth, persianDay)}{hhMm}";
            }

            var dayStr = $"، {ToPersianDateTextify(persianYear, persianMonth, persianDay)}{hhMm}";

            if (totalSeconds < 30 * TimeConstants.Day)
            {
                return $"{(int)Math.Abs(totalDays)} روز{suffix}{dayStr}";
            }

            if (totalSeconds < 12 * TimeConstants.Month)
            {
                int months = Convert.ToInt32(Math.Floor((double)Math.Abs(diff.Days) / 30));
                return months <= 1 ? $"1 ماه{suffix}{dayStr}" : $"{months} ماه{suffix}{dayStr}";
            }

            var years = Convert.ToInt32(Math.Floor((double)Math.Abs(diff.Days) / 365));
            var daysMonths = (double)Math.Abs(diff.Days) / 30;
            var nextMonths = Convert.ToInt32(Math.Truncate(daysMonths)) - (years * 12) - 1;
            var nextMonthsStr = nextMonths <= 0 ? "" : $"{(years >= 1 ? " و " : "")}{nextMonths} ماه";

            if (years < 1)
            {
                return $"{nextMonthsStr}{suffix}{dayStr}";
            }

            return $"{years} سال{nextMonthsStr}{suffix}{dayStr}";
        }
    }
}