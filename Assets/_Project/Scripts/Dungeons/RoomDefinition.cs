using Descending.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Room Definition", menuName = "Descending/Definition/Room Definition")]
    public class RoomDefinition : ScriptableObject
    {
        [HorizontalGroup("Split", 150)]
        [PreviewField(38), BoxGroup("Split/Icon"), LabelWidth(75)]
        [SerializeField] private Sprite _icon = null;

        [SerializeField, BoxGroup("Split/Text"), LabelWidth(75)] private string _name = "New Item";
        [SerializeField, BoxGroup("Split/Text"), LabelWidth(75)] private string _key = "";
        [SerializeField] private string _description = "";
        [SerializeField] private GameObject _prefab = null;

        public Sprite Icon => _icon;
        public string Name => _name;
        public string Key => _key;
        public string Description => _description;
        public GameObject Prefab => _prefab;
    }
}