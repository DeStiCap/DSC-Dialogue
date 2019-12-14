using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_CanvasGroupController : BaseDialogueUIGroup
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DSC_Dialogue_DataController m_hDataController;
        [SerializeField] DSC_Dialogue_CanvasController[] m_arrCanvasController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType GroupType { get { return UIType.Canvas; } }

        #endregion

        #endregion

        #region Base - Mono

        private void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_Canvas
                {
                    m_hGroupController = this,
                });
            }
        }

        private void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_Canvas>();
            }
        }

        #endregion

        #region Base - Override

        public override void SetEnable(int nIndex, bool bEnable)
        {
            var hController = GetCanvasController(nIndex);
            hController?.SetEnable(bEnable);
        }

        public override void SetAllEnable(bool bEnable)
        {
            if (!HasCanvasInArray())
                return;

            for (int i = 0; i < m_arrCanvasController.Length; i++)
            {
                m_arrCanvasController[i]?.SetEnable(bEnable);
            }
        }

        #endregion

        #region Main

        public void SetEnable(int nIndex,UIType eGroupType, bool bEnable)
        {
            var hController = GetCanvasController(nIndex);
            hController?.SetEnable(eGroupType, bEnable);
        }

        #endregion

        #region Helper

        protected bool HasCanvasInArray()
        {
            return (m_arrCanvasController != null && m_arrCanvasController.Length > 0);
        }

        protected DSC_Dialogue_CanvasController GetCanvasController(int nIndex)
        {
            if (nIndex < 0 || m_arrCanvasController == null || m_arrCanvasController.Length <= nIndex)
                return null;

            return m_arrCanvasController[nIndex];
        }

        protected bool TryGetCanvasController(int nIndex,out DSC_Dialogue_CanvasController hOutController)
        {
            hOutController = GetCanvasController(nIndex);
            return hOutController != null;
        }

        #endregion
    }
}