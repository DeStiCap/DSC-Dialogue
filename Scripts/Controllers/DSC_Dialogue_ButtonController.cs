using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DSC.UI;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(Button))]
    public class DSC_Dialogue_ButtonController : BaseUIController
    {
        #region Variable

        Button m_hButton;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hButton = GetComponent<Button>();
        }

        #endregion

        #region Base - Override

        public override void SetEnable(bool bEnable)
        {
            m_hButton.enabled = bEnable;
        }

        #endregion

    }
}