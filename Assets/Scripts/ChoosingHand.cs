using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingHand : MonoBehaviour
{
    [SerializeField] private BattleSession battleSession;
    [SerializeField] private Character playerHand;
    [SerializeField] private Character enemyHand;

    public void Setup()
    {
        this.gameObject.SetActive(true);
    }

    public void OnPlayerChooseHand(int handIndex)
    {
        playerHand.hand.currentHand = (Hand.HandEnum)handIndex;
        SetEnemyHand();
    }

    private void SetEnemyHand()
    {
        enemyHand.hand.currentHand = (Hand.HandEnum)(Random.Range(1, 3 * 100) % 3);
        
        battleSession.SetupBattle();
        this.gameObject.SetActive(false);
    }
}
