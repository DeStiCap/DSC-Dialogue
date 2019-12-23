using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_CanvasGroupController : UIGroupController<DSC_Dialogue_CanvasController>
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected List<DSC_Dialogue_CanvasController> m_lstCanvasController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType groupType { get { return UIType.Canvas; } }
        protected override List<DSC_Dialogue_CanvasController> uiControllerList { get { return m_lstCanvasController; } }

        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_Canvas
                {
                    m_hGroupController = this,
                });
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_Canvas>();
            }
        }

        #endregion

        #region Main

        public virtual void SetEnable(int nIndex,UIType eGroupType, bool bEnable)
        {
            var hController = GetCanvasController(nIndex);
            hController?.SetEnable(eGroupType, bEnable);
        }

        #endregion

        #region Helper

        protected bool HasCanvasInList()
        {
            return (m_lstCanvasController != null && m_lstCanvasController.Count > 0);
        }

        protected DSC_Dialogue_CanvasController GetCanvasController(int nIndex)
        {
            if (nIndex < 0 || m_lstCanvasController == null || m_lstCanvasController.Count <= nIndex)
                return null;

            return m_lstCanvasController[nIndex];
        }

        protected bool TryGetCanvasController(int nIndex,out DSC_Dialogue_CanvasController hOutController)
        {
            hOutController = GetCanvasController(nIndex);
            return hOutController != null;
        }

        #endregion
    }
}