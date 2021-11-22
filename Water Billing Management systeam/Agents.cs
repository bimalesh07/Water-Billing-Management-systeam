using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Water_Billing_Management_systeam
{
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
            ShowAgents();
            Reset();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\c#\water DIS.mdf; Integrated Security=True;Connect Timeout=30");
        private void ShowAgents()
        {
            Con.Open();
            string Query = "select AgNum as Code, AgName as Name,AgPhone as Phone, AgAdd as Address,AgPass as Password from AgentTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AgentsDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AgNameTb.Text == "" || AgPassTb.Text == "" || AgPhoneTb.Text == "" || AgAddTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AgentTbl(AgName,AgPhone,AgAdd,AgPass) values(@AN,@AP,@AA,@APa)", Con);
                    cmd.Parameters.AddWithValue("@AN", AgNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", AgPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@AA", AgAddTb.Text);
                    cmd.Parameters.AddWithValue("@APa", AgPassTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Added !!!");
                    Con.Close();
                    ShowAgents();
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
            AgNameTb.Text = "";
            AgPhoneTb.Text = "";
            AgAddTb.Text = "";
            AgPassTb.Text = "";
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int key = 0;
        private void AgentsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AgNameTb.Text = AgentsDGV.SelectedRows[0].Cells[1].Value.ToString();
            AgPhoneTb.Text = AgentsDGV.SelectedRows[0].Cells[2].Value.ToString();
            AgAddTb.Text = AgentsDGV.SelectedRows[0].Cells[3].Value.ToString();
            AgPassTb.Text = AgentsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (AgNameTb.Text == "")
            {
                key = 0;
                
            }
            else
            {
                key = Convert.ToInt32(AgentsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (AgNameTb.Text == "" || AgPassTb.Text == "" || AgPhoneTb.Text == "" || AgAddTb.Text == "")
            {
                MessageBox.Show("Missing Information!!!");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update  AgentTbl set AgName=@AN,AgPhone=@AP,AgAdd=@AA,AgPass=@APa where Agnum=@Akey", Con);
                    cmd.Parameters.AddWithValue("@AN", AgNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", AgPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@AA", AgAddTb.Text);
                    cmd.Parameters.AddWithValue("@APa", AgPassTb.Text);
                    cmd.Parameters.AddWithValue("@Akey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Updated 👌👌👌!!!");
                    Con.Close();
                    ShowAgents();
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
                MessageBox.Show("Select the Agent to Be the Delete!!!");
            }
            else
            {

                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from  AgentTbl  where Agnum=@Akey", Con);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.AddWithValue("@Akey", key);
                    MessageBox.Show("Agent Deleted 👌👌👌😜😜😜!!!");
                    Con.Close();
                    ShowAgents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
           // Billings obj = new Billings();
          //  obj.Show();
            //this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}