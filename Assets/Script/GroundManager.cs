using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroundManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _groundObjects;
    [SerializeField] private Vector2 _groundSize;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float _speed;


    private List<GameObject> _groundInstance;
    private int _groundHeight;
    private int _score;
    private bool _gameOver;

    private void Awake()
    {
        _groundInstance = new();
        _groundHeight = 0;
        GenerateFirstGround();
        for (var i = 1; i < 4; i++)
        {
            GenerateGround();
        }
    }

    private void FixedUpdate()
    {
        if (_gameOver) return;
        for (var i = 0; i < _groundInstance.Count; i++)
        {
            _groundInstance[i].transform.position += Vector3.left * _speed;
        }
        if (_groundInstance[0].transform.position.x < -_groundSize.x * 1.5f)
        {
            Destroy(_groundInstance[0]);
            _groundInstance.RemoveAt(0);
            GenerateGround();
            _score += 6;
        }
    }

    private void GenerateFirstGround()
    {
        _groundInstance.Add(Instantiate(_groundObjects[0], Vector3.zero, Quaternion.identity));
    }

    private void GenerateGround()
    {
        var groundType = Random.Range(0, _groundObjects.Length);
        var ground = Instantiate(_groundObjects[groundType]);
        var groundX = _groundInstance[_groundInstance.Count - 1].transform.position.x + _groundSize.x;
        Vector3 pos;

        switch (ground.tag)
        {
            case "Ground":
                pos = new(groundX, _groundSize.y * _groundHeight,0);
                ground.transform.position = pos;
                break;
            case "SlopeDown":
                _groundHeight--;
                pos = new(groundX, _groundSize.y * _groundHeight, 0);
                ground.transform.position = pos;
                break;
            case "SlopeUp":
                pos = new(groundX, _groundSize.y * _groundHeight, 0);
                ground.transform.position = pos;
                _groundHeight++;
                break;
        }
        _groundInstance.Add(ground);
    }

    public void GameOver()
    {
        _scoreText.text = $"Score: {_score}";
        _scoreText.enabled = true;
        _gameOver = true;
    }
}
