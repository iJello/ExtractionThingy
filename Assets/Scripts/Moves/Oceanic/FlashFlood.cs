
using UnityEngine;

public class FlashFlood : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.blue;
    void Awake()
    {
        moveName = "FlashFlood";
    }
    public override void Action(Creature user, Creature target)
    {
        Debug.Log("Has Swiftstream: " + user.HasStatus(StatusType.Swiftstream));
        if(user.HasStatus(StatusType.Swiftstream))
        {
            Debug.Log("Swiftin");
            damage = Mathf.RoundToInt(damage * 1.25f);
            user.RemoveStatus(StatusType.Swiftstream);
        }
        target.TakeDamage(damage);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}