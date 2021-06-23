using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class QuestTooltip : TooltipSpawner
{
  public override bool CanCreateTooltip()
    {
        return true;

    }

    public override void UpdateTooltip(GameObject tooltip)
    {
       QuestStatus status =  GetComponent<QuestItemUI>().GetQuestStatus();
        tooltip.GetComponent<QuestTooltipUI>().SetUp(status);
    }
}
