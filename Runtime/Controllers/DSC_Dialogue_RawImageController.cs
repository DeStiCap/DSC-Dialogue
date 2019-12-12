using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(RawImage))]
    public class DSC_Dialogue_RawImageController : MonoBehaviour
    {
        #region Variable

        RectTransform m_hRectTransform;
        RawImage m_hRawImage;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hRectTransform = GetComponent<RectTransform>();
            m_hRawImage = GetComponent<RawImage>();
        }

        #endregion

        #region Main

        public void SetImage(Texture hTexture)
        {
            m_hRawImage.texture = hTexture;
        }

        public void SetPosition(Vector2 vPosition)
        {
            m_hRectTransform.anchoredPosition = vPosition;
        }

        public void SetSize(Vector2 vSize)
        {
            m_hRectTransform.sizeDelta = vSize;
        }

        public void SetSizeToNative()
        {
            m_hRawImage.SetNativeSize();
        }

        public void SetRotation(Vector3 vRotation)
        {
            m_hRectTransform.rotation = Quaternion.Euler(vRotation);
        }

        public void SetColor(Color hColor)
        {
            m_hRawImage.color = hColor;
        }

        public void ShowImage()
        {
            m_hRawImage.enabled = true;
        }

        public void HideImage()
        {
            m_hRawImage.enabled = false;
        }

        #endregion
    }
}