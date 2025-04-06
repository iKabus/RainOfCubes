using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public IEnumerator FadeOut(float duration)
    {
        var material = GetComponent<Renderer>().material;

        var startAlpha = material.color.a;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            var newColor = material.color;
            newColor.a = Mathf.Lerp(startAlpha, 0, t / duration);
            material.color = newColor;

            yield return null;
        }

        var finalColor = material.color;

        finalColor.a = 0;

        material.color = finalColor;
    }
}