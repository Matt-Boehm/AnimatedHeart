namespace AnimatedHeart
{
    public partial class Form1 : Form
    {
        Image heart; 
        public Form1()
        {
            InitializeComponent();
            LoadImages(); 
        }
        private void DrawAnimationsPaintEvent(object sender, PaintEventArgs e)
        {
             
            ImageAnimator.UpdateFrames(heart); 
            

            e.Graphics.DrawImage(heart, new Point(-75, 0));
            e.Graphics.DrawImage(heart, new Point(385, 0));
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }


       

        
        





    }
}