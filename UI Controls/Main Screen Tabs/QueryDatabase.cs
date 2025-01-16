using EveHelperWF.UI_Controls.Support_Screens;
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

namespace EveHelperWF.UI_Controls.Main_Screen_Tabs
{
    public partial class QueryDatabase : Objects.FormBase
    {
        public QueryDatabase()
        {
            InitializeComponent();
        }

        private void RunQueryButton_Click(object sender, EventArgs e)
        {
            ResultsGridView.DataSource = null;
            ResultsGridView.Columns.Clear();
            ResultsGridView.Rows.Clear();
            ResultsGridView.ForeColor = Color.Black;
            string queryText = QueryTextBox.Text;
            if (!string.IsNullOrWhiteSpace(queryText))
            {
                if (!HasUnsafeCalls())
                {
                    if (!queryText.Contains("COLLATE NOCASE"))
                    {
                        queryText += Environment.NewLine + "COLLATE NOCASE";
                    }
                    try
                    {

                        List<List<Object>> queryResults = Database.SQLiteCalls.RunCustomQuery(QueryTextBox.Text);
                        if (queryResults != null)
                        {
                            CreateGridColumns(queryResults[0]);
                            queryResults.Remove(queryResults[0]);
                            int i = 0;
                            DataGridViewRow dataGridViewRow;
                            foreach (List<Object> row in queryResults)
                            {
                                i = 0;
                                dataGridViewRow = new DataGridViewRow();
                                dataGridViewRow.CreateCells(ResultsGridView);
                                while (i < row.Count)
                                {
                                    dataGridViewRow.Cells[i].Value = row[i];
                                    i++;
                                }
                                ResultsGridView.Rows.Add(dataGridViewRow);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error ocurred during query." + ex.Message, "Query Error");
                    }
                }
                else
                {
                    MessageBox.Show("Your query has unsafe commands. You cannot update, create, delete, drop, or otherwise modify the SDE.", "Unsafe Query");
                }
            }
        }

        private void CreateGridColumns(List<Object> columnRow)
        {
            foreach (Object column in columnRow)
            {
                ResultsGridView.Columns.Add(column.ToString(), column.ToString());
            }
        }

        private bool HasUnsafeCalls()
        {
            bool hasUnsafe = false;

            string queryText = QueryTextBox.Text.ToLowerInvariant();

            if (queryText.Contains("update"))
            {
                hasUnsafe = true;
            }
            if (queryText.Contains("create"))
            {
                hasUnsafe = true;
            }
            if (queryText.Contains("delete"))
            {
                hasUnsafe = true;
            }
            if (queryText.Contains("drop"))
            {
                hasUnsafe = true;
            }

            return hasUnsafe;
        }

        private void QueryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunQueryButton_Click(this, new EventArgs());
            }
        }

        private void eveHelperButton2_Click(object sender, EventArgs e)
        {
            DatabaseSchema dbSchema = new DatabaseSchema();
            dbSchema.StartPosition = FormStartPosition.CenterParent;
            dbSchema.Show();
        }
    }
}
