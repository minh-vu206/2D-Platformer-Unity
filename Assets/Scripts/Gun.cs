using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmno = 24;
    [SerializeField] private TextMeshProUGUI amoText;
    [SerializeField] private AudioManager audioManager;
    public int currentAmmo;
    void Start()
    {
        currentAmmo = maxAmno;
        UpdateAmoText();
    }

    void Update()
    {
        RotateGun();
        Shoot();
        ReLoad();
    }
    void RotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            //Instantiate tao ban sao clone vien dan//
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            //firePos.position noi dan sinh ra, firePos.rotation dan bay dug huog sung //
            currentAmmo--;
            UpdateAmoText();
            audioManager.PlayShootSound();
        }
    }
    void ReLoad()
    {
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmno)
        {
            currentAmmo = maxAmno;
            UpdateAmoText();
            audioManager.PlayReLoadSound();
        }
    }
private void UpdateAmoText() {
        if (amoText != null)
        {
            if (currentAmmo > 0)
            {
                amoText.text = currentAmmo.ToString();

            }
            else
            {
                amoText.text = "Empty";
            }
        }
    }            
}
            

        

