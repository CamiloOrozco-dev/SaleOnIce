﻿namespace SaleOnIce.Models.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }    
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public DebitCard? DebitCard { get; set; }
    }
}