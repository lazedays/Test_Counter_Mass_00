using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    public List<GameObject> listBulletPools = new List<GameObject>();

    private void Awake()
    {
        
    }

    public void SetFirstPool_Test()
    {
        if (listBulletPools == null)
            listBulletPools = new List<GameObject>();

        if(listBulletPools.Count <= 0)
        {
            for(int i = 0; i< 1; i ++)
            {
                GameObject obj = GameObject.Instantiate(Resources.Load(String_.Path_Prefab_BulletPistol)) as GameObject;
                obj.SetActive(false);
                obj.transform.parent = this.transform;
                listBulletPools.Add(obj);
            }
        }
    }

    public Bullet00 PullBulletObj(Vector3 position, Quaternion qu)
    {
        foreach (var item in listBulletPools)
        {
            if (item.gameObject.activeSelf == false)
            {
                Bullet00 bullet = item.GetComponent<Bullet00>();
                bullet.PoolInit(position, qu);
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        GameObject obj = GameObject.Instantiate(Resources.Load(String_.Path_Prefab_BulletPistol)) as GameObject;
        Bullet00 newBullet = obj.GetComponent<Bullet00>();
        if(newBullet != null)
        {
            newBullet.PoolInit(position, qu);
            listBulletPools.Add(obj);
            obj.transform.parent = this.transform;
            obj.SetActive(true);
            return newBullet;
        }
        else
        {
            Debug.Log("투사체 Bullet00 컴포넌트 없음");
            return null;
        }
    }

}
