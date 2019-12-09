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
            None,
            SetDialogueColor,
            ResetDialogueColor,
            SetTalkerColor,
            ResetTalkerColor,
            SetTextColor,
            ResetTextColor,
        }

        #endregion

        #region Data

        [System.Serializable]
        protected struct DialogueEvent_TextData
        {
            public TextEventType m_eType;
            public int m_nIndex;
            public Color m_hColor;
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DialogueEvent_TextData[] m_arrEventData;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (m_arrEventData == null || m_arrEventData.Length <= 0)
                return;

            if (!lstData.TryGetData(out DialogueEventData_Text hOutData))
                return;

            var hTextGroupController = hOutData.m_hGroupController;
            if (hTextGroupController == null)
                return;

            for(int i = 0; i < m_arrEventData.Length; i++)
            {
                var hEventData = m_arrEventData[i];

                switch (hEventData.m_eType)
                {
                    case TextEventType.None:
                        continue;

                    case TextEventType.SetDialogueColor:
                        SetDialogueColor(hTextGroupController, hEventData);
                        break;

                    case TextEventType.ResetDialogueColor:
                        ResetDialogueColor(hTextGroupController);
                        break;

                    case TextEventType.SetTalkerColor:
                        SetTalkerColor(hTextGroupController, hEventData);
                        break;

                    case TextEventType.ResetTalkerColor:
                        ResetTalkerColor(hTextGroupController);
                        break;

                    case TextEventType.SetTextColor:
                        SetTextColor(hTextGroupController, hEventData);
                        break;

                    case TextEventType.ResetTextColor:;
                        ResetTextColor(hTextGroupController, hEventData);
                        break;
                }
            }
        }

        #endregion

        #region Main

        protected void SetDialogueColor(DSC_Dialogue_TextGroupController hTextGroupController,DialogueEvent_TextData hEventData)
        {
            hTextGroupController.SetDialogueTextColor(hEventData.m_hColor);
        }

        protected void ResetDialogueColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.ResetDialogueTextColorToDefault();
        }

        protected void SetTalkerColor(DSC_Dialogue_TextGroupController hTextGroupController, DialogueEvent_TextData hEventData)
        {
            hTextGroupController.SetTalkerTextColor(hEventData.m_hColor);
        }

        protected void ResetTalkerColor(DSC_Dialogue_TextGroupController hTextGroupController)
        {
            hTextGroupController.ResetTalkerTextColorToDefault();
        }

        protected void SetTextColor(DSC_Dialogue_TextGroupController hTextGroupController, DialogueEvent_TextData hEventData)
        {
            hTextGroupController.SetTextColor(hEventData.m_nIndex,hEventData.m_hColor);
        }

        protected void ResetTextColor(DSC_Dialogue_TextGroupController hTextGroupController, DialogueEvent_TextData hEventData)
        {
            hTextGroupController.ResetTextColorToDefault(hEventData.m_nIndex);
        }

        #endregion
    }
}