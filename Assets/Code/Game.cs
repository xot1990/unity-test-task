using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviourService<Game>
{

    public LayerMask enemyLayerMask;
    public LayerMask playerLayerMask;

    public bool isPause;

    protected override void OnCreateService()
    {
        enemyLayerMask = LayerMask.GetMask("Enemy");
        playerLayerMask = LayerMask.GetMask("Player");
        isPause = true;
    }

    protected override void OnDestroyService()
    {
        
    }
}
