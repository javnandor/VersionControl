﻿using Beadandó_7.Abstractions;
using Beadandó_7.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadandó_7
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        Toy _nextToy;
        private IToyFactory ToyFactory;

        public IToyFactory Factory
        {
            get { return ToyFactory; }
            set 
            { 
                ToyFactory = value;
                DisplayNext();
                
            }
        }

        private void DisplayNext()
        {
            if (_nextToy != null) Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _toys.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }

        private void conveyorTime_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _toys)
            {
                ball.MoveToy();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void btnBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory() { BallColor = btnColor.BackColor };
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorDialog = new ColorDialog();

            colorDialog.Color = button.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorDialog.Color;
        }
    }
}
