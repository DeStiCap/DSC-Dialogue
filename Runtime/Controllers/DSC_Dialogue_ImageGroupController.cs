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
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
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
            if(TryGetImageController(nIndex,out var hOutController))
            {
                hOutController.SetImage(hSprite);
            }
        }

        public void SetPosition(int nIndex, Vector2 vPosition)
        {
            if(TryGetImageController(nIndex,out var hOutController))
            {
                hOutController.SetPosition(vPosition);
            }
        }

        public void ShowImage(int nIndex)
        {
            if(TryGetImageController(nIndex,out var hOutController))
            {
                hOutController.ShowImage();
            }
        }

        public void HideImage(int nIndex)
        {
            if(TryGetImageController(nIndex,out var hOutController))
            {
                hOutController.HideImage();
            }
        }

        #endregion

        #region Helper

        DSC_Dialogue_ImageController GetImageController(int nIndex)
        {
            DSC_Dialogue_ImageController hResult = null;

            for (int i = 0; i < m_arrImageController.Length; i++)
            {
                var hController = m_arrImageController[i];
                if (hController.Index == nIndex)
                {
                    hResult = hController;
                    break;
                }
            }

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