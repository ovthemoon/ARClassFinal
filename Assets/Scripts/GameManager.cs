using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerExp = 0;
    [HideInInspector]
    public float maxHp=5;
    [HideInInspector]
    public int level = 1;
    public bool isCleared = false;

    [SerializeField]
    private int[] expMax;
    private float curHp;
    private bool isDead=false;
    private int currentEnemyCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddExp(int expEarn)
    {
        //경험치 획득
        playerExp+=expEarn;
        if (playerExp<=Instance.expMax[level-1])
        {
            playerExp = playerExp % Instance.expMax[level - 1];
            level++;
        }
    }
    public void decreaseHp(int attackAmount)
    {
        //HP 감소
        curHp -= attackAmount;
        if(curHp <= 0)
        {
            isDead = true;
        }
    }
    

    public void EnemyDefeated()
    {
        currentEnemyCount++;
        if (currentEnemyCount >=SpawnManager.instance.enemyCount)
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
