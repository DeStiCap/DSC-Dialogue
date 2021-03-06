﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace DSC.Dialogue
{
    public class DSC_Dialogue_TypingController : MonoBehaviour
    {
        #region Data

        [System.Serializable]
        protected struct EventTyping
        {
            public UnityEvent m_hStartTyping;
            public UnityEvent m_hOnTyping;
            public UnityEvent m_hEndTyping;
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [Header("Dialogue Controller")]
        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected DSC_Dialogue_TextGroupController m_hDialogueTextGroup;

        [Header("Option")]
        [Min(0)]
        [SerializeField] protected float m_fTypingDelayTime = 0.05f;
        [Min(0)]
        [SerializeField] protected float m_fEndEventDelayTime;
        [SerializeField] protected AudioClip m_hTypingSound;
        [SerializeField] protected bool m_bUseRealTime;

        [Header("Events")]
        [SerializeField] protected EventTyping m_hTypingEvent;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public float typingDelayTime
        {
            get
            {
                return m_fTypingDelayTime;
            }

            set
            {
                m_fTypingDelayTime = value;
                if (m_fTypingDelayTime < 0)
                    m_fTypingDelayTime = 0;
            }
        }

        public float endEventDelayTime
        {
            get
            {
                return m_fEndEventDelayTime;
            }

            set
            {
                m_fEndEventDelayTime = value;
                if (m_fEndEventDelayTime < 0)
                    m_fEndEventDelayTime = 0;
            }
        }

        public AudioClip typingSound
        {
            get
            {
                return m_hTypingSound;
            }

            set
            {
                m_hTypingSound = value;
            }
        }

        protected DSC_Dialogue_DataController dataController
        {
            get
            {
                if (m_hDataController == null)
                    m_hDataController = GetComponent<DSC_Dialogue_DataController>();

                if (m_hDataController == null)
                    Debug.LogWarning("Don't have data controller in typing controller.");

                return m_hDataController;
            }
        }

        public DSC_Dialogue_TextGroupController dialogueTextGroup
        {
            get
            {
                if (m_hDialogueTextGroup == null)
                    Debug.Log("Don't have dialogue text group set in dialogue typing controller.");

                return m_hDialogueTextGroup;
            }
        }

        protected TextMeshProUGUI dialogueText
        {
            get
            {
                if (dialogueTextGroup == null)
                    return null;

                return m_hDialogueTextGroup.dialogueText;
            }
        }

        protected AudioSource typingAudioSource
        {
            get
            {
                if (m_hTypingAudioSource == null)
                    m_hTypingAudioSource = gameObject.AddComponent<AudioSource>();

                return m_hTypingAudioSource;
            }
        }

        #endregion

        protected Dialogue m_hCurrentDialogue;
        protected bool m_bIsTyping;
        protected bool m_bWaitEndTyping;
        protected int m_nCurrentCharIndex;
        protected float m_fLastTypingTime = -100f;
        protected AudioSource m_hTypingAudioSource;

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (dataController && m_hDataController.dialogueEventDataList != null)
            {
                if (m_hDataController.dialogueEventDataList.TryGetData(out DialogueEventData_MonoBehaviour<DSC_Dialogue_TypingController> hOutData, out int nOutIndex))
                {
                    hOutData.m_hMono = this;
                    m_hDataController.dialogueEventDataList[nOutIndex] = hOutData;
                }
                else
                {


                    m_hDataController.dialogueEventDataList.Add(new DialogueEventData_MonoBehaviour<DSC_Dialogue_TypingController>
                    {
                        m_hMono = this
                    });
                }
            }
        }

        /*
        protected virtual void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.dialogueEventDataList != null)
            {
                if (m_hDataController.dialogueEventDataList.TryGetData(out DialogueEventData_MonoBehaviour<DSC_Dialogue_TypingController> hOutData, out int nOutIndex))
                {
                    m_hDataController.dialogueEventDataList.RemoveAt(nOutIndex);
                }
            }
        }*/

        protected virtual void Update()
        {
            if (m_bWaitEndTyping)
            {
                WaitEndTyping();
            }
            else if (m_bIsTyping)
            {
                Typing();
            }
        }

        #endregion

        #region Events

        public void StartNewDialogue(DialogueData hDialogueData)
        {
            if (dataController == null)
                return;

            m_hDataController.SetAndStartNewDialogueData(hDialogueData);
        }

        public void SetCurrentDialogue(Dialogue hDialogue)
        {
            if (m_bIsTyping)
                EndTyping();

            m_hCurrentDialogue = hDialogue;

            if (!TryGetDialogueText(out var hText))
                return;
            
            hText.SetText(hDialogue.m_sDialogue);
            
            StartTyping();
        }

        public void OnInteraction()
        {
            if (dataController == null || dialogueText == null)
                return;

            if (m_bWaitEndTyping)
            {
                FinishTypingText();
                EndTyping();
            }
            else if (m_bIsTyping)
            {
                FinishTypingText();
                StartWaitEndTyping();
            }
            else
            {
                dataController.NextDialogue();
            }
        }

        #endregion

        #region Main

        protected void StartTyping()
        {
            var hDialogueText = dialogueText;

            hDialogueText.maxVisibleCharacters = 0;
            m_bIsTyping = true;
            m_nCurrentCharIndex = 0;

            m_hTypingEvent.m_hStartTyping?.Invoke();

            if (m_hCurrentDialogue.m_sDialogue == null || m_nCurrentCharIndex >= m_hCurrentDialogue.m_sDialogue.Length)
            {
                EndTyping();
            }
            else if (m_fTypingDelayTime == 0)
            {
                FinishTypingText();
                EndTyping();
            }
        }

        protected void Typing()
        {
            float fTime = m_bUseRealTime ? Time.unscaledTime : Time.time;
            if (fTime < m_fLastTypingTime + m_fTypingDelayTime)
                return;

            var hDialogueText = dialogueText;

            if (m_hCurrentDialogue.m_sDialogue.Length <= m_nCurrentCharIndex)
            {
                StartWaitEndTyping();
                return;
            }
            
            m_nCurrentCharIndex++;

            m_fLastTypingTime = fTime;

            hDialogueText.maxVisibleCharacters = m_nCurrentCharIndex;

            if (m_hTypingSound != null)
            {
                typingAudioSource.PlayOneShot(m_hTypingSound);
            }

            RunDialogueEventOnExecute(m_hCurrentDialogue);

            m_hTypingEvent.m_hOnTyping?.Invoke();
        }

        protected void StartWaitEndTyping()
        {
            m_bWaitEndTyping = true;
            WaitEndTyping();
        }

        protected void WaitEndTyping()
        {
            float fTime = m_bUseRealTime ? Time.unscaledTime : Time.time;
            if (fTime >= m_fLastTypingTime + m_fEndEventDelayTime)
            {
                EndTyping();
            }
        }

        protected void EndTyping()
        {
            m_bIsTyping = false;
            m_bWaitEndTyping = false;

            RunDialogueEventOnEnd(m_hCurrentDialogue);

            m_hTypingEvent.m_hEndTyping?.Invoke();
        }

        protected void FinishTypingText()
        {
            var hDialogueText = dialogueText;
            hDialogueText.maxVisibleCharacters = m_hCurrentDialogue.m_sDialogue.Length;

            m_fLastTypingTime = m_bUseRealTime ? Time.unscaledTime : Time.time;
        }

        #endregion

        #region Helper

        protected bool TryGetDialogueText(out TextMeshProUGUI hDialogueText)
        {
            hDialogueText = dialogueText;
            return hDialogueText != null;
        }

        protected void RunDialogueEventOnExecute(Dialogue hDialogue)
        {
            var arrEvent = hDialogue.m_arrEvent;
            if (arrEvent == null || arrEvent.Length <= 0)
                return;

            
            for (int i = 0; i < arrEvent.Length; i++)
            {
                var hEvent = arrEvent[i];
                if (hEvent != null)
                    hEvent.OnExecute(dataController.dialogueEventDataList);
            }
        }

        protected void RunDialogueEventOnEnd(Dialogue hDialogue)
        {
            var arrEvent = hDialogue.m_arrEvent;
            if (arrEvent == null || arrEvent.Length <= 0)
                return;

            for (int i = 0; i < arrEvent.Length; i++)
            {
                var hEvent = arrEvent[i];
                if (hEvent != null)
                    hEvent.OnEnd(dataController.dialogueEventDataList);
            }
        }

        #endregion
    }
}