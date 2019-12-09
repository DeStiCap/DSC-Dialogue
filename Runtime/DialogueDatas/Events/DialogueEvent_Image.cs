using System.Collections;
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
            SetImage,
            SetPosition,
            SetImageAndPosition,
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
        }

        #endregion

        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] DialogueEvent_ImageData[] m_EventDataArray;

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

            ImageEventStart(lstData);
        }

        #endregion

        #region Main

        protected virtual void ImageEventStart(List<IDialogueEventData> lstData)
        {
            if (m_EventDataArray.Length <= 0)
                return;

            if (!lstData.TryGetData(out DialogueEventData_Image hOutData))
                return;

            var hImageGroupController = hOutData.m_hGroupController;
            if (hImageGroupController == null)
                return;

            for (int i = 0; i < m_EventDataArray.Length; i++)
            {
                var hEventData = m_EventDataArray[i];

                switch (hEventData.m_eType)
                {
                    case ImageEventType.None:
                        continue;

                    case ImageEventType.SetImage:
                        SetImage(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetPosition:
                        SetPosition(hImageGroupController, hEventData);
                        break;

                    case ImageEventType.SetImageAndPosition:
                        SetImage(hImageGroupController, hEventData);
                        SetPosition(hImageGroupController, hEventData);
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

        protected virtual void SetImage(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.SetImage(hEventData.m_nIndex, hEventData.m_hSprite);
        }

        protected virtual void SetPosition(DSC_Dialogue_ImageGroupController hImageGroupController, DialogueEvent_ImageData hEventData)
        {
            hImageGroupController.SetPosition(hEventData.m_nIndex, hEventData.m_vPosition);
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