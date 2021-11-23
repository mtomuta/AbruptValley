using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHitGenerator : MonoBehaviour
{
    public TextHit textHit;
    public Range defaultRangeX = new Range();
    public Range defaultRangeY = new Range();

    public void CreateTextHit(TextHit textHit, string text, Transform parent, float size, Color color, Range rangeX, Range rangeY, float activeTime)
    {
        Vector3 offset = new Vector2(Random.Range(rangeX.min, rangeX.max), Random.Range(rangeY.min, rangeY.max));
        TextHit newTextHit = Instantiate(textHit, parent.position+offset, Quaternion.identity, parent);
        newTextHit.activeTime = activeTime;
        newTextHit.textMeshPro.color = color;
        newTextHit.textMeshPro.fontSize = size;
        newTextHit.textMeshPro.text = text;
    }

    public void CreateTextHit(TextHit textHit, float text, Transform transform, float size, Color color, Range rangeX, Range rangeY, float activeTime)
    {
        string textString = text.ToString();
        CreateTextHit(textHit, textString, transform, size, color, rangeX, rangeY, activeTime);
    }

    public void CreateTextHit(TextHit textHit, float text, Transform transform, float size, Color color, float activeTime)
    {
        CreateTextHit(textHit, text, transform, size, color, defaultRangeX, defaultRangeY, activeTime);
    }

    public void CreateTextHit(string text)
    {
        CreateTextHit(textHit, text, transform, 0.25f, Color.white, defaultRangeX, defaultRangeY, 2f);
    }

    public void CreateTextHit(float text, Transform parent)
    {
        CreateTextHit(textHit, text, parent, 2.5f, Color.white, defaultRangeX, defaultRangeY, 2f);
    }
}
