using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSelection : EventTrigger
{
    private GameManager manager;
    public override void OnPointerDown(PointerEventData data)
    {
        if (!manager.isSelectionPending)
        {
            string selectedBall = manager.GetBowlingMode() ? "Spin " : "Fast ";
            manager.UpdateStatus(selectedBall + gameObject.name);
            manager.AppendStatus("Click on the runs that you want to score");
            base.OnPointerDown(data);
            manager.isSelectionPending = true;
        }
    }

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();     
    }
  }

