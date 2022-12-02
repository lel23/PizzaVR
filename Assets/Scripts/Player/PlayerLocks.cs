
using UnityEngine;
using UnityEngine.Events;

public class PlayerLocks : MonoBehaviour
{

    #region Initialization
    public static PlayerLocks Instance { private set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [HideInInspector] public bool IsPlayerLocked { private set; get; }
    [HideInInspector] public bool IsRightHandLocked { private set; get; }
    [HideInInspector] public bool IsLeftHandLocked { private set; get; }
    
    public UnityEvent OnPlayerLocked;
    public UnityEvent OnPlayerUnlocked;
    public UnityEvent OnRightHandLocked;
    public UnityEvent OnRightHandUnlocked;
    public UnityEvent OnLeftHandLocked;
    public UnityEvent OnLeftHandUnlocked;
    
    public bool LockPlayer()
    {
        if (IsPlayerLocked)
        {
            return false;
        }

        IsPlayerLocked = true;
        OnPlayerLocked.Invoke();
        return true;
    }

    public void UnlockPlayer()
    {
        
        IsPlayerLocked = false;
        OnPlayerUnlocked.Invoke();
    }

    public bool LockRightHand()
    {
        if (IsRightHandLocked)
        {
            return false;
        }

        IsRightHandLocked = true;
        OnRightHandLocked.Invoke();
        return true;
    }

    public void UnlockRightHand()
    {
        
        IsRightHandLocked = false;
        OnRightHandUnlocked.Invoke();
    }
    
    public bool LockLeftHand()
    {
        
        if (IsLeftHandLocked)
        {
            return false;
        }

        IsLeftHandLocked = true;
        OnLeftHandLocked.Invoke();
        return true;
    }

    public void UnlockLeftHand()
    {
        
        IsLeftHandLocked = false;
        OnLeftHandUnlocked.Invoke();
    }
}
