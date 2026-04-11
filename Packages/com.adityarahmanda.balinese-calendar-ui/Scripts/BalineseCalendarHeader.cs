using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace CalendarUI
{
    public class BalineseCalendarHeader : MonoBehaviour
    {
        [SerializeField] private CalendarManager calendarManager;
        [SerializeField] private TextMeshProUGUI monthAndYearText;
        [SerializeField] private TextMeshProUGUI balineseMonthAndYearText;
        
        private void Awake()
        {
            calendarManager.onCalendarUpdated.AddListener(OnCalendarUpdated);
        }

        private void OnCalendarUpdated()
        {
            var date = new DateTime(calendarManager.ShownYear, calendarManager.ShownMonth, 1);
            var balineseDate = new BalineseCalendar.BalineseDate(date);
            monthAndYearText.text = date.ToString("MMMM", CultureInfo.GetCultureInfo("id-ID")) + " " + date.ToString("yyyy");
            balineseMonthAndYearText.text = "(" + balineseDate.sasih + " " + balineseDate.saka + ")";
        }
    }
}