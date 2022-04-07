using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorGenerater : MonoBehaviour //this class is simple enought that it can just be tweaked in the editor, no need to inheirt generators
{
    public Terrain terrain_t;
    public Decorator decorater;
    public int width = 1000;
    public float scale = 2f;

    [HideInInspector] //so not shown in editor
    public enum GeneratorType {G_INTERIOR, G_EXTERIOR}; //things like this I would put in a superclass but I dont want to deal with unity rn
    // Start is called before the first frame update
    void Start() //everything done in here so on game start it generates only once
    {
        //too lazy to name these any better
        TerrainData terrain = terrain_t.terrainData;
        terrain.heightmapResolution = width + 1;
        terrain.size = new Vector3(width, 40, width);
        float[,] heights = new float[width, width];
        //generate random 'heights'
        for (int i = 0; i < width; i++)
            for (int j = 0; j < width; j++)
                heights[j,i] = Mathf.PerlinNoise((float)i / width * scale, (float)j / width * scale);
        terrain.SetHeights(0, 0, heights);
        decorater.Decorate(terrain_t);
    }
}
