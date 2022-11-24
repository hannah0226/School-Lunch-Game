using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;
}


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField]ObjectInfo[] objectInfo = null;
    public Queue<GameObject> StudentOQueue = new Queue<GameObject>();
    public Queue<GameObject> StudentXQueue = new Queue<GameObject>();
    public Queue<GameObject> StudentOHappyQueue = new Queue<GameObject>();
    public Queue<GameObject> StudentOSadQueue = new Queue<GameObject>();
    public Queue<GameObject> StudentXHappyQueue = new Queue<GameObject>();
    public Queue<GameObject> StudentXSadQueue = new Queue<GameObject>();

    void Start()
    {
        instance = this;
        StudentOQueue = InsertQueue(objectInfo[0]);
        StudentXQueue = InsertQueue(objectInfo[1]);
        StudentOHappyQueue = InsertQueue(objectInfo[2]);
        StudentOSadQueue = InsertQueue(objectInfo[3]);
        StudentXHappyQueue = InsertQueue(objectInfo[4]);
        StudentXSadQueue = InsertQueue(objectInfo[5]);
    }

    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for(int i=0; i<p_objectInfo.count; i++)
        {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.localPosition, Quaternion.identity);
            t_clone.SetActive(false);
            if(p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent,false);
            else
                t_clone.transform.SetParent(this.transform,false);
            t_queue.Enqueue(t_clone);
        }
        return t_queue;
    }
}
