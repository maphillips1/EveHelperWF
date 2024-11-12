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

        public override Color BackColor
        {
            get
            {
                return Enums.Enums.BackgroundColor;
            }
        }

        public override Cursor Cursor
        {
            get
            {
                return Cursors.Hand;
            }
        }

        

        #region <Round Corners> : (Draw)
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner-
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        /// <summary> Draw Corners (Round or Square). </summary>
        /// <param name="e"></param>
        private void DrawCorners()
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        #endregion

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.FlatStyle = FlatStyle.Standard;
            this.UseVisualStyleBackColor = false;
            this.ForeColor = CommonHelper.GetInvertedColor(this.BackColor);
            base.OnPaint(pe);
            DrawCorners();
        }
    }
}
