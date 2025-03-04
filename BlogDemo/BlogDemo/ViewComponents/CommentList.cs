using BlogDemo.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlogDemo.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					Username = "Okan"
				},
				new UserComment
				{
					ID = 2,
					Username = "İrem"
				},
				new UserComment
				{
					ID = 3,
					Username = "Sarıoğlu"
				}
			};
			return View(commentvalues);
		}
	}
}
