using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace GosFormsApp
{
    public partial class Form1 : Form
    {
        //Ебать, это лист Игр, тут всё хранить будем, ёпта
        private List<Game> games = new List<Game>();
        /// <summary>
        /// ЕБАТЬ ЭТО ЖЕ КОНСТРУКТОР ЕБАНОЙ ФОРМЫ, ЧТО ТУТ БЛЯТЬ НАПИСАТЬ-ТО?
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ахуенный метод кнопки добавления новой игры
        /// P.S КНОПОЧКА НЕ НАЖАЛАСЬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ЕБАШИМ АДОВЫЙ ЭКЗЕМПЛЯР ФОРМОЧКИ
            Form2 form = new Form2();
            //запускаем диалоговую формочку, ну а хули
            form.ShowDialog();
            //Спрашиваем, как там с игрой-то?
            if (form.DialogResult == DialogResult.OK)
            {
                //Засовываем в жопу листа новую игру
                games.Add(form.game);
                //Ебашим загрузку данных на всякие датагриды
                LoadData();
            }
        }
        //Ультимативный метод разъёба данных
        private void LoadData()
        {
            //Ебаный рефреш не работает, так что сначала обнуляем датасорс
            dataGridView1.DataSource = null;
            //Вставляем наши игори в датагрид
            dataGridView1.DataSource = games;
            //сейм для комбобокса
            comboBox1.DataSource = null;
            comboBox1.DataSource = games;
            //отображение на комбо боксе
            comboBox1.DisplayMember = "Genre";
            //значение в комбо боксе
            comboBox1.ValueMember = "Genre";
        }
        //Ну тут изи метод для чтения из файла
        private void button2_Click(object sender, EventArgs e)
        {
            //открываем ебаный файл
            using FileStream fileStream = File.OpenRead(Directory.GetCurrentDirectory() + "/jsonFile.txt");
            //Десериализуем эту парашу, не забывая приводить к нужному нам типу
            games = JsonSerializer.Deserialize<List<Game>>(fileStream);
            //Ебашим загрузку данных на всякие датагриды
            LoadData();
        }
        //Ну а хули, пишем в файл жсон
        private void button3_Click(object sender, EventArgs e)
        {
            //Создаём/открываем файл
            FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + "/jsonFile.txt", FileMode.OpenOrCreate);
            //Сериализуем наши игры
            var test = JsonSerializer.Serialize(games);
            //Пишем в файл всё что сериализовалось
            fileStream.Write(System.Text.Encoding.UTF8.GetBytes(test), 0, test.Length);
            //Не забываем смыть за собой 
            fileStream.Flush();
            //Закрываем нахуй файл, чтобы до нас не доебались
            fileStream.Close();
        }
        //ЕБАНЫЙ ЛИНКЬЮ ПОШЁЛ, жанр указан пользователем, так что выводим только то, что указано
        private void button4_Click(object sender, EventArgs e)
        {
            //выбираем, чё там пользователь выбрал
            var selected = from game in games
                           where game.Genre == comboBox1.SelectedValue.ToString()
                           select game;
            //Не забываем из этого говна сделать нужный нам Лист
            List<Game> test = selected.ToList();
            //Вставляем в датагрид
            dataGridView2.DataSource = test;
        }
        //Пошёл нахуй этот линкью, тут уже чисто сгруппировать и показать кто чаще всего встречается
        private void button5_Click(object sender, EventArgs e)
        {
            //Группируем, выбираем, создаём списочек
            var res = games
                .GroupBy(x => x.Genre)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                });
             //Пишем в текстбокс кто там самый модный из жанров
            textBox1.Text = res.Single(x=>x.Count == res.Max(y=>y.Count)).Count.ToString();
        }
    }
}
