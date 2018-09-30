namespace UnityEngine.Networking
{
	[RequireComponent(typeof(NetworkManager))]
	public class NetworkHudManager : MonoBehaviour
	{
		private NetworkManager _networkManager;

		private void Awake()
		{
			_networkManager = GetComponent<NetworkManager>();
			StopClient();
		}

		public void StartHost()
		{
			if (!NetworkServer.active)
				_networkManager.StartHost();
		}

		public void StartClient()
		{
			if (!NetworkClient.active)
				_networkManager.StartClient();
		}

		public void StopClient()
		{
			if (NetworkClient.active)
				_networkManager.StopClient();
		}
	}
}