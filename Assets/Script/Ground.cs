using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacleObjects;

    private void Start()
    {
        foreach(GameObject obstacle in _obstacleObjects)
        {
            obstacle.SetActive(false);
        }
        if(Random.Range(0, 2) == 0)
            _obstacleObjects[Random.Range(0, _obstacleObjects.Length)].SetActive(true);
    }
}
