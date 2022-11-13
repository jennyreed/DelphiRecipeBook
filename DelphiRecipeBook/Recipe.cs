using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DelphiRecipeBook
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Author { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }


    }
}
