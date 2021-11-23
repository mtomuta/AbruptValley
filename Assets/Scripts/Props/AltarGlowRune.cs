using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarGlowRune : MonoBehaviour
{
    public List<SpriteRenderer> runes;
    public float glowUpSpeed;

    private Color currentColor;
    private Color targetColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetColor = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        currentColor = Color.Lerp(currentColor, targetColor, glowUpSpeed * Time.deltaTime);

        foreach (var rune in runes)
        {
            rune.color = currentColor;
        }
    }
}
