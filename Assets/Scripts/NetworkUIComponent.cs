namespace UnityEngine.Networking
{
	[RequireComponent(typeof(RectTransform))]
	public class NetworkUIComponent : MonoBehaviour
	{
		public void StartHost()
		{
			FindObjectOfType<NetworkManagerExt>().StartServerHost();
		}

		public void StartClient()
		{
			FindObjectOfType<NetworkManagerExt>().ConnectToServer();
		}

		public void ChangeScene(string scene)
		{
			FindObjectOfType<NetworkManagerExt>().ChangeScene(scene);
		}

		public void SetAddress(string address)
		{
			FindObjectOfType<NetworkManagerExt>().SetAddress(address);
		}

		public void SetLocalAddress()
		{
			FindObjectOfType<NetworkManagerExt>().SetLocalAddress();
		}
	}
}