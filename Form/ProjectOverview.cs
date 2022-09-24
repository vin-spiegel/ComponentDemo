using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIDemo
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
            this.Load += Overview_Load;
        }

        public void Overview_Load(object sender, EventArgs args)
        {
            foreach (var control in this.GetAllControls())
            {
                Console.WriteLine(control.Name);
            }

        }
    }
}