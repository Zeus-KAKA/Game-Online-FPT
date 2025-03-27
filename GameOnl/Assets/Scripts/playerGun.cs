using Fusion;
using UnityEngine;

public class playerGun : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public NetworkRunner networkRunner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (networkRunner is not null && networkRunner.LocalPlayer.IsRealPlayer)
            {
                var bullet = networkRunner.Spawn(bulletPrefab, firePoint.position, firePoint.rotation);

                var bulletdirection = firePoint.forward;
                bullet.GetComponent<Rigidbody>().AddForce(bulletdirection * 20f, ForceMode.Impulse);
            }
        }
    }
}