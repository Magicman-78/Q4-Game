using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.IO.Pipes;

public class ButtonPressScript : MonoBehaviour
{
    public UnityEvent buttonInteract;

    public bool isPressing;

    public void ButtonInteract()
    {
        if (isPressing == false)
        {
            StartCoroutine(ButtonPress(GetComponentInChildren<Animator>()));
        }
    }

    IEnumerator ButtonPress(Animator buttonAnimation)
    {
        buttonAnimation.SetTrigger("Press");

        isPressing = true;

        buttonInteract.Invoke();

        yield return new WaitForSeconds(0.5f);

        buttonAnimation.SetTrigger("Reset");

        isPressing = false;
    }
}