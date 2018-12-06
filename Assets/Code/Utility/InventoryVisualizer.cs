using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVisualizer : MonoBehaviour {

    #region member variables

    private Text m_text;
    private PersistentData m_pData;
    private Inventory m_playerInv;

    #endregion

    void Start ()
    {
        m_text = GetComponent<Text>();
        m_pData = FindObjectOfType<PersistentData>();
        m_playerInv = m_pData.GetComponent<Inventory>();
    }
	
	void Update ()
    {
        string info = "";
        info += "Presents = " + m_pData.m_presentsProduced + "\n";

        foreach (Item itm in m_playerInv.m_contents)
        {
            info += itm.m_name + " = " + itm.m_quantity + "\n"; 
        }

        m_text.text = info;
	}
}
