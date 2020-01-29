using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DSC.Dialogue
{
    [CreateAssetMenu(fileName = "DialogueEvent_SceneLoad", menuName = "DSC/Dialogue/Events/Scene Load")]
    public class DialogueEvent_SceneLoad : DialogueEvent
    {
        #region Enum

        protected enum LoadBy
        {
            Index,
            Name
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected LoadBy m_eLoadBy;
        [SerializeField] protected int m_nSceneIndex;
        [SerializeField] protected string m_sSceneName;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            switch (m_eLoadBy)
            {
                case LoadBy.Index:
                    SceneManager.LoadSceneAsync(m_nSceneIndex);
                    break;

                case LoadBy.Name:
                    SceneManager.LoadSceneAsync(m_sSceneName);
                    break;
            }
            
        }

        #endregion
    }
}