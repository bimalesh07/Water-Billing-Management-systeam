using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water_Billing_Management_systeam
{
    public partial class Dasboard : Form
    {
        public Dasboard()
        {
            InitializeComponent();
            CountAgents();
            CountConsumer();
            SumBill();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\water DIS.mdf; Integrated Security=True;Connect Timeout=30");
        private void Dasboard_Load(object sender, EventArgs e)
        {

        }
        private void CountAgents()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from AgentTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AgNumLbl.Text = dt.Rows[0][0].ToString()+"  Agents";
            Con.Close();

        }
        private void CountConsumer()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ConsumerTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ConsLbl.Text = dt.Rows[0][0].ToString()+" Consumer";
            Con.Close();

        }
        private void SumBill()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(Total) from BillTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BillLbl.Text = "RS "+dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void ConsLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BPeriod_onValueChanged(object sender, EventArgs e)
        {
            String BPer = BPeriod.Value.Month + "/" + BPeriod.Value.Year;
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(Total) from BillTbl where BPeriod='" +BPer+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BillMonthLbl.Text = "RS " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Billings obj = new Billings();
            obj.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Agents obj = new Agents();
            obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

            Consumers obj = new Consumers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
