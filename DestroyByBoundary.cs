using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    private GameController gameController;

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
