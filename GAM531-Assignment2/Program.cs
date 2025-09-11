using OpenTK.Mathematics;

// part 1 - vectors
Console.WriteLine($"Part 1: Vectors");
Console.WriteLine($"==============");

Vector3 vA = new Vector3(1, 2, 3);
Vector3 vB = new Vector3(2, 3, 4);
float fDot = Vector3.Dot(vA, vB); 
Vector3 vCross = Vector3.Cross(vA, vB);
Vector3 vNormalized = Vector3.Normalize(vCross);

Console.WriteLine($"Dot = {fDot}");
Console.WriteLine($"Cross = {vCross}");
Console.WriteLine($"Normalized = {vNormalized}\n");

// part 2 - matrix
// basically we scale a point by (3x, 1.5y, 0.5z), then rotatie it 50 degrees around y axis, then translate it by (15, 5, 0)
Console.WriteLine($"Part 2: Matrix");
Console.WriteLine($"==============");

Matrix4 scaleMatrix = Matrix4.CreateScale(3.0f, 1.5f, 0.5f);
Matrix4 rotationMatrix = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(50));
Matrix4 translationMatrix = Matrix4.CreateTranslation(15.0f, 5.0f, 0.0f);

// order matters
Matrix4 transformMatrix = scaleMatrix * rotationMatrix * translationMatrix;

Vector3 originalPoint = new Vector3(1.0f, 1.0f, 1.0f);
Vector3 transformedPoint = Vector3.TransformPosition(originalPoint, transformMatrix);

Console.WriteLine($"Original = {originalPoint}");
Console.WriteLine($"Transformed = {transformedPoint}\n");

// part 3 - quaternion
Console.WriteLine($"Part 3: Quaternion");
Console.WriteLine($"==============");

Quaternion rotation = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(50));
Vector3 originalVector = new Vector3(1.0f, 0.0f, 0.0f); // Point along X-axis
Vector3 rotatedVector = Vector3.Transform(originalVector, rotation);

Console.WriteLine($"Original = {originalVector}");
Console.WriteLine($"Rotated = {rotatedVector}");
