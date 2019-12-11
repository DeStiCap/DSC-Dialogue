using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_ImageSet", menuName = "DSC/Dialogue/Events/Image Set")]
    public class DialogueEvent_ImageSet : DialogueEvent
    {
        #region Enum

        protected enum ImageSetType
        {
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

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected ImageSetType m_eType;
        [SerializeField] protected int m_nIndex;
        [SerializeField] Sprite m_hSprite;
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
                case ImageSetType.SetSprite:
                    SetSprite(hImageGroupController);
                    break;

                case ImageSetType.SetPosition:
                    SetPosition(hImageGroupController);
                    break;

                case ImageSetType.SetSize:
                    SetSize(hImageGroupController);
                    break;

                case ImageSetType.SetSizeNative:
                    SetSizeToNative(hImageGroupController);
                    break;

                case ImageSetType.SetSpritePosition:
                    SetSprite(hImageGroupController);
                    SetPosition(hImageGroupController);
                    break;

                case ImageSetType.SetSpriteSize:
                    SetSprite(hImageGroupController);
                    SetSize(hImageGroupController);
                    break;

                case ImageSetType.SetSpriteSizeNative:
                    SetSprite(hImageGroupController);
                    SetSizeToNative(hImageGroupController);
                    break;

                case ImageSetType.SetPositionSize:
                    SetPosition(hImageGroupController);
                    SetSize(hImageGroupController);
                    break;

                case ImageSetType.SetPositionSizeNative:
                    SetPosition(hImageGroupController);
                    SetSizeToNative(hImageGroupController);
                    break;

                case ImageSetType.SetSpritePositionSize:
                    SetSprite(hImageGroupController);
                    SetPosition(hImageGroupController);
                    SetSize(hImageGroupController);
                    break;

                case ImageSetType.SetSpritePositionSizeNative:
                    SetSprite(hImageGroupController);
                    SetPosition(hImageGroupController);
                    SetSizeToNative(hImageGroupController);
                    break;

                case ImageSetType.Show:
                    ShowImage(hImageGroupController);
                    break;

                case ImageSetType.Hide:
                    HideImage(hImageGroupController);
                    break;
            }
        }

        #endregion

        #region Main

        protected virtual void SetSprite(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetImageSprite(m_nIndex, m_hSprite);
        }

        protected virtual void SetPosition(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetImagePosition(m_nIndex, m_vPosition);
        }

        protected virtual void SetSize(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetImageSize(m_nIndex, m_vSize);
        }

        protected virtual void SetSizeToNative(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetImageSizeToNative(m_nIndex);
        }

        protected virtual void ShowImage(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.ShowImage(m_nIndex);
        }

        protected virtual void HideImage(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.HideImage(m_nIndex);
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