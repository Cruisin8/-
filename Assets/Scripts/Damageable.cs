using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Damageable : MonoBehaviour
{
	[SerializeField] private Health health;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private UnityEvent damaged;

	private Color _defaultColor;

	// 造成伤害
	public void TakeDamage(int damage)
	{
		health.DecreaseHealth(damage);
		// 受伤后闪烁红色 原始颜色->红->原始颜色
		spriteRenderer.DOColor(Color.red, 0.2f).SetLoops(2,LoopType.Yoyo).ChangeStartValue(_defaultColor);

		damaged.Invoke();
	}

	private void Awake()
	{
		_defaultColor = spriteRenderer.color;
	}
}
