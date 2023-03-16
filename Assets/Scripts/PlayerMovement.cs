using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float _speed;
	private Vector2 _inputDirection;

	public void Move(InputAction.CallbackContext context)
	{
		_inputDirection = context.ReadValue<Vector2>();
	}

	private void FixedUpdate()
	{
		// 当前位置
		Vector2 position = transform.position;
		// 目标位置
		Vector2 targetPosition = position + _inputDirection;

		// 消除达到目标位置后继续move导致的抖动
		if (position != targetPosition) {
			// 设置为按速度移动
			rb.DOMove(targetPosition, _speed).SetSpeedBased();
		}
		
	}
}
