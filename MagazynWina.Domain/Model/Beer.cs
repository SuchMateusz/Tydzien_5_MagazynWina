﻿using MagazynWina.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagazynWina.Domain.Model
{
    public class Beer : BaseModel
    {
        public int YearProduction { get; set; }
        public string Yeast { get; set; }
        public string TypeOfBeer { get; set; }
        protected bool Low { get; set; }
        public Beer(int typeBeerId, int beerId, string nameBeer, int blg, int year, int quantity, string yeast, string typeOfBeer)
        {
            TypeObjectId = typeBeerId;
            Id = beerId;
            Name = nameBeer;
            Blg = blg;
            YearProduction = year;
            Quantity = quantity;
            Yeast = yeast;
            TypeOfBeer = typeOfBeer;
        }
        public void CheckValueBeer(int quantity)
        {
            string check;
            if (quantity <= 15)
            {
                Low = true;
            }

            else
                Low = false;
            if (Low == true)
            {
                check = "Posiadasz już zbyt małą ilość do handlu";
            }

            else
            {
                check = "Posiadana ilość jest wystarczająca";
            }

            Console.WriteLine(check);
        }
    }
}