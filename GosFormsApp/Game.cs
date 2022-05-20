using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosFormsApp
{
    /// <summary>
    /// Ну а вот и виновник торжества, класс с данными
    /// </summary>
    public class Game
    {
        //Название игры
        public string Name { get; set; }
        //Жанр игры
        public string Genre { get; set; }
        //Возрастной рейтинг
        public int Rating { get; set; }
        //Описание
        public string Description { get; set; }
    }
}
