using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    #region Enum

    public enum UIType
    {
        None,
        Canvas,
        Text,
        Image,
        RawImage,
        Button,
    }

    #endregion

    public abstract class BaseDialogueUIGroup : MonoBehaviour
    {
        public abstract UIType GroupType { get; }
        public abstract void SetEnable(int nIndex, bool bEnable);
        public abstract void SetAllEnable(bool bEnable);
    }
}