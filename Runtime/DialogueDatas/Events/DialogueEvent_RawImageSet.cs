using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_RawImageSet", menuName = "DSC/Dialogue/Events/Raw Image Set")]
    public class DialogueEvent_RawImageSet : DialogueEvent
    {
        #region Enum

        protected enum RawImageSetType
        {
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

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected RawImageSetType m_eType;
        [SerializeField] protected int m_nIndex;
        [SerializeField] Texture m_hTexture;
        [SerializeField] Vector2 m_vPosition;
        [SerializeField] Vector2 m_vSize;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (!lstData.TryGetData(out DialogueEventData_Image hOutData))
                return;

            var hImageGroupController = hOutData.m_hGroupController;
            if (hImageGroupController == null)
                return;

            switch (m_eType)
            {
                case RawImageSetType.SetTexture:
                    SetTexture(hImageGroupController);
                    break;

                case RawImageSetType.SetPosition:
                    SetPosition(hImageGroupController);
                    break;

                case RawImageSetType.SetSize:
                    SetSize(hImageGroupController);
                    break;

                case RawImageSetType.SetSizeNative:
                    SetSizeToNative(hImageGroupController);
                    break;

                case RawImageSetType.SetTexturePosition:
                    SetTexture(hImageGroupController);
                    SetPosition(hImageGroupController);
                    break;

                case RawImageSetType.SetTextureSize:
                    SetTexture(hImageGroupController);
                    SetSize(hImageGroupController);
                    break;

                case RawImageSetType.SetTextureSizeNative:
                    SetTexture(hImageGroupController);
                    SetSizeToNative(hImageGroupController);
                    break;

                case RawImageSetType.SetPositionSize:
                    SetPosition(hImageGroupController);
                    SetSize(hImageGroupController);
                    break;

                case RawImageSetType.SetPositionSizeNative:
                    SetPosition(hImageGroupController);
                    SetSizeToNative(hImageGroupController);
                    break;

                case RawImageSetType.SetTexturePositionSize:
                    SetTexture(hImageGroupController);
                    SetPosition(hImageGroupController);
                    SetSize(hImageGroupController);
                    break;

                case RawImageSetType.SetTexturePositionSizeNative:
                    SetTexture(hImageGroupController);
                    SetPosition(hImageGroupController);
                    SetSizeToNative(hImageGroupController);
                    break;

                case RawImageSetType.Show:
                    ShowImage(hImageGroupController);
                    break;

                case RawImageSetType.Hide:
                    HideImage(hImageGroupController);
                    break;
            }
        }

        #endregion

        #region Main

        protected virtual void SetTexture(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetRawImageTexture(m_nIndex, m_hTexture);
        }

        protected virtual void SetPosition(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetRawImagePosition(m_nIndex, m_vPosition);
        }

        protected virtual void SetSize(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetRawImageSize(m_nIndex, m_vSize);
        }

        protected virtual void SetSizeToNative(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetRawImageSizeToNative(m_nIndex);
        }

        protected virtual void ShowImage(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.ShowRawImage(m_nIndex);
        }

        protected virtual void HideImage(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.HideRawImage(m_nIndex);
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