using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    [Header("Reel Setup")]
    public Image symbolImage;
    public List<Sprite> symbols;
    public float spinInterval = 0.03f;

    private int currentIndex;

    public IEnumerator Spin(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            currentIndex = Random.Range(0, symbols.Count);
            symbolImage.sprite = symbols[currentIndex];

            yield return new WaitForSeconds(spinInterval);
            timer += spinInterval;
        }
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void SetFinalSymbol(int index)
    {
        currentIndex = index;
        symbolImage.sprite = symbols[index];
    }
}