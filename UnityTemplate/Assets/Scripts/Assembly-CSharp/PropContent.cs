using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000134 RID: 308
[CreateAssetMenu(fileName = "PropContent", menuName = "ContentEvent/PropContent", order = 0)]
public class PropContent : ScriptableObject
{
	// Token: 0x04000446 RID: 1094
	[HideInInspector]
	public bool isArtifact;

	// Token: 0x04000447 RID: 1095
	public float contentValue;

	// Token: 0x04000448 RID: 1096
	public ushort id;

	// Token: 0x04000449 RID: 1097
	public string[] comments;
}
