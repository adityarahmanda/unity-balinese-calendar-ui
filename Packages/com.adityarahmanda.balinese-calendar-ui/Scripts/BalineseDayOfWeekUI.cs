using System;
using System.Globalization;
using BalineseCalendar;
using TMPro;
using UnityEngine;

namespace CalendarUI.Balinese
{
    public class BalineseDayOfWeekUI : BaseDayOfWeekUI
    {
        [SerializeField] private TextMeshProUGUI dayOfWeekText;
        [SerializeField] private TextMeshProUGUI balineseDayOfWeekText;
        [SerializeField] private Color dayDefaultColor = Color.black;
        [SerializeField] private Color dayOffColor = Color.red;
        
        public override void Setup(DayOfWeek dayOfWeek, bool isDayOff)
        {
            dayOfWeekText.text = CultureInfo.GetCultureInfo("id-ID").DateTimeFormat.GetDayName(dayOfWeek);
            dayOfWeekText.color = isDayOff ? dayOffColor : dayDefaultColor;

            balineseDayOfWeekText.text = $"({SaptaWara.Values[(int)dayOfWeek]})";
            balineseDayOfWeekText.color = isDayOff ? dayOffColor : dayDefaultColor;
        }
    }
}