namespace AnimatedHeart
{
    public partial class Form1 : Form
    {
        Image heart;
        System.Windows.Forms.Timer textTimer;
        string displayText = "I Love You Paige";
        int textPositionX = 0;
        int textPositionY = 0;
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

        private int textDirectionX = 1;
        private int textDirectionY = 1;

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            // Update the position of the text
            textPositionX += 5 * textDirectionX;
            if (textPositionX + textSize.Width > this.Width)
            {
                // Text hit the right edge, reverse direction and move left
                textDirectionX *= -1;
                textPositionX = (int)(this.Width - textSize.Width);
            }
            else if (textPositionX < 0)
            {
                // Text hit the left edge, reverse direction and move right
                textDirectionX *= -1;
                textPositionX = 0;
            }
            textPositionY += 5 * textDirectionY;
            if (textPositionY + textSize.Height > this.Height)
            {
                // Text hit the bottom edge, reverse direction and move up
                textDirectionY *= -1;
                textPositionY = (int)(this.Height - textSize.Height);
            }
            else if (textPositionY < 0)
            {
                // Text hit the top edge, reverse direction and move down
                textDirectionY *= -1;
                textPositionY = 0;
            }

            this.Invalidate();
        }


        private void DrawAnimationsPaintEvent(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(heart);
            e.Graphics.DrawImage(heart, new Point(-75, 0));
            e.Graphics.DrawImage(heart, new Point(385, 0));

            Font font = new Font("Arial", 50);
            Brush brush = Brushes.Purple;
            textSize = e.Graphics.MeasureString(displayText, font);
            e.Graphics.DrawString(displayText, font, brush, new PointF(textPositionX, textPositionY));
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


