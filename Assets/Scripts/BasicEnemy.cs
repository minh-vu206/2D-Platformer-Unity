using UnityEngine;

public class BasicEnemy : Enemy
{//OnTriggerEnter2D: xu ly va cham//
 //collision. cách Unity phát hiện khi hai vật thể chạm nhau//
 //CompareTag là hàm có sẵn trong Unity dùng để so sánh nhanh xem một GameObject có mang tag//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
}
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage);
    }
        }
    }
}
