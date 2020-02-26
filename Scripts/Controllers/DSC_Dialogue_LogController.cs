using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Dialogue
{
    public class DSC_Dialogue_LogController : MonoBehaviour
    {
        #region Variable

        protected List<Dialogue> m_lstLog = new List<Dialogue>();

        #endregion

        #region Events

        public void AddLog(Dialogue hDialogue)
        {
            m_lstLog.Add(hDialogue);
        }

        public void ClearLog()
        {
            m_lstLog.Clear();
        }

        #endregion
    }
}