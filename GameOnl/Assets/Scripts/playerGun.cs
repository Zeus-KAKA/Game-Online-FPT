using Fusion;
using UnityEngine;

public class playerGun : NetworkBehaviour
{
    public GameObject bulletPrefab;  // Tiền tố của viên đạn
    public Transform firePoint;      // Vị trí bắn

    public NetworkRunner networkRunner;  // NetworkRunner để quản lý mạng

    private void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Kiểm tra nếu NetworkRunner không phải null và người chơi là người thật
            if (networkRunner != null && networkRunner.LocalPlayer.IsRealPlayer)
            {
                // Tạo viên đạn trên mạng
                var bullet = networkRunner.Spawn(bulletPrefab, firePoint.position, firePoint.rotation);

                // Lấy hướng di chuyển của viên đạn
                var bulletDirection = firePoint.forward;

                // Thêm lực vào Rigidbody của viên đạn để nó di chuyển
                var rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(bulletDirection * 20f, ForceMode.Impulse);
                }
            }
        }
    }
}