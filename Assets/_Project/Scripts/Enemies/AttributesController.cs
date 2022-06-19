using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using UnityEngine;

namespace Descending.Enemies
{
    public class AttributesController : MonoBehaviour
    {
        [SerializeField] private AttributeDictionary _attributes = null;
        [SerializeField] private AttributeDictionary _vitals = null;
        [SerializeField] private AttributeDictionary _statistics = null;
        [SerializeField] private AttributeDictionary _resistances = null;

        public AttributeDictionary Attributes => _attributes;
        public AttributeDictionary Vitals => _vitals;
        public AttributeDictionary Statistics => _statistics;
        public AttributeDictionary Resistances => _resistances;

        public void Setup(EnemyDefinition enemyDefinition)
        {
            _attributes.Clear();
            _vitals.Clear();
            _statistics.Clear();

            foreach (var kvp in Database.instance.Attributes.Attributes)
            {
                _attributes.Add(kvp.Key, new Attribute(kvp.Key));
            }

            foreach (var kvp in Database.instance.Attributes.Vitals)
            {
                _vitals.Add(kvp.Key, new Attribute(kvp.Key));
            }

            foreach (var kvp in Database.instance.Attributes.Statistics)
            {
                _statistics.Add(kvp.Key, new Attribute(kvp.Key));
            }
            
            CalculateAttributes(1, enemyDefinition);
        }

        public void CalculateAttributes(int level, EnemyDefinition enemyDefinition)
        {
            _vitals["Life"].Setup(Random.Range(enemyDefinition.StartingVitals["Life"].MinimumValue, enemyDefinition.StartingVitals["Life"].MinimumValue + 1) + 
                                  (_attributes["Endurance"].Maximum + _attributes["Might"].Maximum) / 2);
            _vitals["Stamina"].Setup(Random.Range(enemyDefinition.StartingVitals["Stamina"].MinimumValue, enemyDefinition.StartingVitals["Stamina"].MinimumValue + 1) + 
                                     (_attributes["Endurance"].Maximum + _attributes["Spirit"].Maximum) / 2);
            _vitals["Magic"].Setup(Random.Range(enemyDefinition.StartingVitals["Magic"].MinimumValue, enemyDefinition.StartingVitals["Magic"].MinimumValue + 1) + 
                                   (_attributes["Intellect"].Maximum + _attributes["Spirit"].Maximum) / 2);
            
            _vitals["Actions"].Setup(Random.Range(enemyDefinition.StartingVitals["Actions"].MinimumValue, enemyDefinition.StartingVitals["Actions"].MinimumValue + 1));
        }
        
        public void LoadData(List<Attribute> attributes, List<Resistance> resistances)
        {
            //_baseAttributes = attributes;
            //_resistances = resistances;
        }
        
        public bool IsAlive()
        {
            return true;//Get(Core.Attributes.Life).Current > 0;
        }

        public Attribute GetAttribute(string key)
        {
            return _attributes[key];
        }

        public Attribute GetVital(string key)
        {
            return _vitals[key];
        }

        public Attribute GetStatistic(string key)
        {
            return _statistics[key];
        }

        public void LoadData(AttributesSaveData saveData)
        {
            _statistics = Attribute.ConvertToDictionary(saveData.Attributes);
            _vitals = Attribute.ConvertToDictionary(saveData.Vitals);
        }
        
        public void RefreshActions()
        {
            GetVital("Actions").Refresh();
        }
    }

    [System.Serializable]
    public class AttributesSaveData
    {
        [SerializeField] private List<Attribute> _attributes = null;
        [SerializeField] private List<Attribute> _vitals = null;
        [SerializeField] private List<Attribute> _statistics = null;
        [SerializeField] private List<Resistance> _resistances = null;

        public List<Attribute> Attributes => _attributes;
        public List<Attribute> Vitals => _vitals;
        public List<Attribute> Statistics => _statistics;
        public List<Resistance> Resistances => _resistances;

        public AttributesSaveData(AttributesController controller)
        {
            _attributes = Attribute.ConvertToList(controller.Attributes);
            _vitals = Attribute.ConvertToList(controller.Vitals);
            _statistics = Attribute.ConvertToList(controller.Statistics);
            //_resistances = Attribute.SaveAttributes(attributes.Resistances;
        }
    }
}