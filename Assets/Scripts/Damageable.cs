using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Damageable : MonoBehaviour
{
	[SerializeField] private Health health;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private UnityEvent damaged;

	private Color _defaultColor;

	// ����˺�
	public void TakeDamage(int damage)
	{
		health.DecreaseHealth(damage);
		// ���˺���˸��ɫ ԭʼ��ɫ->��->ԭʼ��ɫ
		spriteRenderer.DOColor(Color.red, 0.2f).SetLoops(2,LoopType.Yoyo).ChangeStartValue(_defaultColor);

		damaged.Invoke();
	}

	private void Awake()
	{
		_defaultColor = spriteRenderer.color;
	}
}
