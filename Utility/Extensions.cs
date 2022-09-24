using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUIDemo
{
    public static class Extensions
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr handle, IntPtr hRgn, bool bRedraw);
       
        /// <summary xml:lang="ko">
        /// 컨트롤을 라운딩 처리 해줍니다.
        /// </summary>
        public static void SetRound(this Control control, int x, int y)
        {
            var ip = CreateRoundRectRgn(0, 0, control.Width, control.Height, x, y);
            SetWindowRgn(control.Handle, ip, true);
        }

        private static IEnumerable<Control> GetAllControlsRecursive(Control container)
        {
            var result = new List<Control>();
            foreach (Control control in container.Controls)
            {
                result.Add(control);
                if (control.Controls.Count > 0)
                {
                    result.AddRange(GetAllControlsRecursive(control));
                }
            }
            return result.ToArray();
        }

        /// <summary xml:lang="ko">
        /// 폼의 모든 컨트롤을 얻습니다
        /// </summary>
        public static Control[] GetAllControls(this Form form)
        {
            var result = new List<Control>();
            
            foreach (Control control in form.Controls)
            {
                result.Add(control);
                result.AddRange(GetAllControlsRecursive(control));
            }
            return result.ToArray();
        }
        
    }
    
}