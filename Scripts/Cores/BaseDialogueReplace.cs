using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public abstract class BaseDialogueReplace : ScriptableObject
    {
        public abstract string ID { get; }
        public abstract ReplaceEventType ReplaceType { get; }
        public abstract string ReplaceColor { get; }
        public abstract IgnoreReplaceType IgnoreType { get; }
        public abstract IgnoreColorType IgnoreColor { get; }
    }
}