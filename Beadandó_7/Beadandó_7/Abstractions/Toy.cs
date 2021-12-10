﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadandó_7.Abstractions
{
    abstract class Toy: Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = Height = 50;
            Paint += Ball_Paint;
        }
        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics g);
   
        public void MoveBall()
        {
            Left++;
        }
    }
}
