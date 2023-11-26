using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject FirePrefab;
    public Vector3 offset=new Vector3(0,0,3);
    public float cooldownTime = 3f; // 쿨타임 시간 (초 단위)
    public float fireballSpeed = 10f;
    private bool isCooltime = false;
    private Vector3 pos;
    private void Update()
    {
        pos = Camera.main.transform.position;

        // 카메라의 회전을 고려한 offset 계산
        Vector3 forward = Camera.main.transform.forward;
        Vector3 adjustedOffset = forward * offset.z + Camera.main.transform.right * offset.x + Camera.main.transform.up * offset.y;
        offset = adjustedOffset;
    }

    public void FireEffect()
    {
        if (!isCooltime)
        {
            Vector3 fireStartPosition = pos + offset;

            // 파이어볼 인스턴스 생성
            GameObject fire = Instantiate(FirePrefab, fireStartPosition, Quaternion.identity);

            // 파이어볼에 리지드바디 컴포넌트가 있는지 확인하고, 속도를 설정합니다.
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
