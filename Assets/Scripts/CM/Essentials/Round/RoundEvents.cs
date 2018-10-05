using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CM.Essentials
{
	public class RoundEvents : MonoBehaviour
	{
		[SerializeField] private MonoBehaviour _manager;

		public UnityEvent onRoundSetup;
		public UnityEvent onRoundStart;
		public UnityEvent onRoundEnd;
		public UnityEvent onRoundFinish;

		private void Start()
		{
			IRound manager = (IRound)_manager;
			manager.Round().RoundSetup += OnRoundSetup;
			manager.Round().RoundStart += OnRoundStart;
			manager.Round().RoundEnd += OnRoundEnd;
			manager.Round().RoundFinish += OnRoundFinish;
		}

		private void OnRoundSetup()
		{
			onRoundSetup.Invoke();
		}

		private void OnRoundStart()
		{
			onRoundStart.Invoke();
		}

		private void OnRoundEnd()
		{
			onRoundEnd.Invoke();
		}

		private void OnRoundFinish()
		{
			onRoundFinish.Invoke();
		}
	}
}