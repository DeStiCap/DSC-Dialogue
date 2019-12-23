using UnityEngine;
using TMPro;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_TextGroupController : DSC_UI_TextGroupController
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;

        [Header("Main Dialogue")]
        [SerializeField] protected DSC_Dialogue_TextController m_hDialogueText;
        [SerializeField] protected DSC_Dialogue_TextController m_hTalkerText;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_GroupController<DSC_Dialogue_TextGroupController>
                {
                    m_hGroupController = this,
                });
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_GroupController<DSC_Dialogue_TextGroupController>>();
            }
        }

        #endregion

        #region Main

        public virtual void SetDialogueTextColor(Color hColor)
        {
            m_hDialogueText?.SetTextColor(hColor);
        }

        public virtual void ResetDialogueTextColorToDefault()
        {
            m_hDialogueText?.ResetTextColorToDefault();
        }

        public virtual TextAlignmentOptions GetDialogueTextAlign()
        {
            if (m_hDialogueText == null)
                return TextAlignmentOptions.Center;

            return m_hDialogueText.GetTextAlign();
        }

        public virtual void SetDialogueTextAlign(TextAlignmentOptions eAlign)
        {
            m_hDialogueText?.SetTextAlign(eAlign);
        }

        public virtual void SetTalkerTextColor(Color hColor)
        {
            m_hTalkerText?.SetTextColor(hColor);
        }

        public virtual void ResetTalkerTextColorToDefault()
        {
            m_hTalkerText?.ResetTextColorToDefault();
        }

        public virtual TextAlignmentOptions GetTalkerTextAlign()
        {
            if (m_hTalkerText == null)
                return TextAlignmentOptions.Center;

            return m_hTalkerText.GetTextAlign();
        }

        public virtual void SetTalkerTextAlign(TextAlignmentOptions eAlign)
        {
            m_hTalkerText?.SetTextAlign(eAlign);
        }

        #endregion
    }
}