using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UniStorm;
using UnityEngine;

namespace Descending.Core
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private IntEvent onNewHour = null;
        [SerializeField] private IntEvent onNewDay = null;
        [SerializeField] private IntEvent onNewMonth = null;
        [SerializeField] private IntEvent onNewYear = null;
        
        private int _year = 334;
        private int _month = 3;
        private int _day = 31;
        private int _hour = 16;

        private void Start()
        {
            UniStormSystem.Instance.OnHourChangeEvent.AddListener(HourChanged);
            UniStormSystem.Instance.OnDayChangeEvent.AddListener(DayChanged);
            UniStormSystem.Instance.OnMonthChangeEvent.AddListener(MonthChanged);
            UniStormSystem.Instance.OnYearChangeEvent.AddListener(YearChanged);

            UniStormSystem.Instance.Hour = _hour;
            UniStormSystem.Instance.Day = _day;
            UniStormSystem.Instance.Month = _month;
            UniStormSystem.Instance.Year = _year;

            //Debug.Log(_year + " " + _month + " " + _day + " " + _hour);
        }

        private void HourChanged()
        {
            _hour = UniStormSystem.Instance.Hour;
            onNewHour.Invoke(_hour);
            //Debug.Log(GetTimeString());
        }

        private void DayChanged()
        {
            _day = UniStormSystem.Instance.Day;
            onNewDay.Invoke(_day);
            //Debug.Log(GetTimeString());
        }

        private void MonthChanged()
        {
            _month = UniStormSystem.Instance.Month;
            onNewMonth.Invoke(_month);
            //Debug.Log(GetTimeString());
        }

        private void YearChanged()
        {
            _year = UniStormSystem.Instance.Year;
            onNewYear.Invoke(_year);
            //Debug.Log(GetTimeString());
        }
        
        public string GetTimeString()
        {
            return "Year " + _year + " Month " + _month + " Day " + _day + " Hour " + (_hour + 1);
        }

        public void OnSkipTime(int hoursToSkip)
        {
            DateTime dateTime = UniStormManager.Instance.GetDate();
            Debug.Log(dateTime.ToString());
            int newHour = dateTime.Hour + hoursToSkip;
            int newDay = dateTime.Day;
            int newMonth = dateTime.Month;
            int newYear = dateTime.Year;
            
            if (newHour >= 23)
            {
                newHour = dateTime.Hour + hoursToSkip - 23;
                newDay++;
                
                if (newDay >= 30)
                {
                    newDay = 1;
                    newMonth++;
                    if (newMonth >= 12)
                    {
                        newMonth = 1;
                        newYear++;
                    }
                }
            }
            
            Debug.Log(newYear + " " + newMonth + " " + newDay + " " + newHour);
            
           UniStormManager.Instance.SetTime(newHour, dateTime.Minute);
           UniStormManager.Instance.SetDate(newMonth, newDay, newYear);
           HourChanged();
           DayChanged();
           MonthChanged();
           YearChanged();
        }
    }
}
