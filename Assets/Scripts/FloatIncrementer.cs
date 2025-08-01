using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatIncrementer : MonoBehaviour
{
    public float currentValue = 0f;

    public async UniTask IncrementOverTime(float targetIncrement, float duration)
    {
        float startValue = currentValue;
        float endValue = startValue + targetIncrement;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            currentValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            await UniTask.Yield();
        }

        currentValue = endValue; 
    }
}
