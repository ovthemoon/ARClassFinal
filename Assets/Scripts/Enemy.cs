using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float impulsePower = 10f;
    public int enemyExp = 10;
    Rigidbody rb;
    GameObject target;
    Vector3 direction;
    [SerializeField]
    private float enemyHp = 3;
    
    private int attackAmount = 2;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            direction = (target.transform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Attack"))
        {
            enemyHp -= collider.GetComponent<Skills>().attackAmount;
            //rb.AddForce(-direction*impulsePower, ForceMode.Impulse);
            
        }
        else if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.decreaseHp(attackAmount);

        }
        if (enemyHp <= 0)
        {
            GameManager.Instance.AddExp(enemyExp);
            GameManager.Instance.EnemyDefeated();
            Destroy(this.gameObject);
        }
        
    }
}
