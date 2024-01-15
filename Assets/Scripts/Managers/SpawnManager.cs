using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int AmountObstacles;
    public GameObject ObstaclesPrefab;
    public Queue<GameObject> Obstacles = new();

    public float MinRandomNumber = 0;
    public float MaxRandomNumber = 2;

    #region StartMethods
    private void OnEnable()
    {
        PlayerController.GameOverEvent.AddListener(StopSpawn);
    }

    private void OnDisable()
    {
        PlayerController.GameOverEvent.RemoveListener(StopSpawn);
    }

    private void Start()
    {
        CreateObstaclePool();

        StartCoroutine(SpawnEnemy());
    }
    #endregion

    #region ObstaclePoolMethod
    public void CreateObstaclePool()
    {
        for (int i = 0; i < AmountObstacles; i++)
        {
            GameObject obstacle = Instantiate(ObstaclesPrefab, transform.position, Quaternion.identity);
            obstacle.SetActive(false);
            Obstacles.Enqueue(obstacle);
        }
    }

    [ContextMenu("Clear")]
    public void ClearObstaclePool()
    {
        for (int i = 0; i < AmountObstacles; i++)
        {
            Destroy(Obstacles.Dequeue());
        }
    }

    public GameObject GetObstacleObject(Vector3 position)
    {
        GameObject obstacle = Obstacles.Dequeue();
        obstacle.SetActive(true);
        obstacle.transform.position = position;
        Obstacles.Enqueue(obstacle);
        return obstacle;
    }
    #endregion

    #region Spawn
    public IEnumerator SpawnEnemy()
    {
        GetObstacleObject(transform.position);

        yield return new WaitForSecondsRealtime(Random.Range(MinRandomNumber, MaxRandomNumber));

        StartCoroutine(SpawnEnemy());
    }

    private void StopSpawn()
    {
        StopAllCoroutines();
    }
    #endregion
}