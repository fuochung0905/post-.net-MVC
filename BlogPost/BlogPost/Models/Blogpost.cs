using System;
using System.Collections.Generic;

namespace BlogPost.Models;

public partial class Blogpost
{
    public int Id { get; set; }

    public string Heading { get; set; } = null!;

    public string Pagetitle { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Shortdescription { get; set; } = null!;

    public string Featuredimage { get; set; } = null!;

    public string Urlhandle { get; set; } = null!;

    public DateTime? Publisheddate { get; set; }

    public string? Author { get; set; }

    public bool? Visible { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
