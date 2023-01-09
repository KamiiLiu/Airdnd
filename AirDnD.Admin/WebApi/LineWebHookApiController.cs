using Airdnd.Core.Entities;
using Airdnd.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;



namespace Airdnd.Admin.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineWebHookApiController : LineWebHookControllerBase
    {
        private readonly string Token = "cD8EijnNYmf9lVHNNeWIF8fhyIrKgs7grQDpc808EQI7mi7TL4W+ICc+Vi/1cDCd+lj06aBgOZ+p5BFUrZQ9HPKe4Uf0oX6hw7b+dF+LewQSho/up54MCE/XUxYCZB6JnmX4MXFPBs5yHOIpq/GmoAdB04t89/1O/w1cDnyilFU=";
        private readonly string Id = "U897a6ad771ea267a2724d31078a6c3e3";
        //private readonly IRepository<Listing> _listing;
        //private readonly IRepository<ListingImage> _listingImage;

        //public LineWebHookApiController(IRepository<Listing> listing, IRepository<ListingImage> listingImage)
        //{
        //    _listing = listing;
        //    _listingImage = listingImage;
        //}


        [HttpPost]
        [Route("LineWebHook")]
        public IActionResult LineWebHook()
        {
            List<string> LineUserId = new List<string>();
            LineUserId.Add(Id);


            if (ReceivedMessage.events.FirstOrDefault().type == "follow")
            {
                //新朋友來了(或解除封鎖)
                isRock.LineBot.Bot followbot = new isRock.LineBot.Bot(Token);
                //var userId = 
                var userInfo = followbot.GetUserInfo(ReceivedMessage.events.FirstOrDefault().source.userId);
                followbot.ReplyMessage(ReceivedMessage.events.FirstOrDefault().replyToken, $"哈，'{userInfo.displayName}' 你來了...歡迎");
                LineUserId.Add(userInfo.userId);
                return Ok();
            }
            return Ok();
        }


    }
}
