using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CM.UI
{
	public class CM_UI_Screen : MonoBehaviour
	{
		[SerializeField] private UnityEvent openEvent;

		private void Awake()
		{
			Setup();
		}

		protected virtual void Setup()
		{

		}

		public virtual void Close()
		{
			gameObject.SetActive(false);
		}

		public virtual void Open()
		{
			openEvent.Invoke();
		}
	}
}