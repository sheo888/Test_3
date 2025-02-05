﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int captchaCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        Bas bas = new Bas();
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {

            if (Login_Input.Text != "" && Password_Input.Password != "")
            {
                string pass = "", role = "" , status = "";
                if (captchaCount <= 3)
                {
                    MySqlCommand Cmd = new MySqlCommand(bas.log + "'" + Login_Input.Text.ToLower() + "';", Bas.Connect);
                    try
                    {
                        Bas.Connect.Open();
                        MySqlDataReader Data = Cmd.ExecuteReader();
                        if (Data.Read())
                        {
                            role = Data[3].ToString();
                            pass = Data[2].ToString();
                            status = Data[4].ToString();
                            Bas.Connect.Close();
                            Bas.Connect.Open();
                            MySqlCommand cmd = new MySqlCommand(bas.rol + "'" + role + "';", Bas.Connect);
                            MySqlDataReader Date = cmd.ExecuteReader();
                            Date.Read();
                            role = Date[2].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Пользователя с таким логином не существует!");
                        }
                    }
                    catch (Exception ex)
                    {
                        //throw;
                        MessageBox.Show("Ошибка подключения к Базе Данных!" + ex.ToString());
                    }
                    finally
                    {
                        Bas.Connect.Close();
                    }

                    if (Password_Input.Password.Equals(pass))
                    {
                        switch (role)
                        {
                            case "Admin":
                                {
                                    bas.login = Login_Input.Text;
                                    Admin admin = new Admin();
                                    this.Close();
                                    admin.Show();
                                    break;
                                }
                            case "deleted":
                                {
                                    MessageBox.Show("Этот пользователь удален!");
                                    break;
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("тут будет капча");

                    //    Window6 window6 = new Window6();
                    //    this.Close();
                    //    window6.Show();
                }
                captchaCount++;
            }
            else
            {
                MessageBox.Show("Заполните, пожалуйста, данные!");
            }
        }
    }
}
