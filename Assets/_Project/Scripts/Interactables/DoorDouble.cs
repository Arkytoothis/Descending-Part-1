using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using MoreMountains.Feedbacks;

namespace Descending.Interactables
{
    public class DoorDouble : Interactable
    {
        [SerializeField] private MMF_Player _leftPlayer = null;
        [SerializeField] private MMF_Player _rightPlayer = null;
        [SerializeField] private DoorDouble _otherDoor = null;
        
        private bool _isOpen = false;

        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }

        public override void Interact()
        {
            if (_isOpen == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private void Open()
        {
            //Debug.Log("Opening");
            _leftPlayer.FeedbacksList[0].Play(transform.position);
            _rightPlayer.FeedbacksList[0].Play(transform.position);
            _isOpen = true;
            _otherDoor.IsOpen = true;
        }

        private void Close()
        {
            //Debug.Log("Closing");
            _leftPlayer.FeedbacksList[1].Play(transform.position);
            _rightPlayer.FeedbacksList[1].Play(transform.position);
            _isOpen = false;
            _otherDoor.IsOpen = false;
        }
    }
}