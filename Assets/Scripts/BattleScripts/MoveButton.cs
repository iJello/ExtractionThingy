using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveButton : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;

    private MovesBase assignedMove;
    private BattleManager battleManager;

    private void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }

    public void AssignMove(MovesBase move)
    {
        assignedMove = move;

        buttonText.text = move.moveName;

        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() =>
        {
            battleManager.Attack(assignedMove);
        });
        Debug.Log("Assigned " + move.moveName);
        button.interactable = true;
    }

    public void ClearButton()
    {
        assignedMove = null;

        buttonText.text = "";

        button.onClick.RemoveAllListeners();

        button.interactable = false;
    }
}