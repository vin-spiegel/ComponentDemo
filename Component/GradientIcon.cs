using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUIDemo.Component
{
    public class GradientIcon : Label
    {
        private Brush gradientBrush;
        private EventHandler handlerGradientChanged;
        
        [Browsable(true)]
        public Color StartColor { get; set; }

        [Browsable(true)]
        public Color EndColor { get; set; }

        [Browsable(true)]
        public LinearGradientMode GradientMode { get; set; }

        private Color GetRandomColor()
        {
            var rand = new Random(1);
            return Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }

        public GradientIcon(string name = "", int size = 32, bool randomColor = false)
        {
            handlerGradientChanged = new EventHandler(GradientChanged);
            ResizeRedraw = true;
            Height = size;
            Width = size;
            Text = name;
            var color = new Color();
            StartColor = color.GetRandomColor();
            EndColor = color.GetRandomColor();
            TextAlign = ContentAlignment.MiddleCenter;
            ForeColor = Color.White;
            this.SetRound(15);
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            gradientBrush = new LinearGradientBrush(ClientRectangle, StartColor, EndColor, GradientMode);
            e.Graphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        private void GradientChanged(object sender, EventArgs e)
        {
            gradientBrush?.Dispose();
            gradientBrush = null;
            Invalidate();
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && gradientBrush != null)
            {
                gradientBrush.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}