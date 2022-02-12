//using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography;
//using Encoding = System.Text.Encoding;
using UnityEngine;
using UnityEngine.Networking;
//using Org.BouncyCastle.Asn1;
//using Org.BouncyCastle.Crypto.Parameters;
//using Org.BouncyCastle.Security;

namespace Tama.API
{
	public class API_Connection : MonoBehaviour
	{
		protected int timeOutLimit = 15;
		protected string requestTimeOut = "RequestTimeOut";
		protected string connectionError = "ConnectionError";
		protected string unknownError = "UnknownError";
		protected string success = "Success";

		protected List<string> successStatus = new List<string>
		{
			"SUCCESS", "SUKSES", "200"
		};

		protected string[] errorMessages = new string[]
		{
			"There is a null response from the server, please try again later!",
			"Your device cannot be connected to the server, please check your internet connection!",
			"There is something wrong with the server, please try again later!",
			"There is a null response from the server",
			"Your device cannot be connected to the server",
			"There is something wrong with the server",
			"Your device is not authorized",
			"Your username or password is incorrect",
			"There is no response from the server, please try again later!"
		};

		protected void CheckResponse(UnityWebRequest req, DownloadHandlerBuffer downloadHandlerBuffer, System.Action<ApiResponse> apiResponse)
		{
			if (req.result == UnityWebRequest.Result.ConnectionError)
			{
				apiResponse(new ApiResponse(false, connectionError, req.responseCode, downloadHandlerBuffer.text));
			}
			else if ((req.result == UnityWebRequest.Result.ProtocolError) || string.IsNullOrEmpty(downloadHandlerBuffer.text) || !successStatus.Contains(req.responseCode.ToString()))
			{
				apiResponse(new ApiResponse(false, unknownError, req.responseCode, downloadHandlerBuffer.text));
			}
			else
			{
				apiResponse(new ApiResponse(true, success, req.responseCode, downloadHandlerBuffer.text));
			}
		}

		protected void CheckResponse(WWW req, System.Action<ApiResponse> apiResponse)
		{
			long responseCode = GetWWWResponseCode(req);

			if (req.error != null || !successStatus.Contains(responseCode.ToString()))
			{
				apiResponse(new ApiResponse(false, unknownError, responseCode, req.text));
			}
			else
			{
				apiResponse(new ApiResponse(true, success, responseCode, req.text));
			}
		}

		protected int GetWWWResponseCode(WWW request)
		{
			if (request.responseHeaders.Equals(null))
			{
				Debug.LogError("No Response Headers.");
			}
			else
			{
				if (!request.responseHeaders.ContainsKey("STATUS"))
				{
					Debug.LogError("Response Headers Has No STATUS.");
				}
				else
				{
					return ParseWWWResponseCode(request.responseHeaders["STATUS"]);
				}
			}

			return 0; // ERROR
		}

		protected int ParseWWWResponseCode(string statusLine)
		{
			int resCode = 0;
			string[] components = statusLine.Split(' ');

			if (components.Length < 3)
			{
				Debug.LogError("Invalid Response Status: " + statusLine);
			}
			else
			{
				if (!int.TryParse(components[1], out resCode))
				{
					Debug.LogError("Invalid Response Code: " + components[1]);
				}
			}

			return resCode;
		}

		protected string Md5Encript(string strToEncrypt)
		{
			System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
			byte[] bytes = ue.GetBytes(strToEncrypt);

			// encrypt bytes
			System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] hashBytes = md5.ComputeHash(bytes);

			// Convert the encrypted bytes back to a string (base 16)
			string hashString = "";

			for (int i = 0; i < hashBytes.Length; i++)
			{
				hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
			}

			return hashString.PadLeft(32, '0');
		}

		//protected string RSAEncryptWithBC(string pkey, string stringToEncrypt)
		//{
		//	Asn1Object obj = Asn1Object.FromByteArray(System.Convert.FromBase64String(pkey));

		//	DerSequence publicKeySequence = (DerSequence)obj;
		//	DerBitString encodedPublicKey = (DerBitString)publicKeySequence[1];
		//	DerSequence publicKey = (DerSequence)Asn1Object.FromByteArray(encodedPublicKey.GetBytes());

		//	DerInteger modulus = (DerInteger)publicKey[0];
		//	DerInteger exponent = (DerInteger)publicKey[1];

		//	RsaKeyParameters keyParameters = new RsaKeyParameters(false, modulus.PositiveValue, exponent.PositiveValue);

		//	RSAParameters parameters = DotNetUtilities.ToRSAParameters(keyParameters);
		//	RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
		//	rsa.ImportParameters(parameters);

		//	byte[] dataToEncrypt = Encoding.UTF8.GetBytes(stringToEncrypt);
		//	byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
		//	return System.Convert.ToBase64String(encryptedData);
		//}

		[System.Serializable]
		public class ApiResponse
		{
			public bool isSuccess;
			public string status;
			public long code;
			public string body;

			public ApiResponse(bool isSuccess, string status, long code, string body)
			{
				this.isSuccess = isSuccess;
				this.status = status;
				this.code = code;
				this.body = body;
			}
		}

		[System.Serializable]
		public class ErrorResponse
		{
			public string error;
			public string error_description;
		}

		[System.Serializable]
		public class Response
		{
			public bool isSuccess;
			public string result;

			public Response(bool isSuccess, string result)
			{
				this.isSuccess = isSuccess;
				this.result = result;
			}
		}
	}
}
