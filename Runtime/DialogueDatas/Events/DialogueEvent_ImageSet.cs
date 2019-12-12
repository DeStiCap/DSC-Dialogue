using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_ImageSet", menuName = "DSC/Dialogue/Events/Image Set")]
    public class DialogueEvent_ImageSet : DialogueEvent
    {
        #region Enum

        [System.Flags]
        protected enum ImageSetType
        {
            SetSprite     =   1 << 0,
            SetPosition   =   1 << 1,
            SetSize       =   1 << 2,
            SetRotation   =   1 << 3,
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [EnumMask]
        [SerializeField] protected ImageSetType m_eType;
        [SerializeField] protected int m_nIndex;
        [SerializeField] Sprite m_hSprite;
        [SerializeField] Vector2 m_vPosition;
        [SerializeField] Vector2 m_vSize;
        [SerializeField] bool m_bUseNativeSize;
        [SerializeField] Vector3 m_vRotation;

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

            if (FlagUtility.HasFlagUnsafe(m_eType, ImageSetType.SetSprite))
                SetSprite(hImageGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, ImageSetType.SetPosition))
                SetPosition(hImageGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, ImageSetType.SetSize))
                SetSize(hImageGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, ImageSetType.SetRotation))
                SetRotation(hImageGroupController);
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
            if (!m_bUseNativeSize)
                hImageGroupController.SetImageSize(m_nIndex, m_vSize);
            else
                hImageGroupController.SetImageSizeToNative(m_nIndex);
        }

        protected virtual void SetRotation(DSC_Dialogue_ImageGroupController hImageGroupController)
        {
            hImageGroupController.SetImageRotation(m_nIndex, m_vRotation);
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