using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractUnit
{
    

    void Start()
    {
        base.OnStart();
        ChangeState<IdleEnemyState>();
    }

}
