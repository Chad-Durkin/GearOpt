using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GearOptimizer.Models
{
    [Table("Gears")]
    public class Gear
    {
        [Key]
        public int Id { get; set; }
        public string Slot { get; set; }
        public string Name { get; set; }
        public string Reqs { get; set; }
        public int Price { get; set; }
        public int AtkStab { get; set; }
        public int AtkSlash { get; set; }
        public int AtkCrush { get; set; }
        public int AtkMagic { get; set; }
        public int AtkRange { get; set; }
        public int DefStab { get; set; }
        public int DefSlash { get; set; }
        public int DefCrush { get; set; }
        public int DefMagic { get; set; }
        public int DefRange { get; set; }
        public int MeleeStr { get; set; }
        public int RangeStr { get; set; }
        public int MagicDmg { get; set; }
        public int Prayer { get; set; }
        public int Undead { get; set; }
        public int Slayer { get; set; }
        public virtual ICollection<FullSetGear> FullSetGears { get; set; }

        public static void UpdatePrice(GearOptimizerDbContext _db)
        {
            Gear[] updatePrice = _db.Gears.ToArray();
            for (var i = 0; i < updatePrice.Length; i++)
            {
                var id = Item.LoadJsonFindId(updatePrice[i].Name);
                if (id != 0)
                {
                    //Grab the json object of the item
                    var json = Item.GetPrices("/api/catalogue/detail.json?item=" + id).ToString();

                    var data = (JObject)JsonConvert.DeserializeObject(json);

                    string newPrice = data["item"]["current"]["price"].Value<string>();

                    newPrice = newPrice.Replace("m", "00000");
                    newPrice = newPrice.Replace("k", "00");
                    newPrice = newPrice.Replace(".", "");

                    //Update the price in the database
                    updatePrice[i].Price = int.Parse(newPrice);

                    _db.Entry(updatePrice[i]).State = EntityState.Modified;
                }
            }
            _db.SaveChanges();
        }

    }
}
