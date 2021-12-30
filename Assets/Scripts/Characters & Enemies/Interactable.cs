using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        onWalkAway?.Invoke();
    }

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
        if (player.GetComponent<Health>().ActualHealth < player.GetComponent<Health>().health)
        {
            player.GetComponent<Health>().ActualHealth = player.GetComponent<Health>().health;
            player.GetComponent<Health>().currentHealthBar.fillAmount = (float)player.GetComponent<Health>().ActualHealth / player.GetComponent<Health>().health;
            SoundManager.PlaySound("playerHeal");
        }
    }
}
