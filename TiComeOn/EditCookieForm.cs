using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiCome
{
    public partial class EditCookieForm : Form
    {
        private MainForm parent;
        private Howto howto;

        public EditCookieForm(MainForm parent)
        {
            InitializeComponent();
            howto = new Howto();
            if(parent != null && !parent.IsDisposed)
            {
                this.parent = parent;
                user_session.Text = this.parent.GetCookie();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(parent == null || parent.IsDisposed)
            {
                parent = new MainForm();
                parent.FormClosed += (s, args) => this.Close();
            }
            parent.SetCookie(user_session.Text);
            parent.Show();
            this.Hide();
            howto?.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(howto == null || howto.IsDisposed)
            {
                howto = new Howto();
            }
            howto.Hide();
            howto.Show();
        }
    }
}
