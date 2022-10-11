using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get { return ingredients; } set { ingredients = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel 
        { 
            get 
            {
                int sum = 0;

                foreach (var item in Ingredients)
                {
                    sum += item.Alcohol;
                }

                return sum;
            } 
        }

        public void Add(Ingredient ingredient)
        {
            if (!this.Ingredients.Any(i => i.Name == ingredient.Name) && this.Ingredients.Count < this.Capacity && ingredient.Alcohol <= MaxAlcoholLevel)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (this.Ingredients.Any(i => i.Name == name))
            {
                this.Ingredients = this.Ingredients.Where(i => i.Name != name).ToList();
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (this.Ingredients.Any(i => i.Name == name))
            {
                return this.Ingredients.Where(i => i.Name == name).ToList()[0];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.OrderByDescending(i => i.Alcohol).ToList()[0];
        }

       
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            for (int i = 0; i < this.Ingredients.Count; i++)
            {
                if (i == this.Ingredients.Count - 1)
                {
                    sb.Append(Ingredients[i].ToString());
                }
                else
                {
                    sb.AppendLine(Ingredients[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
