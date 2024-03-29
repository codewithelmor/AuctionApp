﻿using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BidHeroApp.InputModels
{
    public class ItemsInputModel : BaseInputModel
    {
        public string Name { get; set; } = string.Empty;
        public IBrowserFile Image { get; set; }
        public bool IsActive { get; set; } = true;
        public int Quantity { get; set; } = 1;

        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;

        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;

        public int Category { get; set; }
    }
}
