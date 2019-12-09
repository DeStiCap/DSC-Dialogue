﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_Image", menuName = "DSC/Dialogue/Events/Image")]
    public class DialogueEvent_Image : DialogueEvent
    {
        #region Enum

        protected enum ImageEventType
        {
            None,
            SetSprite,
            SetPosition,
            SetSize,
            SetSizeNative,
            SetSpritePosition,
            SetSpriteSize,
            SetSpriteSizeNative,
            SetPositionSize,
            SetPositionSizeNative,
            SetSpritePositionSize,
            SetSpritePositionSizeNative,
            Show,
            Hide,
        }

        #endregion

        #region Data

        [System.Serializable]
        protected struct DialogueEvent_ImageData
        {
            public ImageEventType m_eType;
            public int m_nIndex;
            public Sprite m_hSprite;
            public Vector2 m_vPosition;
            public Vector2 m_vSize;
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DialogueEvent_ImageData[] m_arrEventData;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override DialogueEventType EventType { get { return DialogueEventType.Image; } }

        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (m_arrEventData == null || m_arrEventData.Length <= 0)
                return;

            if (!lstData.TryGetData(out DialogueEventData_Image hOutData))
                return;

            var hImageGroupController = hOutData.m_hGroupController;
            if (hImageGroupController == null)
                return;

            for (int i = 0; i < m_arrEventData.Length; i++)
            {
                var hEventData = m_arrEventData[i];

                switch (hEventData.m_eType)
                {
                    case ImageEventType.None:
                        continue;

                    case ImageEventType.SetSprite:
                        SetSprite(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetPosition:
                        SetPosition(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSize:
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSizeNative:
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSpritePosition:
                        SetSprite(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSpriteSize:
                        SetSprite(hImageGroupController, hEventData);
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSpriteSizeNative:
                        SetSprite(hImageGroupController, hEventData);
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetPositionSize:
                        SetPosition(hImageGroupController, hEventData);
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetPositionSizeNative:
                        SetPosition(hImageGroupController, hEventData);
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSpritePositionSize:
                        SetSprite(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetSpritePositionSizeNative:
                        SetSprite(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.Show:
                        ShowImage(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.Hide:
                        HideImage(hImageGroupController, hEventData);
                        break;
                }
            }
        }

        #endregion

        #region Main

        protected virtual void SetSprite(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.SetImageSprite(hEventData.m_nIndex, hEventData.m_hSprite);
        }

        protected virtual void SetPosition(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.SetImagePosition(hEventData.m_nIndex, hEventData.m_vPosition);
        }

        protected virtual void SetSize(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.SetImageSize(hEventData.m_nIndex, hEventData.m_vSize);
        }

        protected virtual void SetSizeToNative(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.SetImageSizeToNative(hEventData.m_nIndex);
        }

        protected virtual void ShowImage(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.ShowImage(hEventData.m_nIndex);
        }

        protected virtual void HideImage(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.HideImage(hEventData.m_nIndex);
        }

        #endregion

        #region Helper

        protected DSC_Dialogue_ImageGroupController GetImageGroupController(List<IDialogueEventData> lstData)
        {
            DSC_Dialogue_ImageGroupController hResult = null;

            if (lstData.TryGetData(out DialogueEventData_Image hOutData))
            {
                hResult = hOutData.m_hGroupController;
            }

            return hResult;
        }

        #endregion

    }
}