using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {

    #region member variables

    public int m_presentsProduced;

    #endregion

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update ()
    {
		
	}
}
