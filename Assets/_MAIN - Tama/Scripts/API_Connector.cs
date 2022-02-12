using System.Collections;
using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Net;
//using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;

namespace Tama.API
{ 
	public class API_Connector : API_Connection
	{
		public static API_Connector instance;

		private const string sampleUrl = "https://www.google.com";

		private void Awake()
		{
			instance = this;
		}

		public void GetID(string token, System.Action<ApiResponse> apiResponse)
		{
			StartCoroutine(GetIDCoroutine(token, apiResponse));
		}

		IEnumerator GetIDCoroutine(string token, System.Action<ApiResponse> apiResponse)
		{
			string url = $"{sampleUrl}/api/user/token?{token}"; // EDIT HERE

			UnityWebRequest req = UnityWebRequest.Get(url);
			req.timeout = timeOutLimit;
			DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();
			req.downloadHandler = downloadHandlerBuffer;

			yield return req.SendWebRequest();

			CheckResponse(req, downloadHandlerBuffer, apiResponse);
		}

		public void GetScore(string id, System.Action<ApiResponse> apiResponse)
		{
			StartCoroutine(GetScoreCoroutine(id, apiResponse));
		}

		IEnumerator GetScoreCoroutine(string id, System.Action<ApiResponse> apiResponse)
		{
			string url = $"{sampleUrl}/api/score/id?{id}"; // EDIT HERE

			UnityWebRequest req = UnityWebRequest.Get(url);
			req.timeout = timeOutLimit;
			DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();
			req.downloadHandler = downloadHandlerBuffer;

			yield return req.SendWebRequest();

			CheckResponse(req, downloadHandlerBuffer, apiResponse);
		}

		public void PostScore(string id, string token, int game, int score, System.Action<ApiResponse> apiResponse)
		{
			StartCoroutine(PostScoreCoroutine(id, token, game, score, apiResponse));
		}

		IEnumerator PostScoreCoroutine(string id, string token, int game, int score, System.Action<ApiResponse> apiResponse)
		{
			string url = $"{sampleUrl}/api/score"; // EDIT HERE

			WWWForm content = new WWWForm();
			content.AddField("token", token);
			content.AddField("id", id);
			content.AddField("game", game);
			content.AddField("score", score);

			UnityWebRequest req = UnityWebRequest.Post(url, content);
			req.timeout = timeOutLimit;
			DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();
			req.downloadHandler = downloadHandlerBuffer;

			yield return req.SendWebRequest();

			CheckResponse(req, downloadHandlerBuffer, apiResponse);
		}

		#region HTTP CLIENT
		//public static async Task<Response> GetID(string token)
		//{
		//	string url = $"{serverUrl}/api/user?{token}"; // EDIT HERE
		//	HttpClient client = new HttpClient { BaseAddress = new System.Uri(url) };

		//	try
		//	{
		//		using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress))
		//		{
		//			using (HttpResponseMessage response = await client.SendAsync(request))
		//			{
		//				return new Response(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
		//			}
		//		}
		//	}
		//	catch (HttpRequestException e)
		//	{
		//		return new Response(false, e.ToString());
		//	}
		//}

		//public static async Task<Response> GetScore(string id)
		//{
		//	string url = $"{serverUrl}/api/score?{id}"; // EDIT HERE
		//	HttpClient client = new HttpClient { BaseAddress = new System.Uri(url) };

		//	try
		//	{
		//		using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress))
		//		{
		//			using (HttpResponseMessage response = await client.SendAsync(request))
		//			{
		//				return new Response(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
		//			}
		//		}
		//	}
		//	catch (HttpRequestException e)
		//	{
		//		return new Response(false, e.ToString());
		//	}
		//}

		//public static async Task<Response> PostScore(string id, string token, int game, int score)
		//{
		//	string url = $"{serverUrl}/api/score"; // EDIT HERE
		//	HttpClient client = new HttpClient { BaseAddress = new System.Uri(url) };

		//	try
		//	{
		//		using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress))
		//		{
		//			var content = new MultipartFormDataContent
		//			{
		//				{ new StringContent(token), "token" },
		//				{ new StringContent(id), "id" },
		//				{ new StringContent(game.ToString()), "game" },
		//				{ new StringContent(score.ToString()), "score" }
		//			};

		//			request.Content = content;

		//			using (HttpResponseMessage response = await client.SendAsync(request))
		//			{
		//				return new Response(response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
		//			}
		//		}
		//	}
		//	catch (HttpRequestException e)
		//	{
		//		return new Response(false, e.ToString());
		//	}
		//}
		#endregion HTTP CLIENT
	}
}