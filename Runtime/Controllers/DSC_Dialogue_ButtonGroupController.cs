using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ButtonGroupController : BaseDialogueUIGroup
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DSC_Dialogue_ButtonController[] m_arrButtonController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType GroupType { get { return UIType.Button; } }

        #endregion

        #endregion

        #region Base - Override

        public override void SetEnable(int nIndex,bool bEnable)
        {
            var hController = GetButtonController(nIndex);

            hController?.SetEnable(bEnable);
        }

        public override void SetAllEnable(bool bEnable)
        {
            if (!HasButtonControllerInArray())
                return;

            for(int i = 0; i < m_arrButtonController.Length; i++)
            {
                m_arrButtonController[i]?.SetEnable(bEnable);
            }
        }

        #endregion

        #region Helper

        protected bool HasButtonControllerInArray()
        {
            return (m_arrButtonController != null && m_arrButtonController.Length > 0);
        }

        protected DSC_Dialogue_ButtonController GetButtonController(int nIndex)
        {
            if (nIndex < 0 || m_arrButtonController == null || m_arrButtonController.Length <= nIndex)
                return null;

            return m_arrButtonController[nIndex];
        }

        protected bool TryGetButtonController(int nIndex,out DSC_Dialogue_ButtonController hOutController)
        {
            hOutController = GetButtonController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}