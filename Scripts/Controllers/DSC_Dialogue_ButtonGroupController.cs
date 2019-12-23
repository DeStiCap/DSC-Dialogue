using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ButtonGroupController : UIGroupController<DSC_Dialogue_ButtonController>
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected List<DSC_Dialogue_ButtonController> m_lstButtonController;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override UIType groupType { get { return UIType.Button; } }
        protected override List<DSC_Dialogue_ButtonController> uiControllerList { get { return m_lstButtonController; } }

        #endregion

        #endregion
    }
}