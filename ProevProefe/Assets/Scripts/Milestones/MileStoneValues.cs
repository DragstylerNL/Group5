using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Milestone", menuName = "Milestone")]
public class MileStone : ScriptableObject
{
    public string MilestoneName;
    public float GoalAmount;
    public float CurrentGoalAmount;
    public GameObject reward;
    public string Description;
    
}
