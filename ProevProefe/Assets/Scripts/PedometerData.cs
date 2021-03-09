//pedometer API courtesy of Yusuf Olokoba
// script outputs action "OnStepCounted" which will give steps and distance whenever the pedometer updates
// it also contains ResetPedometer() and OnDisable() to be used

namespace PedometerU.data
{
    using System;
    using UnityEngine;

    public class PedometerData : MonoBehaviour
    {
        private Pedometer pedometer;
        public Action<int, double> OnStepCounted;
        private static PedometerData pedometerInstance;

        //this prevents duplicates from forming from DontDestroyOnLoad
        private void Awake()
        {
            DontDestroyOnLoad(this);

            if (pedometerInstance == null)
            {
                pedometerInstance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            pedometer = new Pedometer(OnStep);
            ResetPedometer();
        }

        public void ResetPedometer()
        {
            OnStep(0, 0);
        }

        private void OnStep(int steps, double distance)
        {
            // feet = distance * 3.28084
            OnStepCounted?.Invoke(steps, distance);
        }

        // Release the pedometer
        public void OnDisable()
        {
            if (pedometer != null)
            {
                pedometer.Dispose();
                pedometer = null;
            }
        }

        
    }
}