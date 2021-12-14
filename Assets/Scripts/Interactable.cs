using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour //IPointerDownHandler
{
    protected BoxCollider2D myCollider;
    protected PlayerController player;
    public UnityEvent onInteraction;
    public UnityEvent onWalkAway;

    protected Health health;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerController>();
        //player = GameManager.instance.player.GetComponent<PlayerController>();
    }

    private void Update()
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        onWalkAway?.Invoke();
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Interact();
    //}

    public virtual void Interact()
    {
        foreach (RaycastHit2D interactable in player.Interact())
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

    public virtual void InteractionHeal()
    {
        player.GetComponent<Health>().ActualHealth = 6;
        player.GetComponent<Health>().currentHealthBar.fillAmount = (float)player.GetComponent<Health>().ActualHealth / player.GetComponent<Health>().health;
        SoundManager.PlaySound("playerHeal");
    }
}
