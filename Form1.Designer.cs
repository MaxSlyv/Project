using System.Windows.Forms;

namespace project.Forms
{
    partial class BicyclesForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvBicycles;
        private TextBox tbModel;
        private TextBox tbBrandId;
        private TextBox tbPrice;
        private TextBox tbStock;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private Label lblModel;
        private Label lblBrandId;
        private Label lblPrice;
        private Label lblStock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBicycles = new DataGridView();
            this.tbModel = new TextBox();
            this.tbBrandId = new TextBox();
            this.tbPrice = new TextBox();
            this.tbStock = new TextBox();

            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            this.lblModel = new Label();
            this.lblBrandId = new Label();
            this.lblPrice = new Label();
            this.lblStock = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBicycles)).BeginInit();
            this.SuspendLayout();

            // === DataGridView ===
            this.dgvBicycles.AllowUserToAddRows = false;
            this.dgvBicycles.AllowUserToDeleteRows = false;
            this.dgvBicycles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBicycles.Location = new System.Drawing.Point(12, 160);
            this.dgvBicycles.Name = "dgvBicycles";
            this.dgvBicycles.ReadOnly = true;
            this.dgvBicycles.RowHeadersVisible = false;
            this.dgvBicycles.Size = new System.Drawing.Size(620, 400);
            this.dgvBicycles.CellClick += new DataGridViewCellEventHandler(this.dgvBicycles_CellClick);

            this.dgvBicycles.Columns.Add("Id_bicycle", "ID");
            this.dgvBicycles.Columns.Add("Model_name", "Модель");
            this.dgvBicycles.Columns.Add("Id_brand", "Бренд ID");
            this.dgvBicycles.Columns.Add("Price", "Ціна");
            this.dgvBicycles.Columns.Add("Stock_quantity", "Кількість");

            //стовпці
            int lblX = 20, tbX = 120, y = 20, dy = 30;

            this.lblModel.Text = "Модель:";
            this.lblModel.Location = new System.Drawing.Point(lblX, y);
            this.tbModel.Location = new System.Drawing.Point(tbX, y - 3);
            this.tbModel.Size = new System.Drawing.Size(150, 23);
            y += dy;

            this.lblBrandId.Text = "ID бренду:";
            this.lblBrandId.Location = new System.Drawing.Point(lblX, y);
            this.tbBrandId.Location = new System.Drawing.Point(tbX, y - 3);
            this.tbBrandId.Size = new System.Drawing.Size(150, 23);
            y += dy;

            this.lblPrice.Text = "Ціна:";
            this.lblPrice.Location = new System.Drawing.Point(lblX, y);
            this.tbPrice.Location = new System.Drawing.Point(tbX, y - 3);
            this.tbPrice.Size = new System.Drawing.Size(150, 23);
            y += dy;

            this.lblStock.Text = "Кількість:";
            this.lblStock.Location = new System.Drawing.Point(lblX, y);
            this.tbStock.Location = new System.Drawing.Point(tbX, y - 3);
            this.tbStock.Size = new System.Drawing.Size(150, 23);

            //кнопки
            this.btnAdd.Text = "Додати";
            this.btnAdd.Location = new System.Drawing.Point(300, 20);
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Редагувати";
            this.btnEdit.Location = new System.Drawing.Point(300, 65);
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Видалити";
            this.btnDelete.Location = new System.Drawing.Point(300, 110);
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            //форма
            this.ClientSize = new System.Drawing.Size(650, 580);
            this.Controls.Add(this.dgvBicycles);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);

            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.lblBrandId);
            this.Controls.Add(this.tbBrandId);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.tbStock);

            this.Name = "BicyclesForm";
            this.Text = "Склад велосипедів";
            this.Load += new System.EventHandler(this.BicyclesForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBicycles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
