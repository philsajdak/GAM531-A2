using System;
using OpenTK.Mathematics;

public class Program
{
    public static void Main(string[] args)
    {
        // part 1: vector operations
        Console.WriteLine("Part 1: Vector Operations");
        Console.WriteLine("=================");

        Vector3 vA = new Vector3(1, 2, 3);
        Vector3 vB = new Vector3(2, 3, 4);

        Console.WriteLine($"Vector A: {vA}");
        Console.WriteLine($"Vector B: {vB}");

        Vector3 addition = MathLibrary.AddVectors(vA, vB);
        Vector3 subtraction = MathLibrary.SubtractVectors(vA, vB);
        float dotProduct = MathLibrary.DotProduct(vA, vB);
        Vector3 crossProduct = MathLibrary.CrossProduct(vA, vB);

        Console.WriteLine($"Addition: {addition}");
        Console.WriteLine($"Subtraction: {subtraction}");
        Console.WriteLine($"Dot Product: {dotProduct}");
        Console.WriteLine($"Cross Product: {crossProduct}\n");

        // part 2: matrix operations and transforming vector
        Console.WriteLine("Part 2: Matrix Operations and Transformations");
        Console.WriteLine("====================================");

        Matrix4 identityMatrix = MathLibrary.CreateIdentityMatrix();
        Matrix4 scaleMatrix = MathLibrary.CreateScaleMatrix(2.0f, 1.5f, 0.5f);
        Matrix4 rotationMatrix = MathLibrary.CreateRotationYMatrix(MathLibrary.DegreesToRadians(45));

        Console.WriteLine($"Identity Matrix:\n{identityMatrix}");

        Matrix4 combinedMatrix = MathLibrary.MultiplyMatrices(scaleMatrix, rotationMatrix);
        Console.WriteLine($"Scale * Rotation Matrix:\n{combinedMatrix}");

        Vector3 originalVector = new Vector3(1.0f, 1.0f, 1.0f);
        Console.WriteLine($"Original Vector: {originalVector}");

        Vector3 scaledVector = MathLibrary.TransformVector(originalVector, scaleMatrix);
        Console.WriteLine($"After Scaling: {scaledVector}");

        Vector3 rotatedVector = MathLibrary.TransformVector(originalVector, rotationMatrix);
        Console.WriteLine($"After Rotation: {rotatedVector}");
    }
}