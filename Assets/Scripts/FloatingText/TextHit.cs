using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent (typeof(TextMeshPro))]
public class TextHit : MonoBehaviour
{
    public Color color;
    public TextMeshPro textMeshPro;
    private Vector3 verticalMovement;

    public float activeTime = 1f;
    public float elevationDistance = 2;
    public float startTimeFade;

    private float actualDistance = 0;
    private float textAscend = 0.1f;
    private bool fading;

    void start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        verticalMovement = new Vector3(0, textAscend);
    }

    void Update()
    {
        if (actualDistance < elevationDistance)
        {
            transform.localPosition += verticalMovement;
            actualDistance += textAscend;
        }
        else
        {
            if (fading == false)
            {
                //Destroy(gameObject, activeTime);
                fading = true;
                StartCoroutine(Fade());
            }
        }
    }

    IEnumerator Fade()
    {
        Color actualColor = textMeshPro.color;
        for (float alpha = 1; alpha > 0; alpha -= (1/(activeTime)*Time.deltaTime))
        {
            actualColor.a = alpha;
            textMeshPro.color = actualColor;
            yield return new WaitForEndOfFrame();
        }
    }
}
