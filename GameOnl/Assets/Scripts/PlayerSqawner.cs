using Fusion;
using UnityEngine;
// class này dùng để spawn player vào game trong network
public class playerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    // khi vào mạng thì tạo nhân vật cho người chơi
    public void PlayerJoined(PlayerRef player)
    {
        // kiểm tra xem người chơi này có phải là người đang chơi không
        if(player == Runner.LocalPlayer)
        {
            //tạo nhân vật vị trí (0,1,0)
            var position = new Vector3(0, 1, 0);
            // spawn nhân vật ở vị trí này
            Runner.Spawn(
                playerPrefab, 
                position, 
                Quaternion.identity,
                Runner.LocalPlayer,
                (runner, obj) => 
                {
                    
                });
            
        }

    }
}