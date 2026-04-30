using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    [Header("Reel Setup")]
    public Image symbolImage;
    public List<Sprite> symbols;

    private int currentIndex;
    private bool isSpinning = false;

    public IEnumerator Spin(float duration)
    {
        isSpinning = true;

        float timer = 0f;

        while (timer < duration)
        {
            currentIndex = Random.Range(0, symbols.Count);
            symbolImage.sprite = symbols[currentIndex];

            yield return new WaitForSeconds(0.05f);
            timer += 0.05f;
        }

        isSpinning = false;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}