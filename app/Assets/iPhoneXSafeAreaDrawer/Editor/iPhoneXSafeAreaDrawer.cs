using System.Linq;
using UnityEditor;
using UnityEngine;

namespace iPhoneXSafeAreaDrawerEditor
{
	[InitializeOnLoad]
	public static class iPhoneXSafeAreaDrawer
	{
		private static Texture m_portraitImage;
		private static Texture m_landscapeImage;
		private static iPhoneXSafeAreaDrawerSettings m_settings;

		private static Texture portraitImage
		{
			get
			{
				if ( m_portraitImage == null )
				{
					var guid = AssetDatabase
						.FindAssets( "iPhoneXSafeAreaDrawer-portrait" )
						.FirstOrDefault()
					;

					var path = AssetDatabase.GUIDToAssetPath( guid );

					m_portraitImage = AssetDatabase.LoadAssetAtPath<Texture>( path );
				}
				return m_portraitImage;
			}
		}

		private static Texture landscapeImage
		{
			get
			{
				if ( m_landscapeImage == null )
				{
					var guid = AssetDatabase
						.FindAssets( "iPhoneXSafeAreaDrawer-landscape" )
						.FirstOrDefault()
					;

					var path = AssetDatabase.GUIDToAssetPath( guid );

					m_landscapeImage = AssetDatabase.LoadAssetAtPath<Texture>( path );
				}
				return m_landscapeImage;
			}
		}

		private static iPhoneXSafeAreaDrawerSettings settings
		{
			get
			{
				if ( m_settings == null )
				{
					m_settings = AssetDatabase
						.FindAssets( "t:iPhoneXSafeAreaDrawerSettings" )
						.Select( c => AssetDatabase.GUIDToAssetPath( c ) )
						.Select( c => AssetDatabase.LoadAssetAtPath<iPhoneXSafeAreaDrawerSettings>( c ) )
						.FirstOrDefault()
					;
				}
				return m_settings;
			}
		}

		static iPhoneXSafeAreaDrawer()
		{
			// Unity エディタ起動時にゲームオブジェクトを生成する場合は
			// 1 フレーム処理を遅らせる必要がある
			EditorApplication.delayCall += Initialize;
		}

		private static void Initialize()
		{
			var obj = GameObject.Find( "OnGUIHandler" );

			if ( obj == null )
			{
				obj = new GameObject( "OnGUIHandler", typeof( OnGUIHandler ) );
				obj.hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy;
			}

			var handler = obj.GetComponent<OnGUIHandler>();
			handler.mOnGUI = OnGUI;
		}

		private static void OnGUI()
		{
			if ( !settings.IsEnable ) return;

			var img = settings.IsPortrait ? portraitImage : landscapeImage;
			var pos = new Rect( 0, 0, Screen.width, Screen.height );
			GUI.DrawTexture( pos, img );
		}
	}
}