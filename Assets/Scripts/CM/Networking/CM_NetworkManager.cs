using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;

namespace CM.Networking
{
	public class CM_NetworkManager : NetworkManager
	{
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
	}
}