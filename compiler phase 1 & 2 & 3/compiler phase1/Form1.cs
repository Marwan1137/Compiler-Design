namespace compiler_phase1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Image.FromFile(@"D:\MSA\Compiler Design\Phase 1 compiler design\Welcome to compiler scanner black.png");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}