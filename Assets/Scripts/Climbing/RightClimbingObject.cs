
public class RightClimbingObject : ClimbingObject
{
    public override void TryClimb()
    {
        if (!PlayerLocks.Instance.LockRightHand())
        {
            return;
        }

        _objectHasLock = true;
        base.TryClimb();
    }

    public override void ReleaseClimb()
    {
        if (!_objectHasLock)
        {
            return;
        }
        PlayerLocks.Instance.UnlockRightHand();
        base.ReleaseClimb();
    }
}
