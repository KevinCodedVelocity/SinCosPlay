using UnityEngine;

public class Gradient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var startColor = Color.red;
        //var endColor = Color.blue;

        //var mesh = GetComponent<MeshFilter>().mesh;
        //var colors = new Color[mesh.vertices.Length];
        //colors[0] = startColor;
        //colors[1] = endColor;
        //colors[2] = startColor;
        //colors[3] = endColor;
        //mesh.colors = colors;

    }

    // Update is called once per frame
    void Update()
    {
        var color1 = new Color(0, SinPositive(Time.time), 0);
        var color2 = new Color(0, SinPositive(Time.time), CosPositive(Time.time));
        var color3 = new Color(0, CosPositive(Time.time), 0);
        var color4 = new Color(0, CosPositive(Time.time), SinPositive(Time.time));

        var mesh = GetComponent<MeshFilter>().mesh;
        var colors = new Color[mesh.vertices.Length];
        colors[0] = color1;
        colors[1] = color2;
        colors[2] = color3;
        colors[3] = color4;

        mesh.colors = colors;

    }

    float CosPositive(float input)
    {
        return (1 + Mathf.Cos(input)) / 2;
    }

    float SinPositive(float input)
    {
        return (1 + Mathf.Sin(input))/2;
    }
}
