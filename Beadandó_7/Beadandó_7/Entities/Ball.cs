using Beadandó_7.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadandó_7.Entities
{
    public class Ball:Toy
    {
        public SolidBrush BallBrush { get; private set; }

        public Ball(Color kivantszin)
        {
            BallBrush = new SolidBrush(kivantszin);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallBrush, 0, 0, Width, Height);
        }
    }
}
