using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRL : PointShootProjectile
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
            GameObject bulletRL = BulletPool.Instance.RequestBullet("BulletRL(Clone)");
            bulletRL.transform.position = shootPosition.position;
            bulletRL.transform.rotation = transform.rotation;

            if (bulletRL.TryGetComponent(out BulletRL bulletRLScript))
            {
                bulletRLScript.LaunchProjectile(transform.right, speedBullet);
                bulletRLScript.endPosition = worldPosition;
            }
            timeLastShoot = 0;

        }



    }


}
