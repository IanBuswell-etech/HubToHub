﻿using System;

namespace JobPusher.Services.Dtos
{
    public class UpdateDto
    {
        public Guid Id { get; set; }
        public string Ref { get; set; }
        public string Address { get; set; }
        public string Product { get; set; }
    }
}