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

        private double zoomRatio = 1.0; // 1.0 = 100%

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
            // 시작점 저장
            startPoint = new Point((int)(e.X / zoomRatio), (int)(e.Y / zoomRatio));
            endPoint = startPoint; // 초기화 시 시작점과 끝점을 같게 설정
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            // 여기가 중요! startPoint가 아니라 endPoint를 업데이트해야 합니다.
            endPoint = new Point((int)(e.X / zoomRatio), (int)(e.Y / zoomRatio));
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            // 여기도 endPoint를 업데이트해야 합니다.
            endPoint = new Point((int)(e.X / zoomRatio), (int)(e.Y / zoomRatio));

            // 비트맵에 실제로 그리기
            DrawShape(canvasGraphics, new Pen(currentColor, currentLineWidth));
            picCanvas.Image = canvasBitmap;
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

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // 2. 3가지 포맷(.png, .jpg, .bmp) 필터 설정
                saveFileDialog.Title = "그림 저장하기";
                saveFileDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp";

                // 사용자가 파일명을 입력하고 '확인'을 눌렀을 때 실행
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 3. 파일 확장자에 맞춰 포맷 결정 및 저장
                        string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                        ImageFormat format = ImageFormat.Png; // 기본값

                        switch (extension)
                        {
                            case ".jpg":
                            case ".jpeg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            case ".png":
                            default:
                                format = ImageFormat.Png;
                                break;
                        }

                        // 현재 도화지(canvasBitmap)를 선택한 형식으로 저장
                        canvasBitmap.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("이미지가 정상적으로 저장되었습니다!", "저장 완료");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("저장 중 오류가 발생했습니다: " + ex.Message);
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 1. 파일에서 원본 이미지 로드
                    Image originalImage = Image.FromFile(openFileDialog.FileName);

                    // 2. 이미지 크기에 맞춰 새로운 비트맵과 캔버스 생성
                    canvasBitmap = new Bitmap(originalImage.Width, originalImage.Height);
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    // 3. 불러온 이미지를 캔버스에 그리기
                    canvasGraphics.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);

                    // 4. PictureBox 설정 업데이트
                    picCanvas.Image = canvasBitmap;
                    picCanvas.Size = canvasBitmap.Size; // 이미지 크기에 맞춰 컨트롤 크기 조정 (스크롤 생성됨)

                    originalImage.Dispose();
                    zoomRatio = 1.0; // 확대 비율 초기화
                }
            }
        }

        // 확대/축소 적용 함수
        // 확대 버튼 (+)
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoomRatio += 0.2; // 20%씩 확대
            ApplyZoom();
        }

        // 축소 버튼 (-)
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (zoomRatio > 0.2) // 너무 작아지면 안 되므로 최소 20%까지만
            {
                zoomRatio -= 0.2; // 20%씩 축소
                ApplyZoom();
            }
        }

        // 실제로 PictureBox 크기를 조절하는 함수
        private void ApplyZoom()
        {
            if (canvasBitmap != null)
            {
                // 1. PictureBox의 크기를 비율에 맞춰 계산
                picCanvas.Width = (int)(canvasBitmap.Width * zoomRatio);
                picCanvas.Height = (int)(canvasBitmap.Height * zoomRatio);

                // 2. 이미지가 PictureBox 크기에 꽉 차도록 설정
                picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}