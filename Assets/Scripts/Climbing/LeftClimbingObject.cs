
public class LeftClimbingObject : ClimbingObject
{
    public override void TryClimb()
    {
        if (!PlayerLocks.Instance.LockLeftHand())
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
        PlayerLocks.Instance.UnlockLeftHand();
        base.ReleaseClimb();
    }
}
