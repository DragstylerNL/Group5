using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MilestoneDataSave
{
    public int currentProgres;
    public int isCompleted;

    public MilestoneDataSave(MileStoneData data)
    {
        currentProgres = data.CurrentAmountInt;
        
    }

}

