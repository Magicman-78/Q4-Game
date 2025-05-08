using UnityEngine;

public class Flame : MonoBehaviour
{
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Unlit Flame"))
        {
            Destroy(gameObject);
        }
    }
}
