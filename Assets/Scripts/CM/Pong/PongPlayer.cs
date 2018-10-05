using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace CM.Pong
{
	public class PongPlayer : NetworkBehaviour
	{
		private float _radius;

		public override void OnStartLocalPlayer()
		{
			GetComponent<SpriteRenderer>().color = Color.white;
		}

		private void Start()
		{
			if (!isLocalPlayer)
				enabled = false;

			_radius = transform.localScale.y / 2;
		}

		private void Update()
		{
			float height = 2f * Camera.main.orthographicSize;
			float width = height * Camera.main.aspect;

			if (Input.GetKey(KeyCode.UpArrow))
			{
				if (transform.position.y < height / 2 - _radius)
				{
					transform.Translate(Vector2.up * 2 * Time.deltaTime);
				}
				else
				{
					transform.position = new Vector3(transform.position.x, height / 2 - _radius);
				}
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				if (transform.position.y > -height / 2 + _radius)
				{
					transform.Translate(Vector2.down * 2 * Time.deltaTime);
				}
				else
				{
					transform.position = new Vector3(transform.position.x, -height / 2 + _radius);
				}
			}
		}
	}
}