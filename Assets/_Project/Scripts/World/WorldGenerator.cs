using System.Collections;
using System.Collections.Generic;
using System.IO;
using Den.Tools;
using Descending.Core;
using Descending.Encounters;
using Descending.Party;
using MapMagic.Core;
using MapMagic.Products;
using MapMagic.Terrains;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.World
{
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] private EncounterManager _encounterManager = null;
        [SerializeField] private float _threatModifier = 10f;
        [SerializeField] private MapMagicObject _mapMagic = null;
        
        private bool _randomize = true;
        private List<WorldSpawner> _worldSpawners = new List<WorldSpawner>();
        private PartyManager _partyManager = null;
        private int _seed = 0;
        private SceneLoadData _sceneLoadData = null;
        
        public void Generate(PartyManager partyManager, SceneLoadData sceneLoadData)
        {
            _partyManager = partyManager;
            _sceneLoadData = sceneLoadData;

            // if (_sceneLoadData.LoadType == SceneBuildTypes.Generate)
            // {
            //     _randomize = true;
            // }
            // else
            // {
            //     _randomize = false;
            // }
            //
            // if (_randomize == true)
            // {
            //     _seed = Random.Range(0, 10000000);
            //     SaveData();
            //     _mapMagic.graph.random = new Noise(_seed, permutationCount:32768);
            // }
            // else
            // {
            //     LoadData();
            // }
        }

        private void SaveData()
        {
            WorldGenerationData worldData = new WorldGenerationData(_seed);
            byte[] bytes = SerializationUtility.SerializeValue(worldData, DataFormat.JSON);
            File.WriteAllBytes(Database.instance.WorldDataFilePath, bytes);
        }

        private void LoadData()
        {
            byte[] bytes = null;
            if (!File.Exists(Database.instance.WorldDataFilePath)) return;
            bytes = File.ReadAllBytes(Database.instance.WorldDataFilePath);
            _seed = SerializationUtility.DeserializeValue<WorldGenerationData>(bytes, DataFormat.JSON).WorldSeed;
        }
        
        public void OnRegisterSpawner(WorldSpawner spawner)
        {
            _worldSpawners.Add(spawner);
        }
        
        private void FinalizeWorld  (TerrainTile tile, TileData data, StopToken stop)
        {
            if (data.isDraft)
            {
                //Debug.Log("Just applied draft tile");
            }
            else
            {
                //Debug.Log($"Applied main tile at {tile.coord.x}, {tile.coord.z}");
                _worldSpawners.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));
                _worldSpawners[0].SpawnParty(_partyManager);
                
                for (int i = 0; i < _worldSpawners.Count; i++)
                {
                    _worldSpawners[i].Setup(_partyManager.PartyObject.transform.position, _threatModifier);
                }
                
                ProcessSpawner("Village", 0, true);
                _worldSpawners.Sort((a, b) => a.ThreatLevel.CompareTo(b.ThreatLevel));
                ProcessSpawner("Dungeon Entrance", 0, true);
                ProcessSpawner("Village", (_worldSpawners.Count - 1) / 2, true);
                ProcessSpawner("Dungeon Entrance", (_worldSpawners.Count + 1) / 2, true);
                ProcessSpawner("Village", _worldSpawners.Count - 3, true);
                ProcessSpawner("Boss Dungeon", _worldSpawners.Count - 1, true);
                ProcessSpawner("Oracle", _worldSpawners.Count - 1, true);

                for (int i = 0; i < _worldSpawners.Count; i++)
                {
                    int type = Random.Range(0, 5);
                    if (type == 0)
                    {
                        ProcessSpawner("Dungeon Entrance", i, false);
                    }
                    else if (type == 1)
                    {
                        ProcessSpawner("Obelisk", i, false);
                    }
                    else if (type == 2)
                    {
                        ProcessSpawner("Camp", i, false);
                    }
                    else if (type == 3)
                    {
                        ProcessSpawner("Lair", i, false);
                    }
                    else if (type == 4)
                    {
                        ProcessSpawner("Dwelling", i, false);
                    }
                }
                
                ClearSpawners();
                
                _encounterManager.CalculateTreatLevels(_partyManager.PartyObject.transform.position, _threatModifier);
                _partyManager.PartyObject.GetComponent<FirstPersonController>().UseGravity = true;
            }
        }

        private void ProcessSpawner(string featureKey, int index, bool remove)
        {
            FeatureDefinition def = Database.instance.Features.GetFeature(featureKey);
            _worldSpawners[index].Spawn(def.Prefab, transform);
            if(remove) RemoveSpawner(index);
        }
        
        private void RemoveSpawner(int index)
        {
            Destroy(_worldSpawners[index].gameObject);
            _worldSpawners.RemoveAt(index);  
        }
        
        private void ClearSpawners()
        {  
            for (int i = 0; i < _worldSpawners.Count; i++)
            {
                Destroy(_worldSpawners[i].gameObject);
            }
                
            _worldSpawners.Clear();
        }
        public void OnEnable ()
        {
            TerrainTile.OnTileApplied -= FinalizeWorld;
            TerrainTile.OnTileApplied += FinalizeWorld;
        }

        public void OnDisable ()
        {
            TerrainTile.OnTileApplied -= FinalizeWorld;
        }

    }
}
