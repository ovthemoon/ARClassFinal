using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnMode : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnCooltime = 3f;
    public float spawnRadius = 20f;
    public UIManager uiManager;
    private ARPlane spawnPlane;
    private GameObject player;
    public int enemyTotalCount { get; private set; }
    public int curEnemyCount { get; private set; }
    private void OnEnable()
    {
        UIController.ShowUI("Main");
    }
    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
        spawnPlane = ScanMode.selectedPlane;
        enemyTotalCount = GameManager.Instance.dungeonInfo.monsterCount;
        spawnCooltime = GameManager.Instance.dungeonInfo.spawnTime;
        StartCoroutine(StartSpawning());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartSpawning()
    {
        for (int i = 0; i < enemyTotalCount; i++)
        {
            SpawnEnemyNearPlayer();
            yield return new WaitForSeconds(spawnCooltime);
        }
    }
    
    void SpawnEnemyNearPlayer()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPoint.x+player.transform.position.x, spawnPlane.transform.position.y-2f, randomPoint.y+ player.transform.position.x);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
