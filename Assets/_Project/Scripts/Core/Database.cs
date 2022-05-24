using Descending.Abilities;
using Descending.Attributes;
using Descending.Enemies;
using Descending.Equipment;
using Descending.Equipment.Enchantments;
using Descending.World;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descending.Core
{
    [CreateAssetMenu(menuName = "Descending/Database/Database")]
    public class Database : SingletonScriptableObject<Database>
    {
        [SerializeField] private AbilityDatabase _abilities = null;
        [SerializeField] private AttributeDatabase _attributes = null;
        [SerializeField] private SkillDatabase _skills = null;
        [SerializeField] private RaceDatabase _races = null;
        [SerializeField] private ProfessionDatabase _profession = null;
        [SerializeField] private DamageTypeDatabase _damageTypes = null;
        [SerializeField] private ItemDatabase _items = null;
        [SerializeField] private MaterialDatabase _materials = null;
        [SerializeField] private EnchantmentDatabase _enchants = null;
        [SerializeField] private RarityDatabase _rarities = null;
        [SerializeField] private FeatureDatabase _features = null;
        [SerializeField] private EnemyDatabase _enemies = null;

        [SerializeField] private GameObject _heroPrefab = null;

        [SerializeField] private string _sceneLoadFilePath = "";
        [SerializeField] private string _partyDataFilePath = "";
        [SerializeField] private string _resourceDataFilePath = "";
        [SerializeField] private string _timeDataFilePath = "";

        [SerializeField] private Sprite _blankSprite = null;

        private bool _initialized = false;

        public AbilityDatabase Abilities => _abilities;
        public AttributeDatabase Attributes => _attributes;
        public SkillDatabase Skills => _skills;
        public RaceDatabase Races => _races;
        public ProfessionDatabase Profession => _profession;
        public DamageTypeDatabase DamageTypes => _damageTypes;
        public ItemDatabase Items => _items;
        public MaterialDatabase Materials => _materials;
        public EnchantmentDatabase Enchants => _enchants;
        public RarityDatabase Rarities => _rarities;
        public FeatureDatabase Features => _features;
        public EnemyDatabase Enemies => _enemies;
        public GameObject HeroPrefab => _heroPrefab;
        public Sprite BlankSprite => _blankSprite;
        public string SceneLoadPath => _sceneLoadFilePath;
        public string PartyDataFilePath => _partyDataFilePath;
        public string TimeDataFilePath => _timeDataFilePath;
        public string ResourceDataFilePath => _resourceDataFilePath;

        public void Setup()
        {
            if (_initialized == true) return;

            _initialized = true;
            LoadPaths();
        }

        [Button("Load Paths")]
        private void LoadPaths()
        {
            _sceneLoadFilePath = Application.streamingAssetsPath + "/SaveData/scene_load_data.dat";
            _partyDataFilePath = Application.streamingAssetsPath + "/SaveData/party_data.dat";
            _timeDataFilePath = Application.streamingAssetsPath + "/SaveData/time_data.dat";
            _resourceDataFilePath = Application.streamingAssetsPath + "/SaveData/resource_data.dat";
        }
    }
}