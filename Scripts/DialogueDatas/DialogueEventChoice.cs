using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Dialogue
{
    [CreateAssetMenu(fileName = "DialogueEventChoice", menuName = "DSC/Dialogue/Choice")]
    public class DialogueEventChoice : BaseDialogueChoice
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected Choice[] m_arrChoice;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override Choice[] choiceArray { get { return m_arrChoice; } }

        #endregion

        #endregion

        #region Base - Override

        public override void OnStart(List<IDialogueEventData> lstData)
        {
            base.OnStart(lstData);

            if (!lstData.TryGetData(out DialogueEventData_MonoBehaviour<DSC_Dialogue_ChoiceGroupController> hChoiceGroup))
                return;

            hChoiceGroup.m_hMono.SetAndShowChoice(m_arrChoice);
        }

        #endregion

    }
}