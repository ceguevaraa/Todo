﻿namespace Todo.Application.Lists.Commands.CreateItem
{
    public class CreateItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
