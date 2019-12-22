using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] Transform[] backgrounds;
    [SerializeField] float smoothing;
    [SerializeField] float intensity = 1f;

    float[] scale;

    Transform cam;

    Vector3 prevCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        prevCamPos = cam.position;
        scale = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; ++i)
        {
            scale[i] = backgrounds[i].position.z * -1 * intensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = cam.position;
        if (currentPos != prevCamPos)
        {
            for (int i = 0; i < backgrounds.Length; ++i)
            {
                if (cam.position.y - Camera.main.orthographicSize * 3 > backgrounds[i].position.y)
                {
                    // move to the bottom of the camera
                    backgrounds[i].position = new Vector3(backgrounds[i].position.x, backgrounds[i].position.y + Camera.main.orthographicSize * 6, backgrounds[i].position.z);
                }
                else if (cam.position.y + Camera.main.orthographicSize * 3 < backgrounds[i].position.y)
                {
                    backgrounds[i].position = new Vector3(backgrounds[i].position.x, backgrounds[i].position.y - Camera.main.orthographicSize * 6, backgrounds[i].position.z);
                }
                float p = (prevCamPos.y - currentPos.y) * scale[i];
                Vector3 targetPos = new Vector3(backgrounds[i].position.x, backgrounds[i].position.y - p, backgrounds[i].position.z);
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPos, smoothing * Time.deltaTime);
            }
            prevCamPos = currentPos;
        }
    }
}