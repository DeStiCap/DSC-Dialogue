using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DSC.Dialogue
{
    [CreateAssetMenu(fileName = "DialogueEvent_SceneLoad", menuName = "DSC/Dialogue/Events/Scene Load")]
    public class DialogueEvent_SceneLoad : DialogueEvent
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] int m_nSceneIndex;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            SceneManager.LoadScene(m_nSceneIndex);
        }

        #endregion
    }
}