using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileMG : PointShootProjectile
{
    [SerializeField] private float time;
    [SerializeField] private float speedBullet;
    private float timeLastShoot;
    private bool swiftloadGun;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (Swiftload.swiftloadActivated && !swiftloadGun)
        {
            time -= time * (Swiftload.porcentageTime / 100);
            swiftloadGun = true;
        }

        base.Update();
        Shoot();
    }
    private void Shoot()
    {
        timeLastShoot += Time.deltaTime;

        if (Input.GetMouseButton(0) && timeLastShoot > time && !panelController.inPause && distanceToPlayer > 0.2 && !player.isdead)
        {
            GameObject bulletMG = BulletPool.Instance.RequestBullet("BulletMG(Clone)");
            bulletMG.transform.position = shootPosition.position;
            bulletMG.transform.rotation = transform.rotation;

            if (bulletMG.TryGetComponent(out SpeedProjectile speedProjectile))
            {
                speedProjectile.LaunchProjectile(transform.right, speedBullet);
            }
            timeLastShoot = 0;
        }
    }


}
