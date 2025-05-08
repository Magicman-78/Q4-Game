using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Brazier : MonoBehaviour
{
    public static List<GameObject> yourOrder = new();

    public UnityEvent correct;

    public GameObject flameParticle;

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Flame")) 
        {
            LightBrazier();
        }
    }

    public void LightBrazier()
    {
        Instantiate(flameParticle);
        yourOrder.Add(transform.gameObject);
        Debug.Log("This brazier is lit!");
    }

    public void CheckOrder()
    {
        if (BrazierOrderHost.CompareLists(yourOrder, FindFirstObjectByType<BrazierOrderHost>().correctOrder))
        {
            Debug.Log("This is correct");
            correct.Invoke();
        }

        else
        {
            FindFirstObjectByType<BrazierOrderHost>().ResetOrder();
        }
    }
}
