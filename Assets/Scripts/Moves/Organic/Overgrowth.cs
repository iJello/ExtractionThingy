
using UnityEngine;

public class Overgrowth : MovesBase
{

    public int damage = 20;
    public Color typeColor = Color.green;
    void Awake()
    {
        moveName = "Overgrowth";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        user.Heal(15);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}