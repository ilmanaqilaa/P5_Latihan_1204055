using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    [ToolboxBitmap(typeof(NumericTextBox), "P5_1_XXXXXX.NumericTextBox.ico")]
    public partial class NumericTextBox: TextBox
    {
        public NumericTextBox()
        {
            InitializeComponent();
        }

        //Exposing & Overiding text property
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                try
                {
                    int.Parse(value);
                    base.Text = value;
                    return;
                }
                catch { }
                if (value == null)
                {
                    base.Text = value;
                    return;
                }
            }
        }

        //Raising & overiding OnKeyPress event
        public delegate void InvalidUserEntryEvent(object sender, KeyPressEventArgs e);
        public event InvalidUserEntryEvent InvalidUserEntry;

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            int asciiChar = Convert.ToInt32(e.KeyChar);
            if (asciiChar >= 47 && asciiChar <= 57)
            {
                e.Handled = false;
                return;
            }
            if (asciiChar == 8)
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
            if (InvalidUserEntry != null)
                InvalidUserEntry(this, e);
        }

    }
}
