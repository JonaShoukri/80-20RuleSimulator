using System.Collections;
using System.Collections.Generic;
using Logic;
using Logic.DayAndNight;
using UnityEngine;

public class DayAndNightScript : MonoBehaviour
{
    public float sunriseAngle = 0f;
    public float sunsetAngle = 180f;
    private float nextChangeTime = 0f;
    public float changeInterval = 0.3f;

    private void Update()
    {
        float currentRotation = transform.rotation.x;

        if ((Mathf.Abs(currentRotation - sunriseAngle) < 0.1f) || (Mathf.Abs(currentRotation - sunsetAngle) < 0.1f))
        {
            ChangeState();
        }
    }

    public void ChangeState()
    {
        if (Time.time >= nextChangeTime)
        {
            Controller.Instance().ChangeState();
            nextChangeTime = Time.time + changeInterval;
        }
    }
}