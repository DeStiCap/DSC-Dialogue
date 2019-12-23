using System.Collections.Generic;
using UnityEngine;
using DSC.Core;

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
            SetRotation =   1 << 3,
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
        [SerializeField] Vector3 m_vRotation;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (!lstData.TryGetData(out DialogueEventData_GroupController<DSC_Dialogue_RawImageGroupController> hOutData))
                return;

            var hGroupController = hOutData.m_hGroupController;
            if (hGroupController == null)
                return;

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetTexture))
                SetTexture(hGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetPosition))
                SetPosition(hGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetSize))
                SetSize(hGroupController);

            if (FlagUtility.HasFlagUnsafe(m_eType, RawImageSetType.SetRotation))
                SetRotation(hGroupController);
        }

        #endregion

        #region Main

        protected virtual void SetTexture(DSC_Dialogue_RawImageGroupController hGroupController)
        {
            hGroupController.SetTexture(m_nIndex, m_hTexture);
        }

        protected virtual void SetPosition(DSC_Dialogue_RawImageGroupController hGroupController)
        {
            hGroupController.SetPosition(m_nIndex, m_vPosition);
        }

        protected virtual void SetSize(DSC_Dialogue_RawImageGroupController hGroupController)
        {
            if (!m_bUseNativeSize)
                hGroupController.SetSize(m_nIndex, m_vSize);
            else
                hGroupController.SetSizeToNative(m_nIndex);
        }

        protected virtual void SetRotation(DSC_Dialogue_RawImageGroupController hGroupController)
        {
            hGroupController.SetRotation(m_nIndex, m_vRotation);
        }

        #endregion

        #region Helper

        protected DSC_Dialogue_ImageGroupController GetImageGroupController(List<IDialogueEventData> lstData)
        {
            DSC_Dialogue_ImageGroupController hResult = null;

            if (lstData.TryGetData(out DialogueEventData_GroupController<DSC_Dialogue_ImageGroupController> hOutData))
            {
                hResult = hOutData.m_hGroupController;
            }

            return hResult;
        }

        #endregion
    }
}