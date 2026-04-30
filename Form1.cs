using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        enum ToolType{ Line, Rectangle, Circle }  // 사용할도형타입

        private Bitmap canvasBitmap;  // 실제그림이저장되는비트맵
        private Graphics canvasGraphics;      // 비트맵위에그리기위한객체

        private bool isDrawing= false;       // 현재드래그중인지여부
        private Point startPoint;        // 드래그시작점
        private Point endPoint;       // 드래그끝점

        private ToolType currentTool= ToolType.Line;  // 현재선택된도형
        private Color currentColor= Color.Black;      // 현재색상
        private int currentLineWidth= 2;    // 현재선두께
        enum ToolType{ Line, Rectangle, Circle }
        ToolType currentTool= ToolType.Line;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnLine_Click(object sender, EventArgs e)
        {

        }
    }
}
