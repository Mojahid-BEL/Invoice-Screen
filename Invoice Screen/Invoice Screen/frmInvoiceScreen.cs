using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Invoice_Screen
{
	public partial class frmInvoiceScreen : Telerik.WinControls.UI.RadForm
	{
		Random rnd = new Random();
		private int num;

		public frmInvoiceScreen()
		{
			InitializeComponent();
		}

		private void radLabel2_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.facebook.com/DeveloperSoftwaree");
		}

		private void RadForm1_Load(object sender, EventArgs e)
		{
			//Add Random Number In TextBox
			num = rnd.Next(1, 1000000);
			txtNum.Text = num.ToString();
			//Add date Now In TextBox
			txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
			//Add Header Text In DataGridView
			dgvInvoice.Font = new Font("Segoe UI", 14, FontStyle.Regular);
			dgvInvoice.Columns.Add("colItems", "Items");
			dgvInvoice.Columns[0].ReadOnly = true;
			dgvInvoice.Columns[0].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Regular);
			dgvInvoice.Columns.Add("colPrix", "Prix");
			dgvInvoice.Columns[1].ReadOnly = true;
			dgvInvoice.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Regular);
			dgvInvoice.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
			dgvInvoice.Columns.Add("colQty", "Quantity");
			dgvInvoice.Columns[2].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Regular);
			dgvInvoice.Columns[2].DefaultCellStyle.ForeColor = Color.DarkGreen;
			dgvInvoice.Columns.Add("colTotal", "Total");
			dgvInvoice.Columns[3].ReadOnly = true;
			dgvInvoice.Columns[3].DefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Regular);
			dgvInvoice.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
			//Add Items In ComboBx and Display Prix In TextBox
			Dictionary<int, string> itemsData = new Dictionary<int, string>();
			itemsData.Add(2400, "Intel Core i5 4690K (3.5 GHz)");
			itemsData.Add(2200, "Intel Core i5 4460 (3.2 GHz)");
			itemsData.Add(1550, "Intel Core i3 4170 (3.7 GHz)");
			itemsData.Add(1900, "Intel Core i5 4590 (3.3 GHz)");
			itemsData.Add(2890, "MSI X299 RAIDER");
			itemsData.Add(4090, "ASUS PRIME X299-A");
			itemsData.Add(4590, "MSI X299 GAMING PRO CARBON AC");
			itemsData.Add(3430, "MSI X299 TOMAHAWK");
			itemsData.Add(5190, "MSI X299 GAMING M7 ACK");
			itemsData.Add(940, "Samsung SSD 850 EVO 250GB");
			itemsData.Add(640, "Kingston SSD A400 120GB");
			itemsData.Add(1890, "ZOTAC GeForce GTX 1050 Mini 2GB");
			itemsData.Add(2500, "ZOTAC GeForce GTX 1050 Ti Mini 4GB");
			itemsData.Add(2540, "MSI GeForce GTX 1050 Ti 4GT OC 4GB");
			itemsData.Add(1990, "Gigabyte GeForce GTX 1050 D5 2GB");
			cbItems.DataSource = new BindingSource(itemsData, null);
			cbItems.DisplayMember = "value";
			cbItems.ValueMember = "key";

			txtPrix.Text = cbItems.SelectedValue.ToString();

			txtName.Focus();
			txtName.Select();
			txtName.SelectAll();
		}

		private void txtDate_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				txtDate.ContextMenu = new ContextMenu();
			}
		}

		private void radLabel9_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UClvd-uTRHHrqFhNjdN3QMTQ?view_as=subscriber");
		}

		private void radLabel10_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.linkedin.com/in/mojahid-belaman/");

		}

		private void txtName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				cbItems.Focus();
			}
		}

		private void cbItems_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				txtQty.Focus();
				txtQty.SelectAll();
			}

		}

		private void txtQty_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				btnAdd.PerformClick();
				cbItems.Focus();
			}

		}

		private void btnRandom_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			int num = rnd.Next(1, 1000000);
			txtNum.Text = num.ToString();

		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Regex reg = new Regex("^[a-zA-Z]+(\\s[a-zA-Z]+)*$");
			if (!reg.IsMatch(txtName.Text))
			{
				MessageBox.Show("Incorrect Format Full Name Try Again !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtName.Focus();
				txtName.Select();
				txtName.SelectAll();
			}
			else if (txtQty.Text == String.Empty)
			{
				MessageBox.Show("Enter Quantity Please !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtQty.Focus();
			}
			else if(cbItems.SelectedIndex <= -1)
				return;
			else
			{
				string item = cbItems.Text;
				int prix = Convert.ToInt32(txtPrix.Text);
				int qty = Convert.ToInt32(txtQty.Text);
				int subTotal = prix * qty;

				object[] row = {item, prix, qty, subTotal};
				dgvInvoice.Rows.Add(row);

				txtTotal.Text = (Convert.ToInt32(txtTotal.Text) + subTotal) + "" ;
			}

		}

		private void radLabel2_MouseHover(object sender, EventArgs e)
		{
			radLabel2.ForeColor = Color.White;
		}

		private void radLabel2_MouseLeave(object sender, EventArgs e)
		{
			radLabel2.ForeColor = Color.RoyalBlue;
		}

		private void radLabel9_MouseHover(object sender, EventArgs e)
		{
			radLabel9.ForeColor = Color.White;

		}

		private void radLabel9_MouseLeave(object sender, EventArgs e)
		{
			radLabel9.ForeColor = Color.RoyalBlue;
		}

		private void radLabel10_MouseHover(object sender, EventArgs e)
		{
			radLabel10.ForeColor = Color.White;

		}

		private void radLabel10_MouseLeave(object sender, EventArgs e)
		{
			radLabel10.ForeColor = Color.RoyalBlue;

		}

		private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Display Value Member in TextBox Prix
			txtPrix.Text = cbItems.SelectedValue.ToString();
		}

		private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private string oldQty = "1";
		private void dgvInvoice_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dgvInvoice.CurrentRow != null)
			{
				oldQty = dgvInvoice.CurrentRow.Cells["colQty"].Value.ToString();
			}
		}

		private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvInvoice.CurrentRow != null)
			{
				string newQte = dgvInvoice.CurrentRow.Cells["colQty"].Value.ToString();
				if(newQte == oldQty)
					return;
				if (!Regex.IsMatch(newQte, "^\\d+$") || newQte == "0")
				{
					dgvInvoice.CurrentRow.Cells["colQty"].Value = oldQty;
				}
				else
				{
					int p = (int)dgvInvoice.CurrentRow.Cells["colPrix"].Value;
					int q = Convert.ToInt32(newQte);
					dgvInvoice.CurrentRow.Cells["colTotal"].Value = p * q;
				}

				int newTotal = 0;
				for (int i = 0; i < dgvInvoice.Rows.Count; i++)
				{
					newTotal += Convert.ToInt32(dgvInvoice.Rows[i].Cells["colTotal"].Value);
				}

				txtTotal.Text = newTotal + "";

			}
		}

		private int i = 0;
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.HasMorePages = false;
			float x = 10;
			float y = 10;
			int imgWidth = 200;
			int imgHeight = 200;
			string invNum = "#NU " + txtNum.Text;
			string invDate = "Date : " + txtDate.Text;
			string invName = "Client Name : " + txtName.Text;
			//Pen
			Pen p = new Pen(Color.Black, 1);
			//Font text
			Font f = new Font("Arial", 20, FontStyle.Bold);
			//Size of text
			SizeF strSizeInvNum = e.Graphics.MeasureString(invNum, f);
			SizeF strSizeDate = e.Graphics.MeasureString(invDate, f);
			SizeF strSizeName = e.Graphics.MeasureString(invName, f);
			//Draw Image 
			e.Graphics.DrawImage(Properties.Resources.download, x, y, imgWidth, imgHeight);
			//Draw Invoice Number
			e.Graphics.DrawString(invNum, f, Brushes.Red, (e.PageBounds.Width - strSizeInvNum.Width)/2, y);
			//Draw Invoice Date
			e.Graphics.DrawString(invDate, f, Brushes.Blue, imgWidth + x, y + imgHeight/2);
			//Draw Invoice Name
			e.Graphics.DrawString(invName, f, Brushes.Green, imgWidth +x, y+strSizeInvNum.Height+strSizeDate.Height*4);
			//Draw Rectangle
			float preHeight = strSizeInvNum.Height + strSizeDate.Height + strSizeName.Height + imgHeight + y;
			e.Graphics.DrawRectangle(p, x, imgHeight+y*2, e.PageBounds.Width - x*2, e.PageBounds.Height - preHeight);
			//Column Height
			float colHeight = 60;
			//Column Width
			float col1Width = 450;
			float col2Width = 125 + col1Width;
			float col3Width = 125 + col2Width;
			//Draw Line
			e.Graphics.DrawLine(p, x, preHeight, e.PageBounds.Width - x, preHeight);

			e.Graphics.DrawString("Items",f, Brushes.Black, x*2, preHeight - colHeight);
			e.Graphics.DrawLine(p, x * 2 + col1Width, imgHeight + y * 2, x * 2 + col1Width, e.PageBounds.Height - colHeight - y*4);
			e.Graphics.DrawString("Prix", f, Brushes.Black, x * 2+col1Width, preHeight - colHeight);
			e.Graphics.DrawLine(p, x*2 + col2Width, imgHeight + y * 2, x*2 + col2Width, e.PageBounds.Height - colHeight - y * 4);
			e.Graphics.DrawString("Quantity", f, Brushes.Black, x * 2+col2Width, preHeight - colHeight);
			e.Graphics.DrawLine(p, x * 2 + col3Width, imgHeight + y * 2, x * 2 + col3Width, e.PageBounds.Height - colHeight - y * 4);
			e.Graphics.DrawString("Total", f, Brushes.Black, x * 2+col3Width, preHeight - colHeight);
			e.Graphics.DrawLine(p, x * 2 + col3Width, imgHeight + y * 2, x * 2 + col3Width, e.PageBounds.Height - colHeight - y * 4);
			//Invoice Content
			float rowHeight = 60;
			for (; i < dgvInvoice.Rows.Count; i++)
			{
				if (rowHeight >= e.PageBounds.Height - preHeight -colHeight)
				{
					e.HasMorePages = true;
					break;
				}

				e.Graphics.DrawString(dgvInvoice.Rows[i].Cells[0].Value.ToString(), f, Brushes.Black, x * 2, preHeight + rowHeight - colHeight);
				e.Graphics.DrawString(dgvInvoice.Rows[i].Cells[1].Value.ToString(), f, Brushes.Black, x * 2 + col1Width, preHeight + rowHeight - colHeight);
				e.Graphics.DrawString(dgvInvoice.Rows[i].Cells[2].Value.ToString(), f, Brushes.Black, x * 2 + col2Width, preHeight + rowHeight - colHeight);
				e.Graphics.DrawString(dgvInvoice.Rows[i].Cells[3].Value.ToString(), f, Brushes.Black, x * 2 + col3Width, preHeight + rowHeight - colHeight);

				e.Graphics.DrawLine(p, x, preHeight + rowHeight, e.PageBounds.Width - x,
					preHeight + rowHeight);

				rowHeight += 60;
			}
			if(rowHeight < e.PageBounds.Height - preHeight - colHeight)
			{ 
				e.Graphics.DrawString("Somme", f, Brushes.Red, x * 2 + col2Width, preHeight + rowHeight - colHeight);
				e.Graphics.DrawString(txtTotal.Text, f, Brushes.Green, x * 2 + col3Width, preHeight + rowHeight - colHeight);
			}
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			printPreviewDialog1.WindowState = FormWindowState.Maximized;

			if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.Print();
			}

			i = 0;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvInvoice.CurrentRow != null)
			{
				dgvInvoice.Rows.Remove(dgvInvoice.CurrentRow);
			}
		}

		private void radButton1_Click(object sender, EventArgs e)
		{
			if (printDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.Print();
			}

			i = 0;
		}
	}
}
