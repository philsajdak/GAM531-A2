using OpenTK.Mathematics;

namespace GAM531_Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GAM531 Assignment 2: Vector & Matrix Operations\n");

            Console.WriteLine("Vector Operations");
            Vector3 v1 = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 v2 = new Vector3(4.0f, 5.0f, 6.0f);

            Console.WriteLine($"Vector A: {v1}");
            Console.WriteLine($"Vector B: {v2}");
            Console.WriteLine();

            Vector3 sum = MathLibrary.AddVectors(v1, v2);
            Console.WriteLine($"Addition (A + B): {sum}");

            Vector3 diff = MathLibrary.SubtractVectors(v1, v2);
            Console.WriteLine($"Subtraction (A - B): {diff}");

            float dot = MathLibrary.DotProduct(v1, v2);
            Console.WriteLine($"Dot Product: {dot}");

            Vector3 cross = MathLibrary.CrossProduct(v1, v2);
            Console.WriteLine($"Cross Product: {cross}");
            Console.WriteLine();

            Console.WriteLine("Matrix Operations");

            Matrix4 identity = MathLibrary.CreateIdentityMatrix();
            Console.WriteLine("Identity Matrix:");
            PrintMatrix(identity);

            Matrix4 scaleMatrix = MathLibrary.CreateScaleMatrix(2.0f, 2.0f, 2.0f);
            Console.WriteLine("Scale Matrix (2x, 2y, 2z):");
            PrintMatrix(scaleMatrix);

            float rotationAngle = MathLibrary.DegreesToRadians(45.0f);
            Matrix4 rotationMatrix = MathLibrary.CreateRotationYMatrix(rotationAngle);
            Console.WriteLine($"Rotation Matrix:");
            PrintMatrix(rotationMatrix);

            Matrix4 combined = MathLibrary.MultiplyMatrices(scaleMatrix, rotationMatrix);
            Console.WriteLine("Combined Matrix (Scale * Rotation):");
            PrintMatrix(combined);

            Console.WriteLine("Transformation Results");
            Vector3 testVector = new Vector3(1.0f, 0.0f, 0.0f);
            Console.WriteLine($"Original Vector: {testVector}");

            Vector3 scaled = MathLibrary.TransformVector(testVector, scaleMatrix);
            Console.WriteLine($"After Scaling: {scaled}");

            Vector3 rotated = MathLibrary.TransformVector(testVector, rotationMatrix);
            Console.WriteLine($"After Rotation: {rotated}");

            Vector3 transformed = MathLibrary.TransformVector(testVector, combined);
            Console.WriteLine($"After Combined Transform: {transformed}");
            Console.WriteLine();

            using (Engine engine = new Engine(800, 600, "Assignment 2 - Transformations"))
            {
                engine.Run();
            }
        }

        static void PrintMatrix(Matrix4 matrix)
        {
            Console.WriteLine($"  [{matrix.M11:F3}, {matrix.M12:F3}, {matrix.M13:F3}, {matrix.M14:F3}]");
            Console.WriteLine($"  [{matrix.M21:F3}, {matrix.M22:F3}, {matrix.M23:F3}, {matrix.M24:F3}]");
            Console.WriteLine($"  [{matrix.M31:F3}, {matrix.M32:F3}, {matrix.M33:F3}, {matrix.M34:F3}]");
            Console.WriteLine($"  [{matrix.M41:F3}, {matrix.M42:F3}, {matrix.M43:F3}, {matrix.M44:F3}]");
            Console.WriteLine();
        }
    }
}