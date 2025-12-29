using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.Objects.Custom_Controls
{
    public partial class EveHelperButton : Button
    {
        public EveHelperButton()
        {
            InitializeComponent();
        }

        private Pen borderPen;

        public Color defaultBackColor = Enums.Enums.BackgroundColor;
        public Color defaultForeColor = CommonHelper.GetInvertedColor(DefaultBackColor);
        private bool borderFull = true;
        private bool borderBottom = false;
        private bool borderLeft = false;
        private bool borderRight = false;
        private bool borderTop = false;
        private float borderWidth = 2;

        public override Color BackColor
        {
            get
            {
                return defaultBackColor;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return CommonHelper.GetInvertedColor(defaultBackColor);
            }
        }

        public override Cursor Cursor
        {
            get
            {
                return Cursors.Hand;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BorderFull { get => borderFull; set => borderFull = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BorderBottom { get => borderBottom; set => borderBottom = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BorderLeft { get => borderLeft; set => borderLeft = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BorderRight { get => borderRight; set => borderRight = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BorderTop { get => borderTop; set => borderTop = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float BorderWidth { get => borderWidth; set => borderWidth = value; }


        private void DrawBorder(PaintEventArgs pe)
        {
            if (borderPen == null)
            {
                borderPen = new Pen(this.ForeColor, BorderWidth);
            }
            if (borderFull)
            {
                pe.Graphics.DrawRectangle(borderPen, new RectangleF(0, 0, Width, Height));
            }
            else
            {
                if (borderBottom)
                {
                    pe.Graphics.DrawLine(borderPen, new Point(0, Height), new Point(Width, Height));
                }
                if (borderLeft)
                {
                    pe.Graphics.DrawLine(borderPen, new Point(0, 0), new Point(0, Height));
                }
                if (BorderRight)
                {
                    pe.Graphics.DrawLine(borderPen, new Point(Width, 0), new Point(Width, Height));
                }
                if (BorderTop)
                {
                    pe.Graphics.DrawLine(borderPen, new Point(0, 0), new Point(Width, 0));
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.UseVisualStyleBackColor = false;
            this.ForeColor = defaultForeColor;
            base.OnPaint(pe);
            DrawBorder(pe);
        }

        public void SetBackgroundColor(Color color)
        {
            defaultBackColor = color;
            Invalidate();
        }

        public void SetForeColor(Color color)
        {
            defaultForeColor = color;
            Invalidate();
        }
    }
}
