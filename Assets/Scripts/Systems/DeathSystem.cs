using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathSystem : MonoBehaviour
{
    [SerializeField] protected float timeDeath;

    protected bool isActiveTimerDeath;

    protected virtual void Update()
    {
        if (isActiveTimerDeath)
        {
            timeDeath -= Time.deltaTime;
            if (timeDeath <= 0)
            {
                isActiveTimerDeath = false;
                OnDeathEnd();
            }
        }
    }

    public virtual void Death()
    {
        PlayDeathAnimation();
        OnDeathStart();
        isActiveTimerDeath = true;
    }

    protected abstract void PlayDeathAnimation();
    protected abstract void OnDeathStart();
    protected abstract void OnDeathEnd();
}

