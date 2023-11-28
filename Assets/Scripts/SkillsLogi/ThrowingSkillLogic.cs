using UnityEngine;
using System.Collections;

public class ThrowingSkillLogic : MonoBehaviour, ISkillLogic
{
    public GameObject throwSkillPrefab;
    public SkillScript skillData;
    public float speed = 10f;
    public Vector3 offset = new Vector3(0, 0, 3);
    public float aliveTime = 5f;
    private bool isDestroyed = false;
    private Vector3 pos;
    private bool isCooltime = false;
    
    public void Activate()
    {
        if(!isCooltime)
        {
            StartCoroutine(Cooltime(skillData.cooldown));
            pos = Camera.main.transform.position;

            // ī�޶��� ȸ���� ����� offset ���
            Vector3 forward = Camera.main.transform.forward;
            Vector3 adjustedOffset = forward * offset.z + Camera.main.transform.right * offset.x + Camera.main.transform.up * offset.y;
            offset = adjustedOffset;
            Vector3 fireStartPosition = pos + offset;

            GameObject throwSkill = Instantiate(throwSkillPrefab, fireStartPosition, Quaternion.identity);
            StartCoroutine(DestroySkill(throwSkill));
            // ���̾�� ������ٵ� ������Ʈ�� �ִ��� Ȯ���ϰ�, �ӵ��� �����մϴ�.
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

        // �̹� �ı����� �ʾҴٸ� �ı�
        if (skill!=null)
        {
            Destroy(skill);
        }
    }
    

}