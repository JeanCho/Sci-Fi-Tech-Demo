using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    private AudioClip _pickUpClip;

    
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player.HasCoin == false&& Input.GetKeyDown(KeyCode.E))
            {
                player.HasCoin = true;
                
                AudioSource.PlayClipAtPoint(_pickUpClip,Camera.main.transform.position,1f);
                Destroy(this.gameObject);
            }
        }
    }
}
