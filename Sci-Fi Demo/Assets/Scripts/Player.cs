using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.8f;

    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    [SerializeField]
    private AudioSource _weaponAudio;
    
    private UIManager _uImanager;
    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 30;
    public bool HasCoin = false;
    private bool _isReloading = false;
    private bool _havingGun = false;
    [SerializeField]
    private GameObject _weapon;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxAmmo;
        _uImanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uImanager == null)
        {
            Debug.LogError("Can't find UI MANAGER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(HasCoin)
        {
            _uImanager.UpdateItem();
        }
        if(!HasCoin)
        {
            _uImanager.UseItem();
        }
        if(_havingGun)
        {
            Shoot();
        }
        
        if(Input.GetKeyDown(KeyCode.R)&& _isReloading ==false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
            
        }

        ExitGameMode();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    private void ExitGameMode()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    private void Shoot()
    {
        if (Input.GetMouseButton(0)&&_currentAmmo > 0)
        {
            _currentAmmo--;
            _uImanager.UpdateAmmo(_currentAmmo);
            _muzzleFlash.SetActive(true);
            if(_weaponAudio.isPlaying == false)
            {
                _weaponAudio.Play();

            }
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                GameObject hitmarker = (GameObject)Instantiate(_hitMarker,hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                Destroy(hitmarker, 1.0f);

                Destructable crate = hitInfo.transform.GetComponent<Destructable>();
                if(crate != null)
                {
                    crate.DestroyCrate();
                }
            }
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }
    }

    IEnumerator Reload()
    {

        
        yield return new WaitForSeconds(1.5f);


        _currentAmmo = _maxAmmo;

        _uImanager.UpdateAmmo(_currentAmmo);

        _isReloading = false;
    }

    public void GetGun()
    {
        _weapon.SetActive(true);
        _havingGun = true;
    }

}
