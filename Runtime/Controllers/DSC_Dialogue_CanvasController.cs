using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(Canvas))]
    public class DSC_Dialogue_CanvasController : BaseDialogueUI
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] BaseDialogueUIGroup[] m_arrGroup;

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

        public void SetEnable(UIType eGroupType, bool bEnable)
        {
            if (!TryGetGroupController(eGroupType,out var hOutGroup))
                return;

            hOutGroup.SetAllEnable(bEnable);
        }

        #endregion

        #region Helper

        protected bool HasGroupInArray()
        {
            return (m_arrGroup != null && m_arrGroup.Length > 0);
        }

        protected BaseDialogueUIGroup GetGroupController(UIType eGroupType)
        {
            if (!HasGroupInArray())
                return null;

            for (int i = 0; i < m_arrGroup.Length; i++)
            {
                var hGroup = m_arrGroup[i];
                if (hGroup == null || hGroup.GroupType != eGroupType)
                    continue;

                return hGroup;
            }

            return null;
        }

        protected bool TryGetGroupController(UIType eGroupType,out BaseDialogueUIGroup hOutGroup)
        {
            hOutGroup = GetGroupController(eGroupType);

            return hOutGroup != null;
        }

        #endregion
    }
}