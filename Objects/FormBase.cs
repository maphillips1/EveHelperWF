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

            Color mainBackgroundColor = Color.FromArgb(255, 2, 23, 38);

            this.BackColor = mainBackgroundColor;
            this.ForeColor = Color.White;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
