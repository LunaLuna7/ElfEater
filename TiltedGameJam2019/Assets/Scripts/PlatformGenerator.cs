using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Inspector Header")]
        [SerializeField]
        GameObject platform;

        [SerializeField]
        List<GameObject> blocks = new List<GameObject>();

        [SerializeField]
        int platformLen = 10;

    private float xSpawnValue;

    private void Awake()
    {
        xSpawnValue = Camera.main.transform.position.x - (Camera.main.pixelWidth / 2);
    }

    private void Update()
    {
        SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        float ySpawnValue = Camera.main.transform.position.y + Random.Range( Camera.main.pixelHeight, 2 * Camera.main.pixelHeight);
        Instantiate(platform, new Vector2(xSpawnValue, ySpawnValue), Quaternion.identity);

        int num = 0;
        while (num < platformLen) 
        {
            int blockIndex;
            if (num > 5)
                blockIndex = Random.Range(-1, blocks.Count - (3 * (platformLen - num) ));
            else
                blockIndex = Random.Range(-1, blocks.Count);

            int len = (int) Mathf.Ceil((float) (blockIndex+1) / 3);
            print(len);

            if (blockIndex != -1)
            {
                float xBlock = (xSpawnValue + (blocks[0].GetComponent<SpriteRenderer>().bounds.size.x) * (num)) + blocks[blockIndex].GetComponent<SpriteRenderer>().bounds.size.x / 2;

                Instantiate(blocks[blockIndex], new Vector2(xBlock, ySpawnValue), Quaternion.identity);
                num += len;
            }
            else
            {
                num++;
            }

                
        }

    }

    private void Destroy()
    {
        
    }
}
