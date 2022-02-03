using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingHand : MonoBehaviour
{
    [SerializeField] private BattleSession battleSession;
    [SerializeField] private Character player;
    [SerializeField] private Character enemy;
    [SerializeField] private Image playerImage;

    public void Setup()
    {
        playerImage.color = player.color;
        this.gameObject.SetActive(true);
    }

    public void OnPlayerChooseHand(int handIndex)
    {
        player.hand.currentHand = (Hand.HandEnum)handIndex;
        SetEnemyHand();
    }

    private void SetEnemyHand()
    {
        enemy.hand.currentHand = (Hand.HandEnum)(Random.Range(1, 3 * 100) % 3);
        
        battleSession.SetupBattle();
        this.gameObject.SetActive(false);
    }
}
