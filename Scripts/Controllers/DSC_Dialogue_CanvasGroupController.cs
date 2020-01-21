﻿using System.Collections.Generic;
using UnityEngine;
using DSC.UI;

namespace DSC.DialogueSystem
{
    public class DSC_Dialogue_CanvasGroupController : DSC_UI_CanvasGroupController
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [SerializeField] protected DSC_Dialogue_DataController m_hDataController;

#pragma warning restore 0649
        #endregion

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                if (m_hDataController.DialogueEventDataList.TryGetData(out DialogueEventData_GroupController<DSC_Dialogue_CanvasGroupController> hOutData, out int nOutIndex))
                {
                    hOutData.m_lstGroupController.Add(this);
                    m_hDataController.DialogueEventDataList[nOutIndex] = hOutData;
                }
                else
                {
                    List<DSC_Dialogue_CanvasGroupController> lstGroup = new List<DSC_Dialogue_CanvasGroupController>();
                    lstGroup.Add(this);

                    m_hDataController.DialogueEventDataList.Add(new DialogueEventData_GroupController<DSC_Dialogue_CanvasGroupController>
                    {
                        m_lstGroupController = lstGroup
                    });
                }
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_hDataController && m_hDataController.DialogueEventDataList != null)
            {
                if (m_hDataController.DialogueEventDataList.TryGetData(out DialogueEventData_GroupController<DSC_Dialogue_CanvasGroupController> hOutData, out int nOutIndex))
                {
                    hOutData.m_lstGroupController.Remove(this);

                    if (hOutData.m_lstGroupController.Count > 0)
                        m_hDataController.DialogueEventDataList[nOutIndex] = hOutData;
                    else
                        m_hDataController.DialogueEventDataList.RemoveAt(nOutIndex);
                }                
            }
        }

        #endregion
    }
}