using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Essentials {
	public class UnityWebRequestAwaiter : System.Runtime.CompilerServices.INotifyCompletion {

		private readonly UnityWebRequestAsyncOperation _asyncOp;
		private Action _continuation;

		public UnityWebRequestAwaiter(UnityWebRequestAsyncOperation asyncOp) {
			_asyncOp = asyncOp;
			asyncOp.completed += OnRequestCompleted;
		}

		public bool IsCompleted => _asyncOp.isDone;

		public void GetResult() {
			if (_asyncOp.webRequest.result == UnityWebRequest.Result.ConnectionError ||
				_asyncOp.webRequest.result == UnityWebRequest.Result.ProtocolError)
				Debug.LogError(_asyncOp.webRequest.error);
		}

		public void OnCompleted(Action continuation) {
			if (IsCompleted)
				continuation?.Invoke();
			else
				_continuation = continuation;
		}

		private void OnRequestCompleted(AsyncOperation obj) {
			_continuation?.Invoke();
		}
	}
}