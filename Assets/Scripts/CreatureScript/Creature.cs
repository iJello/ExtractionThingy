
using UnityEngine;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public int block;
    public int defensePoints;
    
    //Shader stuff
    public CreatureShaderController shaderController;

    public List<MovesBase> moves = new List<MovesBase>();

    private void Awake()
    {
        health = maxHealth;
        if (shaderController == null)
        {
            shaderController = GetComponent<CreatureShaderController>();
        }
    
    }

    public void TakeDamage(int dmg)
    {
  
        float reduction = Mathf.Clamp(defensePoints * 0.10f, 0f, 1f);
        int reducedDamage = Mathf.CeilToInt(dmg * (1f - reduction));

   
        defensePoints = 0;

 
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
