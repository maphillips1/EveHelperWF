using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects
{
    public class FormBase : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); // for design in 96 DPI


            this.BackColor = Enums.Enums.BackgroundColor;
            this.ForeColor = Color.White;

            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        public void DatabindGridView<T>(Objects.Custom_Controls.EveHelperGridView grid, T dataSource)
        {
            grid.DatabindGridView(dataSource);            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Enums.Enums.BackgroundColor, ButtonBorderStyle.Solid);
        }
    }
}
