using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShop : MonoBehaviour
{
    [SerializeField]
    private AudioClip _purchaseClip;
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player!= null)
            {
                if(player.HasCoin == true&&Input.GetKeyDown(KeyCode.E))
                {
                    player.GetGun();
                    player.HasCoin = false;
                    AudioSource.PlayClipAtPoint(_purchaseClip, Camera.main.transform.position, 1f);
                }
            }
        }
    }
}
