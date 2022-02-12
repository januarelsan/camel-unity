using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tama.API;

namespace Tama.Score
{
	public class ScoreManager : MonoBehaviour
	{
		[Header("Attributes")]
		[SerializeField] string id;
		[SerializeField] string token;
		[SerializeField] int game;

		public void GetUserId()
		{
			API_Connector.instance.GetID(token, apiResponse =>
			{
#if UNITY_EDITOR
				Debug.Log(apiResponse.body); // string result or JSON data
#endif

				if (apiResponse.isSuccess)
				{
					// TODO: JSON Parsing

					// CONTINUE
				}
				else
				{
					// TODO : Handle Error
				}
			});
		}

		public void GetGameScore()
		{
			API_Connector.instance.GetScore(id, apiResponse =>
			{
#if UNITY_EDITOR
				Debug.Log(apiResponse.body); // string result or JSON data
#endif

				if (apiResponse.isSuccess)
				{
					// TODO: JSON Parsing

					// CONTINUE
				}
				else
				{
					// TODO : Handle Error
				}
			});
		}

		public void PostGameScore(int score)
		{
			API_Connector.instance.PostScore(id, token, game, score, apiResponse =>
			{
#if UNITY_EDITOR
				Debug.Log(apiResponse.body); // string result or JSON data
#endif

				if (apiResponse.isSuccess)
				{
					// TODO: JSON Parsing

					// CONTINUE
				}
				else
				{
					// TODO : Handle Error
				}
			});
		}
	}
}
