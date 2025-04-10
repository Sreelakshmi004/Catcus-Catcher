using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct Spawnableobject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnchance;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    public Spawnableobject[] objects;
    public float minspawn = 0.5f;
    public float maxspawn = 1f;

    public void OnEnable()
    {
        Invoke("spawn", Random.Range(minspawn, maxspawn));
    }
    private void OnDisable()
    {

        CancelInvoke();
    }
    void spawn()
    {
        float spawnchance = Random.value;
        foreach(var obj in objects)
        {
            if (spawnchance<obj.spawnchance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnchance -= obj.spawnchance;
        }
        Invoke("spawn",Random.Range(minspawn, maxspawn));
    }
}
