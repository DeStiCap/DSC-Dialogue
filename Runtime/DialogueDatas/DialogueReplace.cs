using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueReplace", menuName = "DSC/Dialogue/Dialogue Replace")]
    public class DialogueReplace : BaseDialogueReplace
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DialogueReplaceData m_hData;

#pragma warning restore 0649
        #endregion

        #endregion

        public override DialogueReplaceData ReplaceData { get { return m_hData; } }
    }
}