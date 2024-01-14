using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMiniPool : MonoBehaviour
{
    public MiniPool<Stair> myPool;
    public Stair prefabs;
    public int initialPoolSize = 10;
    public Transform parentTransform;
    public Vector3 pos;
    public Stair obj;
    private List<Stair> spawnedObjects = new List<Stair>(); // Taọ 1 list để chứa các obj được sinh ra
    private void Start()
    {
        myPool = new MiniPool<Stair>();
        myPool.OnInit(prefabs, initialPoolSize, parentTransform);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            obj = myPool.Spawn(pos, Quaternion.identity);           
            pos.z += 2f;
            spawnedObjects.Add(obj);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            myPool.Despawn(spawnedObjects[spawnedObjects.Count - 1]);
            spawnedObjects.RemoveAt(spawnedObjects.Count - 1);
            
        }


    }
}
