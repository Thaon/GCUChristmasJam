using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour {

    #region member variables

    public BuildingsPrefab[] m_buildingsPrefabs;
    public int m_selectedBuilding = -1;

    private GameObject m_activeSelection = null;
    private PersistentData m_pData;

    #endregion

    void Start()
    {
        m_pData = FindObjectOfType<PersistentData>();
    }

    void Update()
    {
        //debug selection
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectBuilding(0);
        }

        //spawn building
        if (Input.GetMouseButtonDown(0))
        {
            if (m_pData.m_presentsProduced >= m_buildingsPrefabs[m_selectedBuilding].m_price)
            {
                m_pData.m_presentsProduced -= m_buildingsPrefabs[m_selectedBuilding].m_price;
                m_activeSelection.GetComponent<BuildingVisualizer>().BuildConcreteVersion();
            }
        }
    }

    public void SelectBuilding(int buildingID)
    {
        if (m_selectedBuilding != buildingID)
        {
            if (m_activeSelection != null)
            {
                Destroy(m_activeSelection);
                m_activeSelection = null;
            }

            m_selectedBuilding = buildingID;
            m_activeSelection = Instantiate(m_buildingsPrefabs[buildingID].m_prefab);
        }
    }
}

[System.Serializable]
public class BuildingsPrefab
{
    public GameObject m_prefab;
    public int m_price;
}
