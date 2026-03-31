using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : MonoBehaviour//giup tao 1 enemy goc ma k can phai code lai//
{//protected: bien de dung chung de cac enemy con co the truy cap duoc//
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected Player player;
    [SerializeField] protected float maxHp = 50f;
    protected float currentHp;
    [SerializeField] private Image HpBar;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;

    //virtual: co the viet them cau lenh rieng//
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();

    }
    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
        }
        FlipEnemy();
    }
    protected void FlipEnemy()
    {
        if (player != null)
        { //transform.position → vị trí //transform.rotation → góc xoay  //transform.localScale → kích thước


            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }
    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if (HpBar != null)
        {
            //illAmount la thanh hp tu dong
           HpBar.fillAmount = (float)currentHp / maxHp;
        }
    }
}
