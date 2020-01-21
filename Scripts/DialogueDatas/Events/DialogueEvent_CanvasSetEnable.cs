using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

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

        [SerializeField] protected int m_nGroupID;
        [SerializeField] protected int m_nIndex;
        [SerializeField] protected UIType m_eGroupType;
        [SerializeField] protected SetType m_eSetType;

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
            if (!lstData.TryGetData(out DialogueEventData_GroupController<DSC_Dialogue_CanvasGroupController> hOutData) || hOutData.m_lstGroupController == null)
                return null;

            for(int i = 0; i < hOutData.m_lstGroupController.Count; i++)
            {
                var hGroupController = hOutData.m_lstGroupController[i];
                if (hGroupController == null)
                    continue;

                if (hGroupController.groupID == m_nGroupID)
                    return hGroupController;
            }

            return null;
        }

        protected bool TryGetCanvasGroupController(List<IDialogueEventData> lstData, out DSC_Dialogue_CanvasGroupController hOutController)
        {
            hOutController = GetCanvasGroupController(lstData);
            return hOutController != null;
        }

        #endregion
    }
}