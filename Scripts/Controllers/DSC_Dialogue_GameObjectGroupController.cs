using UnityEngine;
using DSC.Core;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_GameObjectGroupController : BaseComponentGroupController
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected GameObject[] m_arrGameObject;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_GroupController<DSC_Dialogue_GameObjectGroupController>
                {
                    m_hGroupController = this,
                });
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_GroupController<DSC_Dialogue_GameObjectGroupController>>();
            }
        }

        #endregion

        #region Main

        public override void SetEnable(int nIndex, bool bEnable)
        {
            var hGameObject = GetGameObject(nIndex);
            hGameObject?.SetActive(bEnable);
        }

        public override void SetAllEnable(bool bEnable)
        {
            for(int i = 0; i < m_arrGameObject.Length; i++)
            {
                m_arrGameObject[i]?.SetActive(bEnable);
            }
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