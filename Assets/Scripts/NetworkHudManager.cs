namespace UnityEngine.Networking
{
	[RequireComponent(typeof(NetworkManager))]
	public class NetworkHudManager : MonoBehaviour
	{
		private NetworkManager _networkManager;

		private void Awake()
		{
			_networkManager = GetComponent<NetworkManager>();
		}

		public void StartHost()
		{
			if (!NetworkServer.active && !NetworkClient.active)
				_networkManager.StartHost();
		}
	}
}