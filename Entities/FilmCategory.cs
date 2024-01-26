﻿namespace Movie_rental.Entities
{
    public class FilmCategory : BaseEntity
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
