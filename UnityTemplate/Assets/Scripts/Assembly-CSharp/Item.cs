using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zorro.Core.CLI;

// Token: 0x0200020F RID: 527
[CreateAssetMenu(fileName = "Item", menuName = "W/Item", order = -1)]
public class Item : ScriptableObject
{
	// Token: 0x040007EA RID: 2026
	[FormerlySerializedAs("shopName")]
	public string displayName;

	// Token: 0x040007EB RID: 2027
	public Sprite icon;

	// Token: 0x040007EC RID: 2028
	public GameObject itemObject;

	// Token: 0x040007ED RID: 2029
	public Item.ItemType itemType = Item.ItemType.Tool;

	// Token: 0x040007EE RID: 2030
	[FormerlySerializedAs("toolBudget")]
	public int toolBudgetCost = 1;

	// Token: 0x040007EF RID: 2031
	public bool spawnable;

	// Token: 0x040007F0 RID: 2032
	public RARITY toolSpawnRarity = RARITY.common;

	// Token: 0x040007F1 RID: 2033
	public int budgetCost;

	// Token: 0x040007F2 RID: 2034
	public float rarity = 1f;

	// Token: 0x040007F3 RID: 2035
	public PropContent content;

	// Token: 0x040007F4 RID: 2036
	public float groundSizeMultiplier = 1f;

	// Token: 0x040007F5 RID: 2037
	public float groundMassMultiplier = 1f;

	// Token: 0x040007F6 RID: 2038
	public float mass = 3f;

	// Token: 0x040007F7 RID: 2039
	public Vector3 holdPos;

	// Token: 0x040007F8 RID: 2040
	public bool useAlternativeHoldingPos;

	// Token: 0x040007F9 RID: 2041
	public Vector3 alternativeHoldPos;

	// Token: 0x040007FA RID: 2042
	public Vector3 holdRotation;

	// Token: 0x040007FB RID: 2043
	public bool useAlternativeHoldingRot;

	// Token: 0x040007FC RID: 2044
	public Vector3 alternativeHoldRot;

	// Token: 0x040007FD RID: 2045
	public byte id;

	// Token: 0x040007FE RID: 2046
	public string persistentID;

	// Token: 0x040007FF RID: 2047
	public bool purchasable;

	// Token: 0x04000800 RID: 2048
	public ShopItemCategory Category;

	// Token: 0x04000801 RID: 2049
	public int price;

	// Token: 0x04000802 RID: 2050
	public int quantity;

	// Token: 0x04000803 RID: 2051
	public Emote emoteInfo;

	// Token: 0x04000804 RID: 2052
	public List<ItemKeyTooltip> Tooltips = new List<ItemKeyTooltip>();

	// Token: 0x020003B6 RID: 950
	public enum ItemType
	{
		// Token: 0x04001123 RID: 4387
		Camera,
		// Token: 0x04001124 RID: 4388
		Tool,
		// Token: 0x04001125 RID: 4389
		Artifact,
		// Token: 0x04001126 RID: 4390
		Disc
	}
}
