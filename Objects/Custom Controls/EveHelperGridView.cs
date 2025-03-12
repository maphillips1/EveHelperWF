using EveHelperWF.ScreenHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.Objects.Custom_Controls
{
    public partial class EveHelperGridView : DataGridView
    {

        private Type? datasourceType {  get; set; }
        private string? m_EditableColumns {  get; set; }
        public string? EditableColumns
        {
            get
            {
                return this.m_EditableColumns;
            }
            set
            {
                this.m_EditableColumns = value;
            }
        }

        public EveHelperGridView()
        {
            InitializeComponent();
            this.EnableHeadersVisualStyles = false;
            this.AutoGenerateColumns = false;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackgroundColor = Enums.Enums.BackgroundColor;
            this.GridColor = Enums.Enums.BackgroundColor;
            this.ForeColor = CommonHelper.GetInvertedColor(this.BackColor);
            this.ColumnHeadersDefaultCellStyle.BackColor = this.BackgroundColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersDefaultCellStyle.BackColor = this.BackgroundColor;
            this.RowHeadersDefaultCellStyle.ForeColor= this.ForeColor;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            base.OnPaint(e);
        }

        public void DatabindGridView(object listToBind)
        {
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.datasourceType = listToBind.GetType();
            this.DataSource = listToBind;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            SetColumnEditMode();
            SetColumnFormat();
        }

        private void SetColumnFormat()
        {
            foreach (DataGridViewColumn column in this.Columns)
            {
                column.DefaultCellStyle.BackColor = Enums.Enums.BackgroundColor;
                column.DefaultCellStyle.ForeColor = CommonHelper.GetInvertedColor(Enums.Enums.BackgroundColor);
                column.DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);
                if (datasourceType != null)
                {
                    Type itemType = datasourceType;
                    foreach (Type interfaceType in datasourceType.GetInterfaces())
                    {
                        if (interfaceType.IsGenericType &&
                            interfaceType.GetGenericTypeDefinition()
                            == typeof(IList<>))
                        {
                            itemType = datasourceType.GetGenericArguments()[0];
                        }
                    }

                    Type? columnPropertyType = itemType.GetProperty(column.DataPropertyName)?.PropertyType;
                    if (columnPropertyType != null)
                    {
                        switch (Type.GetTypeCode(columnPropertyType))
                        {
                            case TypeCode.Double:
                            case TypeCode.Decimal:
                                column.DefaultCellStyle.Format = "N2";
                                break;
                            case TypeCode.Int16:
                            case TypeCode.Int32:
                            case TypeCode.Int64:
                                column.DefaultCellStyle.Format = "N0";
                                break;
                            case TypeCode.DateTime:
                                column.DefaultCellStyle.Format = "d";
                                break;
                            default:
                                column.DefaultCellStyle.Format = "";
                                break;
                        }
                    }
                }
            }
        }

        private void SetColumnEditMode()
        {
            string[]? columnsToEdit = null;
            if (!string.IsNullOrWhiteSpace(this.EditableColumns))
            {
                columnsToEdit = this.EditableColumns.Split(',');
            }
            foreach (DataGridViewColumn column in this.Columns)
            {
                if (columnsToEdit != null && columnsToEdit.Contains(column.Name))
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true;
                }
            }
        }

        protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex < 0) { return; }
            DataGridViewColumn column = this.Columns[e.ColumnIndex];
            Object? defaultVlaue = null;
            if (datasourceType != null)
            {
                Type itemType = datasourceType;
                foreach (Type interfaceType in datasourceType.GetInterfaces())
                {
                    if (interfaceType.IsGenericType &&
                        interfaceType.GetGenericTypeDefinition()
                        == typeof(IList<>))
                    {
                         itemType = datasourceType.GetGenericArguments()[0];
                    }
                }

                Type? columnPropertyType = itemType.GetProperty(column.DataPropertyName)?.PropertyType;
                if (columnPropertyType != null)
                {
                    defaultVlaue  = columnPropertyType.IsValueType ? Activator.CreateInstance(columnPropertyType) : null;
                }
            }

            if ( defaultVlaue == null)
            {
                defaultVlaue = "";
            }
            e.Value = defaultVlaue;
        }

        protected override void OnCellValuePushed(DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex < 0) { return; }
            DataGridViewColumn column = this.Columns[e.ColumnIndex];
            Object? defaultVlaue = null;
            if (datasourceType != null)
            {
                Type itemType = datasourceType;
                foreach (Type interfaceType in datasourceType.GetInterfaces())
                {
                    if (interfaceType.IsGenericType &&
                        interfaceType.GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        itemType = datasourceType.GetGenericArguments()[0];
                    }
                }

                PropertyInfo? propertyInfo = itemType.GetProperty(column.DataPropertyName);
                if (propertyInfo != null)
                {
                    Type columnPropertyType = propertyInfo.PropertyType;
                    if (columnPropertyType != null)
                    {
                        defaultVlaue = columnPropertyType.IsValueType ? Activator.CreateInstance(columnPropertyType) : null;

                        try
                        {
                            e.Value = Convert.ChangeType(e.Value, columnPropertyType);
                        }
                        catch (InvalidCastException ex)
                        {
                            e.Value = defaultVlaue = columnPropertyType.IsValueType ? Activator.CreateInstance(columnPropertyType) : null;
                            MessageBox.Show("Error: Invalid data. Using default of " + defaultVlaue?.ToString());
                        }
                    }
                }
            }
        }
    }
}
