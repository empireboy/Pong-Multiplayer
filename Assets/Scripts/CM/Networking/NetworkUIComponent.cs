using UnityEngine;
using UnityEngine.Networking;

namespace CM.Networking
{
	[RequireComponent(typeof(RectTransform))]
	public class NetworkUIComponent : MonoBehaviour
	{
		public void StartHost()
		{
			FindObjectOfType<CM_NetworkManager>().StartServerHost();
		}

		public void StartClient()
		{
			FindObjectOfType<CM_NetworkManager>().ConnectToServer();
		}

		public void ChangeScene(string scene)
		{
			FindObjectOfType<CM_NetworkManager>().ChangeScene(scene);
		}

		public void SetAddress(string address)
		{
			FindObjectOfType<CM_NetworkManager>().SetAddress(address);
		}

		public void SetLocalAddress()
		{
			FindObjectOfType<CM_NetworkManager>().SetLocalAddress();
		}
	}
}