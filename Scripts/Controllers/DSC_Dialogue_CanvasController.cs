using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(Canvas))]
    public class DSC_Dialogue_CanvasController : BaseUIController
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected List<BaseUIGroupController> m_lstGroup;

#pragma warning restore 0649
        #endregion

        Canvas m_hCanvas;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hCanvas = GetComponent<Canvas>();
        }

        #endregion

        #region Main

        public override void SetEnable(bool bEnable)
        {
            m_hCanvas.enabled = bEnable;
        }

        public virtual void SetEnable(UIType eGroupType, bool bEnable)
        {
            if (!TryGetGroupController(eGroupType,out var hOutGroup))
                return;

            hOutGroup.SetAllEnable(bEnable);
        }

        #endregion

        #region Helper

        protected bool HasGroupInList()
        {
            return (m_lstGroup != null && m_lstGroup.Count > 0);
        }

        protected BaseUIGroupController GetGroupController(UIType eGroupType)
        {
            if (!HasGroupInList())
                return null;

            for (int i = 0; i < m_lstGroup.Count; i++)
            {
                var hGroup = m_lstGroup[i];
                if (hGroup == null || hGroup.groupType != eGroupType)
                    continue;

                return hGroup;
            }

            return null;
        }

        protected bool TryGetGroupController(UIType eGroupType,out BaseUIGroupController hOutGroup)
        {
            hOutGroup = GetGroupController(eGroupType);

            return hOutGroup != null;
        }

        #endregion
    }
}