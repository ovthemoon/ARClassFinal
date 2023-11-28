using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float impulsePower = 10f;
    public int enemyExp = 10;
    public int moneyDrop = 3;
    
    Rigidbody rb;
    GameObject target;
    Vector3 direction;
    [SerializeField]
    private float enemyHp = 3;
    private int attackAmount = 2;
    private bool isDead;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.gameObject;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
    }
    public void decreaseEnemyHp(float attack)
    {
        enemyHp -= attack;
        if (enemyHp <= 0)
        {
            isDead = true;
            DataManager.Instance.UpdateExp(enemyExp);
            DataManager.Instance.UpdateMoney(moneyDrop);
            GameManager.Instance.EnemyDefeated();
            animator.SetBool("IsDead", isDead);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().decreaseHp(attackAmount);

        }
    }
}
