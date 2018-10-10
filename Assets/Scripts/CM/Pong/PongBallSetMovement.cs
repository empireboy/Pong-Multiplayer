using UnityEngine;
using CM.Networking;

namespace CM.Pong
{
	public class PongBallSetMovement : MonoBehaviour
	{
		private void Start()
		{
			FindObjectOfType<PongGameManager>().Round().RoundStart += OnRoundStart;
		}

		private void OnRoundStart()
		{
			GetComponent<PongBall>().SetMovable(true);

			FindObjectOfType<PongGameManager>().Round().RoundStart -= OnRoundStart;
		}
	}
}