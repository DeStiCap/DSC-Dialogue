using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    #region Data

    [System.Serializable]
    public struct Dialogue
    {
        public string m_sDialogue;
        public string m_sTalker;
    }

    #endregion

    public abstract class BaseDialogueData : ScriptableObject
    {
        public abstract Dialogue[] AllDialogue { get; }
    }
}