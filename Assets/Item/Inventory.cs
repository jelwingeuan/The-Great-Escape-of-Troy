using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private HashSet<ItemId> owned = new HashSet<ItemId>();

    public bool Has(ItemId id) => owned.Contains(id);

    public void Add(ItemId id)
    {
        owned.Add(id);
    }
}
