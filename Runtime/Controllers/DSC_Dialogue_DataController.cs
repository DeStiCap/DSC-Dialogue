using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_DataController : MonoBehaviour
    {
        #region Temp

        // Need to transfer this to Core System.

        [System.Serializable]
        class EventString : UnityEvent<string>
        {

        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [Header("Data")]
        [SerializeField] DialogueData m_DialogueData;

        [Header("Current")]
        [SerializeField] int m_nCurrentDialogueIndex;

        [Header("Events")]
        [SerializeField] EventString m_OnDialogueStart;
        [SerializeField] EventString m_OnDialogueChange;
        [SerializeField] UnityEvent m_OnDialogueEnd;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Events

        public void StartDialogue()
        {
            if (!TryGetAllDialogueInData(out var arrDialogue))
                return;

            m_nCurrentDialogueIndex = 0;
            m_OnDialogueStart.Invoke(arrDialogue[m_nCurrentDialogueIndex].m_sDialogue);
        }

        public void NextDialogue()
        {
            if (!TryGetAllDialogueInData(out var arrDialogue))
                return;

            if(arrDialogue.Length <= m_nCurrentDialogueIndex + 1)
            {
                m_OnDialogueEnd.Invoke();
                return;
            }

            m_nCurrentDialogueIndex++;

            m_OnDialogueChange.Invoke(arrDialogue[m_nCurrentDialogueIndex].m_sDialogue);
        }

        #endregion

        #region Main

        public string GetCurrentDialogue()
        {
            string sResult = null;

            if (m_DialogueData == null)
                return sResult;


            var arrDialogue = m_DialogueData.AllDialogue;
            if (arrDialogue == null || arrDialogue.Length <= 0 || arrDialogue.Length <= m_nCurrentDialogueIndex)
                return sResult;

            sResult = arrDialogue[m_nCurrentDialogueIndex].m_sDialogue;

            return sResult;
        }

        #endregion


        #region Helper

        Dialogue[] GetAllDialogueInData()
        {
            Dialogue[] hResult = null;
            if (m_DialogueData == null)
                return hResult;

            hResult = m_DialogueData.AllDialogue;

            return hResult;
        }

        bool TryGetAllDialogueInData(out Dialogue[] arrOutDialogue)
        {
            arrOutDialogue = GetAllDialogueInData();

            return arrOutDialogue != null;
        }

        #endregion
    }
}