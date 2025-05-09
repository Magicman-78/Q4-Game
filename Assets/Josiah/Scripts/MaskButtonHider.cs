using UnityEngine;
using UnityEngine.Events;

public class MaskButtonHider : MonoBehaviour
{
    public UnityEvent showMoonMaskButton;
    public UnityEvent showSunMaskButton;
    public UnityEvent showLeafMaskButton;

    private void Update()
    {
        CheckCollectedMasks();
    }
    public void CheckCollectedMasks()
    {
        if (GetComponent<MoonMask>().collectedMask == true)
        {
            showMoonMaskButton.Invoke();
        }

        if (GetComponent<SunMask>().collectedMask == true)
        {
            showSunMaskButton.Invoke();
        }

        if (GetComponent<LeafMask>().collectedMask == true)
        {
            showLeafMaskButton.Invoke();
        }
    }
}
