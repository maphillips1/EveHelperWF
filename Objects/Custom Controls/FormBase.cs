﻿using System;
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

            Color mainBackgroundColor = Enums.Enums.BackgroundColor;

            this.BackColor = mainBackgroundColor;
            this.ForeColor = Color.White;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void DatabindGridView<T>(DataGridView grid, T dataSource)
        {
            grid.DataSource = null;
            DataGridViewAutoSizeColumnsMode dataGridViewAutoSizeColumnsMode = grid.AutoSizeColumnsMode;
            DataGridViewAutoSizeRowsMode dataGridViewAutoSizeRowMode = grid.AutoSizeRowsMode;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.AutoGenerateColumns = false;
            grid.DataSource = dataSource;
            grid.AutoSizeColumnsMode = dataGridViewAutoSizeColumnsMode;
            grid.AutoSizeRowsMode = dataGridViewAutoSizeRowMode;
            
        }
    }
}
