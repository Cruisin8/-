using Timers;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
	// ¹¥»÷Ä¿±ê±êÇ©
	[SerializeField] private string targetTag;
	// ¹¥»÷ÊÂ¼ş
	[SerializeField] private UnityEvent attack;

	private bool _canAttack = true;

	// Åö×²ÉËº¦
	private void OnTriggerEnter2D(Collider2D collision)
	{
		DealDamage(collision);
	}

	// ÖØµşÉËº¦
	private void OnTriggerStay2D(Collider2D other)
	{
		DealDamage(other);
	}

	private void CanAttack()
	{
		_canAttack = true;
	}

	private void DealDamage(Collider2D col)
	{
		// ÉËº¦ÀäÈ´¼ì²â
		if (!_canAttack) {
			return;
		}

		if (col.CompareTag(targetTag)) {
			Damageable damageable = col.GetComponent<Damageable>();
			damageable.TakeDamage(1);
			// ÉèÖÃÉËº¦ÀäÈ´Îª1s
			TimersManager.SetTimer(this, 1, CanAttack);
			_canAttack = false;
			attack.Invoke();
		}
	}
}
