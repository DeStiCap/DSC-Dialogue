using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_TextGroupController : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DSC_Dialogue_DataController m_hDataController;

        [Header("Main Dialogue")]
        [SerializeField] DSC_Dialogue_TextController m_hDialogueText;
        [SerializeField] DSC_Dialogue_TextController m_hTalkerText;

        [Header("Other Text")]
        [SerializeField] DSC_Dialogue_TextController[] m_arrTextController;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Mono

        private void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_Text
                {
                    m_hGroupController = this,
                });
            }
        }

        private void OnDestroy()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_Text>();
            }
        }

        #endregion

        #region Main

        public void SetDialogueTextColor(Color hColor)
        {
            m_hDialogueText?.SetTextColor(hColor);
        }

        public void ResetDialogueTextColorToDefault()
        {
            m_hDialogueText?.ResetTextColorToDefault();
        }

        public void SetTalkerTextColor(Color hColor)
        {
            m_hTalkerText?.SetTextColor(hColor);
        }

        public void ResetTalkerTextColorToDefault()
        {
            m_hTalkerText?.ResetTextColorToDefault();
        }

        public void SetText(int nIndex, string sText)
        {
            var hController = GetTextController(nIndex);
            hController?.SetText(sText);
        }

        public void SetTextColor(int nIndex,Color hColor)
        {
            var hController = GetTextController(nIndex);
            hController?.SetTextColor(hColor);
        }

        public void ResetTextColorToDefault(int nIndex)
        {
            var hController = GetTextController(nIndex);
            hController?.ResetTextColorToDefault();
        }

        #endregion

        #region Helper

        DSC_Dialogue_TextController GetTextController(int nIndex)
        {
            DSC_Dialogue_TextController hResult = null;

            if (nIndex < 0 || m_arrTextController.Length <= nIndex)
                return hResult;

            hResult = m_arrTextController[nIndex];

            return hResult;
        }

        bool TryGetTextController(int nIndex,out DSC_Dialogue_TextController hOutController)
        {
            hOutController = GetTextController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}