
using UnityEngine;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public int block;

    // Damage reduction for the opponent's next attack.
    [HideInInspector] public int defensePoints;

    public List<MovesBase> moves = new List<MovesBase>();

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        // Apply defense: 1 point = 10% damage reduction.
        float reduction = Mathf.Clamp(defensePoints * 0.10f, 0f, 1f);
        int reducedDamage = Mathf.CeilToInt(dmg * (1f - reduction));

        // Defense applies to the next attack only.
        defensePoints = 0;

        // Block absorbs damage first.
        int absorbed = Mathf.Min(block, reducedDamage);
        block -= absorbed;
        reducedDamage -= absorbed;

        health = Mathf.Max(0, health - reducedDamage);

        Debug.Log($"{name} has {health}/{maxHealth} HP remaining.");
    }

    public void Heal(int healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    public void AddBlock(int blockAmount)
    {
        block += Mathf.Max(0, blockAmount);
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
