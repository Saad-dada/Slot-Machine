using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Economy")]
    public int startingBalance = 100;
    public int spinCost = 10;
    private int balance;

    [Header("Spin Settings")]
    [SerializeField] private float reel1Duration = 1.0f;
    [SerializeField] private float reel2Duration = 1.2f;
    [SerializeField] private float reel3Duration = 1.4f;

    [SerializeField, Range(0.05f, 0.5f)] private float stopDelay = 0.2f;

    [Header("Win Settings")]
    [SerializeField, Range(0.1f, 0.8f)] private float winChance = 0.3f;

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
        resultText.text = "Press Spin";
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
        spinButton.GetComponent<UnityEngine.UI.Button>().interactable = false;

        // Deduct cost
        balance -= spinCost;
        UpdateBalanceUI();

        resultText.text = "Spinning...";

        bool isWin = Random.value < winChance;

        int r1 = Random.Range(0, reel1.symbols.Count);
        int r2 = isWin ? r1 : Random.Range(0, reel2.symbols.Count);
        int r3 = isWin ? r1 : Random.Range(0, reel3.symbols.Count);

        yield return StartCoroutine(reel1.Spin(reel1Duration));
        reel1.SetFinalSymbol(r1);

        yield return new WaitForSeconds(stopDelay);

        yield return StartCoroutine(reel2.Spin(reel2Duration));
        reel2.SetFinalSymbol(r2);

        yield return new WaitForSeconds(stopDelay);

        yield return StartCoroutine(reel3.Spin(reel3Duration));
        reel3.SetFinalSymbol(r3);

        CheckWin();

        spinButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
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
            case 0: return 100; // 7
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