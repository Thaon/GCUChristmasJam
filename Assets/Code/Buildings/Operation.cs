using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
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