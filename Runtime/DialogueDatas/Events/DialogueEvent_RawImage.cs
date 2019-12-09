using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_RawImage", menuName = "DSC/Dialogue/Events/Raw Image")]
    public class DialogueEvent_RawImage : DialogueEvent
    {
        #region Enum

        protected enum RawImageEventType
        {
            None,
            SetTexture,
            SetPosition,
            SetSize,
            SetSizeNative,
            SetTexturePosition,
            SetTextureSize,
            SetTextureSizeNative,
            SetPositionSize,
            SetPositionSizeNative,
            SetTexturePositionSize,
            SetTexturePositionSizeNative,
            Show,
            Hide,
        }

        #endregion

        #region Data

        [System.Serializable]
        protected struct DialogueEvent_RawImageData
        {
            public RawImageEventType m_eType;
            public int m_nIndex;
            public Texture m_hTexture;
            public Vector2 m_vPosition;
            public Vector2 m_vSize;
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DialogueEvent_RawImageData[] m_arrEventData;

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
                    case RawImageEventType.None:
                        continue;

                    case RawImageEventType.SetTexture:
                        SetTexture(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetPosition:
                        SetPosition(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetSize:
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetSizeNative:
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetTexturePosition:
                        SetTexture(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetTextureSize:
                        SetTexture(hImageGroupController, hEventData);
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetTextureSizeNative:
                        SetTexture(hImageGroupController, hEventData);
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetPositionSize:
                        SetPosition(hImageGroupController, hEventData);
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetPositionSizeNative:
                        SetPosition(hImageGroupController, hEventData);
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetTexturePositionSize:
                        SetTexture(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
                        SetSize(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.SetTexturePositionSizeNative:
                        SetTexture(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
                        SetSizeToNative(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.Show:
                        ShowImage(hImageGroupController, hEventData);
                        break;

                    case RawImageEventType.Hide:
                        HideImage(hImageGroupController, hEventData);
                        break;
                }
            }
        }

        #endregion

        #region Main

        protected virtual void SetTexture(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_RawImageData hEventData)
        {
            hImageGroupController.SetRawImageTexture(hEventData.m_nIndex, hEventData.m_hTexture);
        }

        protected virtual void SetPosition(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_RawImageData hEventData)
        {
            hImageGroupController.SetRawImagePosition(hEventData.m_nIndex, hEventData.m_vPosition);
        }

        protected virtual void SetSize(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_RawImageData hEventData)
        {
            hImageGroupController.SetRawImageSize(hEventData.m_nIndex, hEventData.m_vSize);
        }

        protected virtual void SetSizeToNative(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_RawImageData hEventData)
        {
            hImageGroupController.SetRawImageSizeToNative(hEventData.m_nIndex);
        }

        protected virtual void ShowImage(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_RawImageData hEventData)
        {
            hImageGroupController.ShowRawImage(hEventData.m_nIndex);
        }

        protected virtual void HideImage(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_RawImageData hEventData)
        {
            hImageGroupController.HideRawImage(hEventData.m_nIndex);
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