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
        [SerializeField] private Image backgroundImage;
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
            
            if (_calendarDayMode == CalendarDayMode.Disabled)
            {
                backgroundImage.color = Color.gray;
                button.interactable = false;
                currentDateIndicator.SetActive(false);
            }
            else if (_calendarDayMode == CalendarDayMode.Current)
            {
                backgroundImage.color = Color.white;
                button.interactable = true;
                currentDateIndicator.SetActive(true);
            }
            else
            {
                backgroundImage.color = Color.white;
                button.interactable = true;
                currentDateIndicator.SetActive(false);
            }
        }
    }
}