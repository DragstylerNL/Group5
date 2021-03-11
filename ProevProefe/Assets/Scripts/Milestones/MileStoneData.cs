using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MileStoneData : MonoBehaviour
{
    public Text mainTitle;
    public Text description;
    public Text CurrentAmount;
    public Text Goal;
    public int CurrentAmountInt;
    public int GoalInt;
    public GameObject reward;
    public Slider progrresBarr;
    public bool isCompleted = false;

    public MileStone milestone;
    // Start is called before the first frame update
    void Start()
    {

        mainTitle.text = milestone.MilestoneName;
        description.text = milestone.Description;
        CurrentAmount.text = "" + milestone.CurrentGoalAmount;
        Goal.text = "" + milestone.GoalAmount;
        //reward = milestone.reward;
        
        
    }

   
}
