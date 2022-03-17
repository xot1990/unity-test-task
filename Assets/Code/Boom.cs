using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private Game _game;

    private float explosionTimer = 2;

    void Start()
    {
        _game = Game.Get();    
    }
    
    void Update()
    {
        explosionTimer -= Time.deltaTime;

        if (explosionTimer <= 0)
        {
            foreach (var Target in Physics2D.OverlapCircleAll(transform.position, 2, _game.enemyLayerMask))
            {
                Target.GetComponent<Enemy>().Dirty();
            }

            Destroy(gameObject);
        }
    }
}
