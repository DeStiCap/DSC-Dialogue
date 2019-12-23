using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_TextColor", menuName = "DSC/Dialogue/Events/Text Color")]
    public class DialogueEvent_TextColor : DialogueEvent
    {
        #region Enum

        protected enum TextEventType
        {
            SetDialogueColor,
            ResetDialogueColor,
            SetTalkerColor,
            ResetTalkerColor,
            SetTextColor,
            ResetTextColor,
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected TextEventType m_eType;
        [SerializeField] protected int m_nIndex;
        [SerializeField] protected Color m_hColor;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (!lstData.TryGetData(out DialogueEventData_GroupController<DSC_Dialogue_TextGroupController> hOutData))
                return;

            var hTextGroupController = hOutData.m_hGroupController;
            if (hTextGroupController == null)
                return;

            switch (m_eType)
            {
                case TextEventType.SetDialogueColor:
                    SetDialogueColor(hTextGroupController);
                    break;

                case TextEventType.ResetDialogueColor:
                    ResetDialogueColor(hTextGroupController);
                    break;

                case TextEventType.SetTalkerColor:
                    SetTalkerColor(hTextGroupController);
                    break;

                case TextEventType.ResetTalkerColor:
                    ResetTalkerColor(hTextGroupController);
                    break;

                case TextEventType.SetTextColor:
                    SetTextColor(hTextGroupController);
                    break;

                case TextEventType.ResetTextColor:
                    ;
                    ResetTextColor(hTextGroupController);
                    break;
            }
        }

        #endregion

        #region Main

        protected void SetDialogueColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.SetDialogueTextColor(m_hColor);
        }

        protected void ResetDialogueColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.ResetDialogueTextColorToDefault();
        }

        protected void SetTalkerColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.SetTalkerTextColor(m_hColor);
        }

        protected void ResetTalkerColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.ResetTalkerTextColorToDefault();
        }

        protected void SetTextColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.SetTextColor(m_nIndex, m_hColor);
        }

        protected void ResetTextColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.ResetTextColorToDefault(m_nIndex);
        }

        #endregion
    }
}