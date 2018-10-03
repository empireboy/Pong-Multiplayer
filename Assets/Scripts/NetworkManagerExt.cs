using System.Net;
using System.Net.Sockets;
using UnityEngine.Events;

namespace UnityEngine.Networking
{
	public class NetworkManagerExt : NetworkManager
	{
		public delegate void StartClientHandler(NetworkClient client);
		public event StartClientHandler StartClientEvent;
		public delegate void DisconnectedClientHandler(NetworkConnection conn);
		public event DisconnectedClientHandler DisconnectedClientEvent;

		public string LocalIPAddress()
		{
			IPHostEntry host;
			string localIP = "";
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					localIP = ip.ToString();
					break;
				}
			}
			return localIP;
		}

		public void ChangeScene(string scene)
		{
			ServerChangeScene(scene);
		}

		public void SetAddress(string address)
		{
			networkAddress = address;
		}

		public void SetLocalAddress()
		{
			networkAddress = LocalIPAddress();
		}

		public void ConnectToServer()
		{
			if (!NetworkClient.active)
			{
				StartClient();
			}
		}

		public void StartServerHost()
		{
			if (!NetworkServer.active)
			{
				StartHost();
			}
		}

		public override void OnStartClient(NetworkClient client)
		{
			base.OnStartClient(client);

			if (StartClientEvent != null)
				StartClientEvent(client);
		}

		public override void OnClientDisconnect(NetworkConnection conn)
		{
			base.OnClientDisconnect(conn);

			if (DisconnectedClientEvent != null)
				DisconnectedClientEvent(conn);
		}
	}
}