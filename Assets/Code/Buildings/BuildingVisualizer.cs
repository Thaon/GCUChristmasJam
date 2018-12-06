using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingVisualizer : MonoBehaviour {

    #region member variables

    public GameObject m_concreteVersion;

    private Material m_mat;

    #endregion

    private void Start()
    {
        m_mat = GetComponentInChildren<MeshRenderer>().sharedMaterial;
    }

    void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            transform.position = hit.point;
        }
	}

    public void BuildConcreteVersion()
    {
        Instantiate(m_concreteVersion, transform.position, transform.rotation);
    }
}
