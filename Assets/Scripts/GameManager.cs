using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } //Her class'tan GameManager'a erisim

    [SerializeField] private FruitObjectSettting setting;
    [SerializeField] private GameArea gameArea;
    [SerializeField] private Transform spawnPoint;


    private bool IsClick => Input.GetMouseButtonDown(0);
    private readonly Vector2Int _fruitRange = new Vector2Int(x: 0, y: 4);

    private void Awake()
    {
        Instance = this; //Her class'tan GameManager'a erisim
    }

    private float GetInputHorizontalPosition()
    {
        var inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        var limit = gameArea.GetBorderPositionHorizontal();
        var result = Mathf.Clamp(inputPosition, limit.x, limit.y); //Sinirlandirma
        return result;
    }

    private void OnClick()
    {
        var index = Random.Range(_fruitRange.x, _fruitRange.y);
        var spawnPosition = new Vector2(GetInputHorizontalPosition(), spawnPoint.position.y);
        SpawnFruit(index, spawnPosition);
    }


    private void SpawnFruit(int index, Vector2 position)
    {
        var prefab = setting.SpawnObject;


        var fruitObject = Instantiate(prefab, position, Quaternion.identity);

        var sprite = setting.GetSprite(index);
        var scale = setting.GetScale(index);
        fruitObject.Prepare(sprite, index, scale);
    }

    public void Merge(FruitObject first, FruitObject second)
    {
        var type = first.type + 1;
        var spawnPosition = (first.transform.position + second.transform.position) * 0.5f;
        Destroy(first.gameObject);
        Destroy(second.gameObject);
        SpawnFruit(type, spawnPosition);
    }

    private void Update()
    {
        if (IsClick)
        {
            OnClick();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
