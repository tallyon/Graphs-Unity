using UnityEngine;

public class Graph : MonoBehaviour
{
    public enum GraphEngine { LineRenderer, Mesh };
    public GraphEngine graphEngine;
    public float width, height;

    IGraph chosenGraphEngine;

    void Start()
    {
        if (graphEngine == GraphEngine.LineRenderer)
            chosenGraphEngine = gameObject.AddComponent<GraphLineRenderer>();
        else if (graphEngine == GraphEngine.Mesh)
            chosenGraphEngine = gameObject.AddComponent<GraphMesh>();

        chosenGraphEngine.Width = width;
        chosenGraphEngine.Height = height;

        // Generate sample graph data
        float[][] graphPoints = new float[][]{
            new float[] {1, 1.2f, 1.4f, 1.6f, 1.8f, 2, 2.2f, 2.4f, 2.6f, 2.8f, 3, 3.2f, 3.4f, 3.6f, 3.8f, 4},
            new float[] {1.2f, 1.8f, 1.4f, 1.3f, 2, 2.2f, 2.4f, 2.8f, 3, 3.2f, 2.8f, 2.7f, 2.8f, 2.2f, 2.1f, 3.5f }
        };
        chosenGraphEngine.GraphPoints = graphPoints;
    }
}
