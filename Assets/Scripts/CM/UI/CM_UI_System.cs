using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace CM.UI
{
	public class CM_UI_System : MonoBehaviour
	{
		public CM_UI_Screen startScreen;

		private Component[] _screens;

		private CM_UI_Screen _currentScreen;
		public CM_UI_Screen CurrentScreen
		{
			get
			{
				return _currentScreen;
			}
		}

		private void Awake()
		{
			_screens = GetComponentsInChildren<CM_UI_Screen>(true);
		}

		private void Start()
		{
			_currentScreen = startScreen;
		}

		public virtual void SwitchScreens(CM_UI_Screen screen)
		{
			if (screen)
			{
				_currentScreen.Close();

				_currentScreen = screen;
				_currentScreen.gameObject.SetActive(true);
				_currentScreen.Open();
			}
		}
	}
}