using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public bool isCleared = false;
    public SpawnMode spawnMode;
    
    public int currentEnemyCount { get; private set; }
    private Player player;
    public DungeonInfo dungeonInfo;
    private void Start()
    {
        currentEnemyCount = 0;
        player =GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isCleared || player.isDead)
        {
            InteractionController.EnableMode("End");
        }
    }
    public void EnemyDefeated()
    {
        currentEnemyCount++;
        if (currentEnemyCount >=spawnMode.enemyTotalCount)
        {
            isCleared = true;
            // 게임 클리어 처리
        }
    }
    public void SceneChange(string nam)
    {
        SceneManager.LoadScene(nam);
    }
}
