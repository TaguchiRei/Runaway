using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _groundObjects;
    [SerializeField] private Vector2 _groundSize;
    [SerializeField] private float _speed;


    private List<GameObject> _groundInstance;
    private float _groundHeight;

    private void Awake()
    {
        _groundInstance = new();
        foreach (var obj in _groundObjects)
        {
            for (var i = 0; i < 4; i++)
            {
                _groundInstance.Add(Instantiate(obj, Vector2.zero, Quaternion.identity));
            }
        }
        // ƒVƒƒƒbƒtƒ‹
        System.Random rng = new System.Random();
        for (int i = _groundInstance.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (_groundInstance[i], _groundInstance[j]) = (_groundInstance[j], _groundInstance[i]);
        }
    }

    private void FixedUpdate()
    {
        for (var i = 0; i < _groundInstance.Count; i++)
        {
            _groundInstance[i].transform.position += Vector3.left * _speed;
        }        
    }

    private void GroundSetPosition()
    {
    }
}
