using UnityEngine;

namespace DSC.DialogueSystem
{
    public abstract class BaseDialoguePreProcessing : MonoBehaviour
    {
        public abstract void PreProcessingDialogue(ref Dialogue hDialogue); 
    }
}