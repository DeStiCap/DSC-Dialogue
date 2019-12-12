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
        Color m_hDefaultTextColor;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hText = GetComponent<TextMeshProUGUI>();
            m_hDefaultTextColor = m_hText.color;
        }

        #endregion

        #region Events

        public void SetText(string sText)
        {
            m_hText.SetText(sText);
        }

        public void SetTalkerText(Dialogue hDialogue)
        {
            m_hText.SetText(hDialogue.m_sTalker);
        }

        public void SetDialogueText(Dialogue hDialogue)
        {
            m_hText.SetText(hDialogue.m_sDialogue);
        }

        public void SetTextColor(Color hColor)
        {
            m_hText.color = hColor;
        }

        public void ResetTextColorToDefault()
        {
            m_hText.color = m_hDefaultTextColor;
        }
        
        public TextAlignmentOptions GetTextAlign()
        {
            return m_hText.alignment;
        }

        public void SetTextAlign(TextAlignmentOptions eAlign)
        {
            m_hText.alignment = eAlign;
        }

        #endregion
    }
}