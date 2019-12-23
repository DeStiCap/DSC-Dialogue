using UnityEngine;
using TMPro;
using DSC.UI;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DSC_Dialogue_TextController : DSC_UI_TextController
    {
        #region Events

        public virtual void SetTalkerText(Dialogue hDialogue)
        {
            m_hText.SetText(hDialogue.m_sTalker);
        }

        public virtual void SetDialogueText(Dialogue hDialogue)
        {
            m_hText.SetText(hDialogue.m_sDialogue);
        }

        #endregion
    }
}