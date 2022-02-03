using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultHandler : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private Character enemy;

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text winnerName;
    [SerializeField] private Image winnerImage;

    private Character winner;

    public void Setup()
    {
        if(player.winAmount > enemy.winAmount)
        {
            winner = player;
        }
        else
        {
            winner = enemy;
        }

        ShowResult(player.winAmount == enemy.winAmount);
    }

    private void ShowResult(bool isDraw)
    {
        winnerImage.color = winner.color;
        this.gameObject.SetActive(true);
        if(isDraw)
        {
            title.text = "Draw";
            winnerName.text = "";
            winnerImage.gameObject.SetActive(false);
            return;
        }
        title.text = "Congratulation";
        winnerImage.gameObject.SetActive(true);
        winnerName.text = $"{winner.gameObject.name} is the Winner";
        winnerImage.sprite = winner.currentSprite;
    }
}
