using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_ReplaceController : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;
        [SerializeField] protected BaseDialogueReplace[] m_arrReplace;

#pragma warning restore 0649
        #endregion

        protected Dictionary<string, string> m_dicReplace = new Dictionary<string, string>();

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController)
                m_hDataController.SetReplaceController(this);
        }

        #endregion

        #region Events

        public void SetReplaceWord(string sReplaceID,string sReplaceWord)
        {
            if (m_dicReplace.ContainsKey(sReplaceID))
            {
                m_dicReplace[sReplaceID] = sReplaceWord;
            }
            else
            {
                m_dicReplace.Add(sReplaceID, sReplaceWord);
            }
        }

        #endregion

        #region Main

        public virtual void CheckReplaceWord(ref Dialogue hDialogue)
        {
            if (m_arrReplace == null || m_arrReplace.Length <= 0)
                return;

            for(int i = 0; i < m_arrReplace.Length; i++)
            {
                var hReplace = m_arrReplace[i];
                if (hReplace == null)
                    continue;

                bool bReplaceDialogue = true;
                bool bReplace = true;
                switch (hReplace.IgnoreType)
                {
                    case IgnoreReplaceType.Dialogue:
                        bReplaceDialogue = false;
                        break;

                    case IgnoreReplaceType.Talker:
                        bReplace = false;
                        break;
                }

                bool bColorDialogue = true;
                bool bColorTalker = true;
                switch (hReplace.IgnoreColor)
                {
                    case IgnoreColorType.Dialogue:
                        bColorDialogue = false;
                        break;

                    case IgnoreColorType.Talker:
                        bColorTalker = false;
                        break;
                }

                if (bReplaceDialogue && hDialogue.m_sDialogue.Contains(hReplace.ID))
                {
                    switch (hReplace.ReplaceType)
                    {
                        case ReplaceEventType.Replace:
                            ReplaceWord(ref hDialogue.m_sDialogue, hReplace);
                            break;

                        case ReplaceEventType.Color:
                            if(bColorDialogue)
                                ReplaceColor(ref hDialogue.m_sDialogue, hReplace);
                            break;

                        case ReplaceEventType.ReplaceColor:
                            if(bColorDialogue)
                                ReplaceColor(ref hDialogue.m_sDialogue, hReplace);
                            ReplaceWord(ref hDialogue.m_sDialogue, hReplace);
                            break;
                    }
                }

                if (bReplace && hDialogue.m_sTalker.Contains(hReplace.ID))
                {
                    switch (hReplace.ReplaceType)
                    {
                        case ReplaceEventType.Replace:
                            ReplaceWord(ref hDialogue.m_sTalker, hReplace);
                            break;

                        case ReplaceEventType.Color:
                            if(bColorTalker)
                                ReplaceColor(ref hDialogue.m_sTalker, hReplace);
                            break;

                        case ReplaceEventType.ReplaceColor:
                            if(bColorTalker)
                                ReplaceColor(ref hDialogue.m_sTalker, hReplace);
                            ReplaceWord(ref hDialogue.m_sTalker, hReplace);
                            break;
                    }
                }
            }
        }

        protected void ReplaceWord(ref string sOriginal, BaseDialogueReplace hReplace)
        {
            var sReplaceID = hReplace.ID;

            if (TryGetReplaceWord(sReplaceID, out string sReplaceWord))
            {
                sOriginal = sOriginal.Replace(sReplaceID, sReplaceWord);
            }
            else
            {
                Debug.LogWarning("Don't have replace word '" + sReplaceID + "' in data.", gameObject);
            }
        }

        protected void ReplaceColor(ref string sOriginal, BaseDialogueReplace hReplace)
        {
            string sColorWord = "<color=#" + hReplace.ReplaceColor + ">" + hReplace.ID + "</color>";
            sOriginal = sOriginal.Replace(hReplace.ID, sColorWord);
        }
        
        #endregion

        #region Helper

        protected string GetReplaceWord(string sReplaceID)
        {
            string sResult = null;

            if (m_dicReplace == null || m_dicReplace.Count <= 0)
                return sResult;

            if (m_dicReplace.ContainsKey(sReplaceID))
            {
                sResult = m_dicReplace[sReplaceID];
            }

            return sResult;
        }

        protected bool TryGetReplaceWord(string sReplaceID,out string sReplaceWord)
        {
            sReplaceWord = GetReplaceWord(sReplaceID);
            return sReplaceWord != null;
        }

        #endregion
    }
}