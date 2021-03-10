namespace PedometerU.data { 

    using UnityEngine;
    using UnityEngine.UI;

    public class PedometerUI : MonoBehaviour
    {
        public Text stepText, distanceText;
        public PedometerData data;

        private void Start()
        {
            data.OnStepCounted += textDisplayer;
        }

        private void textDisplayer(int steps, double distance)
        {
            // feet = distance * 3.28084
            stepText.text = "steps: " + steps.ToString();
            distanceText.text = distance.ToString("F2") + " m";
        }
    }
}