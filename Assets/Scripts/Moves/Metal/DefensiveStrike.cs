
using UnityEngine;

public class DefensiveStrike : MovesBase
{

    public int damage = 20;
    public Color typeColor = Color.gray;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "DefensiveStrike";
    }
    public override void Action(Creature user, Creature target)
    {
        if(user.HasStatus(StatusType.Defend))
        {
            target.TakeDamage(Mathf.RoundToInt(damage * 1.25f));
        }
        else
        {
            target.TakeDamage(damage);
        }
        
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}