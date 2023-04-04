namespace AnimatedHeart
{
    public partial class Form1 : Form
    {
        Image heart;
        System.Windows.Forms.Timer textTimer;
        string displayText = "I love you";
        int textPosition = 0;

        public Form1()
        {
            InitializeComponent();
            LoadImages();
            SetupTimer();
        }

        private void SetupTimer()
        {
            textTimer = new System.Windows.Forms.Timer();
            textTimer.Interval = 50; // 50ms interval to update the text
            textTimer.Tick += new EventHandler(TextTimer_Tick);
            textTimer.Start();
        }

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            // Update the position of the text
            textPosition += 5;
            if (textPosition > this.Width)
            {
                textPosition = 0;
            }
            this.Invalidate(); // Invalidate the form to trigger repaint

        }

        private void DrawAnimationsPaintEvent(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(heart);
            e.Graphics.DrawImage(heart, new Point(-75, 0));
            e.Graphics.DrawImage(heart, new Point(385, 0));

            // Draw the moving text
            Font font = new Font("Arial", 16);
            Brush brush = Brushes.Red;
            SizeF textSize = e.Graphics.MeasureString(displayText, font);
            e.Graphics.DrawString(displayText, font, brush, new PointF(textPosition, this.Height / 2 - textSize.Height));
        }

        private void LoadImages()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            heart = Properties.Resources.heart;
            ImageAnimator.Animate(heart, this.OnFrameChangedHandler);
        }

        private void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
