using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_RawImageGroupController : UIGroupController<DSC_Dialogue_RawImageController>
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected List<DSC_Dialogue_RawImageController> m_lstRawImageController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType groupType { get { return UIType.RawImage; } }
        protected override List<DSC_Dialogue_RawImageController> uiControllerList { get { return m_lstRawImageController; } }

        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_RawImage
                {
                    m_hGroupController = this,
                });
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_RawImage>();
            }
        }

        #endregion

        #region Main

        public virtual void SetTexture(int nIndex, Texture hTexture)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetImage(hTexture);
        }

        public virtual void SetPosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetPosition(vPosition);
        }

        public virtual void SetSize(int nIndex, Vector2 vSize)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetSize(vSize);
        }

        public virtual void SetSizeToNative(int nIndex)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetSizeToNative();
        }

        public virtual void SetRotation(int nIndex, Vector3 vRotation)
        {
            var hController = GetRawImageController(nIndex);
            hController?.SetRotation(vRotation);
        }

        public virtual void SetColor(int nIndex, Color hColor)
        {
            var hController = GetRawImageController(nIndex); ;
            hController?.SetColor(hColor);
        }

        #endregion

        #region Helper

        protected bool HasRawImageInList()
        {
            return (m_lstRawImageController != null && m_lstRawImageController.Count > 0);
        }

        protected DSC_Dialogue_RawImageController GetRawImageController(int nIndex)
        {
            DSC_Dialogue_RawImageController hResult = null;

            if (nIndex < 0 || m_lstRawImageController == null || m_lstRawImageController.Count <= nIndex)
                return hResult;

            hResult = m_lstRawImageController[nIndex];

            return hResult;
        }

        protected bool TryGetRawImageController(int nIndex, out DSC_Dialogue_RawImageController hOutController)
        {
            hOutController = GetRawImageController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}