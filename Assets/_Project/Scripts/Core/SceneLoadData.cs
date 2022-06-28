using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Core
{
    public enum SceneBuildTypes
    {
        Generate, Load, Number, None
    }
    
    public enum SceneTransitionTypes
    {
        Main_Menu_Play, Overworld_Underworld, Underworld_Overworld, Load, Number, None
    }
    
    [System.Serializable]
    public class SceneLoadData
    {
        [SerializeField] private SceneTransitionTypes _transitionType = SceneTransitionTypes.None;
        [SerializeField] private SceneBuildTypes _loadType = SceneBuildTypes.None;

        public SceneTransitionTypes TransitionType => _transitionType;
        public SceneBuildTypes LoadType => _loadType;

        public SceneLoadData(SceneTransitionTypes transitionType, SceneBuildTypes loadType)
        {
            _transitionType = transitionType;
            _loadType = loadType;
        }
    }
}
