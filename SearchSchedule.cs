using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schedule_Project
{
    public partial class SearchSchedule : Form
    {

        // LoginUser에게 받은 값
        private string useridFromLoginUser;
        private string userNameFromLoginUser;


        // 재귀 호출 방지용 플래그
        private bool isEditing = false; 

        // 자식 창에서 부모 창으로 전달할 데이터를 저장할 프로퍼티
        public string userId { get; set; }
        public string userName { get; set; }

        // DB관련 사전 초기화
        OracleConnection conn;
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDBConnection"].ConnectionString;
        DataSet ds;

        public SearchSchedule(string userid_Calendar, string username_Calendar)
        {
            InitializeComponent();

            // Calendar에게 받은 값 저장.

            userId = userid_Calendar;
            userName = username_Calendar;

            txtHiddenId.Text = userId;
            txtHiddenName.Text = userName;

            ShowSchedule_Grid();

        }

        private void ShowSchedule_Grid()
        {
            try
            {
                using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
                {
                    conn.Open();

                    string sql = " WITH Schedule_CTE AS ( " +
                                    " SELECT " +
                                        " CASE " +
                                            " WHEN TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI') < TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') THEN 'CASE1' " +
                                            " WHEN TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI') BETWEEN TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') AND TO_CHAR(TO_DATE(alram_end_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') THEN 'CASE2' " +
                                            " ELSE 'CASE3' " +
                                        " END AS result_case, " +
                                        " TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI') AS nowtime, " +
                                        " TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') AS statime, " +
                                        " TO_CHAR(TO_DATE(alram_end_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') AS endtime, " +
                                        " alram_time, alram_start_date, alram_end_date,schedule_content, seq, alram_status " +
                                    " FROM tbl_Schedule " +
                                    " WHERE fk_userid=:fk_userid " +
                                " ) " +
                                " SELECT alram_start_date AS \"시작 날짜\", alram_end_date AS \"마지막 날짜\", alram_time AS \"알람 시간\", schedule_content as \"일정 내용\", seq, alram_status " +
                                " FROM Schedule_CTE " +
                                " WHERE result_case IN ('CASE1', 'CASE2') " +
                                " ORDER BY alram_start_date,alram_time,alram_end_date ";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleParameter paramFkUserid = new OracleParameter(":fk_userid", OracleDbType.Varchar2, 20);
                    paramFkUserid.Value = txtHiddenId.Text;

                    cmd.Parameters.Add(paramFkUserid);


                    OracleDataAdapter ad = new OracleDataAdapter(cmd); // cmd를 사용하여 OracleDataAdapter를 초기화. OracleDataAdapter(sql, conn) 아님
                    ds = new DataSet(); // 데이터베이스에서 검색된 데이터를 저장하는 컨테이너
                    ad.Fill(ds, "search_schedule"); // ds의 객체에 채운다.
                                                    // (ds는 데이터를 채울 대상, DataSet 내에 생성될 새로운 테이블이름.임의로 해도 괜찮으나 보통 db테이블 이름과 동일하게 설정)

                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.Columns["일정 내용"].Width = 300;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1) // 비어있는 행을 클릭하면 '행이 없습니다' 에러 방지
            {
                // 해당 행의 DataRow를 가져오기
                DataRow selectedRow = ds.Tables[0].Rows[e.RowIndex];

                // 컬럼의 값을 텍스트박스에 복사
                txtStartDate.Text = selectedRow[0].ToString().Substring(0, 10);
                txtEndDate.Text = selectedRow[1].ToString().Substring(0,10);
                txtAlramTime.Text = selectedRow[2].ToString();
                txtContent.Text = selectedRow[3].ToString();
                txtHiddenSeq.Text = selectedRow[4].ToString();

                if (selectedRow[5].ToString().Equals("1"))
                {
                    checkAlram.Checked = true;
                }
                else
                {
                    checkAlram.Checked= false;
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
                {
                    string sql = "DELETE FROM TBL_SCHEDULE WHERE seq = :seq";

                    OracleCommand cmd = new OracleCommand(sql, conn);
                    OracleParameter paramSeq = new OracleParameter(":seq", OracleDbType.Int64);
                    paramSeq.Value = txtHiddenSeq.Text;

                    cmd.Parameters.Add(paramSeq);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("삭제되었습니다.");
                    clear();                            // 새로고침

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void clear()
        {
            ShowSchedule_Grid();

            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtAlramTime.Text = "";
            txtContent.Text = "";
            txtHiddenSeq.Text = "";

            checkAlram.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int alram_yn = checkAlram.Checked ? 1 : 0;

            try
            {
                using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
                {
                    if (!checkEmpty())
                    {
                        return;
                    }

                    conn.Open();

                    string sql = " UPDATE TBL_SCHEDULE SET alram_start_date = :alram_start_date, alram_end_date = :alram_end_date, " +
                                 " alram_status = :alram_status ";//, alram_time = :alram_time, schedule_content = :schedule_content ";

                    if (!string.IsNullOrEmpty(txtAlramTime.Text)) {
                        sql += ", alram_time = :alram_time ";
                    } // ORA-00932: 일관성 없는 데이터 유형: NUMBER가 필요하지만 DATE임

                    
                    if (!string.IsNullOrEmpty(txtContent.Text))
                    {
                        sql += ", schedule_content = :schedule_content ";
                    }

                    sql += " WHERE seq = :seq ";

                    MessageBox.Show("3번" + sql);

                    OracleCommand cmd = new OracleCommand(sql, conn);


                    OracleParameter paramAlram_start_date = new OracleParameter(":alram_start_date", OracleDbType.Date);
                    paramAlram_start_date.Value = DateTime.Parse(txtStartDate.Text);
                    
                    OracleParameter paramAlram_end_date = new OracleParameter(":alram_end_date", OracleDbType.Date);
                    paramAlram_end_date.Value = DateTime.Parse(txtEndDate.Text);

                    OracleParameter paramAlram_status = new OracleParameter(":alram_status", OracleDbType.Int32);
                    paramAlram_status.Value = alram_yn;
                   
                    OracleParameter paramSeq = new OracleParameter(":seq", OracleDbType.Int32);
                    paramSeq.Value = Convert.ToInt32(txtHiddenSeq.Text);

                    cmd.Parameters.Add(paramAlram_start_date);
                    cmd.Parameters.Add(paramAlram_end_date);
                    cmd.Parameters.Add(paramAlram_status);


                    if (!string.IsNullOrEmpty(txtAlramTime.Text))
                    {
                        OracleParameter paramAlram_time = new OracleParameter(":alram_time", OracleDbType.NVarchar2);
                        paramAlram_time.Value = txtAlramTime.Text;
                        cmd.Parameters.Add(paramAlram_time);
                    }

                    if (!string.IsNullOrEmpty(txtContent.Text))
                    {
                        OracleParameter paramSchedule_content = new OracleParameter(":schedule_content", OracleDbType.NVarchar2, 500);
                        paramSchedule_content.Value = txtContent.Text;
                        cmd.Parameters.Add(paramSchedule_content);
                    }


                    cmd.Parameters.Add(paramSeq);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("수정되었습니다.");
                    clear();                            // 새로고침

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        // textbox가 무조건 숫자만 받도록 하는 메소드
        private void Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 누른 키가 숫자가 아닌지 확인 ( '-' , ctrl + c,v는 허용)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAlramTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 누른 키가 숫자가 아닌지 확인 ( ':', ctrl + c,v는 허용)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ':' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private bool checkEmpty()
        {
            if(txtStartDate.Text.Equals("") || txtEndDate.Text.Equals(""))
            {
                return false;
            }
            return true;
            
        }
    }
}