using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ImageGroupController : UIGroupController<DSC_Dialogue_ImageController>
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected List<DSC_Dialogue_ImageController> m_lstImageController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType groupType { get { return UIType.Image; } }
        protected override List<DSC_Dialogue_ImageController> uiControllerList { get { return m_lstImageController; } }

        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Add(new DialogueEventData_Image
                {
                    m_hGroupController = this,
                });
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController != null && m_hDataController.DialogueEventDataList != null)
            {
                m_hDataController.DialogueEventDataList.Remove<DialogueEventData_Image>();
            }
        }

        #endregion

        #region Main

        public virtual void SetSprite(int nIndex, Sprite hSprite)
        {
            var hController = GetImageController(nIndex);
            hController?.SetImage(hSprite);
        }

        public virtual void SetPosition(int nIndex, Vector2 vPosition)
        {
            var hController = GetImageController(nIndex);
            hController?.SetPosition(vPosition);
        }

        public virtual void SetSize(int nIndex, Vector2 vSize)
        {
            var hController = GetImageController(nIndex);
            hController?.SetSize(vSize);
        }

        public virtual void SetSizeToNative(int nIndex)
        {
            var hController = GetImageController(nIndex);
            hController?.SetSizeToNative();
        }

        public virtual void SetRotation(int nIndex,Vector3 vRotation)
        {
            var hController = GetImageController(nIndex);
            hController?.SetRotation(vRotation);
        }

        public virtual void SetColor(int nIndex,Color hColor)
        {
            var hController = GetImageController(nIndex);
            hController?.SetColor(hColor);
        }
        
        #endregion

        #region Helper

        protected bool HasImageInList()
        {
            return (m_lstImageController != null && m_lstImageController.Count > 0);
        }

        protected DSC_Dialogue_ImageController GetImageController(int nIndex)
        {
            DSC_Dialogue_ImageController hResult = null;

            if (nIndex < 0 || m_lstImageController == null || m_lstImageController.Count <= nIndex)
                return hResult;

            hResult = m_lstImageController[nIndex];
            
            return hResult;
        }

        protected bool TryGetImageController(int nIndex,out DSC_Dialogue_ImageController hOutController)
        {
            hOutController = GetImageController(nIndex);

            return hOutController != null;
        }

        #endregion
    }
}