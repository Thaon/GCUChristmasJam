using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region member variables

    public List<Item> m_contents;

    #endregion

    public bool CheckItem(string itemName)
    {
        foreach (Item itm in m_contents)
        {
            if (itm.m_name == itemName)
                return true;
        }
        return false;
    }

    public int CheckItemQuantity(string itemName)
    {
        int qty = 0;
        foreach (Item itm in m_contents)
        {
            if (itm.m_name == itemName)
                qty++;
        }

        return qty;
    }
}

[System.Serializable]
public class Item {

    public string m_name;
    public int m_quantity;
}

