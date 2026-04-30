using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeverController : MonoBehaviour
{
    [Header("Handle States")]
    [SerializeField] private GameObject leverActive;
    [SerializeField] private GameObject leverInactive;

    [Header("Timing")]
    [SerializeField] private float pressDuration = 0.15f;

    private bool isPressed = false;

    void Start()
    {
        SetIdleState();
    }

    public void PlayLeverAnimation()
    {
        if (!isPressed)
            StartCoroutine(HandlePressRoutine());
    }

    private IEnumerator HandlePressRoutine()
    {
        isPressed = true;

        leverInactive.SetActive(true);
        leverActive.SetActive(false);

        yield return new WaitForSeconds(pressDuration);

        SetIdleState();
        isPressed = false;
    }

    private void SetIdleState()
    {
        if (leverActive != null) leverActive.SetActive(true);
        if (leverInactive != null) leverInactive.SetActive(false);
    }
}