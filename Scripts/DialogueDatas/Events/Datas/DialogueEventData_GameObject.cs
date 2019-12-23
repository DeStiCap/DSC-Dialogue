using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public struct DialogueEventData_GameObject : IDialogueEventData
    {
        public DSC_Dialogue_GameObjectGroupController m_hGroupController;
    }
}