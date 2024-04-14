using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageControl : MonoBehaviour
{
    public Animator theAni;
    public GameObject hitbox;
    [Header("MirageControl")]
    public float lastTime;
    public float lastCounter;

    public bool fadeAway;
    // Start is called before the first frame update
     void Start()
    {
        closeHitBox();
        theAni = GetComponent<Animator>();
        lastCounter = lastTime;
        if (SkillsManager.instance.MirageAttack)
        {
            // Debug.Log("幻影攻击");
            fadeAway = false;
            mirageAttack();
        }
        else
        {
            fadeAway = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeAway)
        {
            if (lastCounter > 0)
            {
                lastCounter -= Time.deltaTime;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, lastCounter);
                if (lastCounter <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private void mirageAttack()
    {
        ChangeAnimation("Attack_1", 0);
        StartCoroutine(AttackCountDownCo());

    }

    private IEnumerator AttackCountDownCo()
    {
        yield return new WaitForSeconds(1.25f);
        ChangeAnimation("idle", 0);
        fadeAway = true;
    }
    public void ChangeAnimation(string animationName, float crossfadeTime = 0.2f)
    {
        theAni.CrossFade(animationName, crossfadeTime);
    }

    public void openHitBox()
    {
        Debug.Log("应该打开攻击");
        hitbox.SetActive(true);
    }

    public void closeHitBox()
    {
        Debug.Log("应该关闭攻击");
        hitbox.SetActive(false);
    }
}
