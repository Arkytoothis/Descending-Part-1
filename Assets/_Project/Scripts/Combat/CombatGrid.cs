using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Combat
{
    public class CombatGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;
        [SerializeField] private GameObject _tilePrefab = null;
        [SerializeField] private Transform _tilesParent = null;
        [SerializeField] private int _gridWidth = 10;
        [SerializeField] private int _gridHeight = 10;
        [SerializeField] private float _tileSize = 1f;
        [SerializeField] private float _gridYOffset = 0.01f;

        private CombatTile[,] _tiles = null;

        private void Start()
        {
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

        public void StartCombat(CombatParameters parameters)
        {
            Vector3 position = parameters.Party.transform.position;
            float moveX = Mathf.Floor(position.x) - (_gridWidth * _tileSize * 0.5f);
            float moveZ = Mathf.Floor(position.z) - (_gridHeight * _tileSize * 0.5f);
            transform.position = new Vector3(moveX, position.y + _gridYOffset, moveZ);
            
            Show();
        }

        public void EndCombat()
        {
            Hide();
        }
        
        private void Show()
        {
            _container.SetActive(true);
        }

        private void Hide()
        {
            _container.SetActive(false);
        }
    }
}