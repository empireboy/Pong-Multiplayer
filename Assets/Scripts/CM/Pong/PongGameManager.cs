using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM.Essentials;
using UnityEngine.Networking;
using CM.Networking;

namespace CM.Pong
{
	public class PongGameManager : MonoBehaviour, IRound
	{
		[SerializeField] private bool _simulateRoundStart = false;

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

		private bool _gameInitialized = false;

		private void Awake()
		{
			_round = GetComponent<Round>();
			_networkSpawner = GetComponent<NetworkSpawner>();
		}

		private void Start()
		{
			if (_simulateRoundStart)
				StartRound();
		}

		public void StartRound()
		{
			_networkSpawner.SpawnBall();

			_round.Setup();
			_round.SetupTimer.Start(3);
		}

		private void Update()
		{
			if (NetworkServer.connections.Count >= 2 && !_gameInitialized)
			{
				StartRound();
				_gameInitialized = true;
			}
		}
	}
}