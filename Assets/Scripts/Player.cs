using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int curHp;
    [HideInInspector]public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        curHp = DataManager.Instance.PlayerMaxHp;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void decreaseHp(int attackAmount)
    {
        //HP °¨¼Ò
        curHp -= attackAmount;
        if (curHp <= 0)
        {
            isDead = true;
        }
    }
}
