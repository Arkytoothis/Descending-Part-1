using System.Collections;
using System.Collections.Generic;
using Descension.Core;
using UnityEngine;

namespace Descending.Party
{
    public class PartyFormation : MonoBehaviour
    {
        [SerializeField] private GameObject _flag = null;
        [SerializeField] private List<Transform> _positions = null;

        public List<Transform> Positions => _positions;

        public void MoveTo(Vector3 startPosition, Vector3 position)
        {
            SetFlagActive(true);
            transform.position = position;
            transform.LookAt(startPosition, Vector3.up);
            transform.Rotate(Vector3.up, 180f);
            
            for (int i = 0; i < _positions.Count; i++)
            {
                _positions[i].GetComponent<PlaceOnGround>().Place();
            }
        }

        public void SetFlagActive(bool active)
        {
            _flag.SetActive(active);
        }
    }
}
