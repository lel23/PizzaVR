using UnityEngine;

public class LeftShooter: Shooter
{
    public override void FireShooter()
    {
        if (!PlayerLocks.Instance.LockLeftHand())
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
        PlayerLocks.Instance.UnlockLeftHand();
    }
}
