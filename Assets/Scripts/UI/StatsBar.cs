using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    [SerializeField] Image fillImageBack;
    [SerializeField] Image fillImageFront;
    [SerializeField] bool delayFill = true;
    [SerializeField] float fillDelay = 0.5f;
    [SerializeField] float fillSpeed = 0.1f;
    float t = 0f;
    protected float targetFillAmount;
    float previousFillAmount;
    float currentFillAmount;

    Canvas canvas;
    WaitForSeconds waitForDelayFill;
    Coroutine bufferedFillingCoroutine;
    private void Awake()
    {
        if (TryGetComponent<Canvas>(out canvas))
        {
            canvas.worldCamera = Camera.main;
        }
        waitForDelayFill = new WaitForSeconds(fillDelay);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    public virtual void Initialize(float currentValue, float maxValue)
    {
        currentFillAmount = currentValue / maxValue;
        targetFillAmount = currentFillAmount;
        fillImageBack.fillAmount = currentFillAmount;
        fillImageFront.fillAmount = currentFillAmount;
    }

    public void UpdateStats(float currentValue, float maxValue)
    {
        targetFillAmount = currentValue / maxValue;

        if (bufferedFillingCoroutine != null)
        {
            StopCoroutine(bufferedFillingCoroutine);
        }

        if (currentFillAmount > targetFillAmount)
        {
            fillImageFront.fillAmount = targetFillAmount;
            bufferedFillingCoroutine = StartCoroutine(BufferedFillingCoroutine(fillImageBack));
        }
        else if (currentFillAmount < targetFillAmount)
        {
            fillImageBack.fillAmount = targetFillAmount;
            bufferedFillingCoroutine = StartCoroutine(BufferedFillingCoroutine(fillImageFront));
        }
    }

    protected virtual IEnumerator BufferedFillingCoroutine(Image image)
    {
        if (delayFill)
        {
            yield return waitForDelayFill;
        }

        previousFillAmount = currentFillAmount;
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * fillSpeed;
            currentFillAmount = Mathf.Lerp(previousFillAmount, targetFillAmount, t);
            image.fillAmount = currentFillAmount;
            yield return null;
        }

    }
}
