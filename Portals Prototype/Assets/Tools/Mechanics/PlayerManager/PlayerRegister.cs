using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegister : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerManager.Instance.RegisterPlayer(this.gameObject);
    }

    // Update is called once per frame
    void OnDisable()
    {
        PlayerManager.Instance.UnRegisterPlayer(this.gameObject);
    }

    public void FreezeControls()
    {
        foreach (var controllable in gameObject.GetComponentsInChildren<IControllable>())
        {
            controllable.FreezeControls();
        }
        _cam.enabled = false;
    }

    public void UnFreezeControls()
    {
        foreach (var controllable in gameObject.GetComponentsInChildren<IControllable>())
        {
            controllable.UnFreezeControls();
        }
        _cam.enabled = true;
    }
}
