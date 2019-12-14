using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_GameObjectGroupController : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DSC_Dialogue_DataController m_hDataController;
        [SerializeField] GameObject[] m_arrGameObject;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Mono

        private void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_GameObject
                {
                    m_hGroupController = this,
                });
            }
        }

        private void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_GameObject>();
            }
        }

        #endregion

        #region Main

        public virtual void SetActiveGameObject(int nIndex,bool bActive)
        {
            var hGameObject = GetGameObject(nIndex);
            hGameObject?.SetActive(bActive);
        }

        #endregion

        #region Helper

        protected GameObject GetGameObject(int nIndex)
        {
            if (nIndex < 0 || m_arrGameObject == null || m_arrGameObject.Length <= nIndex)
                return null;

            return m_arrGameObject[nIndex];
        }

        #endregion
    }
}