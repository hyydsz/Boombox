using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

// Token: 0x0200013E RID: 318
[Serializable]
public class SFX_Settings
{
	// Token: 0x04000383 RID: 899
	public bool spatialize = true;

	// Token: 0x04000384 RID: 900
	public bool nonSpatializedForLocalPlayer;

	// Token: 0x04000385 RID: 901
	public bool occlusion = true;

	// Token: 0x04000386 RID: 902
	[FormerlySerializedAs("reflection")]
	public bool reflections = true;

	// Token: 0x04000387 RID: 903
	public bool transmission;

	// Token: 0x04000388 RID: 904
	[Range(0f, 1f)]
	public float volume = 0.5f;

	// Token: 0x04000389 RID: 905
	[Range(0f, 1f)]
	[Tooltip("0.2 variation means random between 80% of specified volume and 100% of specified volume")]
	public float volume_Variation = 0.2f;

	// Token: 0x0400038A RID: 906
	public float pitch = 1f;

	// Token: 0x0400038B RID: 907
	[Range(0f, 1f)]
	[Tooltip("0.1 variation means random between 95% of specified volume and 105% of specified volume")]
	public float pitch_Variation = 0.1f;

	// Token: 0x0400038C RID: 908
	[Range(0f, 1f)]
	public float spatialBlend = 1f;

	// Token: 0x0400038D RID: 909
	[Range(0f, 1f)]
	public float dopplerLevel = 1f;

	// Token: 0x0400038E RID: 910
	public float range = 150f;

	// Token: 0x0400038F RID: 911
	public float minRange = 1f;

	// Token: 0x04000390 RID: 912
	public AnimationCurve customRangeCurve = new AnimationCurve();

	// Token: 0x04000391 RID: 913
	public int noiseDistance;

	// Token: 0x04000392 RID: 914
	public float cooldown = 0.02f;

	// Token: 0x04000393 RID: 915
	public int maxInstances = 5;

	// Token: 0x04000394 RID: 916
	public AudioMixerGroup mixerGroup;
}
