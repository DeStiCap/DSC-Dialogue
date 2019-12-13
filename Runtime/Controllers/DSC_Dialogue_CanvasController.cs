using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(Canvas))]
    public class DSC_Dialogue_CanvasController : MonoBehaviour
    {
        #region Variable

        Canvas m_hCanvas;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hCanvas = GetComponent<Canvas>();
        }

        #endregion

        #region Main

        public void ShowCanvas()
        {
            m_hCanvas.enabled = true;
        }

        public void HideCanvas()
        {
            m_hCanvas.enabled = false;
        }

        #endregion
    }
}