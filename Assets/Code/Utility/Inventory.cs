using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region member variables

    public List<Item> m_contents;

    #endregion

    public void AddItem(string item, int quantity)
    {
        m_contents.Add(new Item(item, quantity));
    }

    public void RemoveItem(string item, int quantity)
    {
        foreach (Item itm in m_contents)
        {
            if (itm.m_name == item && itm.m_quantity >= quantity)
            {
                itm.m_quantity -= quantity;
                if (itm.m_quantity == 0)
                    m_contents.Remove(itm);
            }
        }
    }

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

    public Item(string nam, int qty)
    {
        m_name = nam;
        m_quantity = qty;
    }

    public string m_name;
    public int m_quantity;
}

