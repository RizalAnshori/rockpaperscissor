using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int totalRound;
    [SerializeField] private ChoosingHand choosingHand;
    [SerializeField] private BattleSession battleSession;
    [SerializeField] private ResultHandler resultHandler;

    private int currentRound;

    private void Start()
    {
        choosingHand.Setup();
    }

    public void OnRoundComplete()
    {
        currentRound++;
        if(currentRound < totalRound)
        {
            choosingHand.Setup();
        }
        else
        {
            resultHandler.Setup();
        }
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
