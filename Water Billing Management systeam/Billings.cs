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
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
            ShowBillings();
            GetCons();
            //Reset();
            AgentLblTb.Text = Login.User;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\water DIS.mdf; Integrated Security=True;Connect Timeout=30");
        private void ShowBillings()
        {
            Con.Open();
            string Query = "select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillingsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (RateTb.Text == "" || TaxTb.Text == "" || ConsTb.Text == "")
            {
                MessageBox.Show("MISSING INFORMATION!!");
            }
            else
            {
                try
                {
                    int R = Convert.ToInt32(RateTb.Text);
                    int Consuption = Convert.ToInt32(ConsTb.Text);
                    double Tax = (R * Consuption) * (Convert.ToInt32(TaxTb.Text) / 100);
                    double Total = (R * Consuption) - Tax;
                    String Period = BPeriod.Value.Month + "/" + BPeriod.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl(CId,Agent,BPeriod,Consuption,Rate,Tax,Total) values (@CI,@Ag,@BP,@Con,@Rate,@Tax,@Tot)", Con);
                    cmd.Parameters.AddWithValue("@CI", CIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Ag", AgentLblTb.Text);
                    cmd.Parameters.AddWithValue("@BP", Period);
                    cmd.Parameters.AddWithValue("@Con",Consuption);
                    cmd.Parameters.AddWithValue("@Rate",RateTb.Text);
                    cmd.Parameters.AddWithValue("@Tax", TaxTb.Text);
                    cmd.Parameters.AddWithValue("@Tot", Total);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Saved!!!");
                    Con.Close();
                    ShowBillings();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        
        }
        private void Reset()
        {
            CIdCb.SelectedIndex = -1;
            RateTb.Text = "";
            TaxTb.Text = "";
            ConsTb.Text = "";
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void GetCons()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Cid from ConsumerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Cid", typeof(int));
            dt.Load(Rdr);
            CIdCb.ValueMember = "Cid";
            CIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetConsRate()
        {
            Con.Open();
            String Query = "Select * from ConsumerTbl where Cid="+ CIdCb.SelectedValue.ToString() +" " ;
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                RateTb.Text = dr["CRte"].ToString();
            }
             Con.Close();
        }
        private void CIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetConsRate();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Consumers obj = new Consumers();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Billings obj = new Billings();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Dasboard obj = new Dasboard();
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
