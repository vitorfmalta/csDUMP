using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtratoBB
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.DataGridView dgvDados;
        private string ordem;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvDados)).BeginInit();
            this.SuspendLayout();
            dgvDados.Parent = this;  // You have to set the parent manually so that the grid is displayed on the form
            dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new System.Drawing.Point(5, 5);
            dgvDados.Name = "myNewGrid";
            dgvDados.Size = new System.Drawing.Size(this.Size.Width - 30, this.Size.Height - 50);
            dgvDados.TabIndex = 0;
            dgvDados.ColumnHeadersVisible = true;
            dgvDados.RowHeadersVisible = false;
            dgvDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvDados.CellClick += MyNewGrid_CellClick;  // Seta o handler para o evento CellClick.  
            dgvDados.ColumnHeaderMouseClick += MyNewGrid_ColumnHeaderMouseClick;  // Seta o handler para o evento ColumnHeaderMouseClick.  
            ((System.ComponentModel.ISupportInitialize)(dgvDados)).EndInit();
            this.ResumeLayout(false);
            dgvDados.Visible = true;
            
            //leitura com objetos (tipado)
            dgvDados.DataSource = clsIO.CreateDataTable(clsIO.ObterDados());            
            
            //Apenas leitura...
            //dgvDados.DataSource = clsIO.ObterDadosSet();
            //dgvDados.DataMember = "Extrato";
            
            dgvDados.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDados.Columns["Valor"].DefaultCellStyle.Format = "0.00";
            //dgvDados.DataSource = clsIO.ObterDados().Where(l => l.NumeroDocumento == 2710031989854).ToList();
        }

        private void MyNewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView v = (DataGridView)sender;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                System.Windows.Forms.MessageBox.Show(v.Columns[e.ColumnIndex].Name.ToString() + " : " + (e.RowIndex + 1) + " = " + v[e.ColumnIndex, e.RowIndex].Value.ToString());                
            }
        }

        private void MyNewGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView v = (DataGridView)sender;
            //objeto List nao consegue ordernar com o list normal... com o datatable nao precisa codificar NADA!
            //if (ordem == v.Columns[e.ColumnIndex].Name.ToString())
            //{
            //    v.Sort(v.Columns[e.ColumnIndex], ListSortDirection.Descending);
            //    ordem = "";
            //}
            //else
            //{
            //    v.Sort(v.Columns[e.ColumnIndex], ListSortDirection.Ascending);
            //    ordem = v.Columns[e.ColumnIndex].Name.ToString();
            //}
            
            //objeto List nao consegue ordernar com o list normal... com o datatable nao precisa codificar NADA!

            
            //ordenando na leitura....
            //var coluna = v.Columns[e.ColumnIndex];
            //v.DataSource = null;
            //if (ordem == coluna.Name.ToString())
            //{
            //    v.DataSource = clsIO.ObterDados(coluna.Name.ToString(), false);
            //    ordem = "";
            //}
            //else
            //{
            //    v.DataSource = clsIO.ObterDados(coluna.Name.ToString(), true);
            //    ordem = coluna.Name.ToString();
            //}

            //dgvDados.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvDados.Columns["Valor"].DefaultCellStyle.Format = "0.00";
            
            //ordenando na leitura....

        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            dgvDados.Size = new System.Drawing.Size(this.Size.Width - 30, this.Size.Height - 50);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dgvDados.Size = new System.Drawing.Size(this.Size.Width - 30, this.Size.Height - 50);
        }
    }
}
