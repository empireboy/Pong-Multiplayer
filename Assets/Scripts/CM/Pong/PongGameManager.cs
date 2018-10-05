using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM.Essentials;
using UnityEngine.Networking;

namespace CM.Pong
{
	public class PongGameManager : MonoBehaviour, IRound
	{
		private Round _round;
		public Round Round()
		{
			return _round;
		}
		private NetworkSpawner _networkSpawner;
		public NetworkSpawner NetworkSpawner
		{
			get
			{
				return _networkSpawner;
			}
		}

		private void Awake()
		{
			_round = GetComponent<Round>();
			_networkSpawner = GetComponent<NetworkSpawner>();
		}

		private void Update()
		{
			if (NetworkServer.connections.Count >= 2 && !_round.Started)
			{
				//_round.SetupTimer.Start(3);
				_round.RoundStart += OnRoundStart;
				_round.Starting();
				//_round.Setup();
			}
		}

		private void OnRoundStart()
		{
			_networkSpawner.SpawnBall();
		}
	}
}