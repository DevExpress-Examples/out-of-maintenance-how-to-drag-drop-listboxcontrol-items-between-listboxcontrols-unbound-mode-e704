using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;

namespace WindowsApplication596
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
		private DevExpress.XtraEditors.ListBoxControl listBoxControl2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxControl2 = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.ItemHeight = 15;
            this.listBoxControl1.Location = new System.Drawing.Point(32, 16);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(248, 288);
            this.listBoxControl1.TabIndex = 0;
            this.listBoxControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxControl1_MouseMove);
            this.listBoxControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxControl1_MouseDown);
            // 
            // listBoxControl2
            // 
            this.listBoxControl2.AllowDrop = true;
            this.listBoxControl2.ItemHeight = 15;
            this.listBoxControl2.Location = new System.Drawing.Point(360, 16);
            this.listBoxControl2.Name = "listBoxControl2";
            this.listBoxControl2.Size = new System.Drawing.Size(248, 288);
            this.listBoxControl2.TabIndex = 0;
            this.listBoxControl2.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxControl2_DragOver);
            this.listBoxControl2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxControl2_DragDrop);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 510);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.listBoxControl2);
            this.Name = "Form1";
            this.Text = "How to drag/drop ListBoxControl Items between ListBoxControls";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e) {
			for (int i = 0; i < 10; i++) {
				if (i % 2 == 0)
					listBoxControl1.Items.Add("Item " + i.ToString());
				else
					listBoxControl2.Items.Add("Item " + i.ToString());				
			}
		}

		Point p = Point.Empty;

		private void listBoxControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			ListBoxControl c = sender as ListBoxControl;
			p = new Point(e.X, e.Y);
			int selectedIndex = c.IndexFromPoint(p);
			if (selectedIndex == -1)
				p = Point.Empty;
		}

		private void listBoxControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (e.Button == MouseButtons.Left)
				if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > 5) || (Math.Abs(e.Y - p.Y) > 5)))
					listBoxControl1.DoDragDrop(sender, DragDropEffects.Move);
		}

		private void listBoxControl2_DragOver(object sender, System.Windows.Forms.DragEventArgs e) {
			e.Effect = DragDropEffects.Move;
		}

		private void listBoxControl2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {            
			ListBoxControl listBox = sender as ListBoxControl;
			Point newPoint = new Point(e.X, e.Y);
			newPoint = listBox.PointToClient(newPoint);
			int selectedIndex = listBox.IndexFromPoint(newPoint);
			object item = listBoxControl1.Items[listBoxControl1.IndexFromPoint(p)];
			if (selectedIndex == -1)
				listBox.Items.Add(item);
			else
				listBox.Items.Insert(selectedIndex, item);
		}
	}
}
