using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Combat
{
    public class CombatGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _tilePrefab = null;
        [SerializeField] private Transform _tilesParent = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private int _gridWidth = 10;
        [SerializeField] private int _gridHeight = 10;
        [SerializeField] private float _tileSize = 1f;

        private CombatTile[,] _tiles = null;

        public void Setup(CombatParameters parameters)
        {
            Vector3 position = parameters.Encounter.transform.position - parameters.Party.transform.position;
            transform.position = new Vector3(position.x + ((_gridWidth * _tileSize) * 0.5f), position.y - 0.02f, position.z + ((_gridHeight * _tileSize) * 0.5f));

            _tiles = new CombatTile[_gridWidth, _gridHeight];

            for (int y = 0; y < _gridHeight; y++)
            {
                for (int x = 0; x < _gridWidth; x++)
                {
                    GameObject clone = Instantiate(_tilePrefab, _tilesParent);
                    clone.transform.position = new Vector3(x, 0, y);

                    CombatTile tile = clone.GetComponent<CombatTile>();
                    tile.Setup(x, y);
                    _tiles[x, y] = tile;
                }
            }
        }
    }
}