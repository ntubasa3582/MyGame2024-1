using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject _scoreItem;
    GameObject[] _scoreItems;
    [SerializeField] int[] _spawnPosition;
    [SerializeField] int _interval = 0;
    [SerializeField] int _spawnCount = 1;
    [SerializeField] int _level = 1;
    private void Awake()
    {
        InstanceObject();
    }

    public void InstanceObject()
    {
        for (int i = 0; i < _level; i++)
        {
            RandomPos();
        }
    }

    void RandomPos()
    {
        float xR = 0; float zR = 0;
        xR = Random.Range(_spawnPosition[0], _spawnPosition[1]);
        zR = Random.Range(_spawnPosition[2], _spawnPosition[3]);
        Instantiate(_scoreItem, new Vector3(xR, 0, zR), Quaternion.identity);
    }
}
