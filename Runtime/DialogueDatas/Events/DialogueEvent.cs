using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DialogueEvent : BaseDialogueEvent
    {
        public override DialogueEventType EventType { get { return DialogueEventType.None; } }

        public override void OnStart(List<IDialogueEventData> lstData)
        {

        }

        public override void OnExecute(List<IDialogueEventData> lstData)
        {

        }

        public override void OnEnd(List<IDialogueEventData> lstData)
        {

        }

    }
}