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
		// ���λ��
		Vector2 playerPosition = PlayerManager.Position;	
		// ����λ��
		Vector2 position = transform.position;
		// �ƶ�����
		Vector2 direction = playerPosition - position;
		// ��������һ�����������
		direction.Normalize();
		// Ŀ��λ��
		Vector2 targetPosition = position + direction;
		// ������ƶ�
		rb.DOMove(targetPosition, _speed).SetSpeedBased();
		moveDirection.Invoke(direction);
	}
}
