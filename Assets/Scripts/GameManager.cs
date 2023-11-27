using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public bool isCleared = false;
    public SpawnMode spawnMode;

    private int currentEnemyCount = 0;
    private Player player;

    private void Start()
    {
        player=GameObject.FindWithTag("Player").GetComponent<Player>();
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
        if (currentEnemyCount >=spawnMode.enemyCount)
        {
            isCleared = true;
            // ���� Ŭ���� ó��
        }
    }
    public void SceneChange(string nam)
    {
        SceneManager.LoadScene(nam);
    }
}
