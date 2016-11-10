using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTagUI
{
	public partial class BookingSearchResultForm : Form
	{
		public BookingSearchResultForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form searchResult = new BookingAirplaneSeatForm();
			this.Hide();
			searchResult.ShowDialog();
		}
	}
}
