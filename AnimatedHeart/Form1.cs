namespace AnimatedHeart
{
    public partial class Form1 : Form
    {
        Image heart;
        System.Windows.Forms.Timer textTimer;
        string displayText = "I Love You Paige";
        int textPosition = 0;
        SizeF textSize;

        public Form1()
        {
            InitializeComponent();
            LoadImages();
            SetupTimer();
        }

        private void SetupTimer()
        {
            textTimer = new System.Windows.Forms.Timer();
            textTimer.Interval = 50;
            textTimer.Tick += new EventHandler(TextTimer_Tick);
            textTimer.Start();
        }

        private int textDirection = 1;

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            
            textPosition += 5 * textDirection;
            if (textPosition + textSize.Width > this.Width || textPosition < 0)
            {
                
                textDirection *= -1;
            }
            this.Invalidate();
        }




        private void DrawAnimationsPaintEvent(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(heart);
            e.Graphics.DrawImage(heart, new Point(-75, 0));
            e.Graphics.DrawImage(heart, new Point(385, 0));


            Font font = new Font("Arial", 54);
            Brush brush = Brushes.Purple;
            textSize = e.Graphics.MeasureString(displayText, font);
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
