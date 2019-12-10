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

    #endregion

    #region Data

    [System.Serializable]
    public struct DialogueReplaceData
    {
        public string m_sReplaceID;
        public ReplaceEventType m_eEventType;

        [ColorHtmlProperty]
        public string m_sColor;
    }

    #endregion

    public abstract class BaseDialogueReplace : ScriptableObject
    {
        public abstract DialogueReplaceData ReplaceData { get; }
    }
}