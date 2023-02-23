using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : Singleton<TimeController>
{
    [SerializeField, Range(0, 1f)] float bulletTimeScale = 0.1f;
    float defaultFixedDeltaTime;
    float t;

    protected override void Awake()
    {
        base.Awake();
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }
    public void BulletTime(float duration)
    {
        Time.timeScale = bulletTimeScale;
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
        StartCoroutine(SlowOutCoroutine(duration));
    }

    public void BulletTime(float inDuration, float outDuration)
    {
        StartCoroutine(SlowInAndOutCoroutine(inDuration, outDuration));
    }

    public void BulletTime(float inDuration, float keepingDuration, float outDuration)
    {
        StartCoroutine(SlowInKeepAndOutCoroutine(inDuration, keepingDuration, outDuration));
    }
    public void SlowIn(float inDuration)
    {
        StartCoroutine(SlowInCoroutine(inDuration));
    }

    public void SlowOut(float outDuration)
    {
        StartCoroutine(SlowOutCoroutine(outDuration));
    }

    IEnumerator SlowInKeepAndOutCoroutine(float inDuration, float keepingDuration, float outDuration)
    {
        yield return StartCoroutine(SlowInCoroutine(inDuration));
        yield return new WaitForSecondsRealtime(keepingDuration);
        StartCoroutine(SlowOutCoroutine(outDuration));
    }

    IEnumerator SlowInAndOutCoroutine(float inDuration, float outDuration)
    {
        yield return StartCoroutine(SlowInCoroutine(inDuration));

        StartCoroutine(SlowOutCoroutine(outDuration));
    }
    IEnumerator SlowInCoroutine(float duration)
    {
        t = 0f;
        while (Time.timeScale < 1f)
        {
            t += Time.unscaledDeltaTime / duration;
            Time.timeScale = Mathf.Lerp(1f, bulletTimeScale, t);
            Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;

            yield return null;
        }
    }
    IEnumerator SlowOutCoroutine(float duration)
    {
        t = 0f;
        while (Time.timeScale < 1f)
        {
            t += Time.unscaledDeltaTime / duration;
            Time.timeScale = Mathf.Lerp(bulletTimeScale, 1f, t);
            Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;

            yield return null;
        }
    }
}
