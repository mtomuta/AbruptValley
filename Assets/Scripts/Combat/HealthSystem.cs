using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public static HealthSystem Instance;

	public Image currentHealthBar;
	public float hitPoint = 100f;
	public float maxHitPoint = 100f;

	public Image currentXpBar;
	public float xpPoint = 100f;
	public float maxXpPoint = 100f;

	public bool Regenerate = true;
	public float regen = 0.1f;
	private float timeleft = 0.0f;	// Left time for current interval
	public float regenUpdateInterval = 1f;

	public bool GodMode;

	void Awake()
	{
		Instance = this;
	}
	
  	void Start()
	{
		UpdateGraphics();
		timeleft = regenUpdateInterval; 
	}

	void Update ()
	{
		if (Regenerate)
			Regen();
	}

	private void Regen()
	{
		timeleft -= Time.deltaTime;

		if (timeleft <= 0.0) // Interval ended - update health & mana and start new interval
		{
			// Debug mode
			if (GodMode)
			{
				HealDamage(maxHitPoint);
			}
			else
			{
				HealDamage(regen);			
			}

			UpdateGraphics();

			timeleft = regenUpdateInterval;
		}
	}

	private void UpdateHealthBar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
	}

	public void TakeDamage(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;

		UpdateGraphics();

		StartCoroutine(PlayerHurts());
	}

	public void HealDamage(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	public void SetMaxHealth(float max)
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);

		UpdateGraphics();
	}

	private void UpdateXpBar()
	{
		float ratio = xpPoint / maxXpPoint;
		currentXpBar.rectTransform.localPosition = new Vector3(currentXpBar.rectTransform.rect.width * ratio - currentXpBar.rectTransform.rect.width, 0, 0);
	}

	private void UpdateGraphics()
	{
		UpdateHealthBar();
		UpdateXpBar();
	}

	IEnumerator PlayerHurts()
	{
		// Player gets hurt. Do stuff.. play anim, sound..

		if (hitPoint < 1) // Health is Zero!!
		{
			yield return StartCoroutine(PlayerDied()); // Hero is Dead
		}

		else
			yield return null;
	}

	IEnumerator PlayerDied()
	{
		// Player is dead. Do stuff.. play anim, sound..
		//PopupText.Instance.Popup("You have died!", 1f, 1f); // Demo stuff!

		yield return null;
	}
}
