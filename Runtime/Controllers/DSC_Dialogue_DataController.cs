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

        [System.Serializable]
        protected class EventDialogueData : UnityEvent<Dialogue>
        {

        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [Header("Data")]
        [SerializeField] protected DialogueData m_DialogueData;

        [Header("Current")]
        [SerializeField] protected int m_nCurrentDialogueIndex;

        [Header("Events")]
        [SerializeField] protected EventDialogueData m_OnDialogueStart;
        [SerializeField] protected EventDialogueData m_OnDialogueChange;
        [SerializeField] protected UnityEvent m_OnDialogueEnd;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public List<IDialogueEventData> DialogueEventDataList { get { return m_lstDialogueEventData; } }

        #endregion

        protected List<IDialogueEventData> m_lstDialogueEventData = new List<IDialogueEventData>();

        protected DSC_Dialogue_ReplaceController m_hReplaceController;

        #endregion

        #region Events

        public void StartDialogue()
        {
            if (!TryGetAllDialogueInData(out var arrDialogue))
                return;

            m_nCurrentDialogueIndex = 0;
            var hDialogue = arrDialogue[m_nCurrentDialogueIndex];
            RunDialogue(hDialogue);
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
            var hDialogue = arrDialogue[m_nCurrentDialogueIndex];
            RunDialogue(hDialogue);
        }

        #endregion

        #region Main

        public void SetReplaceController(DSC_Dialogue_ReplaceController hReplaceController)
        {
            m_hReplaceController = hReplaceController;
        }

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

        protected void RunDialogue(Dialogue hDialogue)
        {
            m_hReplaceController?.CheckReplaceWord(ref hDialogue);

            StartAllEventInDialogue(hDialogue);
            m_OnDialogueStart.Invoke(hDialogue);
        }

        protected void StartAllEventInDialogue(Dialogue hDialogue)
        {
            var arrEvent = hDialogue.m_arrEvent;
            if (arrEvent == null || arrEvent.Length <= 0)
                return;

            for(int i = 0; i < arrEvent.Length; i++)
            {
                var hEvent = arrEvent[i];
                if (hEvent == null)
                    continue;

                hEvent.OnStart(m_lstDialogueEventData);
            }
        }

        #endregion


        #region Helper

        protected Dialogue[] GetAllDialogueInData()
        {
            Dialogue[] hResult = null;
            if (m_DialogueData == null)
                return hResult;

            hResult = m_DialogueData.AllDialogue;

            return hResult;
        }

        protected bool TryGetAllDialogueInData(out Dialogue[] arrOutDialogue)
        {
            arrOutDialogue = GetAllDialogueInData();

            return arrOutDialogue != null;
        }

        #endregion
    }
}