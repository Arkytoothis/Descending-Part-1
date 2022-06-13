using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniStorm;
using UnityEngine;

namespace Descending.Gui
{
    public class TimePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _yearLabel = null;
        [SerializeField] private TMP_Text _monthLabel = null;
        [SerializeField] private TMP_Text _dayLabel = null;
        [SerializeField] private TMP_Text _hourLabel = null;
        [SerializeField] private GameObject _container = null;
        
        public void Setup()
        {
            //OnHourChanged(UniStormSystem.Instance.Hour);    
            //OnDayChanged(UniStormSystem.Instance.Day);    
            //OnMonthChanged(UniStormSystem.Instance.Month);    
            //OnYearChanged(UniStormSystem.Instance.Year);    
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }
        
        public void OnHourChanged(int hour)
        {
            _hourLabel.text = "Hour " + (hour + 1);
        }
        
        public void OnDayChanged(int day)
        {
            _dayLabel.text = "Day " + day;
        }
        
        public void OnMonthChanged(int month)
        {
            _monthLabel.text = "Month " + month;
        }
        
        public void OnYearChanged(int year)
        {
            _yearLabel.text = "Year " + year;
        }
    }
}
