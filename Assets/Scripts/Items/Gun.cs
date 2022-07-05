using UnityEngine;

public class Gun : BaseWeapon
{
    [SerializeField] protected float distance;

    public override void Shoot()
    {
        base.Shoot();
        if (!isReadyToShoot)
            return;

        isReadyToShoot = false;
    
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {

            if (hit.collider.gameObject.GetComponent<Damageable>())
                hit.collider.gameObject.GetComponent<Damageable>().TakeDamage(damage,true);
        }


        Invoke(nameof(ReadyToShoot), delayBetweenShoot);
    }

}
