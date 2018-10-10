using System.Collections;
using UnityEngine;

namespace CM.Essentials
{
	public class Timer
	{
		public bool debug = false;

		private int _currentSeconds;

		#region C-Sharp Events
		public delegate void TimerFinishHandler();
		public event TimerFinishHandler Finished;
		public delegate void TimerSecondsChangedHandler(int seconds);
		public event TimerSecondsChangedHandler SecondsChanged;
		#endregion

		public void Start(int seconds)
		{
			if (debug)
				Debug.Log(this + " Start");

			_currentSeconds = seconds;
			GameObject.FindObjectOfType<MonoBehaviour>().StartCoroutine(Routine(seconds));
		}

		private IEnumerator Routine(int seconds)
		{
			while (_currentSeconds > 0)
			{
				if (SecondsChanged != null)
					SecondsChanged(_currentSeconds);

				if (debug)
					Debug.Log(this + " Seconds " + _currentSeconds);

				yield return new WaitForSeconds(1);
				_currentSeconds--;
			}

			if (debug)
				Debug.Log(this + " Finished");

			if (SecondsChanged != null)
				SecondsChanged(_currentSeconds);

			if (Finished != null)
				Finished();
		}
	}
}