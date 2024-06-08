using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockCollisionManager : MonoBehaviour
{
    public event EventHandler<LaunchTheBallEventArgs> LaunchTheBall;
    public class LaunchTheBallEventArgs : EventArgs
    {
        public float forcePower;
    }

    [SerializeField] private float forcePower;
    [SerializeField] private float forcePowerAccumulator;
    [SerializeField] private float maxForcePowerValue;

    private void Start()
    {
        forcePower = 0f;
    }
    public void OnMouseDrag()
    {
        //Accumulate forcePower for ball throw
        
        forcePower += forcePowerAccumulator * Time.deltaTime;
        if (forcePower >= maxForcePowerValue) { forcePower = maxForcePowerValue; }

    }

    public void OnMouseUp()
    {
        //Throw player ball and off interact with unit
        LaunchTheBall?.Invoke(this, new LaunchTheBallEventArgs { forcePower = forcePower});
        forcePower = 0f;
    }


}
