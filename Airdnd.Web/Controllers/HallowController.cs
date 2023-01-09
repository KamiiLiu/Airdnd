using Airdnd.Web.Models;
using Airdnd.Web.Services.Partial;
using Airdnd.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Airdnd.Web.Controllers
{
	public class HallowController : Controller
     
	{
        private readonly MemberService _memberService;
        public HallowController(MemberService memberService)
        {
            _memberService=memberService;
        }
        public IActionResult Index()
		{
            SeoHelpDto seohelp = new SeoHelpDto
            {
                WebAddress = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value.ToString()}/Hallow",
                Title = "萬聖節心理測驗：你有多邪惡？",
                Description = "怎樣的房配怎樣的人~怎樣的人配怎樣的Code~而你敢認清自己嗎?",
                Image = "https://kamiiliu.github.io/fake.png",
            };

            ViewData["seohelp"] = seohelp; 
            ViewData["url"] = $"https://social-plugins.line.me/lineit/share?url={HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value.ToString()}/Hallow";
            int userId = 0;
            string userName = "用戶";
            if (User.Identity.IsAuthenticated)
            {
                userId = int.Parse(User.Identity.Name);
                userName = _memberService.GetUserNameById(userId);
            };
            ViewData["userName"] = userName;
            return View();
		}
	}
}
