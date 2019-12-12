using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    [CreateAssetMenu(fileName = "DialogueEvent_SetEnable", menuName = "DSC/Dialogue/Events/Set Enable")]
    public class DialogueEvent_SetEnable : DialogueEvent
    {
        #region Enum

        protected enum ObjectType
        {
            GameObject,
            Image,
            RawImage,
        }

        protected enum SetType
        {
            Enable,
            Disable
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] ObjectType m_eType;
        [SerializeField] SetType m_eSet;
        [SerializeField] int m_nIndex;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            switch (m_eType)
            {
                case ObjectType.GameObject:
                    SetGameObject(lstData);
                    break;

                case ObjectType.Image:
                    SetImage(lstData);
                    break;

                case ObjectType.RawImage:
                    SetRawImage(lstData);
                    break;
            }
        }

        #endregion

        #region Main

        protected virtual void SetGameObject(List<IDialogueEventData> lstData)
        {
            if (!TryGetGameObjectGroupController(lstData, out var hOutController))
                return;

            bool bActive = m_eSet == SetType.Enable;
            hOutController.SetActiveGameObject(m_nIndex, bActive);
        }

        protected virtual void SetImage(List<IDialogueEventData> lstData)
        {
            if (!TryGetImageGroupController(lstData, out var hOutController))
                return;

            switch (m_eSet)
            {
                case SetType.Enable:
                    hOutController.ShowImage(m_nIndex);
                    break;

                case SetType.Disable:
                    hOutController.HideImage(m_nIndex);
                    break;
            }
        }

        protected virtual void SetRawImage(List<IDialogueEventData> lstData)
        {
            if (!TryGetImageGroupController(lstData, out var hOutController))
                return;

            switch (m_eSet)
            {
                case SetType.Enable:
                    hOutController.ShowRawImage(m_nIndex);
                    break;

                case SetType.Disable:
                    hOutController.HideRawImage(m_nIndex);
                    break;
            }
        }

        #endregion

        #region Helper

        protected DSC_Dialogue_ImageGroupController GetImageGroupController(List<IDialogueEventData> lstData)
        {
            if (!lstData.TryGetData(out DialogueEventData_Image hOutData))
                return null;

            return hOutData.m_hGroupController;            
        }

        protected bool TryGetImageGroupController(List<IDialogueEventData> lstData,out DSC_Dialogue_ImageGroupController hOutController)
        {
            hOutController = GetImageGroupController(lstData);

            return hOutController != null;
        }

        protected DSC_Dialogue_GameObjectGroupController GetGameObjectGroupController(List<IDialogueEventData> lstData)
        {
            if (!lstData.TryGetData(out DialogueEventData_GameObject hOutData))
                return null;

            return hOutData.m_hGroupController;
        }

        protected bool TryGetGameObjectGroupController(List<IDialogueEventData> lstData,out DSC_Dialogue_GameObjectGroupController hOutController)
        {
            hOutController = GetGameObjectGroupController(lstData);
            return hOutController != null;
        }

        #endregion
    }
}