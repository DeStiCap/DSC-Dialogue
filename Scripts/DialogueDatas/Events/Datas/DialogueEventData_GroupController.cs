using DSC.Core;

namespace DSC.DialogueSystem
{
    public struct DialogueEventData_GroupController<GroupController> : IDialogueEventData where GroupController : BaseComponentGroupController
    {
        public GroupController m_hGroupController;
    }
}