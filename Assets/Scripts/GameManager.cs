using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Economy")]
    public int startingBalance = 100;
    public int spinCost = 10;
    private int balance;


    [Header("Reels")]
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    [Header("UI")]
    public TMP_Text resultText;
    public GameObject spinButton;
    public TMPro.TMP_Text balanceText;

    private bool isSpinning = false;

    void Start()
    {
        balance = startingBalance;
        UpdateBalanceUI();
    }

    public void Spin()
    {
        if (isSpinning) return;

        if (balance < spinCost)
        {
            resultText.text = "Not enough coins!";
            return;
        }

        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;
        spinButton.SetActive(false);

        resultText.text = "Spinning...";

        // Start reels one by one (better feel)
        yield return StartCoroutine(reel1.Spin(1.0f));
        yield return StartCoroutine(reel2.Spin(1.2f));
        yield return StartCoroutine(reel3.Spin(1.4f));

        CheckWin();

        spinButton.SetActive(true);
        isSpinning = false;
    }

    private void CheckWin()
    {
        int r1 = reel1.GetCurrentIndex();
        int r2 = reel2.GetCurrentIndex();
        int r3 = reel3.GetCurrentIndex();

        if (r1 == r2 && r2 == r3)
        {
            int reward = GetReward(r1);
            balance += reward;

            resultText.text = "YOU WIN! +" + reward;
        }
        else
        {
            resultText.text = "TRY AGAIN";
        }

        UpdateBalanceUI();
    }

    private int GetReward(int symbolIndex)
    {
        // Example mapping based on your symbol order
        switch (symbolIndex)
        {
            case 0: return 100; // 7 (high value)
            case 1: return 50;  // Cherry
            case 2: return 30;  // Bell
            case 3: return 20;  // BAR
            default: return 10;
        }
    }

    private void UpdateBalanceUI()
    {
        balanceText.text = "Coins: " + balance;
    }
}