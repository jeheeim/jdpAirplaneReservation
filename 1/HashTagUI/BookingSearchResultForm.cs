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
		Account currentUser;
		string dest; string departDay; string departTime;

		public BookingSearchResultForm(Account currentUser, string dest, string departDay, string departTime)
		{
			InitializeComponent();

			this.currentUser = currentUser;
			this.dest = dest;
			this.departDay = departDay;
			this.departTime = departTime;

			label1.Text = label1.Text.Replace("%s", dest);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form searchResult = new BookingAirplaneSeatForm();
			this.Hide();
			searchResult.ShowDialog();
		}
	}
}
