using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private string walkState;
	[SerializeField] private string idleState;
	[SerializeField] private string attackState;

	public void Move(InputAction.CallbackContext context)
	{
		Vector2 direction = context.ReadValue<Vector2>();
		if (direction == Vector2.zero) {
			animator.Play(idleState);
		}
		else {
			animator.Play(walkState);
		}

		// 控制玩家动画转向
		if (direction.x > 0) {
			spriteRenderer.flipX = false;
		} 
		else if (direction.x < 0) {
			spriteRenderer.flipX = true;
		}
	}

	public void Attack()
	{
		animator.Play(attackState);
	}
}
