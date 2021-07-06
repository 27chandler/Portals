using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteract : MonoBehaviour, IControllable
{
    [SerializeField] private float _interactDistance = 0.5f;
    [SerializeField] private GameObject _placeBlock;
    [SerializeField] private Vector3 _gridSize;

    [SerializeField] private bool _areControlsLocked = false;

    void Start()
    {
        InputManager.Instance._onFire += PlaceBlock;
        InputManager.Instance._onSecondaryFire += DestroyBlock;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onFire -= PlaceBlock;
        InputManager.Instance._onSecondaryFire -= DestroyBlock;
    }

    private void PlaceBlock()
    {
        if (!_areControlsLocked)
        {
            // Raycast for place block
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, _interactDistance);

            if (hit.collider != null)
            {
                Vector3 block_position = new Vector3();
                block_position = hit.point + (hit.normal * 0.01f);
                block_position = (new Vector3(Mathf.Round(block_position.x / _gridSize.x),
                              Mathf.Round(block_position.y / _gridSize.y),
                              Mathf.Round(block_position.z / _gridSize.z)) * _gridSize.x);

                Instantiate(_placeBlock, block_position, new Quaternion());
            }
        }
    }

    private void DestroyBlock()
    {
        if (!_areControlsLocked)
        {
            // Raycast for break block
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, _interactDistance);

            if (hit.collider != null)
            {
                Mineable mineable = hit.collider.gameObject.GetComponent<Mineable>();
                if (mineable != null)
                {
                    Destroy(hit.collider.transform.parent.gameObject);
                }
            }
        }
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
