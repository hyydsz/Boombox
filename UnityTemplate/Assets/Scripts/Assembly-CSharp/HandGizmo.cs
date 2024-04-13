using System;
using UnityEngine;

// Token: 0x020001DE RID: 478
public class HandGizmo : MonoBehaviour
{
	// Token: 0x06000A64 RID: 2660 RVA: 0x0002B7D6 File Offset: 0x000299D6
	private void Start()
	{
		base.transform.GetChild(0).gameObject.SetActive(false);
	}
}
