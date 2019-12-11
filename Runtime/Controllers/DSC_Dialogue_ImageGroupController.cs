using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ImageGroupController : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DSC_Dialogue_DataController m_hDataController;
        [SerializeField] DSC_Dialogue_ImageController[] m_arrImageController;
        [SerializeField] DSC_Dialogue_RawImageController[] m_arrRawImageController;

#pragma warning restore 0649
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

        #region Main

        public void SetImageSprite(int nIndex, Sprite hSprite)
        {
            var hController = GetImageController(nIndex);
            hController?.SetImage(hSprite);
        }

        public void SetImagePosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetImageController(nIndex);
            hController?.SetPosition(vPosition);
        }

        public void SetImageSize(int nIndex, Vector2 vSize)
        {
            var hController = GetImageController(nIndex);
            hController?.SetSize(vSize);
        }

        public void SetImageSizeToNative(int nIndex)
        {
            var hController = GetImageController(nIndex);
            hController?.SetSizeToNative();
        }

        public void SetImageColor(int nIndex,Color hColor)
        {
            var hController = GetImageController(nIndex);
            hController?.SetColor(hColor);
        }

        public void ShowImage(int nIndex)
        {
            var hController = GetImageController(nIndex);
            hController?.ShowImage();
        }

        public void HideImage(int nIndex)
        {
            var hController = GetImageController(nIndex);
            hController?.HideImage();
        }

        public void SetRawImageTexture(int nIndex, Texture hTexture)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetImage(hTexture);
        }

        public void SetRawImagePosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetPosition(vPosition);
        }

        public void SetRawImageSize(int nIndex, Vector2 vSize)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetSize(vSize);
        }

        public void SetRawImageSizeToNative(int nIndex)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetSizeToNative();
        }

        public void SetRawImageColor(int nIndex,Color hColor)
        {
            var hController = GetRawImageController(nIndex); ;
            hController?.SetColor(hColor);
        }

        public void ShowRawImage(int nIndex)
        {
            var hController = GetRawImageController(nIndex);
            hController?.ShowImage();
        }

        public void HideRawImage(int nIndex)
        {
            var hController = GetRawImageController(nIndex);
            hController?.HideImage();
        }

        #endregion

        #region Helper

        DSC_Dialogue_ImageController GetImageController(int nIndex)
        {
            DSC_Dialogue_ImageController hResult = null;

            if (nIndex < 0 ||  m_arrImageController.Length <= nIndex)
                return hResult;

            hResult = m_arrImageController[nIndex];
            
            return hResult;
        }

        bool TryGetImageController(int nIndex,out DSC_Dialogue_ImageController hOutController)
        {
            hOutController = GetImageController(nIndex);

            return hOutController != null;
        }

        DSC_Dialogue_RawImageController GetRawImageController(int nIndex)
        {
            DSC_Dialogue_RawImageController hResult = null;

            if (nIndex < 0 || m_arrRawImageController.Length <= nIndex)
                return hResult;

            hResult = m_arrRawImageController[nIndex];

            return hResult;
        }

        bool TryGetRawImageController(int nIndex,out DSC_Dialogue_RawImageController hOutController)
        {
            hOutController = GetRawImageController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}