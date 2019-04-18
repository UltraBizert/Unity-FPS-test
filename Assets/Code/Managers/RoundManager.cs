using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public NPCManager NPCManager;
    public Player Player;
    public Button RestartButton;
    public GameObject FinishPanel;
    public int RoundInGame = 3;

    private void Awake()
    {
        RestartButton.onClick.AddListener(RestartGame);
        NPCManager.AllNPCDead += RoundEnded;
        Player.OnDie += () => ShowFinish(true);
    }

    private void RestartGame()
    {
        ShowFinish(false);
        finishedRoundsCount = 0;
        NPCManager.StartRound();
    }

    private int finishedRoundsCount;

    private void RoundEnded()
    {
        finishedRoundsCount++;
        if (finishedRoundsCount >= RoundInGame)
            ShowFinish(true);
        else
            NPCManager.StartRound();
    }

    private void ShowFinish(bool value) => FinishPanel.gameObject.SetActive(value);
}
