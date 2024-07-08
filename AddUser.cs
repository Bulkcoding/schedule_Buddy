using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace schedule_Project
{
    public partial class AddUser : Form
    {
        OracleConnection conn;

        // app.config에 있는 DB 정보와 연결
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDBConnection"].ConnectionString;

        bool idDBCheck = false;                 // 아이디 중복체크 boolean
        bool birthDateCheck = false;                 // 생년월일 형식체크 boolean

        public AddUser()
        {
            InitializeComponent();

            //btnOk.Click += BtnOk_Click;
            //btnCancel.Click += BtnCancel_Click; // 버튼을 클릭하면 해당 메소드로 이동 
        }

/*        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }*/

        // 회원가입 인증요청 클릭시
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            int checkEmpty = 0;             // 비워져 있는 칸이 없는지 유무
            int checkid = 0;                // 아이디 중복체크 유무
            int checkMobile = 0;            // 전화번호 중복 유무

            // bool 


            // 1. 빈 곳을 전부 채웠는지 알아본다.
            if (!CheckIsEmpty())
            {
                MessageBox.Show("빈 곳을 전부 채워주세요.");
            }
            else
            {
                checkEmpty = 1;

                // 2. 아이디 중복
                if (!idDBCheck)
                {
                    MessageBox.Show("아이디 중복체크를 하세요.");
                }
                else
                {
                    checkid = 1;
                }

                // 3. 휴대전화번호가 중복되는지 알아본다.
                if (!CheckMobile())
                {
                    MessageBox.Show("휴대전화번호가 이미 존재합니다.");
                }
                else
                {
                    // 전화번호 타입이 맞는지 확인
                    if (textMobile.Text.StartsWith("010") && textMobile.Text.Length == 11)
                    {
                        checkMobile = 1;
                    }
                    else
                    {
                       MessageBox.Show("휴대전화번호를 제대로 입력하세요.");
                    }
                }

            }

            // 4. 인증 요청한다.
            if(checkEmpty * checkid * checkMobile == 1)
            {
                UserDBInsert();         // DB insert 메소드
            }
        }

        // 비워져 있는 칸 확인 메소드
        private bool CheckIsEmpty()
        {
            bool allClear = true;

            string add_userid = textID.Text.Trim();
            string add_pwd = textPwd.Text.Trim();
            string add_name = textName.Text.Trim();
            string add_birth = textBirthday.Text.Trim();
            string add_mobile = textMobile.Text.Trim();
            bool radio_man = radioMan.Checked;
            bool radio_woman = radioWoman.Checked;

            if (add_userid.Equals("")) allClear = false;
            if (add_pwd.Equals("")) allClear = false;
            if (add_name.Equals("")) allClear = false;
            if (add_birth.Equals("")) allClear = false;
            if (add_mobile.Equals("")) allClear = false;
            if (!radio_man && !radio_woman) allClear = false;

            if (allClear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 아이디 중복체크 메소드
        private void BtnIdCheck_Click_1(object sender, EventArgs e)
        {
            using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
            {
                conn.Open();

                string sql = " SELECT count(1) " +
                             " FROM tbl_User " +
                             " WHERE userid = :userid ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleParameter paramUserid = new OracleParameter(":userid", OracleDbType.Varchar2, 40);
                paramUserid.Value = textID.Text;

                cmd.Parameters.Add(paramUserid);
                
                DataTable dt = new DataTable();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dt);

                int count = Convert.ToInt32(dt.Rows[0][0]);

                CheckUseridOk(count);
            }
        }

        // count 값을 받아와서 메세지 처리 + 중복체크버튼 바꾸기 메소드로 이동
        private void CheckUseridOk(int count)
        {
            if(count == 1)
            {
                MessageBox.Show("이미 존재하는 아이디입니다.");
            }
            else
            {
                if (textID.Text.Length <= 4)
                {
                    MessageBox.Show("아이디는 5글자 이상 적어주세요.");
                }
                else
                {
                    MessageBox.Show("사용 가능한 아이디 입니다.");
                    CheckedUserId();
                }
            }
        }

        //  생년월일 자리수 체크
        private void CheckBirthDate(object sender, EventArgs e)
        {
            string add_birthStr = textBirthday.Text.Trim();

            if (add_birthStr.Length == 8)
            {
                birthDateCheck = true;
            }
            else
            {
                MessageBox.Show("생년월일을 8자리로 입력해주세요.");
                textBirthday.Focus();
            }
        }



        // 중복체크버튼 바꾸기 메소드
        private void CheckedUserId()
        {
            idDBCheck = true;
            BtnIdCheck.Text = "사용가능";
            BtnIdCheck.BackColor = Color.LightGreen;
        }

        // 중복체크 한 상태에서 건드리면 다시 원상태로 되돌리는 메소드
        private void textID_KeyDown(object sender, KeyEventArgs e)
        {
            idDBCheck = false;
            BtnIdCheck.Text = "아이디 중복체크";
            BtnIdCheck.BackColor = Color.White;
        }

        // 전화번호 textbox가 무조건 숫자만 받도록 하는 메소드
        private void txtOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 누른 키가 숫자가 아닌지 확인 ( ctrl + c,v는 허용)
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 전화번호 중복체크 메소드
        private bool CheckMobile()
        {
            using(conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = " SELECT count(1) " +
                             " FROM tbl_User " +
                             " WHERE mobile = :mobile ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleParameter paramMobile = new OracleParameter(":mobile", OracleDbType.Varchar2, 11);
                paramMobile.Value = textMobile.Text;

                cmd.Parameters.Add(paramMobile);

                DataTable dt = new DataTable();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dt); // SQL 문장을 실행하고, 결과 데이터를 dt에 채움.

                if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // DB insert 메소드
        private void UserDBInsert()
        {
            string add_userid = textID.Text.Trim();
            string add_pwd = textPwd.Text.Trim();
            string add_name = textName.Text.Trim();
            string add_birthStr = textBirthday.Text.Trim();
            string add_mobile = textMobile.Text.Trim();
            bool radio_man = radioMan.Checked;
            bool radio_woman = radioWoman.Checked;
            int radio_result = 0;

            // DateTime 개체로 변환
            DateTime birthDate;

            try
            {
                 birthDate = DateTime.ParseExact(add_birthStr, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Invalid birthdate format: " + ex.Message);
                return;
            }

            string add_birth = birthDate.ToString("yyyy-MM-dd");

            using (conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = " INSERT INTO tbl_User(userid, pwd, name, gender, birthday, mobile) " +
                             " VALUES(:userid, :pwd, :name, :gender, :birthday, :mobile) ";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleParameter paramUserid = new OracleParameter(":userid", OracleDbType.Varchar2, 40);
                paramUserid.Value = add_userid;

                OracleParameter paramPwd = new OracleParameter(":pwd", OracleDbType.Varchar2, 200);
                paramPwd.Value = add_pwd;

                OracleParameter paramName = new OracleParameter(":name", OracleDbType.Varchar2, 30);
                paramName.Value = add_name;

                OracleParameter paramGender = new OracleParameter(":gender", OracleDbType.Varchar2, 1);

                if (radio_man)
                {
                    radio_result = 1;
                }
                else if (radio_woman)
                {
                    radio_result = 2;
                }

                paramGender.Value = radio_result;

                OracleParameter paramBirthday = new OracleParameter(":birthday", OracleDbType.Varchar2, 10);
                paramBirthday.Value = add_birth;

                OracleParameter paramMobile = new OracleParameter(":mobile", OracleDbType.Varchar2, 11);
                paramMobile.Value = add_mobile;


                cmd.Parameters.Add(paramUserid);
                cmd.Parameters.Add(paramPwd);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramGender);
                cmd.Parameters.Add(paramBirthday);
                cmd.Parameters.Add(paramMobile);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("회원가입을 축하합니다!");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
