using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousGlowRune : MonoBehaviour
{
    public Gradient gradient;
    public float time;

    private SpriteRenderer sprite;
    private float timer;

    private void Start()
    {
        timer = time * Random.value;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (sprite)
        {
            timer += Time.deltaTime;
            if (timer > time) timer = 0.0f;

            sprite.color = gradient.Evaluate(timer / time);
        }
    }
}
