using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleSession : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Character player;
    [SerializeField] private Character enemy;

    [SerializeField] private GameObject playerParent;
    [SerializeField] private Image playerImage;
    [SerializeField] private Image playerHandImage;
    [SerializeField] private TMP_Text playerHandLabel;

    [SerializeField] private GameObject enemyParent;
    [SerializeField] private Image enemyImage;
    [SerializeField] private Image enemyHandImage;
    [SerializeField] private TMP_Text enemyHandLabel;

    [SerializeField] private TMP_Text battleResult;
    [SerializeField]private List<Character> hands;
    private Character winner;

    public void SetupBattle()
    {
        playerImage.color = player.color;
        playerHandLabel.text = player.hand.currentHand.ToString();

        enemyImage.color = enemy.color;
        enemyHandLabel.text = enemy.hand.currentHand.ToString();

        battleResult.text = $"{player.hand.currentHand.ToString()} \n vs \n{enemy.hand.currentHand.ToString()}";

        this.gameObject.SetActive(true);
        if (player.hand.currentHand == enemy.hand.currentHand)
        {
            StartCoroutine(OnDraw());
            return;
        }
        winner = GetWinnerHand();
        StartCoroutine(OnHasWinner());
    }

    private IEnumerator OnHasWinner()
    {
        enemyParent.SetActive(true);
        playerParent.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (winner == player)
        {
            enemyParent.SetActive(false);
            playerParent.SetActive(true);
        }
        else
        {
            enemyParent.SetActive(true);
            playerParent.SetActive(false);
        }
        winner.winAmount++;
        battleResult.text = $"{winner.hand.owner.gameObject.name} is win";
        yield return new WaitForSeconds(2f);
        gameManager.OnRoundComplete();
        this.gameObject.SetActive(false);
    }

    private IEnumerator OnDraw()
    {
        enemyParent.SetActive(true);
        playerParent.SetActive(true);
        yield return new WaitForSeconds(1f);
        battleResult.text = "It's Draw";
        yield return new WaitForSeconds(1f);
        gameManager.OnRoundComplete();
        this.gameObject.SetActive(false);
    }

    private Character GetWinnerHand()
    {
        var rock = hands.Find(x => x.hand.currentHand == Hand.HandEnum.Rock);
        var paper = hands.Find(x => x.hand.currentHand == Hand.HandEnum.Paper);
        var scissor = hands.Find(x => x.hand.currentHand == Hand.HandEnum.Scissor);

        if (rock != null && paper != null)
        {
            return paper;
        }
        else if (rock != null && scissor != null)
        {
            return rock;
        }
        else
        {
            return scissor;
        }
    }
}
