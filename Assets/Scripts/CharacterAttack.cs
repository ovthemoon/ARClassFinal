using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject FirePrefab;
    public Vector3 offset=new Vector3(0,0,3);
    public float cooldownTime = 3f; // ��Ÿ�� �ð� (�� ����)
    public float fireballSpeed = 10f;
    private bool isCooltime = false;
    private Vector3 pos;
    private void Update()
    {
        pos = Camera.main.transform.position;

        // ī�޶��� ȸ���� ����� offset ���
        Vector3 forward = Camera.main.transform.forward;
        Vector3 adjustedOffset = forward * offset.z + Camera.main.transform.right * offset.x + Camera.main.transform.up * offset.y;
        offset = adjustedOffset;
    }

    public void FireEffect()
    {
        if (!isCooltime)
        {
            Vector3 fireStartPosition = pos + offset;

            // ���̾ �ν��Ͻ� ����
            GameObject fire = Instantiate(FirePrefab, fireStartPosition, Quaternion.identity);

            // ���̾�� ������ٵ� ������Ʈ�� �ִ��� Ȯ���ϰ�, �ӵ��� �����մϴ�.
            Rigidbody fireRb = fire.GetComponent<Rigidbody>();
            if (fireRb != null)
            {
                fireRb.velocity = Camera.main.transform.forward * fireballSpeed;
            }
            StartCoroutine(Cooltime());
        }
        
    }
    IEnumerator Cooltime()
    {
        isCooltime = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooltime = false;
    }

}
