using System;
using System.Runtime.CompilerServices;

// Token: 0x020000FF RID: 255
[Serializable]
public class ItemKeyTooltip : IHaveUIData
{
	// Token: 0x060005BB RID: 1467 RVA: 0x0001440A File Offset: 0x0001260A
	public string GetString()
	{
		return this.m_key;
	}

	// Token: 0x04000327 RID: 807
	public string m_key;
}
