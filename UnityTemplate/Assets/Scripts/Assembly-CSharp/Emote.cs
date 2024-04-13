using System;

// Token: 0x0200027D RID: 637
[Serializable]
public class Emote
{
	// Token: 0x04000A59 RID: 2649
	public string displayName;

	// Token: 0x04000A5A RID: 2650
	public string animationName;

	// Token: 0x04000A5B RID: 2651
	public bool unequip = true;

	// Token: 0x04000A5C RID: 2652
	public float emoteLength = 2f;

	// Token: 0x04000A5D RID: 2653
	public float emoteMovementSpeed = 0.1f;

	// Token: 0x04000A5E RID: 2654
	public bool emoteAllowRotate = true;

	// Token: 0x04000A5F RID: 2655
	public float emoteBaseScore;

	// Token: 0x04000A60 RID: 2656
	public float emoteScoreMultiplier = 1.5f;

	// Token: 0x04000A61 RID: 2657
	public string[] comments;
}
