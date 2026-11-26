
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public BattleManager battleManager;

    [Range(0f, 1f)]
    public float healThreshold = 0.35f;

    public int healAP = 2;

    public float actionDelay = 0.75f;

    private bool isTakingTurn = false;

    public void TakeTurn()
    {
        if (isTakingTurn)
            return;

        StartCoroutine(ExecuteTurn());
    }

    private IEnumerator ExecuteTurn()
    {
        isTakingTurn = true;

        yield return new WaitForSeconds(actionDelay);

        if (battleManager.IsPlayerTurn)
        {
            isTakingTurn = false;
            yield break;
        }

        Creature enemy = battleManager.currentCreature;
        Creature player = battleManager.targetCreature;

        if (enemy == null || player == null)
        {
            isTakingTurn = false;
            yield break;
        }

        while (battleManager.CurrentAP > 0 && enemy.IsAlive() && player.IsAlive())
        {
            bool performedAction = false;

            if (ShouldHeal(enemy))
            {
                int points = Mathf.Min(healAP, battleManager.CurrentAP );

                battleManager.Heal(points);

                performedAction = true;
            }
            else
            {
                MovesBase chosenMove = ChooseMove(enemy);

                if (chosenMove != null)
                {
                    battleManager.Attack(chosenMove);
                    performedAction = true;
                }
            }

            battleManager.HandleUI();

            if (!enemy.IsAlive() || !player.IsAlive())
                break;

            if (!performedAction)
                break;

            yield return new WaitForSeconds(actionDelay);
        }

        //End
        if (enemy.IsAlive() && player.IsAlive())
        {
            yield return new WaitForSeconds(actionDelay);
            battleManager.EndTurn();
        }

        isTakingTurn = false;
    }

    private bool ShouldHeal(Creature enemy)
    {
        float healthPercentage =
            (float)enemy.health / enemy.maxHealth;

        return healthPercentage <= healThreshold &&
               battleManager.CurrentAP > 0 &&
               enemy.health < enemy.maxHealth;
    }

    private MovesBase ChooseMove(Creature enemy)
    {
        MovesBase bestMove = null;
        float highestScore = -1f;

        foreach (MovesBase move in enemy.moves)
        {
            if (move == null)
                continue;

            //checks AP
            if (move.actionPointCost > battleManager.CurrentAP)
                continue;

            // 
            float score = (float)move.aiPriority / move.actionPointCost;

            // Random stuff
            score += Random.Range(0f, 0.5f);

            if (score > highestScore)
            {
                highestScore = score;
                bestMove = move;
            }
        }

        return bestMove;
    }
}
