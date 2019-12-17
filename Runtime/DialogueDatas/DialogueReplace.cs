using UnityEngine;
using DSC.Core;

namespace DSC.DialogueSystem
{
    #region Enum

    public enum ReplaceEventType
    {
        Replace,
        Color,
        ReplaceColor,
    }

    public enum IgnoreReplaceType
    {
        None,
        Dialogue,
        Talker,
    }

    public enum IgnoreColorType
    {
        None,
        Dialogue,
        Talker,
    }

    #endregion

    [CreateAssetMenu(fileName = "DialogueReplace", menuName = "DSC/Dialogue/Dialogue Replace")]
    public class DialogueReplace : BaseDialogueReplace
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] string m_sReplaceID;
        [SerializeField] ReplaceEventType m_eEventType;

        [ColorHtml]
        [SerializeField] string m_sColor;

        [Header("Option")]
        [SerializeField] IgnoreReplaceType m_eIgnoreType;
        [SerializeField] IgnoreColorType m_eIgnoreColor;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public override string ID { get { return m_sReplaceID; } }
        public override ReplaceEventType ReplaceType { get { return m_eEventType; } }
        public override string ReplaceColor { get { return m_sColor; } }
        public override IgnoreReplaceType IgnoreType { get { return m_eIgnoreType; } }
        public override IgnoreColorType IgnoreColor { get { return m_eIgnoreColor; } }

        #endregion

        #endregion
    }
}