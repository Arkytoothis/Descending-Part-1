using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private Transform _dialogsParent = null;
        
        private List<Dialog> _dialogs = new List<Dialog>();

        public void RegisterDialog(Dialog dialog)
        {
            dialog.transform.SetParent(_dialogsParent, true);
            _dialogs.Add(dialog);
        }
    }
}
