using OpenTK.Mathematics;

public static class MathLibrary
{
    // vector funcs
    public static Vector3 AddVectors(Vector3 a, Vector3 b)
    {
        return a + b;
    }

    public static Vector3 SubtractVectors(Vector3 a, Vector3 b)
    {
        return a - b;
    }

    public static float DotProduct(Vector3 a, Vector3 b)
    {
        return Vector3.Dot(a, b);
    }

    public static Vector3 CrossProduct(Vector3 a, Vector3 b)
    {
        return Vector3.Cross(a, b);
    }

    // matrix funcs
    public static Matrix4 CreateIdentityMatrix()
    {
        return Matrix4.Identity;
    }

    public static Matrix4 CreateScaleMatrix(float x, float y, float z)
    {
        return Matrix4.CreateScale(x, y, z);
    }

    public static Matrix4 CreateRotationYMatrix(float angleRadians)
    {
        return Matrix4.CreateRotationY(angleRadians);
    }

    public static Matrix4 MultiplyMatrices(Matrix4 a, Matrix4 b)
    {
        return a * b;
    }

    public static Vector3 TransformVector(Vector3 vector, Matrix4 matrix)
    {
        return Vector3.TransformPosition(vector, matrix);
    }

    public static float DegreesToRadians(float degrees)
    {
        return MathHelper.DegreesToRadians(degrees);
    }
}