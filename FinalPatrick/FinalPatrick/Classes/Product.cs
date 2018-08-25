using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPatrick.Classes
{
    public class Product
    {
        private int id;
        private string name;
        private float price;
        private bool active;
        private Category category;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public Category Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public Product(string name, float price, bool active)
        {

            this.Name = name;
            this.Price = price;
            this.Active = active;
        }
        public Product(string name, bool active)
        {

            this.Name = name;
            this.Active = active;

        }

        public Product()
        {

        }
    }
}

        

         
        
    
