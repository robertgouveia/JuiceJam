using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_ShootState : AttackState
{
    private Enemy_2 enemy;
    public E2_ShootState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPosition, D_ShootState stateData, Enemy_2 enemy) : base(stateMachine, entity, animBoolName, attackPosition)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
