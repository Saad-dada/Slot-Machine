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

    [SerializeField] private float tickSoundInterval = 0.1f;
    private float tickTimer = 0f;
    private int currentIndex;

    public IEnumerator Spin(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            currentIndex = Random.Range(0, symbols.Count);
            symbolImage.sprite = symbols[currentIndex];

            tickTimer += spinInterval;

            if (tickTimer >= tickSoundInterval)
            {
                AudioManager.Instance.Play(AudioManager.Instance.reelTick, 0.3f);
                tickTimer = 0f;
            }

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
        AudioManager.Instance.Play(AudioManager.Instance.reelStop, 0.6f);
        symbolImage.sprite = symbols[index];
    }
}