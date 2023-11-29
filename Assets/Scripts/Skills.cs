using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public float attackAmount = 2;
    public float aliveTime = 5f;
    private bool isDestroyed = false;

    private void Start()
    {
        StartCoroutine(DestroySkill());
    }

    IEnumerator DestroySkill()
    {
        yield return new WaitForSeconds(aliveTime);

        // �̹� �ı����� �ʾҴٸ� �ı�
        if (!isDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDestroyed = true; // �ı����� ǥ��
            other.gameObject.GetComponent<Enemy>().decreaseEnemyHp();
            Destroy(gameObject);
        }
    }
}
