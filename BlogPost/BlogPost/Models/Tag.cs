using System;
using System.Collections.Generic;

namespace BlogPost.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Displayname { get; set; } = null!;

    public virtual ICollection<Blogpost> Blogposts { get; set; } = new List<Blogpost>();
}
