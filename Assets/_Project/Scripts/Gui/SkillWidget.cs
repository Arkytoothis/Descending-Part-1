using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using TMPro;
using UnityEngine;

namespace Descending.Gui.PcViewer
{
    public class SkillWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _valueLabel = null;

        public void SetSkill(Skill skill)
        {
            _nameLabel.text = skill.Key;
            _valueLabel.text = skill.Current + "/" + skill.Maximum;
        }
    }
}