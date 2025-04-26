using Business;
using ManageDatabase.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Net;
using System.Windows.Forms;
using System.Web;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace UI
{
    public partial class Form1 : Form
    {
        MenuStrip menuStrip;
        ToolStripMenuItem menu;
        Label label1, label2;
        DataGridView dataGrid;
        DataGridView dataGrid1;
        Button Insert, Update, InsertItem, CreateReport;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            this.BackColor = Color.FromArgb(0, 32, 63);
            CreateMenuStrip();
            CreateLabels();

        }
        private void CreateLabels()
        {
            label1 = new Label
            {
                Text = "Welcome to Our Warehous Management System",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                ForeColor = ColorTranslator.FromHtml("#ADEFD1"),
                TextAlign = ContentAlignment.MiddleCenter,

            };
            label1.Location = Location = new Point(190, 200);
            this.Controls.Add(label1);
            label2 = new Label
            {
                Text = "Please Select Item from menu above and enjoy managing data",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                ForeColor = ColorTranslator.FromHtml("#ADEFD1"),
                TextAlign = ContentAlignment.MiddleCenter,

            };
            label2.Location = Location = new Point(150, 250);
            this.Controls.Add(label2);
        }
        private void CreateMenuStrip()
        {
            menuStrip = new MenuStrip
            {
                Renderer = new CustomMenuRenderer(),
                BackColor = Color.FromArgb(0, 32, 63)
            };

            menu = new ToolStripMenuItem("Menu");

            ToolStripMenuItem warehousesItem = new ToolStripMenuItem("Warehouses");
            warehousesItem.Click += MenuItem_Click;
            warehousesItem.Click += Warehouses_Click;

            ToolStripMenuItem itemsItem = new ToolStripMenuItem("Items");
            itemsItem.Click += MenuItem_Click;
            itemsItem.Click += Items_Click;

            ToolStripMenuItem customersItem = new ToolStripMenuItem("Customers");
            customersItem.Click += MenuItem_Click;
            customersItem.Click += Customers_Click;

            ToolStripMenuItem suppliersItem = new ToolStripMenuItem("Suppliers");
            suppliersItem.Click += MenuItem_Click;
            suppliersItem.Click += Suppliers_Click;

            ToolStripMenuItem supplyingPermissionsItem = new ToolStripMenuItem("Supplying Permissions");
            supplyingPermissionsItem.Click += MenuItem_Click;
            supplyingPermissionsItem.Click += SupplyingPermissions_Click;

            ToolStripMenuItem consumptionPermissionsItem = new ToolStripMenuItem("Consumption Permissions");
            consumptionPermissionsItem.Click += MenuItem_Click;
            consumptionPermissionsItem.Click += ConsumptionPermissions_Click;

            ToolStripMenuItem stockTransformationsItem = new ToolStripMenuItem("Stock Transformations");
            stockTransformationsItem.Click += MenuItem_Click;
            stockTransformationsItem.Click += StockTransformations_Click;
            menu.DropDownItems.Add(warehousesItem);
            menu.DropDownItems.Add(itemsItem);
            menu.DropDownItems.Add(customersItem);
            menu.DropDownItems.Add(suppliersItem);
            menu.DropDownItems.Add(supplyingPermissionsItem);
            menu.DropDownItems.Add(consumptionPermissionsItem);
            menu.DropDownItems.Add(stockTransformationsItem);
            menuStrip.Items.Add(menu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }
        private void CreateButtons()
        {
            if (Update == null)
                Update = new Button
                {
                    BackColor = ColorTranslator.FromHtml("#ADEFD1"),
                    Text = "Update",
                    ForeColor = Color.FromArgb(0, 32, 63),
                };
            if (Insert == null)
                Insert = new Button
                {
                    BackColor = ColorTranslator.FromHtml("#ADEFD1"),
                    Text = "Insert",
                    ForeColor = Color.FromArgb(0, 32, 63),
                };
            if (InsertItem == null)
                InsertItem = new Button
                {
                    BackColor = ColorTranslator.FromHtml("#ADEFD1"),
                    Text = "InsertItem",
                    ForeColor = Color.FromArgb(0, 32, 63),
                };
            if (CreateReport == null)
                CreateReport = new Button
                {
                    BackColor = ColorTranslator.FromHtml("#ADEFD1"),
                    Text = "Create Report",
                    ForeColor = Color.FromArgb(0, 32, 63),
                };
            Update.Location = new Point(20, dataGrid.Height + 30);
            Insert.Location = new Point(Update.Width + 20, dataGrid.Height + 30);
            CreateReport.Location = new Point(Update.Width + 20 + Insert.Width + 20, dataGrid.Height + 30);
            InsertItem.Location = new Point(this.Width - InsertItem.Width - 50, dataGrid.Height + 30);
            Update.Click += Update_Click;
            Insert.Click += Insert_Click;
            CreateReport.Click += CreateReport_Click;
            InsertItem.Click += InsertItem_Click;
            this.Controls.Add(Update);
            this.Controls.Add(Insert);
            this.Controls.Add(CreateReport);
            this.Controls.Add(InsertItem);
        }
        private void InitializeCustomDataGridViewForWarehouses<T>(List<T> table, List<string> columns)
        {
            if (dataGrid != null)
            {
                this.Controls.Remove(dataGrid1);
                dataGrid.Dispose();
            }
            dataGrid = new DataGridView
            {
                Dock = DockStyle.None,
                BackgroundColor = Color.FromArgb(0, 32, 63),
                ForeColor = ColorTranslator.FromHtml("#ADEFD1"),
                GridColor = Color.FromArgb(0, 32, 63),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,
                Location = new Point(10, 20),
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            int maxHeight = 600;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 32, 63);
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ADEFD1");
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dataGrid.RowsDefaultCellStyle.BackColor = Color.FromArgb(0, 32, 63);
            dataGrid.RowsDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ADEFD1");
            dataGrid.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#ADEFD1");
            dataGrid.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 32, 63);

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Select",
                Width = 60
            };
            dataGrid.Columns.Insert(0, checkBoxColumn);

            foreach (var property in typeof(T).GetProperties())
            {
                if (columns.Contains(property.Name)) dataGrid.Columns.Add(property.Name, property.Name);
            }
            foreach (var item in table)
            {
                var row = new DataGridViewRow();
                DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell
                {
                    Value = false // Initialize the checkbox to false
                };
                row.Cells.Add(checkBoxCell);
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!columns.Contains(property.Name)) continue;
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell
                    {
                        Value = property.GetValue(item),
                    };
                    row.Cells.Add(cell);
                }
                dataGrid.Rows.Add(row);
            }
            var row1 = new DataGridViewRow();
            DataGridViewCheckBoxCell checkBoxCell1 = new DataGridViewCheckBoxCell
            {
                Value = false
            };
            row1.Cells.Add(checkBoxCell1);
            dataGrid.Rows.Add(row1);
            int totalWidth = dataGrid.Columns
            .Cast<DataGridViewColumn>()
            .Sum(column => column.Width);

            int scrollBarWidth = SystemInformation.VerticalScrollBarWidth;
            int padding = 10;
            totalWidth += scrollBarWidth + padding;

            dataGrid.Width = totalWidth;
            dataGrid.Height = Math.Min((dataGrid.RowCount + 1) * dataGrid.RowTemplate.Height, maxHeight);

            dataGrid.CellValueChanged += (sender, e) =>
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dataGrid.Rows[e.RowIndex];
                    bool isChecked = (bool)row.Cells[0].Value;

                    if (isChecked)
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ADEFD1");
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 32, 63);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(0, 32, 63);
                        row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ADEFD1");
                    }

                    UpdateDataGrid1();
                }
            };

            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ReadOnly = false;
            this.Controls.Add(dataGrid);
        }
        private void InitializeCustomDataGridViewForItemsInWarehouses<T>(List<T> table, List<string> columns)
        {
            if (dataGrid1 != null)
            {
                this.Controls.Remove(dataGrid1);
                dataGrid1.Dispose();
            }

            dataGrid1 = new DataGridView
            {
                Dock = DockStyle.None,
                BackgroundColor = Color.FromArgb(0, 32, 63),
                ForeColor = ColorTranslator.FromHtml("#ADEFD1"),
                GridColor = Color.FromArgb(0, 32, 63),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            dataGrid1.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ADEFD1");
            dataGrid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 32, 63);
            dataGrid1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dataGrid1.RowsDefaultCellStyle.BackColor = Color.FromArgb(0, 32, 63);
            dataGrid1.RowsDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ADEFD1");
            dataGrid1.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#ADEFD1");
            dataGrid1.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 32, 63);

            foreach (var property in typeof(T).GetProperties())
            {
                if (columns.Contains(property.Name))
                    dataGrid1.Columns.Add(property.Name, property.Name);
            }

            foreach (var item in table)
            {
                var row = new DataGridViewRow();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!columns.Contains(property.Name)) continue;
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell
                    {
                        Value = property.GetValue(item),
                    };
                    row.Cells.Add(cell);
                }
                dataGrid1.Rows.Add(row);
            }
            var row1 = new DataGridViewRow();
            dataGrid1.Rows.Add(row1);
            int totalWidth = dataGrid1.Columns
            .Cast<DataGridViewColumn>()
            .Sum(column => column.Width);

            int scrollBarWidth = SystemInformation.VerticalScrollBarWidth;
            int padding = 10;
            totalWidth += scrollBarWidth + padding;

            dataGrid1.Width = totalWidth;
            dataGrid1.Height = (dataGrid1.RowCount + 1) * dataGrid1.RowTemplate.Height;
            dataGrid1.Location = new Point(this.Width - dataGrid1.Width, 30);
            dataGrid1.AllowUserToAddRows = false;
            dataGrid1.AllowUserToDeleteRows = false;
            dataGrid1.ReadOnly = false;
            this.Controls.Add(dataGrid1);
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            menu.Text = sender.ToString();
        }
        private void Warehouses_Click(object sender, EventArgs e)
        {
            List<Warehouse> warehouses = WarehouseBusiness.SelectAll();
            List<string> columns = new List<string> { "WarehouseName", "WarehouseAddress", "WarehouseMangerId" };
            InitializeCustomDataGridViewForWarehouses(warehouses, columns);
            CreateButtons();
        }
        private void Items_Click(object sender, EventArgs e)
        {
            List<Item> items = ItemBusiness.SelectAll();
            List<string> columns = new List<string> { "ItemCode", "ItemName" };
            InitializeCustomDataGridViewForWarehouses(items, columns);
            CreateButtons();
        }

        private void Customers_Click(object sender, EventArgs e)
        {
            List<Customer> customers = CustomerBusiness.SelectAll();
            List<string> columns = new List<string>
            {
                "CustomerName",
                "CustomerEmail",
                "CustomerFax",
                "CustomerPhone",
                "CustomerMobile",
                "CustomerWebsite",
            };
            InitializeCustomDataGridViewForWarehouses(customers, columns);
            CreateButtons();
        }

        private void Suppliers_Click(object sender, EventArgs e)
        {
            List<Supplier> suppliers = SupplierBusiness.SelectAll();
            List<string> columns = new List<string>
            {
                "SupplierName",
                "SupplierEmail",
                "SupplierFax",
                "SupplierPhone",
                "SupplierMobile",
                "SupplierWebsite",
            };
            InitializeCustomDataGridViewForWarehouses(suppliers, columns);
            CreateButtons();
        }

        private void SupplyingPermissions_Click(object sender, EventArgs e)
        {
            List<SupplingPermission> permissions = SupplingPermissionBusiness.SelectAll();
            List<string> columns = new List<string>
            {
                "SupplingID",
                "PermissionDate",
                "WarehouseName",
                "SupplierName",
            };
            InitializeCustomDataGridViewForWarehouses(permissions, columns);
            CreateButtons();
        }

        private void ConsumptionPermissions_Click(object sender, EventArgs e)
        {
            List<ConsumptionPermission> permissions = ConsumptionPermissionBusiness.SelectAll();
            List<string> columns = new List<string>
            {
                "ConsumptionID",
                "PermissionDate",
                "WarehouseName",
                "CustomerName",
            };
            InitializeCustomDataGridViewForWarehouses(permissions, columns);
            CreateButtons();
        }

        private void StockTransformations_Click(object sender, EventArgs e)
        {
            List<StockTransform> transforms = StockTransformBusiness.SelectAll();
            List<string> columns = new List<string>
            {
                "TransformID",
                "FromWarehouse",
                "ToWarehouse",
                "SupplierName",
            };
            InitializeCustomDataGridViewForWarehouses(transforms, columns);
            CreateButtons();
        }
        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                dataGrid.EndEdit();

                if (menu.Text == "Warehouses")
                {
                    string name = dataGrid.SelectedRows[0].Cells[1].Value?.ToString();
                    string address = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    int manager = int.Parse(dataGrid.SelectedRows[0].Cells[3].Value?.ToString());
                    bool isUpdated = WarehouseBusiness.Update(name, address, manager);
                    if (isUpdated)
                    {
                        MessageBox.Show("Warehouse updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update warehouse.");
                    }
                }
                else if (menu.Text == "Items")
                {
                    string name = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    int code = int.Parse(dataGrid.SelectedRows[0].Cells[1].Value?.ToString());
                    bool isUpdated = ItemBusiness.Update(code, name);
                    if (isUpdated)
                    {
                        MessageBox.Show("Item updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Item.");
                    }
                }
                else if (menu.Text == "Customers")
                {
                    string Name = dataGrid.SelectedRows[0].Cells[1].Value?.ToString();
                    string Phone = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    string Mobile = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string Fax = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    string Mail = dataGrid.SelectedRows[0].Cells[5].Value?.ToString();
                    string Website = dataGrid.SelectedRows[0].Cells[6].Value?.ToString();
                    bool isUpdated = CustomerBusiness.Update(Name, Phone, Mobile, Fax, Mail, Website);
                    if (isUpdated)
                    {
                        MessageBox.Show("Customer updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Customer.");
                    }
                }
                else if (menu.Text == "Suppliers")
                {
                    string Name = dataGrid.SelectedRows[0].Cells[1].Value?.ToString();
                    string Phone = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    string Mobile = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string Fax = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    string Mail = dataGrid.SelectedRows[0].Cells[5].Value?.ToString();
                    string Website = dataGrid.SelectedRows[0].Cells[6].Value?.ToString();
                    bool isUpdated = SupplierBusiness.Update(Name, Phone, Mobile, Fax, Mail, Website);
                    if (isUpdated)
                    {
                        MessageBox.Show("Supplier updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Supplier.");
                    }
                }
                else if (menu.Text == "Supplying Permissions")
                {
                    int id = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[1].Value?.ToString());
                    DateTime permissionDate = System.DateTime.Now;
                    string warehouseName = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string supplierName = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    bool isUpdated = SupplingPermissionBusiness.Update(id, permissionDate, warehouseName, supplierName);
                    if (isUpdated)
                    {
                        MessageBox.Show("Suppling permission updated.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Suppling permission.");
                    }
                }
                else if (menu.Text == "Consumption Permissions")
                {
                    int id = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[1].Value?.ToString());
                    DateTime permissionDate = System.DateTime.Now;
                    string warehouseName = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string supplierName = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    bool isUpdated = ConsumptionPermissionBusiness.Update(id, permissionDate, warehouseName, supplierName);
                    if (isUpdated)
                    {
                        MessageBox.Show("Consumption permission updated.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Zconsumption permission.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }
        private void Insert_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                dataGrid.EndEdit();

                if (menu.Text == "Warehouses")
                {
                    string name = dataGrid.SelectedRows[0].Cells[1].Value?.ToString();
                    string address = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    int manager = int.Parse(dataGrid.SelectedRows[0].Cells[3].Value?.ToString());
                    bool isInserted = WarehouseBusiness.Insert(name, address, manager);
                    if (isInserted)
                    {
                        MessageBox.Show("Warehouse inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert warehouse.");
                    }
                }
                else if (menu.Text == "Items")
                {
                    string name = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    //int code = int.Parse(dataGrid.SelectedRows[0].Cells[1].Value?.ToString());
                    bool isInserted = ItemBusiness.Insert(name);
                    if (isInserted)
                    {
                        MessageBox.Show("Item inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Item.");
                    }
                }
                else if (menu.Text == "Customers")
                {
                    string Name = dataGrid.SelectedRows[0].Cells[1].Value?.ToString();
                    string Phone = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    string Mobile = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string Fax = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    string Mail = dataGrid.SelectedRows[0].Cells[5].Value?.ToString();
                    string Website = dataGrid.SelectedRows[0].Cells[6].Value?.ToString();
                    bool isInserted = CustomerBusiness.Insert(Name, Phone, Mobile, Fax, Mail, Website);
                    if (isInserted)
                    {
                        MessageBox.Show("Customer inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Customer.");
                    }
                }
                else if (menu.Text == "Suppliers")
                {
                    string Name = dataGrid.SelectedRows[0].Cells[1].Value?.ToString();
                    string Phone = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    string Mobile = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string Fax = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    string Mail = dataGrid.SelectedRows[0].Cells[5].Value?.ToString();
                    string Website = dataGrid.SelectedRows[0].Cells[6].Value?.ToString();
                    bool isInserted = SupplierBusiness.Insert(Name, Phone, Mobile, Fax, Mail, Website);
                    if (isInserted)
                    {
                        MessageBox.Show("Supplier inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Supplier.");
                    }
                }
                else if (menu.Text == "Supplying Permissions")
                {
                    DateTime permissionDate = System.DateTime.Now;
                    string warehouseName = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string supplierName = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    bool isInserted = SupplingPermissionBusiness.Insert(permissionDate, warehouseName, supplierName);
                    if (isInserted)
                    {
                        MessageBox.Show("Supplying permission inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Suppling permission.");
                    }
                }
                else if (menu.Text == "Consumption Permissions")
                {
                    DateTime permissionDate = System.DateTime.Now;
                    string warehouseName = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string supplierName = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    bool isInserted = ConsumptionPermissionBusiness.Insert(permissionDate, warehouseName, supplierName);
                    if (isInserted)
                    {
                        MessageBox.Show("Consumption permission inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert consumption permission.");
                    }
                }
                else if (menu.Text == "Stock Transformations")
                {
                    string FwarehouseName = dataGrid.SelectedRows[0].Cells[2].Value?.ToString();
                    string TwarehouseName = dataGrid.SelectedRows[0].Cells[3].Value?.ToString();
                    string supplierName = dataGrid.SelectedRows[0].Cells[4].Value?.ToString();
                    bool isInserted = StockTransformBusiness.Insert(FwarehouseName, TwarehouseName, supplierName);
                    if (isInserted)
                    {
                        MessageBox.Show("Transform inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert Transform.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to insert.");
            }

        }
        private void InsertItem_Click(object sender, EventArgs e)
        {
            if (menu.Text == "Warehouses")
            {
                int itemCode = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[0].Value?.ToString());
                string warehouse = dataGrid1.SelectedRows[0].Cells[1].Value?.ToString();
                bool isInserted = ItemWarehouseBusiness.Insert(itemCode, warehouse);
                if (isInserted)
                {
                    MessageBox.Show("Successfull insertion");
                }
                else
                {
                    MessageBox.Show("Failed to insert");
                }
            }
            else if (menu.Text == "Supplying Permissions")
            {
                int supplingId = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[0].Value?.ToString());
                int itemCode = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[1].Value?.ToString());
                int amount = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[2].Value?.ToString());
                bool isInserted = SupplingPermissionDetailsBusiness.Insert
                    (supplingId, itemCode, amount, DateTime.Now, DateTime.Now);
                if (isInserted)
                {
                    MessageBox.Show("Successfull insertion");
                }
                else
                {
                    MessageBox.Show("Failed to insert");
                }
            }
            else if (menu.Text == "Consumption Permissions")
            {
                int supplingId = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[0].Value?.ToString());
                int itemCode = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[1].Value?.ToString());
                int amount = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[2].Value?.ToString());
                bool isInserted = ConsumptionPermissionDetailsBusiness.Insert(supplingId, itemCode, amount);
                if (isInserted)
                {
                    MessageBox.Show("Successfull insertion");
                }
                else
                {
                    MessageBox.Show("Failed to insert");
                }
            }
            else if (menu.Text == "Stock Transformations")
            {
                int supplingId = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[0].Value?.ToString());
                int itemCode = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[1].Value?.ToString());
                int amount = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[2].Value?.ToString());
                bool isInserted = StockTransformDetailsBusiness.Insert(supplingId, itemCode, amount, DateTime.Now, DateTime.Now);
                if (isInserted)
                {
                    MessageBox.Show("Successfull insertion");
                }
                else
                {
                    MessageBox.Show("Failed to insert");
                }
            }
            else if (menu.Text == "Items")
            {
                int itemCode = Convert.ToInt32(dataGrid1.SelectedRows[0].Cells[0].Value?.ToString());
                string Unit = dataGrid1.SelectedRows[0].Cells[1].Value?.ToString();
                bool isInserted = ItemMeasureUnitBusiness.Insert(itemCode, Unit);
                if (isInserted)
                {
                    MessageBox.Show("Successfull insertion");
                }
                else
                {
                    MessageBox.Show("Failed to insert");
                }
            }
        }
        private void UpdateDataGrid1()
        {
            var checkedRows = dataGrid.Rows
                .Cast<DataGridViewRow>()
                .Where(row => (bool)row.Cells["Select"].Value == true)
                .ToList();

            var primaryKeys = checkedRows
                .Select(row => row.Cells[0].Value?.ToString())
                .ToList();
            if (menu.Text == "Warehouses")
            {
                List<string> columns = new List<string> { "ItemCode", "WarehouseName", "ItemAmount" };
                List<ItemWarehouse> itemWarehouses = ItemWarehouseBusiness
                .SelectItemBasedOnWarehouses(primaryKeys)
                .ToList();
                InitializeCustomDataGridViewForItemsInWarehouses(itemWarehouses, columns);
            }
            else if (menu.Text == "Supplying Permissions")
            {
                List<string> columns = new List<string> { "SupplingID", "ItemCode", "ItemAmount" };
                List<SupplingPermissionDetails> permissions = SupplingPermissionDetailsBusiness
                    .SelectItems(primaryKeys).ToList();
                InitializeCustomDataGridViewForItemsInWarehouses(permissions, columns);
            }
            else if (menu.Text == "Consumption Permissions")
            {
                List<string> columns = new List<string> { "ConsumptionID", "ItemCode", "ItemAmount" };
                List<ConsumptionPermissionDetails> permissions = ConsumptionPermissionDetailsBusiness
                    .SelectItems(primaryKeys).ToList();
                InitializeCustomDataGridViewForItemsInWarehouses(permissions, columns);
            }
            else if (menu.Text == "Stock Transformations")
            {
                List<string> columns = new List<string>
                { "TransformID", "ItemCode", "ItemAmount","ProductionDate","ExpiryDate" };
                List<StockTransformDetails> transforms = StockTransformDetailsBusiness
                    .SelectTransformedItems(primaryKeys).ToList();
                InitializeCustomDataGridViewForItemsInWarehouses(transforms, columns);
            }
            else if (menu.Text == "Items")
            {
                List<string> columns = new List<string> { "ItemCode", "Unit" };
                List<ItemMeasureUnit> items = ItemMeasureUnitBusiness.SelectUnitsForItem(primaryKeys)
                    .ToList();
                InitializeCustomDataGridViewForItemsInWarehouses(items, columns);
            }
        }

        private void CreateReport_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select data to generate the report.");
                return;
            }
            var checkedRows = dataGrid.Rows
                .Cast<DataGridViewRow>()
                .Where(row => (bool)row.Cells["Select"].Value == true)
                .ToList();

            var primaryKeys = checkedRows
                .Select(row => row.Cells[1].Value?.ToString())
                .ToList();

            string filePath = "not exist";

            if (menu.Text == "Warehouses")
            {
                List<Warehouse> reportData = WarehouseBusiness.SelectOne(primaryKeys[0]);
                filePath = GenerateReportFile(reportData);
            }
            else if (menu.Text == "Items")
            {
                List<ItemWarehouse> reportData = ItemWarehouseBusiness.SelectItemBasedOnWarehouses(primaryKeys);
                filePath = GenerateReportFile(reportData);
            }
            else if(menu.Text=="Supplying Permissions")
            {
                List<SupplingPermissionDetails> reportData = SupplingPermissionDetailsBusiness
                    .SelectItemsNearExpire(3);
                filePath = GenerateReportFile(reportData);
            }
            MessageBox.Show($"Report generated successfully at: {filePath}");
        }

        private string GenerateReportFile<T>(List<T> reportData)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, $"{menu.Text}AyaReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                var headers = typeof(T).GetProperties().Select(property => property.Name);
                writer.WriteLine(string.Join(",", headers));
                foreach (var item in reportData)
                {
                    var values = typeof(T).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
                    writer.WriteLine(string.Join(",", values));
                }
            }

            return filePath;
        }
    }
    }
