using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerDownHandler
{
    protected BoxCollider2D myCollider;
    protected PlayerController jugador;
    public UnityEvent onInteraction;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        jugador = GameManager.instance.player.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    onInteraction?.Invoke();
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        Interact();
    }

    private void Interact()
    {
        foreach (RaycastHit2D interactable in jugador.Interact())
        {
            if (interactable.collider.gameObject == gameObject)
            {
                Interaction();
            }
        }
    }

    public virtual void Interaction()
    {
        onInteraction?.Invoke();
    }
}
