
using UnityEngine;

public class WhiteOut : MovesBase
{

    public int damage = 40;
    public Color typeColor = Color.cyan;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "WhiteOut";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        if(Chance(1f))
        {
            target.AddStatus(StatusType.Freeze, StatusIcon, 1);
        }
       
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}