using UnityEngine;

// Token: 0x0200013D RID: 317
[CreateAssetMenu(fileName = "SoundEffectInstance", menuName = "Landfall/SoundEffectInstance")]
public class SFX_Instance : ScriptableObject
{
	// Token: 0x04000380 RID: 896
	public AudioClip[] clips;

	// Token: 0x04000381 RID: 897
	public SFX_Settings settings;

	// Token: 0x04000382 RID: 898
	internal float lastTimePlayed;
}
