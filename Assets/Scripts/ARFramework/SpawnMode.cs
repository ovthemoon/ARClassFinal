using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnMode : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 5;

    public float spawnCooltime = 3f;
    public float spawnRadius = 10f;

    private ARPlane spawnPlane;
    private GameObject player;
    public int curEnemyCount { get; private set; }
    private void OnEnable()
    {
        UIController.ShowUI("Main");
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnPlane = ScanMode.selectedPlane;
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartSpawning()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemyNearPlayer();
            yield return new WaitForSeconds(spawnCooltime);
        }
    }

    void SpawnEnemyNearPlayer()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPoint.x, spawnPlane.transform.position.y, randomPoint.y) + player.transform.position;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
