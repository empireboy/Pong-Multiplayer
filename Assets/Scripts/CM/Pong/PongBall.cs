using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using CM.Pong;

namespace CM.Networking
{
	public class PongBall : NetworkBehaviour
	{
		[SerializeField] private float _speed;

		private float _radius;
		private Vector2 _direction;

		private bool _canMove = false;

		private void Start()
		{
			if (!isServer)
				enabled = false;

			_radius = transform.localScale.x / 2;
			_direction = Vector2.one.normalized;
			_direction.x = (Random.Range(0, 2) == 0) ? -1 : 1;
			_direction.y = (Random.Range(0, 2) == 0) ? -1 : 1;
		}

		private void Update()
		{
			if (!_canMove)
				return;

			transform.Translate(_direction * _speed * Time.deltaTime);

			float height = 2f * Camera.main.orthographicSize;
			float width = height * Camera.main.aspect;

			if (transform.position.y < -height / 2 + _radius && _direction.y < 0)
			{
				_direction.y = -_direction.y;
			}
			if (transform.position.y > height / 2 - _radius && _direction.y > 0)
			{
				_direction.y = -_direction.y;
			}

			if (transform.position.x < -width / 2 + _radius)
			{
				NetworkServer.Destroy(gameObject);
				FindObjectOfType<PongGameManager>().StartRound();
			}
			if (transform.position.x > width / 2 - _radius)
			{
				NetworkServer.Destroy(gameObject);
				FindObjectOfType<PongGameManager>().StartRound();
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (_direction.x < 0)
			{
				_direction.x = -_direction.x;
			}
			else if (_direction.x > 0)
			{
				_direction.x = -_direction.x;
			}
		}

		public void SetMovable(bool movable)
		{
			_canMove = movable;
		}
	}
}