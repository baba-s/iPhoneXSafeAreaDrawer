using UnityEngine;

[CreateAssetMenu]
public sealed class iPhoneXSafeAreaDrawerSettings : ScriptableObject
{
	[SerializeField] private bool m_isEnable	= false;
	[SerializeField] private bool m_isPortrait	= false;

	public bool IsEnable	=> m_isEnable	;
	public bool IsPortrait	=> m_isPortrait	;
}
