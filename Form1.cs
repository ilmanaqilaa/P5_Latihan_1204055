using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace P5_Latihan_1204055
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(816, 298);
        }

        private void btPilih_Click(object sender, EventArgs e)
        {
            if (tbNIM.Text != "")
            {
                if (tbNama.Text != "")
                {
                    if (rbCewe.Checked || rbLaki.Checked)
                    {
                        if (tbAlamat.Text != "")
                        {
                            if (cbProgStud.Text != "– Pilih Program Studi –")
                            {
                                if (tbAkademik.Text != "" && Regex.IsMatch(tbAkademik.Text, @"^\d{4}/\d{4}$"))
                                {
                                    if (tbSemester.Text != "")
                                    {
                                        MessageBox.Show
                                                    ("Sudah terisi semua ya!!",
                                                    "Informasi Data Submit",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Size = new Size(816, 640);

                                    }
                                    else
                                    {
                                        MessageBox.Show
                                                    ("Semester masih  kosong!",
                                                    "Informasi Data Submit",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    if (tbAkademik.Text != "")
                                    {
                                        if (Regex.IsMatch(tbAkademik.Text, @"^\d{4}/\d{4}$"))
                                        {
                                            errorProvider1.SetError(tbAkademik, "");
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(tbAkademik, "Format Tahun Akademik Salah!");
                                            MessageBox.Show
                                                ("Format Tahun Akademik Salah!",
                                                "Informasi Data Submit",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show
                                                ("Tahun Akademik masih kosong!",
                                                "Informasi Data Submit",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show
                                            ("Program Studi masih kosong!",
                                            "Informasi Data Submit",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show
                                        ("Alamat masih kosong!",
                                        "Informasi Data Submit",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show
                                    ("Jenis Kelamin masih kosong!",
                                    "Informasi Data Submit",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show
                                ("Nama masih kosong!",
                                "Informasi Data Submit",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show
                            ("NIM masih kosong!",
                            "Informasi Data Submit",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbAkademik_TextChanged(object sender, EventArgs e)
        {
            if (tbAkademik.Text != "")
            {
                if (Regex.IsMatch(tbAkademik.Text, @"^\d{4}/\d{4}$"))
                {
                    errorProvider1.SetError(tbAkademik, "");
                }
                else
                {
                    errorProvider1.SetError(tbAkademik, "Format Tahun Akademik Salah!");
                }
            }
            else
            {
                errorProvider1.SetError(tbAkademik, "Wajib Diisi");
            }
        }

        private void btSimpan_Click(object sender, EventArgs e)
        {
            string jenisKelamin = null;
            if (rbLaki.Checked)
            {
                jenisKelamin = rbLaki.Text;
            }
            else if (rbCewe.Checked)
            {
                jenisKelamin = rbCewe.Text;
            }

            string kurikulum = null;
            if (rbKur6.Checked)
            {
                kurikulum = rbKur6.Text;
            }
            else if (rbKur10.Checked)
            {
                kurikulum = rbKur10.Text;
            }
            else if (rbKur14.Checked)
            {
                kurikulum = rbKur14.Text;
            }

            string matkul = null;
            if (cbMTK.Checked)
            {
                matkul += cbMTK.Text + ", ";
            }
            if (cbProg1.Checked)
            {
                matkul += cbProg1.Text + ", ";
            }
            if (cbProg2.Checked)
            {
                matkul += cbProg2.Text + ", ";
            }
            if (cbProg3.Checked)
            {
                matkul += cbProg3.Text + ", ";
            }
            if (cbProg4.Checked)
            {
                matkul += cbProg4.Text + ", ";
            }
            if (cbProg5.Checked)
            {
                matkul += cbProg5.Text + ", ";
            }
            if (cbProg6.Checked)
            {
                matkul += cbProg6.Text + ", ";
            }
            if (cbProg7.Checked)
            {
                matkul += cbProg7.Text + ", ";
            }
            if (cbOperasi.Checked)
            {
                matkul += cbOperasi.Text + ", ";
            }
            if (cbPelo.Checked)
            {
                matkul += cbPelo.Text + ", ";
            }
            if (cbJaringan.Checked)
            {
                matkul += cbJaringan.Text + ", ";
            }
            if (cbManajemen.Checked)
            {
                matkul += cbManajemen.Text + ", ";
            }

            MessageBox.Show
                        ("NIM: " + tbNIM.Text +
                        "\nNama: " + tbNama.Text +
                        "\nJenis Kelamin: " + jenisKelamin +
                        "\nAlamat: " + tbAlamat.Text +
                        "\nProgram Studi: " + cbProgStud.Text +
                        "\nTahun Akademik: " + tbAkademik.Text +
                        "\nSemester: " + tbSemester.Text +
                        "\n--------------------------------------------" +
                        "\nKurikulum: " + kurikulum +
                        "\nMata Kuliah: " + matkul,
                        "Informasi Data Submit",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btBatal_Click(object sender, EventArgs e)
        {
            tbNIM.Text = null;
            tbNama.Text = null;
            rbLaki.Checked = false;
            rbCewe.Checked = false;
            tbAlamat.Text = null;
            cbProgStud.Text = null;
            tbAkademik.Text = null;
            tbSemester.Text = null;

            rbKur6.Checked = false;
            rbKur10.Checked = false;
            rbKur14.Checked = false;

            cbMTK.Enabled = false; cbMTK.Checked = false;
            cbProg1.Enabled = false; cbProg1.Checked = false;
            cbProg2.Enabled = false; cbProg2.Checked = false;
            cbProg3.Enabled = false; cbProg3.Checked = false;
            cbProg4.Enabled = false; cbProg4.Checked = false;
            cbProg5.Enabled = false; cbProg5.Checked = false;
            cbProg6.Enabled = false; cbProg6.Checked = false;
            cbProg7.Enabled = false; cbProg7.Checked = false;
            cbPelo.Enabled = false; cbPelo.Checked = false;
            cbJaringan.Enabled = false; cbJaringan.Checked = false;
            cbOperasi.Enabled = false; cbOperasi.Checked = false;
            cbManajemen.Enabled = false; cbManajemen.Checked = false;

            this.Size = new Size(816, 298);

            MessageBox.Show
                        ("Form telah direset",
                        "Informasi Data Submit",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbKur6_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKur6.Checked)
            {
                cbMTK.Enabled = true; cbMTK.Checked = false;
                cbProg1.Enabled = true; cbProg1.Checked = false;
                cbProg2.Enabled = true; cbProg2.Checked = false;
                cbProg3.Enabled = true; cbProg3.Checked = false;
                cbProg4.Enabled = true; cbProg4.Checked = false;
                cbProg5.Enabled = true; cbProg5.Checked = false;
                cbProg6.Enabled = true; cbProg6.Checked = false;
                cbProg7.Enabled = true; cbProg7.Checked = false;
                cbPelo.Enabled = true; cbPelo.Checked = false;
                cbJaringan.Enabled = true; cbJaringan.Checked = false;
                cbOperasi.Enabled = false; cbOperasi.Checked = false;
                cbManajemen.Enabled = false; cbManajemen.Checked = false;
            }
        }

        private void rbKur10_CheckedChanged(object sender, EventArgs e)
        {
            cbMTK.Enabled = false; cbMTK.Checked = false;
            cbProg1.Enabled = true; cbProg1.Checked = false;
            cbProg2.Enabled = true; cbProg2.Checked = false;
            cbProg3.Enabled = true; cbProg3.Checked = false;
            cbProg4.Enabled = true; cbProg4.Checked = false;
            cbProg5.Enabled = true; cbProg5.Checked = false;
            cbProg6.Enabled = true; cbProg6.Checked = false;
            cbProg7.Enabled = true; cbProg7.Checked = false;
            cbPelo.Enabled = true; cbPelo.Checked = false;
            cbJaringan.Enabled = true; cbJaringan.Checked = false;
            cbOperasi.Enabled = false; cbOperasi.Checked = false;
            cbManajemen.Enabled = true; cbManajemen.Checked = false;
        }

        private void rbKur14_CheckedChanged(object sender, EventArgs e)
        {
            cbMTK.Enabled = false; cbMTK.Checked = false;
            cbProg1.Enabled = true; cbProg1.Checked = false;
            cbProg2.Enabled = true; cbProg2.Checked = false;
            cbProg3.Enabled = true; cbProg3.Checked = false;
            cbProg4.Enabled = true; cbProg4.Checked = false;
            cbProg5.Enabled = true; cbProg5.Checked = false;
            cbProg6.Enabled = true; cbProg6.Checked = false;
            cbProg7.Enabled = true; cbProg7.Checked = false;
            cbPelo.Enabled = true; cbPelo.Checked = false;
            cbJaringan.Enabled = true; cbJaringan.Checked = false;
            cbOperasi.Enabled = true; cbOperasi.Checked = false;
            cbManajemen.Enabled = false; cbManajemen.Checked = false;
        }
    }
}