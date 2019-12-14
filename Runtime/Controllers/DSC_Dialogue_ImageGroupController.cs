﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ImageGroupController : BaseDialogueUIGroup
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected DSC_Dialogue_ImageController[] m_arrImageController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType GroupType { get { return UIType.Image; } }

        #endregion

        #endregion

        #region Base - Mono

        private void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_Image
                {
                    m_hGroupController = this,
                });
            }
        }

        private void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_Image>();
            }
        }

        #endregion

        #region Base - Override

        public override void SetEnable(int nIndex, bool bEnable)
        {
            var hController = GetImageController(nIndex);
            hController?.SetEnable(bEnable);
        }

        public override void SetAllEnable(bool bEnable)
        {
            if (!HasImageInArray())
                return;

            for (int i = 0; i < m_arrImageController.Length; i++)
            {
                var hImageController = m_arrImageController[i];
                if (hImageController == null)
                    continue;

                hImageController.SetEnable(bEnable);
            }
        }

        #endregion

        #region Main

        public void SetSprite(int nIndex, Sprite hSprite)
        {
            var hController = GetImageController(nIndex);
            hController?.SetImage(hSprite);
        }

        public void SetPosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetImageController(nIndex);
            hController?.SetPosition(vPosition);
        }

        public void SetSize(int nIndex, Vector2 vSize)
        {
            var hController = GetImageController(nIndex);
            hController?.SetSize(vSize);
        }

        public void SetSizeToNative(int nIndex)
        {
            var hController = GetImageController(nIndex);
            hController?.SetSizeToNative();
        }

        public void SetRotation(int nIndex,Vector3 vRotation)
        {
            var hController = GetImageController(nIndex);
            hController?.SetRotation(vRotation);
        }

        public void SetColor(int nIndex,Color hColor)
        {
            var hController = GetImageController(nIndex);
            hController?.SetColor(hColor);
        }
        
        #endregion

        #region Helper

        protected bool HasImageInArray()
        {
            return (m_arrImageController != null && m_arrImageController.Length > 0);
        }

        protected DSC_Dialogue_ImageController GetImageController(int nIndex)
        {
            DSC_Dialogue_ImageController hResult = null;

            if (nIndex < 0 || m_arrImageController == null ||  m_arrImageController.Length <= nIndex)
                return hResult;

            hResult = m_arrImageController[nIndex];
            
            return hResult;
        }

        protected bool TryGetImageController(int nIndex,out DSC_Dialogue_ImageController hOutController)
        {
            hOutController = GetImageController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}