using System;
using UnityEngine;

// Token: 0x02000140 RID: 320
public class SFX_PlayOneShot : MonoBehaviour
{
	public Action beforePlayAction;

	// Token: 0x0400039F RID: 927
	public Action afterPlayAction;

	// Token: 0x040003A0 RID: 928
	public bool playOnStart;

	// Token: 0x040003A1 RID: 929
	public bool playOnEnable;

	// Token: 0x040003A2 RID: 930
	public bool playOnClick;

	// Token: 0x040003A3 RID: 931
	public float cd;

	// Token: 0x040003A4 RID: 932
	private float lastTimePlayed;

	// Token: 0x040003A5 RID: 933
	private bool t;

	// Token: 0x040003A6 RID: 934
	public SFX_Instance sfx;

	// Token: 0x040003A7 RID: 935
	public SFX_Instance[] sfxs;
}
