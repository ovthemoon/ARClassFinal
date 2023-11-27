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

        // ÀÌ¹Ì ÆÄ±«µÇÁö ¾Ê¾Ò´Ù¸é ÆÄ±«
        if (!isDestroyed)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDestroyed = true; // ÆÄ±«µÊÀ» Ç¥½Ã
            other.gameObject.GetComponent<Enemy>().decreaseEnemyHp();
            Destroy(gameObject);
        }
    }
}
