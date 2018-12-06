using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour {

    #region member variables

    public GameObject m_pData;

    #endregion

    void Awake ()
    {
		if (!FindObjectOfType<PersistentData>())
        {
            Instantiate(m_pData);
        }
	}
	
	void Update ()
    {

	}
}
