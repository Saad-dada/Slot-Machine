using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Reels")]
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    [Header("UI")]
    public TMP_Text resultText;
    public GameObject spinButton;

    private bool isSpinning = false;

    public void Spin()
    {
        if (isSpinning) return;

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
            resultText.text = "YOU WIN!";
        }
        else
        {
            resultText.text = "TRY AGAIN";
        }
    }
}