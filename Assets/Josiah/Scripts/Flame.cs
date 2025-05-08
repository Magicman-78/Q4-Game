using UnityEngine;

public class Flame : MonoBehaviour
{
    public GameObject flame;

    public void OntTriggerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
            Destroy(flame);
        }

        if (collision.gameObject.CompareTag("Unlit Flame"))
        {
            Destroy(flame);
        }
    }
}
