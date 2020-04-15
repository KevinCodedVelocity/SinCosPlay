using UnityEngine;

public class GameController : MonoBehaviour
{
    const float xyOffset = 2;

    public GameObject target;

    const int size = 50;
    public GameObject[,] array = new GameObject[size,size]; 

    // Start is called before the first frame update
    void Awake()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                array[x, y] = (GameObject)Instantiate(target, new Vector3(x*3, 0, y*3), Quaternion.identity);
            }
        }

        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        const float height = 3;
        const float offsetRate = 0.1f;

        float cameraTime = Time.time / 8;
        Camera.main.transform.LookAt(new Vector3(size / 2, 0, size / 2));
        Camera.main.transform.position = new Vector3(
            size/2 * Mathf.Cos(cameraTime), 
            height + 1 + height * Mathf.Sin(Time.time/2), 
            size/2 * Mathf.Sin(cameraTime));

        for (int x = 0; x < size; ++x)
        {
            for (int y = 0; y < size; y++)
            {
                if (array[x, y] != null)
                {
                    float offset = (x * offsetRate) + (y * offsetRate) * size * offsetRate;
                    array[x, y].transform.position = new Vector3(
                        x * xyOffset,
                        height * Mathf.Sin(Time.time + offset),
                        y * xyOffset);

                    array[x, y].GetComponent<MeshRenderer>().material.color = 
                        new Color(
                            Mathf.Sin(Time.time + offset),
                            0, Mathf.Cos(Time.time + offset),
                            Mathf.Sin(Time.time/2 + offset)
                            );
                }
            }
        }
    }
}
