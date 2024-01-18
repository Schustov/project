using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using System.Net;

namespace weather
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client;
        private string api = "d397a995d6b587ba479889ad3dc3cf56";
        public string path = @"weather.json";
        public string txtresponse_j = "";
        
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        async void FetchWeatherInfo()
        {
            label2.Text = "Температура: ";
            label3.Text = "Влажность: ";
            label4.Text = "Давление: ";
            label5.Text = "Состояние: ";
            pictureBox1.Image = null;

            string country = textBox1.Text;        
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={country}&units=metric&APPID={api}&lang=ru");
            var txtresponse = await response.Content.ReadAsStringAsync();
            txtresponse_j = PrettyJson(txtresponse);

            if (response.IsSuccessStatusCode)
            {

                this.Text = $"Погода в г. {country}";
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(txtresponse_j);
                Weather weather = JsonConvert.DeserializeObject<Weather>(weatherResponse.Weather[0].ToString());
                if (weatherResponse.Main.Temp > 0) label2.Text = $"Температура: +{weatherResponse.Main.Temp}℃";
                else label2.Text = $"Температура: {weatherResponse.Main.Temp}℃";
                label3.Text = $"Влажность: {weatherResponse.Main.Humidity}%";
                label4.Text = $"Давление: {Math.Round(weatherResponse.Main.Pressure * 0.7500637554192)} мм рт.ст.";
                label5.Text = $"Состояние: {ToUpper(weather.Description)}";


                pictureBox1.Load($"http://openweathermap.org/img/wn/{weather.Icon}@2x.png");
                /*
                switch (weather.Icon) {
                    case "01d":
                        pictureBox1.Image = Properties.Resources._01d_2x; break;
                    case "01n":
                        pictureBox1.Image = Properties.Resources._01n_2x; break;
                    case "02d":
                        pictureBox1.Image = Properties.Resources._02d_2x; break;
                    case "02n":
                        pictureBox1.Image = Properties.Resources._02n_2x; break;
                    case "03d":
                        pictureBox1.Image = Properties.Resources._03d_2x; break;
                    case "03n":
                        pictureBox1.Image = Properties.Resources._03n_2x; break;
                    case "04d":
                        pictureBox1.Image = Properties.Resources._04d_2x; break;
                    case "04n":
                        pictureBox1.Image = Properties.Resources._04n_2x; break;
                    case "09d":
                        pictureBox1.Image = Properties.Resources._09d_2x; break;
                    case "09n":
                        pictureBox1.Image = Properties.Resources._09n_2x; break;
                    case "10d":
                        pictureBox1.Image = Properties.Resources._10d_2x; break;
                    case "10n":
                        pictureBox1.Image = Properties.Resources._10n_2x; break;
                    case "11d":
                        pictureBox1.Image = Properties.Resources._11d_2x; break;
                    case "11n":
                        pictureBox1.Image = Properties.Resources._11n_2x; break;
                    case "13d":
                        pictureBox1.Image = Properties.Resources._13d_2x; break;
                    case "13n":
                        pictureBox1.Image = Properties.Resources._13n_2x; break;
                    case "50d":
                        pictureBox1.Image = Properties.Resources._50d_2x; break;
                    case "50n":
                        pictureBox1.Image = Properties.Resources._50n_2x; break;
                
                }
                */
            }

        }

        private string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
        }
        private string ToUpper(string str)
        {
            return Char.ToUpper(str[0]) + str.Remove(0, 1);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            textBox1.Text = "Санкт-Петербург";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchWeatherInfo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "Вы действительно хотите выйти?", "Закрытие программы",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            var result = MessageBox.Show(this, "Вы хотели бы сохранить изменения?", "Сохранение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) File.WriteAllText(Path.GetFullPath(path), txtresponse_j);
        }
    }
}
