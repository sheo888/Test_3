using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            try
            {
                Bas.Connect.Open();
                string query = "SELECT type, quantity, resistance , accuracy ,power_w ,manufacturer ,description_inf FROM resistor";
                MySqlCommand cmd = new MySqlCommand(query, Bas.Connect);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Spisok_DataGrid.AutoGenerateColumns = true;
                Spisok_DataGrid.ItemsSource = dt.DefaultView;
                //Bas.Connect.Close();

                MySqlDataReader Date = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Bas.Connect.Close();
            }
        }

        private void but_exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Spisok_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void asd_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void select__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bas.Connect.Open();
                string query = w_text.Text;  
                MySqlCommand cmd = new MySqlCommand(query, Bas.Connect);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Spisok_DataGrid.AutoGenerateColumns = true;
                Spisok_DataGrid.ItemsSource = dt.DefaultView;
                //Bas.Connect.Close();

                MySqlDataReader Date = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Bas.Connect.Close();
            }
        }

        private void select_max_Click(object sender, RoutedEventArgs e)
        {
            Load_plus("SELECT max(description_inf) FROM resistor");
        }

        private void select_min_Click(object sender, RoutedEventArgs e)
        {
            Load_plus("SELECT min(description_inf) FROM resistor");
        }

        private void select_mid_Click(object sender, RoutedEventArgs e)
        {
            Load_plus("SELECT mid(description_inf,2,3) FROM resistor");
        }

        private void Load_plus(string query)
        {
            try
            {
                Bas.Connect.Open();
                //string query = "SELECT type, quantity, resistance , accuracy ,power_w ,manufacturer ,description_inf FROM resistor";
                MySqlCommand cmd = new MySqlCommand(query, Bas.Connect);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Spisok_DataGrid.AutoGenerateColumns = true;
                Spisok_DataGrid.ItemsSource = dt.DefaultView;
                //Bas.Connect.Close();

                MySqlDataReader Date = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Bas.Connect.Close();
            }
        }

        private void select_avg_Click(object sender, RoutedEventArgs e)
        {
            Load_plus("SELECT avg(quantity) FROM resistor");
        }

        private void select_sum_Click(object sender, RoutedEventArgs e)
        {
            Load_plus("SELECT sum(quantity) FROM resistor");
        }

        private void butt_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bas.Connect.Open();
                string query = $"INSERT INTO resistor (type, quantity, resistance, accuracy, power_w, manufacturer, description_inf) VALUES ('{ComboBox_Type.Text}', '{Textbox_Quantity.Text}', '{Textbox_Resistance.Text}', '{Combobox_Accuracy.Text.Length - 1}', '{Combobox_Power_w.Text.Length - 1}', '{Texbox_Manufacturer.Text}', '{Texbox_Description_inf.Text}')";
                MySqlCommand cmd = new MySqlCommand(query, Bas.Connect);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Bas.Connect.Close();
            }
        }

        private void delete()
        {
            try
            {
                Bas.Connect.Open();
                string query = $"DELETE FROM `resistor` WHERE `resistor`.`id` = 4 '";
                MySqlCommand cmd = new MySqlCommand(query, Bas.Connect);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Bas.Connect.Close();
            }
        }
    }
}
