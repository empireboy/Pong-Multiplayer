using UnityEngine;
using UnityEngine.Events;

namespace CM.UI
{
	public class CM_UI_Screen : MonoBehaviour
	{
		[SerializeField] private UnityEvent openEvent;

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