using UnityEngine.UI;

namespace UnityEngine.Networking
{
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Button))]
	public class NetworkButton : MonoBehaviour
	{
		public void StartHost()
		{
			FindObjectOfType<NetworkHudManager>().StartHost();
		}

		public void StartClient()
		{
			FindObjectOfType<NetworkHudManager>().StartClient();
		}
	}
}