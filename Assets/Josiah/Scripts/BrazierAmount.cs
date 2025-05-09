using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

public class BrazierAmount : MonoBehaviour
{
    public static int brazierIDTotal;
    public static bool complete = false;
    public int brazierIDNum;
    public UnityEvent Complete;

    public bool isLit = false;

    private void Update()
    {
        if (complete)
        {
            Debug.Log("COMPLETE");
            Complete.Invoke();

        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Flame") && !isLit)
        {
            Light();
        }
    }

    public void Light()
    {
        isLit = true;

        brazierIDTotal = brazierIDTotal + brazierIDNum;
    }

    public void ResetBraziers()
    {
        isLit = false;
    }
}