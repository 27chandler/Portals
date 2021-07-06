using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int _scoreIncrement;
    [SerializeField] private int _scoreID;

    private ScoreSystem _scoreSystem;
    // Start is called before the first frame update
    void Start()
    {
        if (_scoreSystem == null)
        {
            _scoreSystem = GetComponentInParent <ScoreSystem>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<IScoreActivatable>() != null)
        {
            _scoreSystem.AddScore(_scoreID, _scoreIncrement);
        }
    }
}
