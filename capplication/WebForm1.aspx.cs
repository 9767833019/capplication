using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace capplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        private string connectionString = "Server=DESKTOP-11VRKLP\\SQLEXPRESS;Database=StudentDB;Integrated Security=true;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
                TextBox txtAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAddress");
                TextBox txtAge = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAge");

                if (txtName == null)
                {
                    lblMessage.Text = "Name textbox not found.";
                    return;
                }
                if (txtAddress == null)
                {
                    lblMessage.Text = "Address textbox not found.";
                    return;
                }
                if (txtAge == null)
                {
                    lblMessage.Text = "Age textbox not found.";
                    return;
                }

                string name = txtName.Text.Trim();
                string address = txtAddress.Text.Trim();
                int age;

                if (int.TryParse(txtAge.Text.Trim(), out age))
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Students SET StudentName=@Name, StudentAddress=@Address, StudentAge=@Age WHERE StudentID=@StudentID", con))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", studentID);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Address", address);
                            cmd.Parameters.AddWithValue("@Age", age);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    GridView1.EditIndex = -1;
                    BindGridView();
                }
                else
                {
                    lblMessage.Text = "Please enter a valid age.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE StudentID=@StudentID", con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            BindGridView();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string address = txtAddress.Text.Trim();
            int mob;
            int age;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || !int.TryParse(txtage.Text.Trim(), out age) || !int.TryParse(txtmob.Text.Trim(),out mob))
            {
                lblMessage.Text = "Please fill out all fields correctly.";
                return;
            }
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                using(SqlCommand cd=new SqlCommand("INSERT INTO Students(StudentName,StudentAddress,StudentMob,StudentAge)VALUES(@Name,@Address,@Mob,@Age)",con))
                {
                    cd.Parameters.AddWithValue("@Name", name);
                    cd.Parameters.AddWithValue("@Address", address);
                    cd.Parameters.AddWithValue("@Mob", mob);
                    cd.Parameters.AddWithValue("@Age", age);
                    con.Open();
                    cd.ExecuteNonQuery ();
                    con.Close();
                }
                txtname.Text ="";
                txtAddress.Text = "";
                txtmob.Text = "";
                txtage.Text = "";
            }
            BindGridView ();


        }
    }
}