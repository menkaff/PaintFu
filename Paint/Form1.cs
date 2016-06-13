using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Device device = null;
        private float angle = 0.0f;
        public VertexBuffer vb = null;
        public Form1()
        {
            //  InitializeComponent();

            InitializeGraphics();

        }

        /// <summary>
        /// We will initialize our graphics device here
        /// </summary>
        public void InitializeGraphics()
        {
            // Set our presentation parameters
            PresentParameters presentParams = new PresentParameters();

            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;

            // Create our device
            device = new Device(0, DeviceType.Hardware, this,
               CreateFlags.SoftwareVertexProcessing, presentParams);

            vb = new VertexBuffer(typeof(CustomVertex.PositionColored), 36, device, Usage.Dynamic |
                Usage.WriteOnly, CustomVertex.PositionColored.Format, Pool.Default);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);

            vb.Created += new EventHandler(this.OnVertexBufferCreate);
            OnVertexBufferCreate(vb, null);


        }


        private void Form1_Click(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            device.Clear(ClearFlags.Target, Color.MintCream, 0, 0);

            device.VertexFormat = CustomVertex.PositionColored.Format;

            SetupCamera();

            device.BeginScene();

            angle += 0.1f;

            device.SetStreamSource(0, vb, 0);






            device.Transform.World = Microsoft.DirectX.Matrix.RotationYawPitchRoll(angle + 100 / (float)Math.PI, angle /
    (float)Math.PI * 1.0f, angle / (float)Math.PI / 2.0f) *
    Microsoft.DirectX.Matrix.Translation(3.0f, -2.4f, -10.0f);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 12);



            device.EndScene();
            device.Present();

            this.Invalidate();


        }

        private void SetupCamera()
        {
            device.Transform.Projection = Microsoft.DirectX.Matrix.PerspectiveFovLH((float)Math.PI / 4,
                  this.Width / this.Height, 1.0f, 100.0f);
            device.Transform.View = Microsoft.DirectX.Matrix.LookAtLH(new Vector3(0, 0, 20.1f), new Vector3(),
                new Vector3(0, 1, 0));


            //device.RenderState.FillMode = FillMode.WireFrame;
            device.RenderState.Lighting = false;
            //device.RenderState.CullMode = Cull.None;

        }

        private void CancelResize(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void OnVertexBufferCreate(object sender, EventArgs e)
        {
            VertexBuffer buffer = (VertexBuffer)sender;

            CustomVertex.PositionColored[] verts = new CustomVertex.PositionColored[36];
            // Front face
            verts[0] = new CustomVertex.PositionColored(-1.0f, 1.0f, 1.0f, Color.LightSeaGreen.ToArgb());
            verts[1] = new CustomVertex.PositionColored(-1.0f, -1.0f, 1.0f, Color.LightSeaGreen.ToArgb());
            verts[2] = new CustomVertex.PositionColored(1.0f, 1.0f, 1.0f, Color.LightSeaGreen.ToArgb());
            verts[3] = new CustomVertex.PositionColored(-1.0f, -1.0f, 1.0f, Color.LightSeaGreen.ToArgb());
            verts[4] = new CustomVertex.PositionColored(1.0f, -1.0f, 1.0f, Color.LightSeaGreen.ToArgb());
            verts[5] = new CustomVertex.PositionColored(1.0f, 1.0f, 1.0f, Color.LightSeaGreen.ToArgb());

            // Back face (remember this is facing *away* from the camera, so vertices should be
            // clockwise order)
            verts[6] = new CustomVertex.PositionColored(-1.0f, 1.0f, -1.0f, Color.RoyalBlue.ToArgb());
            verts[7] = new CustomVertex.PositionColored(1.0f, 1.0f, -1.0f, Color.RoyalBlue.ToArgb());
            verts[8] = new CustomVertex.PositionColored(-1.0f, -1.0f, -1.0f, Color.RoyalBlue.ToArgb());
            verts[9] = new CustomVertex.PositionColored(-1.0f, -1.0f, -1.0f, Color.RoyalBlue.ToArgb());
            verts[10] = new CustomVertex.PositionColored(1.0f, 1.0f, -1.0f, Color.RoyalBlue.ToArgb());
            verts[11] = new CustomVertex.PositionColored(1.0f, -1.0f, -1.0f, Color.RoyalBlue.ToArgb());

            // Top face
            verts[12] = new CustomVertex.PositionColored(-1.0f, 1.0f, 1.0f, Color.SeaGreen.ToArgb());
            verts[13] = new CustomVertex.PositionColored(1.0f, 1.0f, -1.0f, Color.SeaGreen.ToArgb());
            verts[14] = new CustomVertex.PositionColored(-1.0f, 1.0f, -1.0f, Color.SeaGreen.ToArgb());
            verts[15] = new CustomVertex.PositionColored(-1.0f, 1.0f, 1.0f, Color.SeaGreen.ToArgb());
            verts[16] = new CustomVertex.PositionColored(1.0f, 1.0f, 1.0f, Color.SeaGreen.ToArgb());
            verts[17] = new CustomVertex.PositionColored(1.0f, 1.0f, -1.0f, Color.SeaGreen.ToArgb());

            // Bottom face (remember this is facing *away* from the camera, so vertices should be
            //clockwise order)
            verts[18] = new CustomVertex.PositionColored(-1.0f, -1.0f, 1.0f, Color.OrangeRed.ToArgb());
            verts[19] = new CustomVertex.PositionColored(-1.0f, -1.0f, -1.0f, Color.OrangeRed.ToArgb());
            verts[20] = new CustomVertex.PositionColored(1.0f, -1.0f, -1.0f, Color.OrangeRed.ToArgb());
            verts[21] = new CustomVertex.PositionColored(-1.0f, -1.0f, 1.0f, Color.OrangeRed.ToArgb());
            verts[22] = new CustomVertex.PositionColored(1.0f, -1.0f, -1.0f, Color.OrangeRed.ToArgb());
            verts[23] = new CustomVertex.PositionColored(1.0f, -1.0f, 1.0f, Color.OrangeRed.ToArgb());

            // Left face
            verts[24] = new CustomVertex.PositionColored(-1.0f, 1.0f, 1.0f, Color.MediumSlateBlue.ToArgb());
            verts[25] = new CustomVertex.PositionColored(-1.0f, -1.0f, -1.0f, Color.MediumSlateBlue.ToArgb());
            verts[26] = new CustomVertex.PositionColored(-1.0f, -1.0f, 1.0f, Color.MediumSlateBlue.ToArgb());
            verts[27] = new CustomVertex.PositionColored(-1.0f, 1.0f, -1.0f, Color.MediumSlateBlue.ToArgb());
            verts[28] = new CustomVertex.PositionColored(-1.0f, -1.0f, -1.0f, Color.MediumSlateBlue.ToArgb());
            verts[29] = new CustomVertex.PositionColored(-1.0f, 1.0f, 1.0f, Color.MediumSlateBlue.ToArgb());

            // Right face (remember this is facing *away* from the camera, so vertices should be
            //clockwise order)
            verts[30] = new CustomVertex.PositionColored(1.0f, 1.0f, 1.0f, Color.DeepPink.ToArgb());
            verts[31] = new CustomVertex.PositionColored(1.0f, -1.0f, 1.0f, Color.DeepPink.ToArgb());
            verts[32] = new CustomVertex.PositionColored(1.0f, -1.0f, -1.0f, Color.DeepPink.ToArgb());
            verts[33] = new CustomVertex.PositionColored(1.0f, 1.0f, -1.0f, Color.DeepPink.ToArgb());
            verts[34] = new CustomVertex.PositionColored(1.0f, 1.0f, 1.0f, Color.DeepPink.ToArgb());
            verts[35] = new CustomVertex.PositionColored(1.0f, -1.0f, -1.0f, Color.DeepPink.ToArgb());

            buffer.SetData(verts, 0, LockFlags.None);


        }

    }
}
