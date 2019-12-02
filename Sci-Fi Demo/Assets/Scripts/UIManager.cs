using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private GameObject _itemImage;
    void Start()
    {
        _ammoText.text = "30/30";
    }

    // Update is called once per frame
    public void UpdateAmmo(int count)
    {
        _ammoText.text = count + "/30";
    }

    public void UpdateItem()
    {
        _itemImage.SetActive(true);
    }

    public void UseItem()
    {
        _itemImage.SetActive(false);

    }
}
