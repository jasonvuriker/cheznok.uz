﻿using cheznok.uz.Enums;

namespace cheznok.uz.Entities;

public class FoodItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fats { get; set; }
    public FoodCategory FoodCategory { get; set; }
}