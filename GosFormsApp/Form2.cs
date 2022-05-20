using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GosFormsApp
{
    public partial class Form2 : Form
    {
        //Мама, а нахуя нам гет, сет? Надо, ебать, как будешь отсюда вытаскивать, что создаёшь?
        public Game game { get; set; }
        //ЕБАТЬ ЭТО ЖЕ ОПЯТЬ КОНСТРУКТОР ФОРМЫ
        public Form2()
        {
            InitializeComponent();
        }
        //Тык кнопка для создания игори из того, что там написал пользователь(обработка ошибок, не, ну его нахуй)
        private void button1_Click(object sender, EventArgs e)
        {
            //Создаём игруху, вкидываем всё что там написали
            game= new Game { Name= textBox1.Text,Genre=textBox2.Text,Rating=Int32.Parse(textBox3.Text),Description=textBox4.Text};
            //Говорим предыдущей форме, что всё заебись, можно дальше ебашить
            this.DialogResult = DialogResult.OK;
            //Закрываемся нахуй
            this.Close();
        }
    }
}
