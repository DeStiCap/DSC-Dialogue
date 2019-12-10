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

        public void CheckReplaceWord(ref Dialogue hDialogue)
        {
            if (m_arrReplace == null || m_arrReplace.Length <= 0)
                return;

            for(int i = 0; i < m_arrReplace.Length; i++)
            {
                var hReplace = m_arrReplace[i];
                if (hReplace == null)
                    continue;

                var hData = hReplace.ReplaceData;

                if (hDialogue.m_sDialogue.Contains(hData.m_sReplaceID))
                {
                    switch (hData.m_eEventType)
                    {
                        case ReplaceEventType.Replace:
                            ReplaceWord(ref hDialogue, hData);
                            break;

                        case ReplaceEventType.Color:
                            ReplaceColor(ref hDialogue, hData);
                            break;

                        case ReplaceEventType.ReplaceColor:
                            ReplaceColor(ref hDialogue, hData);
                            ReplaceWord(ref hDialogue, hData);                            
                            break;
                    }
                }
            }
        }

        protected void ReplaceWord(ref Dialogue hDialogue,DialogueReplaceData hData)
        {
            if(TryGetReplaceWord(hData.m_sReplaceID,out string sReplaceWord))
            {
                hDialogue.m_sDialogue = hDialogue.m_sDialogue.Replace(hData.m_sReplaceID, sReplaceWord);
            }
            else
            {
                Debug.LogWarning("Don't have replace word '" + hData.m_sReplaceID + "' in data.",gameObject);
            }
        }

        protected void ReplaceColor(ref Dialogue hDialogue, DialogueReplaceData hData)
        {
            int nWordIndex = hDialogue.m_sDialogue.IndexOf(hData.m_sReplaceID);
            hDialogue.m_sDialogue = hDialogue.m_sDialogue.Insert(nWordIndex + hData.m_sReplaceID.Length, "</color>");
            hDialogue.m_sDialogue = hDialogue.m_sDialogue.Insert(nWordIndex, "<color=#" + hData.m_sColor + ">");
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