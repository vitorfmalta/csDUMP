using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoReadBigFile
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.DataGridView myNewGrid;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string caminho = "C:\\Users\\user\\Documents\\Visual Studio 2017\\ProjetoReadBigFile\\RS0.csv";
            myNewGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(myNewGrid)).BeginInit();
            this.SuspendLayout();
            myNewGrid.Parent = this;  // You have to set the parent manually so that the grid is displayed on the form
            myNewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myNewGrid.Location = new System.Drawing.Point(5, 5);
            myNewGrid.Name = "myNewGrid";
            myNewGrid.Size = new System.Drawing.Size(500, 500);
            myNewGrid.TabIndex = 0;
            myNewGrid.ColumnHeadersVisible = true;
            myNewGrid.RowHeadersVisible = true;
            myNewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            myNewGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            myNewGrid.CellClick += MyNewGrid_CellClick;  // Set up an event handler for CellClick.  
            ((System.ComponentModel.ISupportInitialize)(myNewGrid)).EndInit();
            this.ResumeLayout(false);
            myNewGrid.Visible = true;
            myNewGrid.DataSource = CEFIOSA.ObterDados(caminho);

        }

        private void MyNewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}