using System;
using UnityEngine;

namespace iPhoneXSafeAreaDrawerEditor
{
	/// <summary>
	/// OnGUI が呼び出されるタイミングでイベントを実行するコンポーネント
	/// </summary>
	[ExecuteInEditMode]
	public sealed class OnGUIHandler : MonoBehaviour
	{
		public Action mOnGUI { private get; set; }

		private void OnGUI()
		{
			mOnGUI?.Invoke();
		}
	}
}