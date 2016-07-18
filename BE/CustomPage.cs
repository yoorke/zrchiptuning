using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class CustomPage : BaseEntity
	{
		[SqlFieldNameAttribute("title")]
		public string Title { get; set; }

		[SqlFieldNameAttribute("description")]
		public string Description { get; set; }

		[SqlFieldNameAttribute("url")]
		public string Url { get; set; }

		[SqlFieldNameAttribute("content")]
		public string Content { get; set; }

		[SqlFieldNameAttribute("heading")]
		public string Heading { get; set; }

		[SqlFieldNameAttribute("head")]
		public string Head { get; set; }

		[SqlFieldNameAttribute("sortindex")]
		public int SortIndex { get; set; }

		[SqlFieldNameAttribute("imageurl")]
		public string ImageUrl { get; set; }

		[SqlFieldNameAttribute("custompagecategoryid", "CustomPageCategory", "id", Relation.OneToOne)]
		public CustomPageCategory CustomPageCategory { get; set; }

        [SqlFieldNameAttribute("footer")]
        public string Footer { get; set; }


		public CustomPage()
		{

		}

		public CustomPage(string title, string description, string url, string content, string heading, string head, int sortindex, string imageurl, CustomPageCategory custompagecategory, int id, string footer)
		{
		    this.Title = title;
		    this.Description = description;
		    this.Url = url;
		    this.Content = content;
		    this.Heading = heading;
		    this.Head = head;
		    this.SortIndex = sortindex;
		    this.ImageUrl = imageurl;
		    this.CustomPageCategory = custompagecategory;
	        this.ID = id;
            this.Footer = footer;
		}
	}
}