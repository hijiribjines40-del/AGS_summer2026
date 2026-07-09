using UnityEngine;

public class MedalSpin : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb =
            GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.angularVelocity =
                Random.insideUnitSphere * 10f;
        }

        Destroy(gameObject, 5f);
    }
}