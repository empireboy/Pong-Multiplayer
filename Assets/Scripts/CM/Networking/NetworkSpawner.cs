using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Networking
{
	public class NetworkSpawner : NetworkBehaviour
	{
		[SerializeField] private GameObject _ball;

		public GameObject SpawnBall()
		{
			GameObject ball = Instantiate(_ball);
			NetworkServer.Spawn(ball);

			return ball;
		}
	}
}