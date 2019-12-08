using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DSC_Dialogue_TextController : MonoBehaviour
    {
        #region Variable

        TextMeshProUGUI m_hText;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hText = GetComponent<TextMeshProUGUI>();
        }

        #endregion

        #region Events

        public void SetTalkerText(Dialogue hDialogue)
        {
            m_hText.SetText(hDialogue.m_sTalker);
        }

        public void SetDialogueText(Dialogue hDialogue)
        {
            m_hText.SetText(hDialogue.m_sDialogue);
        }

        #endregion
    }
}