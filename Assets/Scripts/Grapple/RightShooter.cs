using UnityEngine;

public class RightShooter: Shooter
{
    public override void FireShooter()
    {
        if (!PlayerLocks.Instance.LockRightHand())
        {
            return;
        }
        EnableShooter();
        base.FireShooter();
    }

    public override void ReleaseShooter()
    {
        if (!_shooterHasLock)
        {
            return;
        }
        base.ReleaseShooter();
        PlayerLocks.Instance.UnlockRightHand();
    }
}
