using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_RawImageSet", menuName = "DSC/Dialogue/Events/Raw Image Set")]
    public class DialogueEvent_RawImageSet : DialogueEvent
    {
        #region Enum

        [System.Flags]
        protected enum RawImageSetType
        {
            SetTexture  =   1 << 0,
            SetPosition =   1 << 1,
            SetSize     =   1 << 2,
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [EnumMask]
        [SerializeField] protected RawImageSetType m_eType;
        [SerializeField] protected int m_nIndex;
        [SerializeField] Texture m_hTexture;
        [SerializeField] Vector2 m_vPosition;
        [SerializeField] Vector2 m_vSize;
        [SerializeField] bool m_bUseNativeSize;

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

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetTexture))
                SetTexture(hImageGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetPosition))
                SetPosition(hImageGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetSize))
                SetSize(hImageGroupController);
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
            if (!m_bUseNativeSize)
                hImageGroupController.SetRawImageSize(m_nIndex, m_vSize);
            else
                hImageGroupController.SetRawImageSizeToNative(m_nIndex);
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