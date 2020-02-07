using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DSC.Core;

namespace DSC.Dialogue
{
    public class DSC_Dialogue_UnityEventController : BaseComponentController
    {
        #region Variable

        #region Variable - Inspector

        [Header("Events")]
        [SerializeField] protected UnityEvent m_hRunEvent;

        [Header("Runtime Data")]
        [LabelName("Delay Time")]
        [ReadOnlyField]
        [SerializeField] protected float m_fDelayTime;
        [LabelName("Use Real Time")]
        [ReadOnlyField]
        [SerializeField] protected bool m_bUseRealTime;

        #endregion

        protected float m_fStartDelayTime;
        protected bool m_bDelayRun;

        #endregion

        #region Base - Mono

        protected virtual void Update()
        {
            if (!m_bDelayRun)
                return;

            float fTime = m_bUseRealTime ? Time.unscaledTime : Time.time;

            if (fTime < m_fStartDelayTime + m_fDelayTime)
                return;

            RunEvent();
        }

        #endregion

        #region Base - Override

        public override void SetEnable(bool bEnable)
        {
            
        }

        #endregion

        #region Events

        public void RunEvent()
        {
            m_bDelayRun = false;
            m_hRunEvent?.Invoke();
        }

        public void RunEvent(float fDelayTime,bool bUseRealTime)
        {
            m_fDelayTime = fDelayTime;
            m_bUseRealTime = bUseRealTime;

            if (fDelayTime <= 0)
            {
                m_fDelayTime = 0;
                RunEvent();
            }
            else
            {
                m_fStartDelayTime = bUseRealTime ? Time.unscaledTime : Time.time;
                m_bDelayRun = true;
            }
        }

        #endregion
    }
}