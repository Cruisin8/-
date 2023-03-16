using UnityEngine;
using DG.Tweening;

public class MagicMissileMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float _speed;
	// ������Χ�뾶
	[SerializeField] private int _colRadius = 10;

	// �ӵ�����
	private Vector2 _direction;	

	// ������λ��
	private GameObject LocateEnemy()
	{
		Collider2D[] results = new Collider2D[_colRadius];
		// Բ��Ϊ�ӵ�λ�ã��뾶Ϊ_colRadius���ֳ�_colRadius�η���ÿһ�εļ����
		Physics2D.OverlapCircleNonAlloc(transform.position, _colRadius, results);

		foreach(var result in results) {
			if (result != null && result.CompareTag("Enemy")) {
				return result.gameObject;
			}
		}

		// ����ֵnull���Ż�
		return null;
	}

	// �ӵ��ƶ�
	private Vector2 MoveDirection(Transform target)
	{
		// ����һ�����򣬲�����Ԥ��ֵ
		Vector2 direction = new Vector2(1, 0);

		if (target != null) {
			direction = target.position - transform.position;
			direction.Normalize();
		}

		return direction;
	}

	private void Awake()
	{
		// ���־ͼ��
		GameObject enemy = LocateEnemy();
		if (enemy != null) {
			_direction = MoveDirection(enemy.transform);
		}
		else {
			// enemy�����ܷ���null
			_direction = MoveDirection(null);
		}
		
		// ��ת�ӵ�ͷ�������
		transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);
	}

	private void FixedUpdate()
	{
		Vector2 targetPosition = (Vector2)transform.position + _direction;
		rb.DOMove(targetPosition, _speed).SetSpeedBased();
	}
}
