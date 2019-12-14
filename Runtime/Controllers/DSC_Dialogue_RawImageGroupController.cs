using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_RawImageGroupController : BaseDialogueUIGroup
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected DSC_Dialogue_RawImageController[] m_arrRawImageController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType GroupType { get { return UIType.RawImage; } }

        #endregion

        #endregion

        #region Base - Mono

        private void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_RawImage
                {
                    m_hGroupController = this,
                });
            }
        }

        private void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_RawImage>();
            }
        }

        #endregion

        #region Base - Override

        public override void SetEnable(int nIndex, bool bEnable)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetEnable(bEnable);
        }

        public override void SetAllEnable(bool bEnable)
        {
            if (!HasRawImageInArray())
                return;

            for(int i = 0; i < m_arrRawImageController.Length; i++)
            {
                m_arrRawImageController[i]?.SetEnable(bEnable);
            }
        }

        #endregion

        #region Main

        public void SetTexture(int nIndex, Texture hTexture)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetImage(hTexture);
        }

        public void SetPosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetPosition(vPosition);
        }

        public void SetSize(int nIndex, Vector2 vSize)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetSize(vSize);
        }

        public void SetSizeToNative(int nIndex)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetSizeToNative();
        }

        public void SetRotation(int nIndex, Vector3 vRotation)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetRotation(vRotation);
        }

        public void SetColor(int nIndex, Color hColor)
        {
            var hController = GetRawImageController(nIndex); ;
            hController?.SetColor(hColor);
        }

        #endregion

        #region Helper

        protected bool HasRawImageInArray()
        {
            return (m_arrRawImageController != null && m_arrRawImageController.Length > 0);
        }

        protected DSC_Dialogue_RawImageController GetRawImageController(int nIndex)
        {
            DSC_Dialogue_RawImageController hResult = null;

            if (nIndex < 0 || m_arrRawImageController == null || m_arrRawImageController.Length <= nIndex)
                return hResult;

            hResult = m_arrRawImageController[nIndex];

            return hResult;
        }

        protected bool TryGetRawImageController(int nIndex, out DSC_Dialogue_RawImageController hOutController)
        {
            hOutController = GetRawImageController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}