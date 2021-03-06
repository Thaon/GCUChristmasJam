﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsManager : MonoBehaviour {

    #region member variables

    public BuildingsPrefab[] m_buildingsPrefabs;
    public int m_selectedBuilding = -1;
    public Material m_canPlace, m_cannotPlace;

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

        //change material
        if (m_activeSelection != null)
        {
            Collider[] buildingsInArea = Physics.OverlapSphere(m_activeSelection.transform.position, 10);

            foreach (Collider coll in buildingsInArea)
            {
                if (coll.tag == "Building")
                {
                    m_activeSelection.GetComponentInChildren<MeshRenderer>().sharedMaterial = m_cannotPlace;
                    return;
                }
            }
            m_activeSelection.GetComponentInChildren<MeshRenderer>().sharedMaterial = m_canPlace;

        }

        //spawn building
        if (m_activeSelection != null && Input.GetMouseButtonDown(0))
        {
            //check collisions
            Vector3 pos1 = m_activeSelection.transform.position;
            pos1.y = 0;

            Collider[] buildingsInArea = Physics.OverlapSphere(m_activeSelection.transform.position, 10);

            foreach (Collider coll in buildingsInArea)
            {
                if (coll.tag == "Building")
                    return;
            }

            //spawn if have resources
            if (m_pData.m_presentsProduced >= m_buildingsPrefabs[m_selectedBuilding].m_price)
            {
                m_pData.m_presentsProduced -= m_buildingsPrefabs[m_selectedBuilding].m_price;
                m_activeSelection.GetComponent<BuildingVisualizer>().BuildConcreteVersion();
            }
        }

        //deselect building
        if (Input.GetMouseButtonDown(1))
        {
            m_selectedBuilding = -1;
            if (m_activeSelection != null)
            {
                Destroy(m_activeSelection);
                m_activeSelection = null;
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
