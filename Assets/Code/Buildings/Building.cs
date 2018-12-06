using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    #region member variables

    [SerializeField]
    public List<Requirement> m_requirements;
    [SerializeField]
    public List<Operation> m_operations;

    private Inventory m_inventory;

    #endregion

    void Start ()
    {
        m_inventory = GetComponent<Inventory>();
	}
	
	void Update ()
    {
        //bail if one of the requirements are not met
        foreach (Requirement req in m_requirements)
        {
            if (!req.CheckRequirements(m_inventory))
                return;
        }

        foreach (Operation op in m_operations)
        {
            op.Operate();
        }
	}
}

//Secondary utility classes----------------------------------

public abstract class Effect : MonoBehaviour
{
    public abstract void Activate();
}