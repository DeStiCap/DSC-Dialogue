using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ImageGroupController : DSC_UI_ImageGroupController
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_GroupController<DSC_Dialogue_ImageGroupController>
                {
                    m_hGroupController = this,
                });
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_GroupController<DSC_Dialogue_ImageGroupController>>();
            }
        }

        #endregion
    }
}