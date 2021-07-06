using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private List<GameObject> _playerQueue = new List<GameObject>();
    [SerializeField] private int _activeIndex = 0;

    public void RegisterPlayer(GameObject player)
    {
        _playerQueue.Add(player);
    }

    public void UnRegisterPlayer(GameObject player)
    {
        PlayerRegister player_register = player.GetComponent<PlayerRegister>();
        player_register.FreezeControls();
        //foreach (var controllable in player_register.GetComponentsInChildren<IControllable>())
        //{
        //    controllable.FreezeControls();
        //}

        _playerQueue.Remove(player);
    }


    // Update is called once per frame
    void Update()
    {
        if (_activeIndex != _playerQueue.Count - 1)
        {
            _activeIndex = _playerQueue.Count - 1;
            for (int i=0; i < _playerQueue.Count; i++)
            {
                PlayerRegister player_register = _playerQueue[i].GetComponent<PlayerRegister>();
                if (i != _activeIndex)
                {
                    player_register.FreezeControls();
                    //foreach (var controllable in player_register.GetComponentsInChildren<IControllable>())
                    //{
                    //    controllable.FreezeControls();
                    //}
                }
                else
                {
                    player_register.UnFreezeControls();
                    //foreach (var controllable in player_register.GetComponentsInChildren<IControllable>())
                    //{
                    //    controllable.UnFreezeControls();
                    //}
                }
            }
        }
    }
}
