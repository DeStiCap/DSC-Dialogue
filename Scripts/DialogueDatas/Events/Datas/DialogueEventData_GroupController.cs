using System.Collections.Generic;
using DSC.Core;

namespace DSC.DialogueSystem
{
    public struct DialogueEventData_GroupController<GroupController> : IDialogueEventData where GroupController : BaseComponentGroupController
    {
        public List<GroupController> m_lstGroupController;
    }
}