using UnityEngine;

public class BaseWeapon : MonoBehaviour, IUsable
{
    [SerializeField] protected float damage; 
    [SerializeField] protected float delayBetweenShoot;
    

    protected bool isReadyToShoot =true;

    public void Use()
    {
		Shoot();
    }

    public virtual void Shoot()
    {

	}

    public void ReadyToShoot()
    {
        isReadyToShoot = true;
    }
}
