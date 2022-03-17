using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : AbstractUnit
{
    public enum State
    {
        Walk,
        Angry,
        Dirty,
    }

    private bool isGameStarted = true;
    private float startTimer = 0.3f;
    public TileCustom playerTile;
    public List<Sprite> walk;
    public List<Sprite> angry;
    public List<Sprite> dirty;
       
    protected override void OnStart()
    {
        base.OnStart();
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (isGameStarted)
        {
            startTimer -= Time.deltaTime;

            if (startTimer <= 0)
            {
                ChangeState<IdleEnemyState>();
                isGameStarted = false;
            }
        }

        if (CheckPlayer())
        {
            SceneManager.LoadScene("1");
        }
    }
    
    private bool CheckPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, 0.4f, _game.playerLayerMask);
    }

    public void SpriteSwap(MotionFlag motionFlag, State state)
    {
        switch(state)
        {
            case State.Walk:
                SpriteSwapOnFlag(motionFlag, walk);
                break;
            case State.Dirty:
                SpriteSwapOnFlag(motionFlag, dirty);
                break;
            case State.Angry:
                SpriteSwapOnFlag(motionFlag,angry);
                break;
        }

        void SpriteSwapOnFlag(MotionFlag flag, List<Sprite> sprites)
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
    }

    public void Dirty()
    {
        ChangeState<DirtyState>();
    }
}
