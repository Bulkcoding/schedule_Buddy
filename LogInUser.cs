using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using schedule_Project;

namespace schedule_Project
{
    public partial class LogInUser : Form
    {
        OracleConnection conn;
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDBConnection"].ConnectionString;

        public LogInUser()
        {
            InitializeComponent();

            btnAddUser.Click += BtnAddUser_Click;
        }

        private void textBox_id_PressEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_loigin_Click(sender,e);
            }

        }

        private void textBox_pw_PressEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_loigin_Click(sender, e);
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            using(AddUser addUser = new AddUser())
            {
                DialogResult dr =  addUser.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    MessageBox.Show("가입 성공");
                }
                else
                {
                    MessageBox.Show("가입이 취소되었습니다.");
                }
            }
        }

        private void Btn_searchUser_Click(object sender, EventArgs e)
        {

            try
            {
                using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
                {
                    conn.Open();

                    string sql = "SELECT * FROM tbl_User";

                    OracleDataAdapter ad = new OracleDataAdapter(sql, conn); // ad는 c#과 데이터베이스간의 다리역할

                    DataSet ds = new DataSet(); // 데이터베이스에서 검색된 데이터를 저장하는 컨테이너
                    ad.Fill(ds, "tbl_User"); // ds의 객체에 채운다.
                                             // (ds는 데이터를 채울 대상, DataSet 내에 생성될 새로운 테이블이름.임의로 해도 괜찮으나 보통 db테이블 이름과 동일하게 설정)

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button_loigin_Click(object sender, EventArgs e)
        {
            string userId = textBox_id.Text.Trim();
            string pwd = textBox_pw.Text.Trim();

            try
            {
                using (conn = new OracleConnection(connectionString)) 
                {
                    conn.Open();
                    
                    // 보안을 위한 파라미터 바인딩
                    string SQL = " SELECT * " +
                                 " FROM tbl_User " +
                                 " WHERE userid = :userId and pwd = :pwd ";

                    // OracleCommand 생성 및 SQL 문장 할당
                    using (OracleCommand cmd = new OracleCommand(SQL, conn))
                    {
                        // 파라미터 값 설정 (SQL Injection 방지)
                        cmd.Parameters.Add(":userId", OracleDbType.Varchar2, 30).Value = userId;
                        cmd.Parameters.Add(":password", OracleDbType.Varchar2, 30).Value = pwd;

                        // SQL 문장 실행 및 결과 처리
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // 로그인 성공 여부 확인
                            if (reader.Read())
                            {
                                // 로그인 성공 시 처리
                                // MessageBox.Show("로그인 성공!");
                                // (선택 사항) 사용자 정보 처리
                                string userName = reader["name"].ToString(); // 사용자 이름 가져오기

                                MessageBox.Show(userName+" 님 안녕하세요!");

                                using (Calendar calendar = new Calendar(userId,userName))
                                {
                                    if(calendar.ShowDialog() == DialogResult.OK)
                                    {
                                        // 자식창에서 데이터를 가져오고 싶은경우
                                        // string result1 = childForm.Result1;
                                        // string result2 = childForm.Result2;
                                        // MessageBox.Show($"Received from Child: {result1}, {result2}");
                                    }
                                }
                            }
                            else
                            {
                                // 로그인 실패 시 처리
                                MessageBox.Show("로그인 실패! ID 또는 비밀번호를 확인하세요.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}



    
