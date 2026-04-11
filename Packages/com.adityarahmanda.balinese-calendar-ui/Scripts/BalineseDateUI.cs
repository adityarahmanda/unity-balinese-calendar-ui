using System;
using BalineseCalendar;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CalendarUI.Balinese
{
    public class BalineseDateUI : BaseDateUI
    {
        [SerializeField] private GameObject currentDateIndicator;
        [SerializeField] private Color dateDefaultColor = Color.black;
        [SerializeField] private Color dateHolidayColor = Color.red;
        [SerializeField] private Button button;
        public override Button Button => button;
        
        [Header("Date Information UI Elements")]
        [SerializeField] private TextMeshProUGUI dateText;
        [SerializeField] private TextMeshProUGUI triwaraText;
        [SerializeField] private TextMeshProUGUI pancawaraText;
        [SerializeField] private TextMeshProUGUI uripText;
        [SerializeField] private TextMeshProUGUI paringkelanText;
        [SerializeField] private TextMeshProUGUI wukuText;
        [SerializeField] private TextMeshProUGUI sasihText;
        [SerializeField] private TextMeshProUGUI sasihDayText;
        
        private CalendarDayMode _calendarDayMode; 
        
        private DateTime _date;
        public override DateTime Date => _date;

        private BalineseDate _balineseDate;
        public BalineseDate BalineseDate => _balineseDate;

        public override void Setup(DateTime date, CalendarDayMode calendarDayMode, bool isDayOff)
        {
            _date = date;
            _balineseDate = new BalineseDate(_date);
            _calendarDayMode = calendarDayMode;
            
            dateText.text = date.Day.ToString();
            dateText.color = isDayOff ? dateHolidayColor : dateDefaultColor;
            triwaraText.text = _balineseDate.triWara.Name;
            pancawaraText.text = _balineseDate.pancaWara.Name;
            uripText.text = $"{_balineseDate.saptaWara.Urip} + {_balineseDate.pancaWara.Urip}";
            paringkelanText.text = _balineseDate.ingkel.Name;
            wukuText.text = _balineseDate.wuku.Name;
            sasihText.text = _balineseDate.sasih.Name;
            sasihDayText.text = string.Join("/", _balineseDate.sasihDay);
            ColorUtility.TryParseHtmlString("#dfdfdf", out var disabledColor);
            ColorUtility.TryParseHtmlString("#2f00ca", out var blueColor);
            
            if (_calendarDayMode == CalendarDayMode.Disabled)
            {
                dateText.color = disabledColor;
                triwaraText.color = disabledColor;
                pancawaraText.color = disabledColor;
                uripText.color = disabledColor;
                paringkelanText.color = disabledColor;
                wukuText.color = disabledColor;
                sasihText.color = disabledColor;
                sasihDayText.color = disabledColor;
                button.interactable = false;
                currentDateIndicator.SetActive(false);
            }
            else
            {
                dateText.color = isDayOff ? dateHolidayColor : dateDefaultColor;
                triwaraText.color = blueColor;
                pancawaraText.color = blueColor;
                uripText.color = blueColor;
                paringkelanText.color = blueColor;
                wukuText.color = blueColor;
                sasihText.color = blueColor;
                sasihDayText.color = blueColor;
                button.interactable = true;
                currentDateIndicator.SetActive(_calendarDayMode == CalendarDayMode.Current);
            }
        }
    }
}