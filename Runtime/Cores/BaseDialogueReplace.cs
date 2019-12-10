using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    #region Enum

    public enum ReplaceEventType
    {
        Replace,
        Color,
        ReplaceColor,
    }

    public enum IgnoreReplaceType
    {
        None,
        Dialogue,
        Talker,
        DialogueAndTalker,
    }

    #endregion

    #region Data

    [System.Serializable]
    public struct DialogueReplaceData
    {
        public string m_sReplaceID;
        public ReplaceEventType m_eEventType;

        [ColorHtmlProperty]
        public string m_sColor;

        [Header("Option")]
        public IgnoreReplaceType m_eIgnoreType;
    }

    #endregion

    public abstract class BaseDialogueReplace : ScriptableObject
    {
        public abstract DialogueReplaceData ReplaceData { get; }
    }
}