using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SongIllustrator
{
    public partial class DisplayButton : UserControl
    {
        public DisplayButton()
        {
            InitializeComponent();
        }
        private int colorCount = 0;
        private bool shiftDown = false;
        private bool rightClick = false;
        List<DisplayButton> buttons = new List<DisplayButton>();
        public int ColorCount {
            get {
                return colorCount;
            }
            set {
                colorCount = value;
            }
        }
        public bool ShiftDown {
            get {
                return shiftDown;
            }
            set {
                shiftDown = value;
            }
        }
        string _text = "";
        public string DisplayText {
            get {
                return _text;
            }
            set {
                _text = value;
            }
        }
        public bool InvokeInteraction
        {
            set { Interact(this, EventArgs.Empty); }
        }
        private void DisplayButton_Load(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
            Interact += delegate{ChangeColor();};
        }
        Point cursorLocation = new Point(0,0);
        public event EventHandler Interact;
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            ChangeColor();
            if (rightClick)
            {
                foreach (DisplayButton button in buttons)
                {
                    button.BackColor = this.BackColor;
                }
                rightClick = false;
            }
        }
        private void ChangeColor() {
            switch (colorCount++)
            {
                case 0:
                    BackColor = Color.Red;
                    break;
                case 1:
                    BackColor = Color.Orange;
                    break;
                case 2:
                    BackColor = Color.Yellow;
                    break;
                case 3:
                    BackColor = Color.Green;
                    break;
                case 4:
                    BackColor = Color.Aqua;
                    break;
                case 5:
                    BackColor = Color.Blue;
                    break;
                case 6:
                    BackColor = Color.Purple;
                    break;
                case 7:
                    BackColor = Color.Black;
                    break;
                case 8:
                    BackColor = Color.Gray;
                    colorCount = 0;
                    break;
            }
        }
        private void DisplayButton_DoubleClick(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
            colorCount = 0;
        }

        private void DisplayButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (string.IsNullOrEmpty(DisplayText))
                {
                    mouseFollow.Start();
                    cursorLocation = e.Location;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                buttons = new List<DisplayButton>();
                foreach (DisplayButton button in this.Parent.Controls)
                {
                    if (button.BackColor == this.BackColor)
                    {
                        buttons.Add(button);
                    }
                }
                rightClick = true;
            }
        }

        private void DisplayButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayText))
            {
            mouseFollow.Stop();
            }
        }

        private void mouseFollow_Tick(object sender, EventArgs e)
        {
                Point cursorPosition = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                foreach (DisplayButton button in this.Parent.Controls)
                {
                    Point buttonLocation = button.Location;
                    if (cursorPosition.X + this.Location.X < buttonLocation.X + button.Width && cursorPosition.X + this.Location.X > buttonLocation.X && cursorPosition.Y + this.Location.Y < buttonLocation.Y + button.Height && cursorPosition.Y + this.Location.Y > buttonLocation.Y)
                    {
                        button.BackColor = this.BackColor;
                        Point i = button.Location;
                    }
                }
        }

        private void DisplayButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Shift)
            {
                shiftDown = true;
            }
        }

        private void DisplayButton_KeyUp(object sender, KeyEventArgs e)
        {
            shiftDown = false;
        }

        private void DisplayButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawString(_text, new Font(new FontFamily("Arial"), 12), Brushes.Black, new PointF(0, 0));
        }
    }
}
