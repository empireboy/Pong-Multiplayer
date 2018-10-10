using UnityEngine;
using UnityEngine.Networking;

namespace CM.Essentials
{
	public class Round : MonoBehaviour
	{
		[SerializeField] private bool _debug;

		private Timer _setupTimer = new Timer();
		public Timer SetupTimer
		{
			get
			{
				return _setupTimer;
			}
		}
		private Timer _endTimer = new Timer();
		public Timer EndTimer
		{
			get
			{
				return _endTimer;
			}
		}

		#region C-Sharp Events
		public delegate void RoundSetupHandler();
		public event RoundSetupHandler RoundSetup;
		public delegate void RoundStartHandler();
		public event RoundStartHandler RoundStart;
		public delegate void RoundEndHandler();
		public event RoundEndHandler RoundEnd;
		public delegate void RoundFinishHandler();
		public event RoundFinishHandler RoundFinish;
		#endregion

		private void Awake()
		{
			_setupTimer.Finished += OnSetupTimerFinished;
			_endTimer.Finished += OnEndTimerFinished;
		}

		private void Start()
		{
			if (_debug)
			{
				_setupTimer.debug = true;
				_endTimer.debug = true;
			}
		}

		public void Starting()
		{
			if (_debug)
				Debug.Log(this + " Start Event");

			if (RoundStart != null)
				RoundStart();
		}

		public void Ending()
		{
			if (_debug)
				Debug.Log(this + " End Event");

			if (RoundEnd != null)
				RoundEnd();
		}

		public void Setup()
		{
			if (_debug)
				Debug.Log("Round Setup Event");

			if (RoundSetup != null)
				RoundSetup();
		}

		public void Finish()
		{
			if (_debug)
				Debug.Log(this + " Finished Event");

			if (RoundFinish != null)
				RoundFinish();
		}

		private void OnSetupTimerFinished()
		{
			if (_debug)
				Debug.Log(this + " OnSetupTimerFinished");

			Starting();
		}

		private void OnEndTimerFinished()
		{
			if (_debug)
				Debug.Log(this + " OnEndTimerFinished");

			Finish();
		}
	}

	public interface IRound
	{
		Round Round();
	}
}