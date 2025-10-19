using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace GAM531_Assignment2
{
    public class Engine(int width, int height, string title) : GameWindow(GameWindowSettings.Default, new NativeWindowSettings()
    {
        ClientSize = (width, height),
        Title = title,
        WindowBorder = WindowBorder.Fixed
    })
    {
        float[] vertices =
        {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.5f,  0.5f, 0.0f,
            -0.5f,  0.5f, 0.0f
        };

        uint[] indices =
        {
            0, 1, 2,
            2, 3, 0
        };

        int VertexBufferObject;
        int VertexArrayObject;
        int ElementBufferObject;
        Shader? shader;

        private float rotationAngle = 0.0f;
        private float scale = 1.0f;
        private bool scalingUp = true;

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1f);

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            shader = new Shader("Shader/Shader.vert", "Shader/Shader.frag");
            shader.Use();
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            GL.DeleteBuffer(VertexBufferObject);
            GL.DeleteBuffer(ElementBufferObject);
            GL.DeleteVertexArray(VertexArrayObject);
            shader?.Dispose();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            rotationAngle += 45.0f * (float)args.Time;
            if (rotationAngle > 360.0f)
                rotationAngle -= 360.0f;

            if (scalingUp)
            {
                scale += 0.5f * (float)args.Time;
                if (scale >= 1.5f)
                {
                    scale = 1.5f;
                    scalingUp = false;
                }
            }
            else
            {
                scale -= 0.5f * (float)args.Time;
                if (scale <= 0.5f)
                {
                    scale = 0.5f;
                    scalingUp = true;
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader?.Use();

            Matrix4 scaleMatrix = MathLibrary.CreateScaleMatrix(scale, scale, 1.0f);
            Matrix4 rotationMatrix = MathLibrary.CreateRotationYMatrix(
                MathLibrary.DegreesToRadians(rotationAngle));

            Matrix4 transform = MathLibrary.MultiplyMatrices(scaleMatrix, rotationMatrix);

            shader.SetMatrix4("transform", transform);

            GL.BindVertexArray(VertexArrayObject);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            SwapBuffers();
        }
    }
}