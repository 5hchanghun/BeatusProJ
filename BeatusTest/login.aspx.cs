using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace BeatusTest
{

    public partial class login : System.Web.UI.Page
    {
		protected void Login_Click(object sender, EventArgs e)
		{
			//DB 연결
			MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aranea"].ConnectionString);


			con.Open();
			//쿼리문(sql 명령문)
			string sql = "SELECT * FROM account WHERE UserID = @ID and UserPW = @PW";
			MySqlCommand cmd = new MySqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@ID", UserID.Text);
			cmd.Parameters.AddWithValue("@PW", UserPW.Text);

			//cmd.ExecuteScalar는 명령을 실행한 결과값을 반환한다.
			object obj = cmd.ExecuteScalar();
			MySqlDataReader rdr = cmd.ExecuteReader();

			if (obj != null)
			{
				Response.Redirect("/Default");
				con.Close();
			}
			else
			{
				Response.Write("<script>alert('아이디 또는 비밀번호가 올바르지 않습니다.');</script>");
			}
		}

	}
}
