using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace schedule_Project
{
    public partial class Calendar : Form
    {
        // LoginUser에게 받은 값
        private string useridFromLoginUser;
        private string userNameFromLoginUser;

        // 자식 창에서 부모 창으로 전달할 데이터를 저장할 프로퍼티
        public string userId { get; set; }
        public string userName { get; set; }

        // DB관련 사전 초기화
        OracleConnection conn;
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDBConnection"].ConnectionString;

        //타이머
        private System.Windows.Forms.Timer timer;
        private Timer resetTimer;


        // 인스턴스
        int time = 0;
        string hours;
        string minutes;

        public Calendar(string userid_Loginuser, string username_Loginuser)
        {
            InitializeComponent();

            // 타이머 설정
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1초마다 실행
            timer.Tick += Timer_Tick;
            timer.Start();

            // 초기 선택 범위 지정 (오늘 ~ 2일후)
            monthCalendar.SelectionStart = DateTime.Now;
            monthCalendar.SelectionEnd = DateTime.Now.AddDays(2);

            // MaxSelectionCount 디폴트 값은 7일            
            monthCalendar.MaxSelectionCount = 31;

            // Loginuser에게 받은 값 저장.

            userId = userid_Loginuser;
            userName = username_Loginuser;

            txtHiddenId.Text = userId;
            txtHiddenName.Text = userName;
        }

        // 시간설정 사용 클릭시 텍스트 박스 enable
        private void checkBoxTimeSet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTimeSet.Checked)
            {
                txtTimeSet.Enabled = checkBoxTimeSet.Checked;
                txtTimeSet.BackColor = Color.White;
            }
            else
            {
                txtTimeSet.Enabled = checkBoxTimeSet.Checked;
                txtTimeSet.Text = "체크 한 뒤 시간을 선택하세요.";
                txtTimeSet.BackColor = SystemColors.Control;
            }
        }

        // 캘린더에 일정선택시 텍스트박스에 입력됨
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

            if (monthCalendar.SelectionRange.Start == monthCalendar.SelectionRange.End)
            {
                txtDate.Text = monthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd");
            }
            else
            {
                txtDate.Text = monthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd") + "~" + monthCalendar.SelectionRange.End.ToString("yyyy-MM-dd");
            }
        }

        //timepicker에 시간선택하면 시간에 들어간다.
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (txtTimeSet.Enabled)
            {
                txtTimeSet.Text = dateTimePicker.Value.ToString("tt hh:mm");
            }
        }


        // DB에 일정 insert 하는 메소드
        private void btnSave_Click(object sender, EventArgs e)
        {

            // 하루만 일정이 있으면 시작일 = 끝일, 시작일과 끝일이 존재하면 값을 따로 넣어준다.
            string[] arr_Date = txtDate.Text.Split('~');
            string str_startDate;
            string str_endDate;
            if (arr_Date.Length == 1)
            {
                str_startDate = arr_Date[0];                                                        // 시작일
                str_endDate = str_startDate;                                                        // 끝일
            }
            else
            {
                str_startDate = arr_Date[0];                                                        // 시작일
                str_endDate = arr_Date[1];                                                          // 끝일
            }

            int alram_status;
            string str_timeSet = txtTimeSet.Text;                                                   // 오전 11:23
            string[] array_timeSet = str_timeSet.Split(' ');                                        // ["오전", "11:23"]
            string str_content = txtContent.Text;                                                   // "일어나기"


            // 알림 추가여부 확인
            if (checkBoxAlram.Checked)
            {
                alram_status = 1;
            }
            else
            {
                alram_status = 0;
            }

            // 시간 24시간 형식으로 바꾸기
            if (checkBoxTimeSet.Checked)
            {
                string[] array_24time = array_timeSet[1].Split(':');                // ["11", "23"]
                int hap;

                if (array_timeSet[0].Equals("오후"))
                {
                    if (Convert.ToInt32(array_24time[0]) <= 11)                     //  오후 12:30 -> 24:30 되는것을 방지
                    {
                        hap = Convert.ToInt32(array_24time[0]) + 12;                    // 23
                        array_24time[0] = Convert.ToString(hap);
                        str_timeSet = String.Join(":", array_24time);
                    }
                    else
                    {
                        str_timeSet = array_timeSet[1];                     //  오후 12:30 -> 12:30 이다.
                    }

                }
                else
                {
                    if (Convert.ToInt32(array_24time[0]) == 12)
                    {
                        array_24time[0] = "00";
                        str_timeSet = String.Join(":", array_24time);
                    }
                    else
                    {
                        str_timeSet = array_timeSet[1];
                    }

                }
            }
            else                           // 체크 한 뒤 시간을 선택하세요. 가 insert 되는 것을 방지.
            {
                str_timeSet = "";
            }

            //내 아이디와 이름 가져오기



            // DB에 INSERT 하기
            try
            {
                using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
                {
                    string sql = " INSERT INTO tbl_Schedule(seq, fk_userid, name, alram_start_date, alram_end_date, alram_time, alram_status, schedule_content) " +
                                 " VALUES(scheduleSeq.nextval, :fk_userid, :name, :alram_start_date, :alram_end_date, :alram_time, :alram_status, :schedule_content) ";

                    OracleCommand cmd = new OracleCommand(sql, conn);

                    OracleParameter paramUserid = new OracleParameter(":fk_userid", OracleDbType.Varchar2, 20);
                    paramUserid.Value = txtHiddenId.Text;

                    OracleParameter paramName = new OracleParameter(":name", OracleDbType.Varchar2, 20);
                    paramName.Value = txtHiddenName.Text;

                    OracleParameter paramAlram_start_date = new OracleParameter(":alram_start_date", OracleDbType.Date);
                    paramAlram_start_date.Value = DateTime.Parse(str_startDate);

                    OracleParameter paramAlram_end_date = new OracleParameter(":alram_end_date", OracleDbType.Date);
                    paramAlram_end_date.Value = DateTime.Parse(str_endDate);

                    OracleParameter paramAlram_time = new OracleParameter(":alram_time", OracleDbType.NVarchar2, 20);
                    paramAlram_time.Value = str_timeSet;

                    OracleParameter paramAlram_status = new OracleParameter(":alram_status", OracleDbType.Int32, 1);
                    paramAlram_status.Value = alram_status;

                    OracleParameter paramSchedule_content = new OracleParameter(":schedule_content", OracleDbType.NVarchar2, 500);
                    paramSchedule_content.Value = str_content;

                    cmd.Parameters.Add(paramUserid);
                    cmd.Parameters.Add(paramName);
                    cmd.Parameters.Add(paramAlram_start_date);
                    cmd.Parameters.Add(paramAlram_end_date);
                    cmd.Parameters.Add(paramAlram_time);
                    cmd.Parameters.Add(paramAlram_status);
                    cmd.Parameters.Add(paramSchedule_content);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("저장 되었습니다.");
                    clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelNowTime.Text = DateTime.Now.ToString();        // 현재시간

            //checkMidnight();                                    // 자정인지 체크하는 메소드로 이동

            // db에 저장되어 있고 알림status가 1이고, 아직 지나지 않은 시간이면
            using (conn = new OracleConnection(connectionString)) // using이 끝나면 close를 자동으로 해준다.
            {
               // conn.Open();

                string sql = " WITH Schedule_CTE AS ( " +
                             "  SELECT " +
                             "      CASE " +
                             "          WHEN TO_CHAR(SYSDATE, 'HH24:MI') = TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'HH24:MI') THEN 'CASE4' " +
                             "          WHEN TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI') < TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') THEN 'CASE1' " +
                             "          WHEN TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI') BETWEEN TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') AND TO_CHAR(TO_DATE(alram_end_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') THEN 'CASE2' " +
                             "          ELSE 'CASE3' " +
                             "      END AS result_case, " +
                             "      TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI') AS nowtime, " +
                             "      TO_CHAR(TO_DATE(alram_start_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') AS statime, " +
                             "      TO_CHAR(TO_DATE(alram_end_date || alram_time, 'YY/MM/DD HH24:MI'), 'YY/MM/DD HH24:MI') AS endtime, " +
                             "      alram_time, alram_start_date, schedule_content, seq " +
                             "  FROM tbl_Schedule " +
                             "  WHERE fk_userid= :fk_userid AND alram_status = 1 AND alram_time IS NOT NULL AND check_status is null " +
                             " ), " +
                             " Minutes_Diff_CTE AS ( " +
                             "   SELECT " +
                             "       CASE " +
                             "          WHEN result_case = 'CASE4' THEN 0 " +
                             "          WHEN result_case = 'CASE1' THEN " +
                             "             CASE " +
                             "                WHEN alram_time > TO_CHAR(SYSDATE, 'HH24:MI') THEN " +
                             "                   (TO_NUMBER(TO_DATE(alram_time, 'HH24:MI') - TO_DATE(TO_CHAR(SYSDATE, 'HH24:MI'), 'HH24:MI')) * 24 * 60) + (TO_NUMBER(TO_DATE(alram_start_date) - TO_DATE(TO_CHAR(SYSDATE, 'YY/MM/DD'))) * 24 * 60) " +
                             "               ELSE " +
                             "                   TO_NUMBER(TO_DATE(alram_time, 'HH24:MI') - TO_DATE(TO_CHAR(SYSDATE, 'HH24:MI'), 'HH24:MI')) * 24 * 60 + (TO_NUMBER(TO_DATE(alram_start_date) - TO_DATE(TO_CHAR(SYSDATE, 'YY/MM/DD'))) * 24 * 60) " +
                             "          END " +
                             "     ELSE " +
                             "        CASE " +
                             "           WHEN alram_time > TO_CHAR(SYSDATE, 'HH24:MI') THEN " +
                             "              TO_NUMBER(TO_DATE(alram_time, 'HH24:MI') - TO_DATE(TO_CHAR(SYSDATE, 'HH24:MI'), 'HH24:MI')) * 24 * 60 " +
                             "         ELSE " +
                             "            (24 * 60) + TO_NUMBER(TO_DATE(alram_time, 'HH24:MI') - TO_DATE(TO_CHAR(SYSDATE, 'HH24:MI'), 'HH24:MI')) * 24 * 60 " +
                             "   END " +
                             "  END AS minutes_diff, nowtime, statime, endtime, alram_time, result_case, schedule_content, seq " +
                             "  FROM Schedule_CTE " +
                             "  WHERE result_case IN ('CASE1', 'CASE2', 'CASE4') " +
                             " ) " +
                             " SELECT " +
                             "    trunc(minutes_diff / 60) AS hours, " +
                             "    round(MOD(minutes_diff, 60)) AS minutes, schedule_content, seq " +
                             " FROM Minutes_Diff_CTE " +
                             " ORDER BY trunc(minutes_diff / 60), round(MOD(minutes_diff, 60)) ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleParameter paramFkUserid = new OracleParameter(":fk_userid", OracleDbType.Varchar2, 20);
                paramFkUserid.Value = txtHiddenId.Text;

                conn.Open();

                cmd.Parameters.Add(paramFkUserid);

                DataTable dt = new DataTable();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dt); // SQL 문장을 실행하고, 결과 데이터를 dt에 채움.

                // 첫 번째 행 값 가져오기
                if (dt.Rows.Count > 0)
                {
                    hours = dt.Rows[0]["hours"].ToString();
                    minutes = dt.Rows[0]["minutes"].ToString();

                    labelLeftTime.Text = "알람까지 " + hours + " 시간 " + minutes + " 분 남았습니다.";

                    textBox1.Text = dt.Rows[0]["seq"].ToString();

                    if (hours.Equals("0") && minutes.Equals("0"))
                    {
                        AlramEvent();           // 알람이 울리는 메소드 호출
                    }
                }
                else
                {
                    labelLeftTime.Text = " 저장된 알람이 없습니다. ";
                }

                // 모든 행을 ListBox에 추가하기
                /*listBox.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string listItem = $"Hours: {row["hours"]}, Minutes: {row["minutes"]}, Content: {row["schedule_content"]}";
                    listBox.Items.Add(listItem);
                }*/


            }
            // 현재시간 - 알람시간 -> 분으로 바꿔 time에 저장하기
            //    time -= 1;
            //if time <= 0
            //time = 0;
            //MessageBox.Show("알람이 울립니다.");

        }

        // 남은시간이 00:00이고, status가 0일때, 알람이 울리는 메소드
        private void AlramEvent()
        {
            if (!StatusIsOne())      // status가 1이면 실행하지 않는다.
            {
                ShowMessageBox();
            }
        }

        // status가 1인지 확인
        private bool StatusIsOne()
        {
            using (conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT check_status FROM TBL_SCHEDULE WHERE seq = :seq";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleParameter paramSeq = new OracleParameter(":seq", OracleDbType.Int32);
                paramSeq.Value = textBox1.Text;

                cmd.Parameters.Add(paramSeq);

                DataTable dt = new DataTable();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dt); // SQL 문장을 실행하고, 결과 데이터를 dt에 채움.

                string status = dt.Rows[0][0].ToString();

                return status.Equals("1");
            }
        }


        // 알람 확인 후 status를 1로 바꿔주는 메소드
        private void UpdateCheckStatus()
        {
            using (conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE TBL_SCHEDULE SET check_status = 1 WHERE seq = :seq";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleParameter paramSeq = new OracleParameter(":seq", OracleDbType.Int32);
                paramSeq.Value = textBox1.Text;

                cmd.Parameters.Add(paramSeq);

                cmd.ExecuteNonQuery();
            }
        }

        // 알람이 울린지 1분이 지나면 status를 null로 바꿔주는 메소드
        private void ResetCheckStatus()
        {
            using (conn = new OracleConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE TBL_SCHEDULE SET check_status = null WHERE seq = :seq";

                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleParameter paramSeq = new OracleParameter(":seq", OracleDbType.Int32);
                paramSeq.Value = textBox1.Text;

                cmd.Parameters.Add(paramSeq);

                cmd.ExecuteNonQuery();
            }
        }

        // 알람 메세지 출력.  확인을 누르면 status가 1로 바뀐다.
        private void ShowMessageBox()
        {
            DialogResult result = MessageBox.Show("알람 메시지", "알람", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK || result == DialogResult.Cancel)
            {
                UpdateCheckStatus();

                timerOneMinuteStart();
            }
        }


        // 알람이 울린지 1분이 지나면 status를 null로 돌려주는 메소드를 호출하는 메소드
        private void timerOneMinuteStart()
        {
            Timer timer = new Timer();
            timer.Interval = 60000;
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                ResetCheckStatus();
                timer.Dispose();
            };
            timer.Start();
        }


        // 하루가 지나는 시점에 status null로 넣기
        /*private void checkMidnight()
        {
            DateTime now = DateTime.Now;                // 2024-07-08 15:32
            DateTime midnight = now.Date.AddDays(1);    // 2024-07-09 00:00

            if (now.Hour == 0 && now.Minute == 0 && now.Second < 60)
            {
                ResetCheckStatus();
            }
        }*/


        // 조회창 열기
        private void BtnGoSearchSchedule_Click(object sender, EventArgs e)
        {
            SearchSchedule searchSchedule = new SearchSchedule(userId, userName);

            if (searchSchedule.ShowDialog() == DialogResult.OK)
            {
                /*// 자식 창에서 데이터를 가져옵니다.
                string result1 = calendar.Result1;
                string result2 = calendar.Result2;

                // 데이터를 표시합니다.
                MessageBox.Show($"Received from Child: {result1}, {result2}");*/
            }

            searchSchedule.Dispose();
        }


        // 텍스트박스 원상태로 돌리기
        private void clear()
        {
            checkBoxAlram.Checked = false;

            checkBoxTimeSet.Checked = false;
            txtTimeSet.Text = "체크 한 뒤 시간을 선택하세요.";

            monthCalendar.SelectionStart = DateTime.Now;
            monthCalendar.SelectionEnd = DateTime.Now.AddDays(2);
            txtDate.Text = monthCalendar.SelectionRange.Start.ToString("yyyy-MM-dd") + "~" + monthCalendar.SelectionRange.End.ToString("yyyy-MM-dd");

            txtContent.Text = "";

            dateTimePicker.Value = DateTime.Now;


        }


        /*
         * 자식 to 부모로 데이터 옮기고 싶을때
         private void btnOK_Click(object sender, EventArgs e)
        {
            // Set the data to be passed to the parent form
            Data1 = txtData1.Text;
            Data2 = txtData2.Text;

            // Set the dialog result to OK to indicate success
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }
         */


    }
}
