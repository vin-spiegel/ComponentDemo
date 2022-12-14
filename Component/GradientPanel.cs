using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUIDemo.Component
{
    public class GradientPanel : Panel
    {
        private Brush gradientBrush;
        private EventHandler handlerGradientChanged;
        
        [Browsable(true)]
        public Color StartColor { get; set; }

        [Browsable(true)]
        public Color EndColor { get; set; }

        [Browsable(true)]
        public LinearGradientMode GradientMode { get; set; }

        public GradientPanel()
        {
            handlerGradientChanged = new EventHandler(GradientChanged);
            ResizeRedraw = true;
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            gradientBrush = new LinearGradientBrush(ClientRectangle, StartColor, EndColor, GradientMode);
            e.Graphics.FillRectangle(gradientBrush, ClientRectangle);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            Invalidate();
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