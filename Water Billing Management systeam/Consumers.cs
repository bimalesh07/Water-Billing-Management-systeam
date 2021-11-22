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
    public partial class Consumers : Form
    {
        public Consumers()
        {
            InitializeComponent();
            ShowConsumers();
            Reset();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\water DIS.mdf; Integrated Security=True;Connect Timeout=30");
        private void ShowConsumers()
        {
            Con.Open();
            string Query = "select * from ConsumerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ConsumersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void Consumers_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Consumers obj = new Consumers();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddTb.Text == "" || CPhoneTb.Text == "" || CCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ConsumerTbl(CName,CAddress,Cphone,CCategory,CJDate,CRte) values(@CN,@CA,@CP,@CC,@CD,@CR)", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CC", CCatCb.Text);
                    cmd.Parameters.AddWithValue("@CD", CJDateTb.Text);
                    cmd.Parameters.AddWithValue("@CR", CRateTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consumers Added 👍👍👍!!!");
                    Con.Close();
                    ShowConsumers();
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
            CNameTb.Text = "";
            CAddTb.Text = "";
            CPhoneTb.Text = "";
            CCatCb.SelectedIndex = -1;
            CJDateTb.Text = "";
            CRateTb.Text = "";

        }
        private void GetRate()
        {
            if (CCatCb.SelectedIndex==0)
            {
                CRateTb.Text = "70";
            }else if(CCatCb.SelectedIndex == 1)
            {
                CRateTb.Text = "95";
            }
            else
            {
                CRateTb.Text = "120";
            }
        }
        int key =0;
        private void CCatCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRate();
        }
        private void ConsumersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text = ConsumersDGV.SelectedRows[0].Cells[1].Value.ToString();
            CAddTb.Text = ConsumersDGV.SelectedRows[0].Cells[2].Value.ToString();
            CPhoneTb.Text = ConsumersDGV.SelectedRows[0].Cells[3].Value.ToString();
            CCatCb.Text = ConsumersDGV.SelectedRows[0].Cells[4].Value.ToString();
            CJDateTb.Text = ConsumersDGV.SelectedRows[0].Cells[5].Value.ToString();
            CRateTb.Text = ConsumersDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (CNameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(ConsumersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddTb.Text == "" || CPhoneTb.Text == "" || CCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ConsumerTbl set CName=@CN,CAddress=@CA,CPhone=@CP,CCategory=@CC,CJDate=@CD,CRte=@CR where Cid=@Ckey", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CC", CCatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CD", CJDateTb.Text);
                    cmd.Parameters.AddWithValue("@CR", CRateTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consumers Deleted 😂😂👌!!!");
                    Con.Close();
                    ShowConsumers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the ConsumerTbl to Be the Delete!!!");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from  ConsumerTbl  where Cid=@Ckey", Con);
                    cmd.Parameters.AddWithValue("@Ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consumer Deleted 👌👌👌😜😜😜!!!");
                    Con.Close();
                    ShowConsumers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
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

        private void label3_Click(object sender, EventArgs e)
        {
            Billings obj = new Billings();
            obj.Show();
            this.Hide();
        }
    }
}
