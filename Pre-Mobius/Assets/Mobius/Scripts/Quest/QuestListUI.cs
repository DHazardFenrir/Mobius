using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
public class QuestListUI : MonoBehaviour
{

    [SerializeField] QuestItemUI questPrefab;
    QuestList questList;

    void Start()
    {
        questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.onUpdate += Redraw;

        Redraw();
    }

    private void Redraw()
    {
        transform.DetachChildren();
       
        foreach (QuestStatus status in questList.GetStatuses())
        {
            QuestItemUI uiInstance = Instantiate<QuestItemUI>(questPrefab, transform);
            uiInstance.SetUp(status);

        }
    }

}
