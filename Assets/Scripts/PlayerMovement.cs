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
		// ��ǰλ��
		Vector2 position = transform.position;
		// Ŀ��λ��
		Vector2 targetPosition = position + _inputDirection;

		// �����ﵽĿ��λ�ú����move���µĶ���
		if (position != targetPosition) {
			// ����Ϊ���ٶ��ƶ�
			rb.DOMove(targetPosition, _speed).SetSpeedBased();
		}
		
	}
}
