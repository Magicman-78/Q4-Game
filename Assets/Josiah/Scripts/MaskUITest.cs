using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MaskUITest : MonoBehaviour
{
    public UnityEvent moonMaskImage;
    public UnityEvent sunMaskImage;
    public UnityEvent leafMaskImage;

    public UnityEvent moonMaskHideImage;
    public UnityEvent sunMaskHideImage;
    public UnityEvent leafMaskHideImage;

    public UnityEvent unequippedImage;

    private void Update()
    {
        MaskCheck();
    }

    public void MaskCheck()
    {
        if (GetComponent<PlayerMovement>().currentMask is MoonMask)
        {
            moonMaskImage.Invoke();
        }

        if (GetComponent<PlayerMovement>().currentMask is SunMask)
        {
            sunMaskImage.Invoke();
        }

        if (GetComponent<PlayerMovement>().currentMask is LeafMask)
        {
            leafMaskImage.Invoke();
        }

        if (GetComponent<PlayerMovement>().currentMask is null)
        {
            unequippedImage.Invoke();
            leafMaskHideImage.Invoke();
            sunMaskHideImage.Invoke();
            moonMaskHideImage.Invoke();
        }
    }
}
