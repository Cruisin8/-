using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float _speed;
	[SerializeField] private UnityEvent<Vector2> moveDirection;

	private void FixedUpdate()
	{
		// 玩家位置
		Vector2 playerPosition = PlayerManager.Position;	
		// 自身位置
		Vector2 position = transform.position;
		// 移动距离
		Vector2 direction = playerPosition - position;
		// 把向量归一化，方便计算
		direction.Normalize();
		// 目标位置
		Vector2 targetPosition = position + direction;
		// 向玩家移动
		rb.DOMove(targetPosition, _speed).SetSpeedBased();
		moveDirection.Invoke(direction);
	}
}
