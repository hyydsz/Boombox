using System;
using UnityEngine;
using UnityEngine.Audio;
using Zorro.Core;

// Token: 0x0200002E RID: 46
public class AudioLoop : MonoBehaviour
{
	// Token: 0x0400007A RID: 122
	public AudioClip clip;

	// Token: 0x0400007B RID: 123
	public AudioMixerGroup mixerGroup;

	// Token: 0x0400007C RID: 124
	public float volume = 1f;

	// Token: 0x0400007D RID: 125
	public float pitch = 1f;

	// Token: 0x0400007E RID: 126
	public float minDistance = 1f;

	// Token: 0x0400007F RID: 127
	public float maxDistance = 100f;

	// Token: 0x04000080 RID: 128
	public float obstrability = 0.8f;

	// Token: 0x04000081 RID: 129
	public float blend = 1f;

	// Token: 0x04000082 RID: 130
	private Optionable<float> overrideStartTime = Optionable<float>.None;

	// Token: 0x04000083 RID: 131
	private int checkID;
}
