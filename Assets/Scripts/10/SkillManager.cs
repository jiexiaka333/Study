using System.Collections;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public bool canUseSkill = true;
    void Start()
    {
        //StartCoroutine(DestroyAfterDelay(this.gameObject,3f));
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUseSkill)
        {
            UseSkill();
        }
        //StartCoroutine(WaitForPlayerAction());

    }

    void UseSkill()
    {
        Debug.Log("释放技能！");
        StartCoroutine(SkillCooldown());
    }

    IEnumerator SkillCooldown()
    {
        canUseSkill = false;
        // 冷却5秒
        yield return new WaitForSeconds(5f);
        canUseSkill = true;
        Debug.Log("技能冷却结束");
    }
    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
    IEnumerator WaitForPlayerAction()
    {
        Debug.Log("等待玩家按空格...");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        Debug.Log("玩家按下了空格！");
    }
}
