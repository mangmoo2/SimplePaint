using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        // 1. 열거형 정의는 한 번만!
        // 변수 선언
        enum ToolType { Line, Rectangle, Circle }
        private ToolType currentTool = ToolType.Line;
        private Color currentColor = Color.Black;
        private int currentLineWidth = 2;
        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;

        private bool isDrawing = false;      // 현재 드래그 중인지 확인
        private Point startPoint;            // 마우스 클릭 시작 지점
        private Point endPoint;              // 마우스 이동/종료 지점

        // 초기화 (생성자)
        public Form1()
        {
            InitializeComponent();
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;
            cmbColor.SelectedIndex = 0;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        // --- 도형 선택 기능 ---
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        // --- 색상 선택 기능 ---
        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: currentColor = Color.Black; break;
                case 1: currentColor = Color.Red; break;
                case 2: currentColor = Color.Blue; break;
                case 3: currentColor = Color.Green; break;
                default: currentColor = Color.Black; break;
            }
        }

        // --- 선 굵기 선택 기능 ---
        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
        }
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            endPoint = e.Location;
            picCanvas.Invalidate(); // Paint 이벤트를 발생시켜 화면을 다시 그립니다.
        }
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            endPoint = e.Location;

            // 비트맵에 실제로 그리기
            DrawShape(canvasGraphics, new Pen(currentColor, currentLineWidth));
            picCanvas.Image = canvasBitmap; // 업데이트된 비트맵 반영
        }
        // 실제 그리기 로직
        private void DrawShape(Graphics g, Pen pen) //실제 그리기 
        {
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, startPoint, endPoint);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, GetRectangle(startPoint, endPoint));
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, GetRectangle(startPoint, endPoint));
                    break;
            }
        }

        // 두 점 사이의 좌표를 계산해 사각형 영역을 반환
        private Rectangle GetRectangle(Point p1, Point p2) //싲가점,종점계산,
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }
        private void picCanvas_Paint(object sender, PaintEventArgs e) //미리보기
        {
            if (isDrawing)
            {
                // 드래그 중에는 점선으로 미리보기를 그려줌
                Pen previewPen = new Pen(currentColor, currentLineWidth);
                previewPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                DrawShape(e.Graphics, previewPen);
            }
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {

        }
    }
}