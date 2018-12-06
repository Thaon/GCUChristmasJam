using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    #region member variables

    public List<Requirement> m_requirements;
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

public class Requirement : Behaviour
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

public abstract class Effect : Behaviour
{
    public abstract void Activate();
}

public class Operation : Behaviour
{
    public float m_timeToComplete;
    public List<Effect> m_effects;

    private float m_timer;

    public void Operate()
    {
        m_timer += Time.deltaTime;

        if (m_timer > m_timeToComplete)
        {
            foreach (Effect eff in m_effects)
            {
                eff.Activate();
            }
            m_timer = 0;
        }
    }
}