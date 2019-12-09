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

        public void SetImage(int nIndex, Sprite hSprite)
        {
            var hController = GetImageController(nIndex);
            hController?.SetImage(hSprite);
        }

        public void SetPosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetImageController(nIndex);
            hController?.SetPosition(vPosition);
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

        #endregion
    }
}