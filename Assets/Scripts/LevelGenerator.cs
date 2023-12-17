using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Adjust these values as per your requirements
    public int arraySizeX = 5;
    public int arraySizeZ = 5;
    public int difficulty = 10;
    public int odds = 0.3;

    // 2D array to store integer values
    private int[,] BlockTypes;
    private int[,] BlockValues;

    void Start()
    {
        // Call a function to initialize the array
        InitializeArray();
    }

    void InitializeArray()
    {
        // Initialize the array with size arraySizeX by arraySizeZ
        BlockTypes = new int[arraySizeX, arraySizeZ];
        BlockValues = new int[arraySizeX, arraySizeZ];

        // Loop through each element in the array and set it to 0
        for (int x = 0; x < arraySizeX; x++)
        {
            for (int z = 0; z < arraySizeZ; z++)
            {
                BlockTypes[x, z] = 0;
                BlockValues[x, z] = 0;
            }
        }

        // Place the Source block on a random location on the field and give it a random direction
        int X = Random.Range(0, arraySizeX + 1);
        int Z = Random.Range(0, arraySizeZ + 1);
        int Angle = Random.Range(0, 5);
        BlockTypes[X, Z] = 1;
        BlockValues[X, Z] = Angle;
        int LineAngle = Angle;

        // Draw a line over the Array until the line has bend difficulty amount of times
        for (int i = 0; i < difficulty; i++)
        {
            (X, Z) = LinePath(Angle, X, Z);
            if (Random.Range(0f, 1f) < odds)
            {

            }

        }
    }

    static (int x, int z) LinePath(int angle, int x, int z)
    {
        switch (angle % 4)
        {
            case 0:
                // Angle 0: Increment Z
                return (x, z + 1);
            case 1:
                // Angle 1: Increment X
                return (x + 1, z);
            case 2:
                // Angle 2: Decrement Z
                return (x, z - 1);
            case 3:
                // Angle 3: Decrement X
                return (x - 1, z);
            default:
                // Invalid angle, return the same coordinates
                return (x, z);
        }
    }
}