using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiComeOn
{
    public partial class EditCookieForm : Form
    {
        private MainForm parentForm;
        public EditCookieForm(MainForm form)
        {
            InitializeComponent();
            parentForm = form;
            cookieBox.Text = parentForm.GetCookie();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            parentForm.SetCookie(cookieBox.Text);
            this.Close();
        }
    }
}
