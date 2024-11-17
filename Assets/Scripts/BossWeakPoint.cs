using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakPoint : MonoBehaviour
{
    
    public BossController theBC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageBoss(int damageToDeal)
    {
        theBC.TakeDamage(damageToDeal);
    }
}
