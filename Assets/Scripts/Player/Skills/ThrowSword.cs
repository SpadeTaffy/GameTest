using Unity.Mathematics;
using UnityEngine;

public class ThrowSword : Skill
{
    public GameObject player;
    public GameObject Sword;
    public float ThrowForce;
    public float gravity;

    public int numberOfDots;
    public float IntervalTime;
    public GameObject dotPrefab;
    public GameObject[] dots;
    public override void useSkill()
    {
        Debug.Log("扔剑");
        var Sword_created = Instantiate(Sword, player.transform.position, player.transform.rotation);

        Sword_created.GetComponent<PlayerSwordThrow>().setSwordProperty(getThrowDirection(), gravity, ThrowForce);

    }

    public Vector2 getThrowDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mousePosition - playerPosition;
        Vector2 throwDirection_nomalized = new Vector2(throwDirection.normalized.x, throwDirection.normalized.y);
        return throwDirection_nomalized;
    }

    public void generateDots()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i]=Instantiate(dotPrefab,player.transform.position,quaternion.identity,player.transform);
            dots[i].SetActive(false);
        }

    }

    public Vector2 setDotsPosition(float time)
    {
        Vector2 Dotposition=(Vector2)player.transform.position+new Vector2(
            getThrowDirection().x*ThrowForce*time,
            getThrowDirection().y*ThrowForce*time+(.5f*gravity*Physics2D.gravity.y*time*time)
        );
        return Dotposition;
    }

    public void setDotsActive(bool isActive)
    {
        for(int i=0;i<numberOfDots;i++)
        {
            dots[i].SetActive(isActive);
        }
    }

}