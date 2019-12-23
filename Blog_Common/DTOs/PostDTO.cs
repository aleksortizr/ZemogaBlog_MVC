using System;
using System.Collections.Generic;

namespace Blog_Common.DTOs
{
	public class PostDTO
	{
		public int Id { get; set; } // int
		public int? ParentId { get; set; } // int
		public string Text { get; set; } // nvarchar(255)
		public int UserId { get; set; } // int
		public int StatusId { get; set; } // int

		public string StatusName { get { return ((PostStatuses)StatusId).ToString(); } } // int
		public DateTime CreatedDate { get; set; } // datetime

		public DateTime ApprovalDate { get; set; } // datetime

		public IEnumerable<CommentDTO> Comments { get; set; }

		public string Author { get; set; }
	}
}
