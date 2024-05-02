using System.Collections;
using System.Collections.Generic;
using Logic.DayAndNight;
using UnityEngine;

public class DayAndNightScript : MonoBehaviour
{
    // Adjust these angles according to your setup
    public float sunriseAngle = 0f;
    public float sunsetAngle = 180f;
    public State state = new State();

    private void Update()
    {
        // Get the current rotation of the directional light
        float currentRotation = transform.rotation.eulerAngles.x;

        // Check if the rotation angle is close to sunrise or sunset angles
        if (Mathf.Approximately(currentRotation, sunriseAngle) && state is not Day)
        {
            // Trigger sunrise event
            ChangeState();
        }
        else if (Mathf.Approximately(currentRotation, sunsetAngle) && state is not Night)
        {
            // Trigger sunset event
            ChangeState();
        }
    }
    
    public void ChangeState()
    {
        state.change(this);
    }
}
