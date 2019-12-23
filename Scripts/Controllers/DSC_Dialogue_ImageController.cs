using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DSC.UI;

namespace DSC.DialogueSystem
{
    [RequireComponent(typeof(Image))]
    public class DSC_Dialogue_ImageController : BaseUIController
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

#pragma warning restore 0649
        #endregion


        RectTransform m_hRectTransform;
        Image m_hImage;

        #endregion

        #region Base - Mono

        private void Awake()
        {
            m_hRectTransform = GetComponent<RectTransform>();
            m_hImage = GetComponent<Image>();
        }

        #endregion

        #region Main

        public void SetImage(Sprite hSprite)
        {
            m_hImage.sprite = hSprite;
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
            m_hImage.SetNativeSize();
        }

        public void SetRotation(Vector3 vRotation)
        {
            m_hRectTransform.rotation = Quaternion.Euler(vRotation);
        }

        public void SetColor(Color hColor)
        {
            m_hImage.color = hColor;
        }

        public void ShowImage()
        {
            m_hImage.enabled = true;
        }

        public void HideImage()
        {
            m_hImage.enabled = false;
        }

        public override void SetEnable(bool bEnable)
        {
            m_hImage.enabled = bEnable;
        }

        #endregion
    }
}