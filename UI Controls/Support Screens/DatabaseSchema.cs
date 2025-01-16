using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class DatabaseSchema : Objects.FormBase
    {
        List<string> tableList;
        public DatabaseSchema()
        {
            InitializeComponent();
            LoadTableList();
            ColumnsGridView.ForeColor = Color.Black;
        }

        private void LoadTableList()
        {
            TableTreeView.Nodes.Clear();
            tableList = Database.SQLiteCalls.LoadTableList();

            TreeNode TN;
            foreach (string tableName in tableList)
            {
                TN = new TreeNode();
                TN.Text = tableName;
                TN.Tag = tableName;
                TableTreeView.Nodes.Add(TN);
            }
        }

        private void TableTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ColumnsGridView.Rows.Clear();
            ColumnsGridView.Columns.Clear();
            TableNameLabel.Text = "Name";
            if (TableTreeView.SelectedNode != null && TableTreeView.SelectedNode.Tag != null)
            {
                if (!string.IsNullOrWhiteSpace(TableTreeView.SelectedNode.Tag.ToString()))
                {
                    TableNameLabel.Text = TableTreeView.SelectedNode.Tag.ToString();
                    List<List<Object>> columnList = Database.SQLiteCalls.LoadTableSchema(TableTreeView.SelectedNode.Tag.ToString());
                    if (columnList != null)
                    {
                        CreateGridColumns(columnList[0]);
                        columnList.Remove(columnList[0]);
                        int i = 0;
                        DataGridViewRow dataGridViewRow;
                        foreach (List<Object> row in columnList)
                        {
                            i = 0;
                            dataGridViewRow = new DataGridViewRow();
                            dataGridViewRow.CreateCells(ColumnsGridView);
                            while (i < row.Count)
                            {
                                dataGridViewRow.Cells[i].Value = row[i];
                                i++;
                            }
                            ColumnsGridView.Rows.Add(dataGridViewRow);
                        }
                    }
                }
            }
        }

        private void CreateGridColumns(List<Object> columnRow)
        {
            foreach (Object column in columnRow)
            {
                ColumnsGridView.Columns.Add(column.ToString(), column.ToString());
            }
        }
    }
}
