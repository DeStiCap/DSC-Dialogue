using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Dialogue
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
        [SerializeField] protected DialogueData m_hDialogueData;

        [Header("Processing")]
        [SerializeField] protected BaseDialoguePreProcessing[] m_arrPreProcessing;

        [Header("Events")]
        [SerializeField] protected EventDialogueData m_OnDialogueStart;
        [SerializeField] protected EventDialogueData m_OnDialogueChange;
        [SerializeField] protected UnityEvent m_OnDialogueEnd;

        [Header("Runtime Data")]
        [SerializeField] protected int m_nCurrentDialogueIndex;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public List<IDialogueEventData> dialogueEventDataList { get { return m_lstDialogueEventData; } }

        #endregion

        protected List<IDialogueEventData> m_lstDialogueEventData = new List<IDialogueEventData>();

        #endregion

        #region Events

        public void SetNewDialogueData(DialogueData hData)
        {
            m_hDialogueData = hData;
        }

        public void SetAndStartNewDialogueData(DialogueData hData)
        {
            SetNewDialogueData(hData);
            StartDialogue();
        }

        public void StartDialogue()
        {
            if (!TryGetAllDialogueInData(out var arrDialogue))
                return;

            m_nCurrentDialogueIndex = 0;
            var hDialogue = arrDialogue[m_nCurrentDialogueIndex];
            RunDialogue(ref hDialogue);
            m_OnDialogueStart.Invoke(hDialogue);
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
            RunDialogue(ref hDialogue);
            m_OnDialogueChange.Invoke(hDialogue);
        }

        #endregion

        #region Main

        public string GetCurrentDialogue()
        {
            string sResult = null;

            if (m_hDialogueData == null)
                return sResult;


            var arrDialogue = m_hDialogueData.AllDialogue;
            if (arrDialogue == null || arrDialogue.Length <= 0 || arrDialogue.Length <= m_nCurrentDialogueIndex)
                return sResult;

            sResult = arrDialogue[m_nCurrentDialogueIndex].m_sDialogue;

            return sResult;
        }

        protected void RunDialogue(ref Dialogue hDialogue)
        {
            RunPreProcessing(ref hDialogue);

            StartAllEventInDialogue(hDialogue);
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
            if (m_hDialogueData == null)
                return hResult;

            hResult = m_hDialogueData.AllDialogue;

            return hResult;
        }

        protected bool TryGetAllDialogueInData(out Dialogue[] arrOutDialogue)
        {
            arrOutDialogue = GetAllDialogueInData();

            return arrOutDialogue != null;
        }

        protected void RunPreProcessing(ref Dialogue hDialogue)
        {
            if (m_arrPreProcessing == null || m_arrPreProcessing.Length <= 0)
                return;

            for(int i = 0; i < m_arrPreProcessing.Length; i++)
            {
                var hPreProcessing = m_arrPreProcessing[i];
                if(hPreProcessing != null)
                    hPreProcessing.PreProcessingDialogue(ref hDialogue);
            }
        }

        #endregion
    }
}