using UnityEngine;
using System.Collections.Generic;

public class Graph : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float width, height;
    float[][] graphPoints;
    float maxXCoordinate, minXCoordinate;
    float maxYCoordinate, minYCoordinate;

    public Mesh mesh;
    public Material material;

    void Start()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        graphPoints = new float[][]{
            new float[] {1, 1.2f, 1.4f, 1.6f, 1.8f, 2, 2.2f, 2.4f, 2.6f, 2.8f, 3, 3.2f, 3.4f, 3.6f, 3.8f, 4},
            new float[] {1.2f, 1.8f, 1.4f, 1.3f, 2, 2.2f, 2.4f, 2.8f, 3, 3.2f, 2.8f, 2.7f, 2.8f, 2.2f, 2.1f, 3.5f }
        };

        // Find max and min element for first array (x coordinate)
        maxXCoordinate = minXCoordinate = graphPoints[0][0];
        for (int i = 1; i < graphPoints[0].Length; i++)
        {
            if (graphPoints[0][i] > maxXCoordinate)
                maxXCoordinate = graphPoints[0][i];
            if (graphPoints[0][i] < minXCoordinate)
                minXCoordinate = graphPoints[0][i];
        }
        maxXCoordinate -= minXCoordinate;

        // Rescale all the elments in first array (x coordinate)
        for (int i = 0; i < graphPoints[0].Length; i++)
        {
            graphPoints[0][i] = (graphPoints[0][i] - minXCoordinate) * (width / maxXCoordinate);
        }

        // Find max and min element for second array (y coordinate)
        maxYCoordinate = minYCoordinate = graphPoints[1][0];
        for (int i = 1; i < graphPoints[1].Length; i++)
        {
            if (graphPoints[1][i] > maxYCoordinate)
                maxYCoordinate = graphPoints[1][i];
            if (graphPoints[1][i] < minYCoordinate)
                minYCoordinate = graphPoints[1][i];
        }
        maxYCoordinate -= minYCoordinate;

        // Rescale all the elements in second array (y coordinates)
        for (int i = 0; i < graphPoints[1].Length; i++)
        {
            graphPoints[1][i] = (graphPoints[1][i] - minYCoordinate) * (height / maxYCoordinate);
        }

        DrawLineRendererGraph(graphPoints);
    }

    void Update()
    {
        DrawMeshGraph(graphPoints);
    }

    void DrawLineRendererGraph(float[][] graphPoints)
    {
        Vector3[] graphPointsPositions = new Vector3[graphPoints[0].Length];

        for (int i = 0; i < graphPointsPositions.Length; i++)
        {
            graphPointsPositions[i] = new Vector3(graphPoints[0][i], graphPoints[1][i], 1);
        }

        lineRenderer.SetVertexCount(graphPointsPositions.Length);
        lineRenderer.SetPositions(graphPointsPositions);
    }

    void DrawMeshGraph(float[][] graphPoints)
    {
        Mesh mesh1 = new Mesh();
        Vector3[] graphPointsPositions = new Vector3[graphPoints[0].Length];
        List<Vector3> graphPointsVectors = new List<Vector3>(graphPointsPositions.Length);
        for (int i = 0; i < graphPointsPositions.Length; i++)
        {
            graphPointsVectors.Add(graphPointsPositions[i]);
        }
        //mesh1.SetVertices(graphPointsVectors);

        List<Vector3> square = new List<Vector3>();
        square.Add(new Vector3(-1, -1, 0));
        square.Add(new Vector3(-1, 1, 0));
        square.Add(new Vector3(1, -1, 0));
        square.Add(new Vector3(1, 1, 0));
        mesh1.SetVertices(square);
        Graphics.DrawMesh(mesh1, Vector3.zero, Quaternion.identity, material, 0);
    }
}
