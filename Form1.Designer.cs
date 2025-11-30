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
        private TextBox tbSearchModel;

        private TextBox tbType;
        private TextBox tbFrameSize;
        private TextBox tbFrameMaterial;
        private TextBox tbGearCount;

        private ComboBox cbBrandFilter;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private Label lblModel;
        private Label lblBrandId;
        private Label lblPrice;
        private Label lblStock;
        private Label lblSearchModel;

        private Label lblType;
        private Label lblFrameSize;
        private Label lblFrameMaterial;
        private Label lblGearCount;
        private Label lblBrandFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dgvBicycles = new DataGridView();

            this.tbModel = new TextBox();
            this.tbBrandId = new TextBox();
            this.tbPrice = new TextBox();
            this.tbStock = new TextBox();
            this.tbSearchModel = new TextBox();

            this.tbType = new TextBox();
            this.tbFrameSize = new TextBox();
            this.tbFrameMaterial = new TextBox();
            this.tbGearCount = new TextBox();

            this.cbBrandFilter = new ComboBox();

            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            this.lblModel = new Label();
            this.lblBrandId = new Label();
            this.lblPrice = new Label();
            this.lblStock = new Label();
            this.lblSearchModel = new Label();

            this.lblType = new Label();
            this.lblFrameSize = new Label();
            this.lblFrameMaterial = new Label();
            this.lblGearCount = new Label();
            this.lblBrandFilter = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBicycles)).BeginInit();
            this.SuspendLayout();

            //DataGridView
            this.dgvBicycles.AllowUserToAddRows = false;
            this.dgvBicycles.AllowUserToDeleteRows = false;
            this.dgvBicycles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBicycles.Location = new System.Drawing.Point(12, 325);
            this.dgvBicycles.Name = "dgvBicycles";
            this.dgvBicycles.ReadOnly = true;
            this.dgvBicycles.RowHeadersVisible = false;
            this.dgvBicycles.Size = new System.Drawing.Size(1100, 500);
            this.dgvBicycles.CellClick += new DataGridViewCellEventHandler(this.dgvBicycles_CellClick);

            this.dgvBicycles.Columns.Add("DisplayId", "№");
            this.dgvBicycles.Columns.Add("Model_name", "Модель");
            this.dgvBicycles.Columns.Add("Id_brand", "Бренд ID");
            this.dgvBicycles.Columns.Add("Price", "Ціна");
            this.dgvBicycles.Columns.Add("Stock_quantity", "Кількість");
            this.dgvBicycles.Columns.Add("Type1", "Тип");
            this.dgvBicycles.Columns.Add("Frame_size", "Розмір рами");
            this.dgvBicycles.Columns.Add("Frame_material", "Матеріал рами");
            this.dgvBicycles.Columns.Add("Gear_count", "К-сть передач");
            this.dgvBicycles.Columns.Add("RealId", "ID"); 
            this.dgvBicycles.Columns["RealId"].Visible = false;

            // Автосортировка колонок
            foreach (DataGridViewColumn col in dgvBicycles.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            //Labels и TextBox
            int lblX = 20, tbX = 150, y = 20, dy = 30;

            this.lblModel.Text = "Модель:";
            this.lblModel.Location = new System.Drawing.Point(lblX, y);
            this.tbModel.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblBrandId.Text = "ID бренду:";
            this.lblBrandId.Location = new System.Drawing.Point(lblX, y);
            this.tbBrandId.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblType.Text = "Тип:";
            this.lblType.Location = new System.Drawing.Point(lblX, y);
            this.tbType.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblFrameSize.Text = "Розмір рами:";
            this.lblFrameSize.Location = new System.Drawing.Point(lblX, y);
            this.tbFrameSize.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblFrameMaterial.Text = "Матеріал рами:";
            this.lblFrameMaterial.Location = new System.Drawing.Point(lblX, y);
            this.tbFrameMaterial.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblGearCount.Text = "К-сть передач:";
            this.lblGearCount.Location = new System.Drawing.Point(lblX, y);
            this.tbGearCount.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblPrice.Text = "Ціна:";
            this.lblPrice.Location = new System.Drawing.Point(lblX, y);
            this.tbPrice.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblStock.Text = "Кількість:";
            this.lblStock.Location = new System.Drawing.Point(lblX, y);
            this.tbStock.Location = new System.Drawing.Point(tbX, y - 3);
            y += dy;

            this.lblSearchModel.Text = "Пошук моделі:";
            this.lblSearchModel.Location = new System.Drawing.Point(lblX, y);
            this.tbSearchModel.Location = new System.Drawing.Point(tbX, y - 3);
            this.tbSearchModel.TextChanged += new System.EventHandler(this.tbSearchModel_TextChanged);
            y += dy;

            //ComboBox для фильтра
            this.lblBrandFilter.Text = "Фільтр по бренду:";
            this.lblBrandFilter.Location = new System.Drawing.Point(20, 290);
            this.cbBrandFilter.Location = new System.Drawing.Point(150, 290);
            this.cbBrandFilter.Size = new System.Drawing.Size(150, 23);
            this.cbBrandFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbBrandFilter.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

            //Buttons
            this.btnAdd.Text = "Додати";
            this.btnAdd.Location = new System.Drawing.Point(350, 20);
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Редагувати";
            this.btnEdit.Location = new System.Drawing.Point(350, 60);
            this.btnEdit.Size = new System.Drawing.Size(120, 30);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Видалити";
            this.btnDelete.Location = new System.Drawing.Point(350, 100);
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            //Добавляем контролы на форму
            this.Controls.Add(this.dgvBicycles);

            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.tbBrandId);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbFrameSize);
            this.Controls.Add(this.tbFrameMaterial);
            this.Controls.Add(this.tbGearCount);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.tbSearchModel);
            this.Controls.Add(this.cbBrandFilter);

            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblBrandId);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblFrameSize);
            this.Controls.Add(this.lblFrameMaterial);
            this.Controls.Add(this.lblGearCount);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblSearchModel);
            this.Controls.Add(this.lblBrandFilter);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);

            //Настройки формы
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "BicyclesForm";
            this.Text = "Склад велосипедів";
            this.Load += new System.EventHandler(this.BicyclesForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBicycles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
