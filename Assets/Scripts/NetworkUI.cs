using UnityEngine.UI;

namespace UnityEngine.Networking
{
	[RequireComponent(typeof(RectTransform))]
	public class NetworkUI : MonoBehaviour
	{
		public void StartHost()
		{
			FindObjectOfType<NetworkHudManager>().StartHost();
		}

		public void StartClient()
		{
			FindObjectOfType<NetworkHudManager>().StartClient();
		}

		public void ChangeScene(string scene)
		{
			FindObjectOfType<NetworkHudManager>().ChangeScene(scene);
		}

		public void SetAddress(string address)
		{
			FindObjectOfType<NetworkHudManager>().SetAddress(address);
		}
	}
}