using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_CanvasSetEnable", menuName = "DSC/Dialogue/Events/Canvas Set Enable")]
    public class DialogueEvent_CanvasSetEnable : DialogueEvent
    {
        #region Enum

        protected enum SetType
        {
            Enable,
            Disable,
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] int m_nIndex;
        [SerializeField] UIType m_eGroupType;
        [SerializeField] SetType m_eSetType;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (!TryGetCanvasGroupController(lstData, out var hOutController))
                return;

            switch (m_eSetType)
            {
                case SetType.Enable:
                    hOutController.SetEnable(m_nIndex, m_eGroupType, true);
                    break;

                case SetType.Disable:
                    hOutController.SetEnable(m_nIndex, m_eGroupType, false);
                    break;
            }
        }

        #endregion

        #region Helper

        protected DSC_Dialogue_CanvasGroupController GetCanvasGroupController(List<IDialogueEventData> lstData)
        {
            if (!lstData.TryGetData(out DialogueEventData_Canvas hOutData))
                return null;

            return hOutData.m_hGroupController;
        }

        protected bool TryGetCanvasGroupController(List<IDialogueEventData> lstData, out DSC_Dialogue_CanvasGroupController hOutController)
        {
            hOutController = GetCanvasGroupController(lstData);
            return hOutController != null;
        }

        #endregion
    }
}