using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement : MonoBehaviour
{
    public Inventory m_requirements;

    public bool CheckRequirements(Inventory inv)
    {
        foreach (Item itm in m_requirements.m_contents)
        {
            if (inv.CheckItemQuantity(itm.m_name) < itm.m_quantity)
                return false;
        }
        return true;
    }
}
