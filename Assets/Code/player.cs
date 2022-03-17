using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractUnit
{
    public GameObject bomb;

    public float bombTimer = 2;
    public List<Sprite> walk;   

    protected override void OnUpdate()
    {
        base.OnUpdate();
        bombTimer -= Time.deltaTime;
    }

    public void SpriteSwapOnFlag(MotionFlag flag, List<Sprite> sprites)
    {
        switch (flag)
        {
            case MotionFlag.Down:
                spriteRenderer.sprite = sprites[3];
                break;
            case MotionFlag.Left:
                spriteRenderer.sprite = sprites[1];
                break;
            case MotionFlag.Right:
                spriteRenderer.sprite = sprites[0];
                break;
            case MotionFlag.Up:
                spriteRenderer.sprite = sprites[2];
                break;
        }
    }

    protected override void OnStart()
    {
        base.OnStart();
        ChangeState<IdleState>();
    }

}
