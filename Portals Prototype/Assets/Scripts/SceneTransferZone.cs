using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferZone : MonoBehaviour
{
    private void SwapScene(Transform traveller)
    {
        SceneManager.MoveGameObjectToScene(traveller.gameObject, gameObject.scene);
        Debug.Log("Scene Swap");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        // Just entered this world, set owning scene to current one
        SceneSwappable swappable = other.transform.GetComponent<SceneSwappable>();

        if (swappable != null)
        {
            SwapScene(other.transform);
        }
    }
}
