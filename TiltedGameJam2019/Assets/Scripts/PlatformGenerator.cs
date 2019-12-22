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

        for (int num = 0; num < platformLen; num++)
        {
            int blockIndex = Random.Range(-1, blocks.Count);
            float xBlock = xSpawnValue + (blocks[0].GetComponent<SpriteRenderer>().bounds.size.x) * (num);

            if (blockIndex != -1)
                Instantiate(blocks[blockIndex], new Vector2(xBlock, ySpawnValue), Quaternion.identity);
        }

    }

    private void Destroy()
    {
        
    }
}
