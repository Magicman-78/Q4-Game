using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MaskUITest : MonoBehaviour
{
    public UnityEvent moonMaskImage;
    public UnityEvent sunMaskImage;
    public UnityEvent leafMaskImage;


    public void MaskCheck()
    {
        //if (GetComponent<PlayerMovement>().currentMask == MoonMask)
        //{
        //    moonMaskImage.Invoke();
        //}

        //if (GetComponent<PlayerMovement>().currentMask == SunMask)
        //{
        //    sunMaskImage.Invoke();
        //}

        //if (GetComponent<PlayerMovement>().currentMask == LeafMask)
        //{
        //    leafMaskImage.Invoke();
        //}
    }
}
