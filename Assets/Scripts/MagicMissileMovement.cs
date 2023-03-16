using UnityEngine;
using DG.Tweening;

public class MagicMissileMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float _speed;
	// 攻击范围半径
	[SerializeField] private int _colRadius = 10;

	// 子弹方向
	private Vector2 _direction;	

	// 检测敌人位置
	private GameObject LocateEnemy()
	{
		Collider2D[] results = new Collider2D[_colRadius];
		// 圆心为子弹位置，半径为_colRadius，分成_colRadius段返回每一段的检测结果
		Physics2D.OverlapCircleNonAlloc(transform.position, _colRadius, results);

		foreach(var result in results) {
			if (result != null && result.CompareTag("Enemy")) {
				return result.gameObject;
			}
		}

		// 返回值null待优化
		return null;
	}

	// 子弹移动
	private Vector2 MoveDirection(Transform target)
	{
		// 创建一个方向，并给予预设值
		Vector2 direction = new Vector2(1, 0);

		if (target != null) {
			direction = target.position - transform.position;
			direction.Normalize();
		}

		return direction;
	}

	private void Awake()
	{
		// 开局就检测
		GameObject enemy = LocateEnemy();
		if (enemy != null) {
			_direction = MoveDirection(enemy.transform);
		}
		else {
			// enemy检测可能返回null
			_direction = MoveDirection(null);
		}
		
		// 旋转子弹头朝向敌人
		transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);
	}

	private void FixedUpdate()
	{
		Vector2 targetPosition = (Vector2)transform.position + _direction;
		rb.DOMove(targetPosition, _speed).SetSpeedBased();
	}
}
