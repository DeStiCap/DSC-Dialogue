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

        #endregion

        #endregion

        #region Base - Override

        public override void SetEnable(bool bEnable)
        {
            
        }

        #endregion

        #region Events

        public void RunEvent()
        {
            m_hRunEvent?.Invoke();
        }

        #endregion
    }
}