using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateHost : MonoBehaviour
{
    //things that stay the same
    public int plateCorrectID;
    public List<PressurePlate> plates;

    public void CheckPlates()
    {
        //this will run the check for if the code was correct
        if (plateCorrectID == PressurePlate.plateIDTotal)
        {
            PressurePlate.platesComplete = true;
        }

        else
        {
            PressurePlate.plateIDTotal = 0;
            plates.ForEach(item => item.ResetPressurePlates());
        }
    }
}
