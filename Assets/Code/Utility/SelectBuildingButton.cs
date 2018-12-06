using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBuildingButton : MonoBehaviour {

    public int m_selectionID;

    public void SelectBuilding()
    {
        FindObjectOfType<BuildingsManager>().SelectBuilding(m_selectionID);
    }
}
