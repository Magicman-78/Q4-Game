using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Brazier : MonoBehaviour
{
    public static List<GameObject> yourOrder = new();

    public UnityEvent correct;

    public GameObject flameParticle;

    public bool lit;

    [HideInInspector]public GameObject currentParticles;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Flame")) 
        {
            LightBrazier();
        }
    }

    public void LightBrazier()
    {
        if (lit == false)
        {
            currentParticles = Instantiate(flameParticle, transform);
            yourOrder.Add(transform.gameObject);
            Debug.Log("This brazier is lit!");
        }
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

    public void MakeBoolFalse()
    {
        lit = false;
    }
}
