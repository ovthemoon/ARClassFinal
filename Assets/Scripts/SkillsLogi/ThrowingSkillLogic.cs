using UnityEngine;
using System.Collections;

public class ThrowingSkillLogic : MonoBehaviour, ISkillLogic
{
    [HideInInspector]
    public GameObject throwSkillPrefab;
    public float speed = 10f;
    public Vector3 offset = new Vector3(0, 0, 3);
    public float aliveTime = 5f;
    private bool isDestroyed = false;
    private Vector3 pos;
    private bool isCooltime = false;
    public void Activate(GameObject target)
    {
        if(!isCooltime)
        {
            StartCoroutine(Cooltime(throwSkillPrefab.GetComponent<SkillScript>().cooldown));
            pos = Camera.main.transform.position;

            // 카메라의 회전을 고려한 offset 계산
            Vector3 forward = Camera.main.transform.forward;
            Vector3 adjustedOffset = forward * offset.z + Camera.main.transform.right * offset.x + Camera.main.transform.up * offset.y;
            offset = adjustedOffset;
            Vector3 fireStartPosition = pos + offset;

            GameObject throwSkill = Instantiate(throwSkillPrefab, fireStartPosition, Quaternion.identity);
            StartCoroutine(DestroySkill(throwSkill));
            // 파이어볼에 리지드바디 컴포넌트가 있는지 확인하고, 속도를 설정합니다.
            Rigidbody rb = throwSkill.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Camera.main.transform.forward * speed;
            }
        }
    }


    IEnumerator Cooltime(float cooltime)
    {
        isCooltime = true;
        yield return new WaitForSeconds(cooltime);
        isCooltime = false;
    }
    IEnumerator DestroySkill(GameObject skill)
    {
        yield return new WaitForSeconds(aliveTime);

        // 이미 파괴되지 않았다면 파괴
        if (skill!=null)
        {
            Destroy(skill);
        }
    }
    

}