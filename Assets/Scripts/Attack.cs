using Timers;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
	// ����Ŀ���ǩ
	[SerializeField] private string targetTag;
	// �����¼�
	[SerializeField] private UnityEvent attack;

	private bool _canAttack = true;

	// ��ײ�˺�
	private void OnTriggerEnter2D(Collider2D collision)
	{
		DealDamage(collision);
	}

	// �ص��˺�
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
		// �˺���ȴ���
		if (!_canAttack) {
			return;
		}

		if (col.CompareTag(targetTag)) {
			Damageable damageable = col.GetComponent<Damageable>();
			damageable.TakeDamage(1);
			// �����˺���ȴΪ1s
			TimersManager.SetTimer(this, 1, CanAttack);
			_canAttack = false;
			attack.Invoke();
		}
	}
}
