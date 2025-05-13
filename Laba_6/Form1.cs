using static Laba_6.Emitter;
using static Laba_6.Particle;

namespace Laba_6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // ������� ���� ��� ��������

        GravityPoint point1; // ������� ���� ��� ������ �����
        GravityPoint point2; // ������� ���� ��� ������ �����

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                GravitationY = 0.5f // ��������� ���������� ����
            };

            emitters.Add(this.emitter);

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
                Power = 100 // ����� ������ ��������� ��������
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
                Power = 100
            };

            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
        }


        private void picDisplay_Click(object sender, EventArgs e)
        {

        }

        // �� � ��������� ���� �������, ��� ������ ������������ ���������
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // ��� ������ ��������� �������

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // � ��� ������ �������� ����� �������
            }

            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // ��� �� �������
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // � ��� �������� ��������� ����, � ��������� ���������
            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // ����������� �������� ����������� �������� ��������
            lblDirection.Text = $"{tbDirection.Value}�"; // ������� ����� ��������
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }
    }
}
