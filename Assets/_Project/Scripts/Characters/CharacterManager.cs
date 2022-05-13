using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _characterPrefabs = null;
        [SerializeField] private Transform _charactersParent = null;
        [SerializeField] private List<GameObject> _characters = null;
        [SerializeField] private int _minCharactersToSpawn = 1;
        [SerializeField] private int _maxCharactersToSpawn = 3;
        [SerializeField] private float _spawnRange = 2f;

        //private CharacterSpawnPoint _characterSpawn = null;
        //private DungeonExit _dungeonExit = null;

        public void Setup()
        {
            
        }
        
        public void SpawnCharacters()
        {
            _characters = new List<GameObject>();
            int numCharacter = Random.Range(_minCharactersToSpawn, _maxCharactersToSpawn + 1);

            for (int i = 0; i < numCharacter; i++)
            {
                int index = Random.Range(0, _characterPrefabs.Count);
                SpawnCharacter(index);
            }
        }

        private void SpawnCharacter(int index)
        {
            GameObject clone = Instantiate(_characterPrefabs[index], _charactersParent);
            float x = Random.Range(-_spawnRange, _spawnRange);
            float z = Random.Range(-_spawnRange, _spawnRange);
            //clone.transform.position = _characterSpawn.transform.position + new Vector3(x, 0, z);
            //clone.transform.rotation = _characterSpawn.transform.rotation;
            _characters.Add(clone);
        }

        public void OnRegisterCharacterSpawn(GameObject spawnObject)
        {
            // _characterSpawn = spawnObject.GetComponent<CharacterSpawnPoint>();
            //
            // if (_characterSpawn != null)
            // {
            //     SpawnCharacters();
            // }
        }

        public void OnRegisterDungeonExit(GameObject exitObject)
        {
            // _dungeonExit = exitObject.GetComponent<DungeonExit>();
            //
            // if (_dungeonExit == null)
            // {
            //     Debug.Log("_dungeonExit == null");
            // }
            //
            // StartCoroutine(StartAttackCoroutine(1f));
        }

        private IEnumerator StartAttackCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            for (int i = 0; i < _characters.Count; i++)
            {
                //_characters[i].GetComponent<CharacterPathfinder>().SetDestination(_dungeonExit.transform);
            }
        }
    }
}
