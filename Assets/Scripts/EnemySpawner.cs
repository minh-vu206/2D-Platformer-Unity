using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour//System.Collections: chứa IEnumerator cần cho coroutine.
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 2f;
  
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }
private IEnumerator SpawnEnemyCoroutine()
    //IEnumerator là một kiểu dữ liệu đặc biệt trong C# (gọi là interface), cho phép duy trì trạng thái tạm dừng và tiếp tục của một hàm.
    {
        while (true)
        {
            //🔹 yield return nghĩa là:
//👉 “Tạm dừng việc thực thi của hàm tại đây, trả lại quyền điều khiển cho Unity, và tiếp tục chạy lại từ chỗ này khi điều kiện được thoả mãn.”
            yield return new WaitForSeconds(timeBetweenSpawns);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            //range:pham vi
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
    }
   
}





/*sing UnityEngine;
using System.Collections;
UnityEngine: thư viện chính của Unity (MonoBehaviour, GameObject, Transform...).

System.Collections: chứa IEnumerator cần cho coroutine.

csharp
Sao chép mã
public class EnemySpawner : MonoBehaviour
Tạo một component (script) có thể gắn lên GameObject trong scene. Kế thừa MonoBehaviour để dùng Start(), StartCoroutine()...

csharp
Sao chép mã
[SerializeField] private GameObject[] enemies;
[SerializeField] private Transform[] spawnPoints;
[SerializeField] private float timeBetweenSpawns = 2f;
GameObject[] enemies: mảng các prefab quái (kéo thả prefab vào Inspector).

Transform[] spawnPoints: mảng các điểm spawn (kéo thả các Transform vào Inspector).

timeBetweenSpawns: thời gian giữa 2 lần spawn, mặc định 2 giây.

SerializeField cho phép trường private vẫn hiển thị và chỉnh trong Inspector.

csharp
Sao chép mã
void Start()
{
    StartCoroutine(SpawnEnemyCoroutine());
}
Start() gọi ngay khi GameObject active lần đầu.

StartCoroutine(SpawnEnemyCoroutine()) khởi chạy coroutine SpawnEnemyCoroutine. Coroutine này chạy song song (không block) cùng frame update chính.

csharp
Sao chép mã
private IEnumerator SpawnEnemyCoroutine()
{
    while (true)
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }
}
private IEnumerator SpawnEnemyCoroutine():

Coroutine phải trả về IEnumerator. Unity sẽ gọi hàm này và xử lý các yield return theo thời gian.

while (true):

Vòng lặp vô hạn — coroutine sẽ tiếp tục spawn mãi cho tới khi component hoặc GameObject bị disable/destroy hoặc bạn dừng coroutine bằng StopCoroutine/StopAllCoroutines.

yield return new WaitForSeconds(timeBetweenSpawns);:

Dừng coroutine tại đây trong timeBetweenSpawns giây rồi tiếp tục. Đây là cách "chờ" giữa các lần spawn mà không block main thread.

GameObject enemy = enemies[Random.Range(0, enemies.Length)];

Random.Range(int min, int max) (với int) trả về số nguyên >= min và < max. Vậy chỉ số hợp lệ là 0..enemies.Length-1.

Lấy prefab quái ngẫu nhiên từ mảng.

Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

Chọn điểm spawn ngẫu nhiên tương tự.

Instantiate(enemy, spawnPoint.position, Quaternion.identity);

Tạo bản sao (instance) của prefab enemy ở spawnPoint.position.

Quaternion.identity = không xoay (rotation mặc định).

Instantiate trả về GameObject instance mới nếu cần giữ reference (ở đây bạn không lưu lại).

Lưu ý quan trọng & xử lý lỗi phổ biến
Kiểm tra mảng rỗng / null
Nếu enemies hoặc spawnPoints rỗng (length == 0) hoặc chưa set trong Inspector, Random.Range(0, 0) sẽ lỗi. Thêm kiểm tra an toàn:

csharp
Sao chép mã
if (enemies == null || enemies.Length == 0 || spawnPoints == null || spawnPoints.Length == 0)
{
    Debug.LogWarning("EnemySpawner: enemies or spawnPoints not set!");
    yield break; // dừng coroutine
}
Dừng coroutine khi cần

Nếu muốn dừng spawn (ví dụ khi player chết), bạn có thể:

StopCoroutine(SpawnEnemyCoroutine()); — lưu reference khi gọi StartCoroutine để dừng chính xác, hoặc

StopAllCoroutines(); — dừng mọi coroutine trên component này.

Nếu dùng yield break trong coroutine thì coroutine kết thúc luôn.

Object pooling (tối ưu hiệu năng)

Instantiate/Destroy liên tục gây garbage và có thể lag. Dùng object pool: tạo sẵn nhiều enemy và enable/disable lại thay vì Instantiate mỗi lần.

Rotation

Quaternion.identity đặt rotation mặc định. Nếu prefab cần hướng đúng theo spawnPoint rotation thì dùng spawnPoint.rotation.

Spawn an toàn (collisions)

Nếu spawn quái ngay trong vị trí chật, quái có thể chèn vào collider khác. Có thể raycast hoặc dùng Physics.OverlapSphere kiểm tra trước khi spawn.

Offset vị trí

Có thể thêm offset ngẫu nhiên nhỏ để spawn không chồng chéo:

csharp
Sao chép mã
Vector3 pos = spawnPoint.position + new Vector3(Random.Range(-1f,1f), 0, Random.Range(-1f,1f));
Instantiate(enemy, pos, spawnPoint.rotation);*/