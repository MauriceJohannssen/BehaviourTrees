﻿public class CheckHealthNode : Node
{
    private AIBlackboard _AI;
    private float _criticalHealthThreshold;

    public CheckHealthNode(AIBlackboard AI, float criticalHealthThreshold)
    {
        _AI = AI;
        _criticalHealthThreshold = criticalHealthThreshold;
    }

    public override State EvaluateState()
    {
        if (_AI.CurrentHealth >= _criticalHealthThreshold)
        {
            nodeState = State.Failure;
            _AI.hidingFirstTime = true;
        }
        else nodeState = State.Success;
        return nodeState;
    }
}
 