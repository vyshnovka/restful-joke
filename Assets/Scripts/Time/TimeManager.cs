using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Gradient color;

    void Start()
    {
        Camera.main.backgroundColor = color.Evaluate(TimePassed());
    }

    private float TimePassed()
    {
        DateTime time = DateTime.Now;

        float passed = time.Hour * 60 * 60 + time.Minute * 60 + time.Second;
        float full = 24 * 60 * 60;

        return passed / full;
    }
}
