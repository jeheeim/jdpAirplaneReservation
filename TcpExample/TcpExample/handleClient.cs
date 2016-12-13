using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace TcpServerExample
{
    internal class handleClient
    {
        // Fields
        private int clientNo;
        private TcpClient clientSocket;
        internal static Dictionary<string, Airplane> dic_airplaneList = new Dictionary<string, Airplane>();
        internal Dictionary<string, AlarmSeat> dic_alarmSeat = new Dictionary<string, AlarmSeat>();
        internal static Dictionary<string, Account> dic_userInfo = new Dictionary<string, Account>();

        // Events
        public delegate void MessageDisplayHandler(string text);
        public delegate void CalculateClientCounter();
        public event CalculateClientCounter OnCalculated;

        public event MessageDisplayHandler OnReceived;
        static handleClient()
        {
            dic_userInfo = new Dictionary<String, Account>();
            dic_airplaneList = new Dictionary<string, Airplane>();
        }
        // Methods
        public handleClient()
        {
            this.makeAccountInfo();
            this.addAirplaneList();
            this.addAlarmSeatList();
        }
        public void startClient(TcpClient ClientSocket, int clientNo)
        {
            this.clientSocket = ClientSocket;
            this.clientNo = clientNo;

            Thread t_hanlder = new Thread(doChat);
            t_hanlder.IsBackground = true;
            t_hanlder.Start();
        }


        private string addAccount(string id, string pw, string name, string email, string interest)
        {
            if (!dic_userInfo.ContainsKey(id))
            {
                Account account = new Account(id, pw, name, email, interest, "NULL", "NULL");
                dic_userInfo.Add(account.id, account);
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&"
                };
                string str = "INSERT INTO account(id, pw, name, email,airplane_id, seat_info, interest) VALUES(@id, @pw, @name, @email, @airplane_id, @seat_info, @interest)";
                MySqlCommand command = new MySqlCommand(str, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@pw", pw);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@airplane_id", "NULL");
                command.Parameters.AddWithValue("@seat_info", "NULL");
                command.Parameters.AddWithValue("@interest", interest);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return "T";
            }
            return "F";
        }
        
        public void makeAccountInfo()
        {
            try
            {
                string id = "";
                string pw = "";
                string name = "";
                string email = "";
                string airplane = "";
                string seats = "";
                string interest = "";
                string str8 = "Server=localhost;Database=airplane;Uid=root;Pwd=gusdh288&;";
                MySqlConnection connection = new MySqlConnection(str8);
                connection.Open();
                string str9 = "select * from account";
                MySqlDataReader reader = new MySqlCommand(str9, connection).ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetString(0);
                    pw = reader.GetString(1);
                    name = reader.GetString(2);
                    email = reader.GetString(3);
                    interest = reader.GetString(6);
                    airplane = reader.GetString(4);
                    seats = reader.GetString(5);
                    Account account = new Account(id, pw, name, email, interest, airplane, seats);
                    if (!dic_userInfo.ContainsKey(id))
                    {
                        dic_userInfo.Add(id, account);
                    }
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }

        

        public void addAirplaneList()
        {
            try
            {
                string str = "Server=localhost;Database=airplane;Uid=root;Pwd=gusdh288&;";
                MySqlConnection connection = new MySqlConnection(str);
                connection.Open();
                string str2 = "select * from airplane";
                MySqlDataReader reader = new MySqlCommand(str2, connection).ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string region = reader.GetString(1);
                    string destCountry = reader.GetString(2);
                    string departApt = reader.GetString(3);
                    string destApt = reader.GetString(4);
                    string date = reader.GetString(5);
                    string time = reader.GetString(6);
                    string s = reader.GetString(7);
                    string seats = reader.GetString(8);
                    Airplane airplane = new Airplane(id, region, destCountry, departApt, destApt, date, time, int.Parse(s), seats);
                    if (!dic_airplaneList.ContainsKey(id))
                    {
                        dic_airplaneList.Add(id, airplane);
                    }
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }

        public void addAlarmSeatList()
        {
            try
            {
                string str = "Server=localhost;Database=airplane;Uid=root;Pwd=gusdh288&;";
                MySqlConnection connection = new MySqlConnection(str);
                connection.Open();
                string str2 = "select * from alarmseat";
                MySqlDataReader reader = new MySqlCommand(str2, connection).ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string str4 = reader.GetString(1);
                    string str5 = reader.GetString(2);
                    string check = reader.GetString(3);
                    AlarmSeat seat = new AlarmSeat(id, str4, str5, check);
                    this.dic_alarmSeat.Add(id, seat);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }

        private string alarm(string id, string airplane_id, string seat)
        {
            string[] strArray2;
            MySqlCommand command;
            string[] strArray = seat.Split(new char[] { ',' });
            string str = "";
            foreach (string str2 in strArray)
            {
                foreach (KeyValuePair<string, AlarmSeat> pair in this.dic_alarmSeat)
                {
                    if (pair.Value.containsSeat(str2))
                    {
                        str = str + str2 + ",";
                    }
                }
            }
            if (str != "")
            {
                return str.Substring(0, str.Length - 1);
            }
            if (!this.dic_alarmSeat.ContainsKey(id))
            {
                this.dic_alarmSeat.Add(id, new AlarmSeat(id, airplane_id, seat, ""));
                try
                {
                    MySqlConnection connection = new MySqlConnection
                    {
                        ConnectionString = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&"
                    };
                    string str3 = "INSERT INTO alarmseat(id, airplane_id, seat, checks) VALUES(@id, @airplane_id, @seat, @checks)";
                    strArray2 = this.dic_alarmSeat[id].ToString().Split(new char[] { ' ' });
                    MessageBox.Show(this.dic_alarmSeat[id].ToString());
                    command = new MySqlCommand(str3, connection);
                    command.Parameters.AddWithValue("@id", strArray2[0]);
                    command.Parameters.AddWithValue("@airplane_id", strArray2[1]);
                    command.Parameters.AddWithValue("@seat", strArray2[2]);
                    command.Parameters.AddWithValue("@checks", strArray2[3]);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (MySqlException exception1)
                {
                    MessageBox.Show(exception1.ToString());
                }
                return "T";
            }
            this.dic_alarmSeat[id].addToAlarmSeats(airplane_id, seat, "");
            strArray2 = this.dic_alarmSeat[id].ToString().Split(new char[] { ' ' });
            try
            {
                string str4 = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                using (MySqlConnection connection2 = new MySqlConnection(str4))
                {
                    connection2.Open();
                    using (command = new MySqlCommand("UPDATE alarmseat SET airplane_id=@airplane_id, seat=@seat, checks=@checks WHERE id=@id", connection2))
                    {
                        command.Parameters.AddWithValue("@id", strArray2[0]);
                        command.Parameters.AddWithValue("@airplane_id", strArray2[1]);
                        command.Parameters.AddWithValue("@seat", strArray2[2]);
                        command.Parameters.AddWithValue("@checks", strArray2[3]);
                        int num = command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException exception2)
            {
                MySqlException exception = exception2;
            }
            return "T";
        }

        private string cancel(string id, string airplane_id, string seat)
        {
            if (dic_userInfo[id].BookedSeats[airplane_id].Contains(seat))
            {
                string str;
                MySqlConnection connection;
                MySqlCommand command;
                int num;
                MySqlException exception;
                Exception exception2;
                dic_airplaneList[airplane_id].Seats[seat] = false;
                dic_userInfo[id].BookedSeats[airplane_id].Remove(seat);
                if (dic_userInfo[id].BookedSeats[airplane_id].Count == 0)
                {
                    dic_userInfo[id].BookedSeats.Remove(airplane_id);
                }
                foreach (KeyValuePair<string, AlarmSeat> pair in this.dic_alarmSeat)
                {
                    if (pair.Value.containsSeat(seat))
                    {
                        pair.Value.alarmSeats[airplane_id][seat] = "1";
                        string[] strArray = pair.Value.ToString().Split(new char[] { ' ' });
                        try
                        {
                            str = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                            using (connection = new MySqlConnection(str))
                            {
                                connection.Open();
                                using (command = new MySqlCommand("UPDATE alarmseat SET airplane_id=@airplane_id, seat=@seat, checks=@checks WHERE id=@id", connection))
                                {
                                    command.Parameters.AddWithValue("@id", strArray[0]);
                                    command.Parameters.AddWithValue("@airplane_id", strArray[1]);
                                    command.Parameters.AddWithValue("@seat", strArray[2]);
                                    command.Parameters.AddWithValue("@checks", strArray[3]);
                                    num = command.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (MySqlException exception1)
                        {
                            exception = exception1;
                            MessageBox.Show(exception.ToString());
                        }
                        catch (Exception exception3)
                        {
                            exception2 = exception3;
                            MessageBox.Show(exception2.ToString());
                        }
                    }
                }
                string[] strArray2 = dic_userInfo[id].ToString().Split(new char[] { ' ' });
                try
                {
                    str = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (connection = new MySqlConnection(str))
                    {
                        connection.Open();
                        using (command = new MySqlCommand("UPDATE account SET airplane_id=@airplane_id, seat_info=@seat_info WHERE id=@id", connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@airplane_id", strArray2[5]);
                            command.Parameters.AddWithValue("@seat_info", strArray2[6]);
                            num = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException exception4)
                {
                    exception = exception4;
                    MessageBox.Show(exception.ToString());
                }
                catch (Exception exception5)
                {
                    exception2 = exception5;
                    MessageBox.Show(exception2.ToString());
                }
                try
                {
                    str = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (connection = new MySqlConnection(str))
                    {
                        connection.Open();
                        using (command = new MySqlCommand("UPDATE airplane SET seat_info=@seat_info WHERE airplane_id=@airplane_id", connection))
                        {
                            command.Parameters.AddWithValue("@airplane_id", airplane_id);
                            command.Parameters.AddWithValue("@seat_info", dic_airplaneList[airplane_id].ConvertSeatInDBForm());
                            num = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException exception6)
                {
                    MessageBox.Show(exception6.ToString());
                }
                catch (Exception exception7)
                {
                    MessageBox.Show(exception7.ToString());
                }
                return "T";
            }
            return "F";
        }

        private string cancelAlarm(string id, string airplane_id, string seat)
        {
            string str2;
            MySqlConnection connection;
            MySqlCommand command;
            int num2;
            string[] strArray = airplane_id.Split(new char[] { ',' });
            string[] strArray2 = seat.Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray3 = strArray2[i].Split(new char[] { ',' });
                foreach (string str in strArray3)
                {
                    if (this.dic_alarmSeat.ContainsKey(id))
                    {
                        this.dic_alarmSeat[id].cancelSeat(strArray[i], str);
                    }
                }
                if (this.dic_alarmSeat[id].alarmSeats[strArray[i]].Count == 0)
                {
                    this.dic_alarmSeat[id].alarmSeats.Remove(strArray[i]);
                }
            }
            if (this.dic_alarmSeat[id].alarmSeats.Count == 0)
            {
                this.dic_alarmSeat.Remove(id);
                try
                {
                    str2 = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (connection = new MySqlConnection(str2))
                    {
                        connection.Open();
                        using (command = new MySqlCommand("DELETE FROM alarmseat WHERE id=@id", connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            num2 = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException exception1)
                {
                    MySqlException exception = exception1;
                    MessageBox.Show(exception.ToString());
                }
                catch (Exception exception3)
                {
                    Exception exception2 = exception3;
                    MessageBox.Show(exception2.ToString());
                }
            }
            else
            {
                string[] strArray4 = this.dic_alarmSeat[id].ToString().Split(new char[] { ' ' });
                try
                {
                    str2 = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (connection = new MySqlConnection(str2))
                    {
                        connection.Open();
                        using (command = new MySqlCommand("UPDATE alarmseat SET airplane_id=@airplane_id, seat=@seat, checks=@checks WHERE id=@id", connection))
                        {
                            command.Parameters.AddWithValue("@id", strArray4[0]);
                            command.Parameters.AddWithValue("@airplane_id", strArray4[1]);
                            command.Parameters.AddWithValue("@seat", strArray4[2]);
                            command.Parameters.AddWithValue("@checks", strArray4[3]);
                            num2 = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException exception4)
                {
                    MessageBox.Show(exception4.ToString());
                }
                catch (Exception exception5)
                {
                    MessageBox.Show(exception5.ToString());
                }
            }
            return "T";
        }

        private string delAirplane(string id)
        {
            if (dic_airplaneList.ContainsKey(id))
            {
                dic_airplaneList.Remove(id);
                try
                {
                    string str = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (MySqlConnection connection = new MySqlConnection(str))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand("DELETE FROM airplane WHERE airplane_id=@airplane_id", connection))
                        {
                            command.Parameters.AddWithValue("@airplane_id", id);
                            int num = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException exception)
                {
                    MessageBox.Show(exception.ToString());
                }
                return "T";
            }
            return "F";
        }

        private string deleteAccount(string delId)
        {
            if (dic_userInfo.ContainsKey(delId))
            {
                dic_userInfo.Remove(delId);
                try
                {
                    string str = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (MySqlConnection connection = new MySqlConnection(str))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand("DELETE FROM account WHERE id=@id", connection))
                        {
                            command.Parameters.AddWithValue("@id", delId);
                            int num = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException)
                {
                }
                return "T";
            }
            return "F";
        }

        private void doChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[] buffer = new byte[1024];
                string msg = string.Empty;
                int bytes = 0;
                int MessageCount = 0;

                while (true)
                {
                    MessageCount++;
                    stream = clientSocket.GetStream();
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    msg = Encoding.Unicode.GetString(buffer, 0, bytes);
                    msg = msg.Substring(0, msg.IndexOf("!"));
                    string[] msgArr = msg.Split('$');
                    if (msg.Equals("LOAD"))
                    {
                        msg = sendAirplaneList();
                    }
                    else if (msgArr[0].Equals("CHKID"))
                    {
                        if (dic_userInfo.ContainsKey(msgArr[1]))
                            msg = "T";
                        else
                            msg = "F";
                    }
                    else if (msgArr[0].Equals("DELACC"))
                    {
                        msg = deleteAccount(msgArr[1]);
                    }
                    else if (msgArr[0].Equals("CANAL"))
                    {
                        msg = cancelAlarm(msgArr[1], msgArr[2], msgArr[3]);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("RES"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string airplane_id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seat = msg;
                        msg = reserve(id, airplane_id, seat);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("NACC"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string pw = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string name = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string email = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string interest = msg;
                        msg = addAccount(id, pw, name, email, interest);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("CANS"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string airplane_id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seat = msg;
                        msg = cancel(id, airplane_id, seat);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("MODA"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string pw = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string name = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string email = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string interest = msg;
                        msg = modifyAccount(id, pw, name, email, interest);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("LOGIN"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string pw = msg;
                        msg = login(id, pw);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("FINDID"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string name = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string email = msg;
                        msg = findid(name, email);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("FINDPW"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string name = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string email = msg;
                        msg = findpw(id, name, email);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("ALAS"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string airplane_id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seat = msg;
                        msg = alarm(id, airplane_id, seat);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("LOGINADMIN"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string pw = msg;
                        msg = loginAdmin(id, pw);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("ADDAIR"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string airplane_id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string region = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string country = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string a_port = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string d_port = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string date = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string time = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string cost = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seat = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seats = msg;
                        msg=addAirplane(airplane_id, region, country, d_port, a_port, date, time, int.Parse(cost), seats);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("DELAIR"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string airplane_id = msg;
                        msg = delAirplane(airplane_id);
                    }
                    else if (msg.Substring(0, msg.IndexOf("$")).Equals("MODAIR"))
                    {
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string airplane_id = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string region = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string country = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string a_port = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string d_port = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string date = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string time = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string cost = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seat = msg.Substring(0, msg.IndexOf("$"));
                        msg = msg.Substring(msg.IndexOf("$") + 1);
                        string seats = msg;
                        msg = modAirplane(airplane_id, region, country, d_port, a_port, date, time, int.Parse(cost), seats);
                    }


                    byte[] sbuffer = Encoding.Unicode.GetBytes(msg);
                    stream.Write(sbuffer, 0, sbuffer.Length);
                    stream.Flush();

                    if (OnReceived != null)
                    {
                        OnReceived(msg);
                        OnReceived("");
                    }
                }
            }
            catch (SocketException se)
            {
                Trace.WriteLine(string.Format("doChat - SocketException : {0}", se.Message));

                if (clientSocket != null)
                {
                    clientSocket.Close();
                    stream.Close();
                }

                if (OnCalculated != null)
                    OnCalculated();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("doChat - Exception : {0}", ex.Message));

                if (clientSocket != null)
                {
                    clientSocket.Close();
                    stream.Close();
                }

                if (OnCalculated != null)
                    OnCalculated();
            }
        }


        private string findid(string name, string email)
        {
            foreach (KeyValuePair<string, Account> pair in dic_userInfo)
            {
                if (pair.Value.name.Equals(name) && pair.Value.email.Equals(email))
                {
                    return pair.Key;
                }
            }
            return "F";
        }

        private string findpw(string id, string name, string email)
        {
            foreach (KeyValuePair<string, Account> pair in dic_userInfo)
            {
                if ((pair.Value.name.Equals(id) && pair.Value.name.Equals(name)) && pair.Value.email.Equals(email))
                {
                    return "T";
                }
            }
            return "F";
        }

        private string login(string id, string pw)
        {
            if (dic_userInfo.ContainsKey(id) && dic_userInfo[id].pw.Equals(pw))
            {
                string text = "";
                if (this.dic_alarmSeat.ContainsKey(id))
                {
                    text = this.dic_alarmSeat[id].alarmServiceOkSeat();
                }
                MessageBox.Show(dic_userInfo[id].ToString());
                MessageBox.Show(text);
                return (dic_userInfo[id].ToString() + "$" + text);
            }
            return "F";
        }

        private string loginAdmin(string id, string pw)
        {
            string str = null;
            string str2 = null;
            try
            {
                string str3 = "Server=localhost;Database=airplane;Uid=root;Pwd=gusdh288&;";
                MySqlConnection connection = new MySqlConnection(str3);
                connection.Open();
                string str4 = "select * from manager_ac";
                MySqlDataReader reader = new MySqlCommand(str4, connection).ExecuteReader();
                while (reader.Read())
                {
                    str = reader.GetString(0);
                    str2 = reader.GetString(1);
                    
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            if (id.Equals(str) && pw.Equals(str2))
            {
                return "T";
            }
            else
            {
                return "F";
            }
        }



        private string sendAirplaneList()
        {
            string str = null;
            try
            {
                string str2 = "Server=localhost;Database=airplane;Uid=root;Pwd=gusdh288&;";
                MySqlConnection connection = new MySqlConnection(str2);
                connection.Open();
                string str3 = "select * from airplane";
                MySqlDataReader reader = new MySqlCommand(str3, connection).ExecuteReader();
                while (reader.Read())
                {
                    string str4 = reader.GetString(0);
                    string str5 = reader.GetString(1);
                    string str6 = reader.GetString(2);
                    string str7 = reader.GetString(3);
                    string str8 = reader.GetString(4);
                    string str9 = reader.GetString(5);
                    string str10 = reader.GetString(6);
                    string str11 = reader.GetString(7);
                    string str12 = reader.GetString(8);
                    string str14 = str;
                    str = str14 + str4 + " " + str5 + " " + str6 + " " + str7 + " " + str8 + " " + str9 + " " + str10 + " " + str11 + " " + str12 + "$";
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
            return (str + "!");
        }
        private string reserve(string id, string airplane_id, string seat)
        {
            string str3;
            MySqlConnection connection;
            MySqlCommand command;
            int num2;
            MySqlException exception;
            string[] strArray = airplane_id.Split(new char[] { ',' });
            string[] strArray2 = seat.Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray3 = strArray2[i].Split(new char[] { ',' });
                string str = "";
                foreach (string str2 in strArray3)
                {
                    if (dic_airplaneList[strArray[i]].Seats[str2])
                    {
                        string str5 = str;
                        str = str5 + strArray[i] + "의" + str2 + ",";
                    }
                }
                if (str != "")
                {
                    return str.Substring(0, str.Length - 1);
                }
                foreach (string str2 in strArray3)
                {
                    dic_airplaneList[strArray[i]].Seats[str2] = true;
                    if (!dic_userInfo[id].BookedSeats.ContainsKey(strArray[i]))
                    {
                        List<string> list = new List<string>();
                        dic_userInfo[id].BookedSeats.Add(strArray[i], list);
                        dic_userInfo[id].BookedSeats[strArray[i]].Add(str2);
                    }
                    else
                    {
                        dic_userInfo[id].BookedSeats[strArray[i]].Add(str2);
                    }
                }
            }
            string[] strArray4 = dic_userInfo[id].ToString().Split(new char[] { ' ' });
            try
            {
                str3 = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                using (connection = new MySqlConnection(str3))
                {
                    connection.Open();
                    using (command = new MySqlCommand("UPDATE account SET airplane_id=@airplane_id, seat_info=@seat_info WHERE id=@id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@airplane_id", strArray4[5]);
                        command.Parameters.AddWithValue("@seat_info", strArray4[6]);
                        num2 = command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException exception1)
            {
                exception = exception1;
            }
            try
            {
                str3 = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                using (connection = new MySqlConnection(str3))
                {
                    connection.Open();
                    using (command = new MySqlCommand("UPDATE airplane SET seat_info=@seat_info WHERE airplane_id=@airplane_id", connection))
                    {
                        command.Parameters.AddWithValue("@airplane_id", airplane_id);
                        command.Parameters.AddWithValue("@seat_info", dic_airplaneList[airplane_id].ConvertSeatInDBForm());
                        num2 = command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException exception2)
            {
                exception = exception2;
            }
            return "T";
        }

        private string modifyAccount(string id, string pw, string name, string email, string interest)
        {
            if (dic_userInfo.ContainsKey(id))
            {
                dic_userInfo[id].pw = pw;
                dic_userInfo[id].name = name;
                dic_userInfo[id].email = email;
                dic_userInfo[id].interest = interest;
                try
                {
                    string str = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (MySqlConnection connection = new MySqlConnection(str))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand("UPDATE account SET pw=@pw, name=@name, email=@email, interest=@interest WHERE id=@id", connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@pw", pw);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@interest", interest);
                            int num = command.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException)
                {
                }
                return "T";
            }
            return "F";
        }

        private string addAirplane(string id, string region, string destCountry, string departApt, string destApt, string date, string time, int cost, string seats)
        {
            if (!dic_airplaneList.ContainsKey(id))
            {
                Airplane airplane = new Airplane(id, region, destCountry, departApt, destApt, date, time, cost, seats);
                dic_airplaneList.Add(id, airplane);
                try
                {
                    MySqlConnection connection = new MySqlConnection
                    {
                        ConnectionString = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&"
                    };
                    string str = "INSERT INTO airplane(airplane_id, region, country, d_airport,a_airport, date, time, cost, seat_info) VALUES(@airplane_id, @region, @country, @d_airport,@a_airport, @date, @time, @cost, @seat_info)";
                    MySqlCommand command = new MySqlCommand(str, connection);
                    command.Parameters.AddWithValue("@airplane_id", id);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@country", destCountry);
                    command.Parameters.AddWithValue("@d_airport", departApt);
                    command.Parameters.AddWithValue("@a_airport", destApt);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@cost", cost);
                    command.Parameters.AddWithValue("@seat_info", seats);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
                return "T";
            }
            return "F";
        }

        private string modAirplane(string id, string region, string destCountry, string departApt, string destApt, string date, string time, int cost, string seats)
        {
            if (dic_airplaneList.ContainsKey(id))
            {
                try
                {
                    string connectionString = "Server=localhost;database=airplane;uid=root;pwd=gusdh288&";
                    using (MySqlConnection conn =
                        new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd =
                            new MySqlCommand("UPDATE airplane SET region=@region, country=@country, d_airport=@d_airport, a_airport=@a_airport, date=@date, time=@time, cost=@cost, seat_info=@seat_info" +
                                " WHERE airplane_id=@airplane_id", conn))
                        {
                            cmd.Parameters.AddWithValue("@airplane_id", id);
                            cmd.Parameters.AddWithValue("@region", region);
                            cmd.Parameters.AddWithValue("@country", destCountry);
                            cmd.Parameters.AddWithValue("@d_airport", departApt);
                            cmd.Parameters.AddWithValue("@a_airport", destApt);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@time", time);
                            cmd.Parameters.AddWithValue("@cost", cost);
                            cmd.Parameters.AddWithValue("@seat_info", seats);

                            int rows = cmd.ExecuteNonQuery();

                            //rows number of record got updated
                        }
                    }

                }

                catch (MySqlException ex)
                {
                    //Log exception
                    //Display Error message
                }
                return "T";
            }
            else
            {
                return "F";
            }
        }


    }
}