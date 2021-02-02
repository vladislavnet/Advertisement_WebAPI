using advertisement.models;
using Advertisement.API.Application.Models;
using Advertisement.Memory;
using Advertisement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Advertisement.Controllers.Adverts
{
    [ApiController]
    [Route("api/adverts")]
    public class AdvertController : Controller
    {
        private readonly IAdvertRepository advertRepository;
        private readonly IUserRepository userRepository;
        public AdvertController(IAdvertRepository advertRepository,
                                IUserRepository userRepository)
        {
            this.advertRepository = advertRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Json(advertRepository.GetAll());
        }

        [Authorize]
        [HttpGet("get-adverts-user")]
        public IActionResult GetAdvertsUser()
        {
            var userId = getUserIdHttpContext(HttpContext);

            var adverts = advertRepository.GetAll().Where(a => a.OwnerUserId == int.Parse(userId));

            return Json(adverts);
        }

        [Authorize]
        [HttpPost("add-advert")]
        public IActionResult Add(AddAdvertModels advert)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = int.Parse(getUserIdHttpContext(HttpContext));
            var user = userRepository.GetById(userId);

            advertRepository.Add(new Advert
            {
                Title = advert.Title,
                Description = advert.Description,
                OwnerUserId = userId,
                OwnerUser = user
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("edit-advert")]
        public IActionResult Update(UpdateAdvertModels advert)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!advertRepository.TryGetById(advert.Id, out Advert updateAdvert))
                return NotFound();

            var userId = int.Parse(getUserIdHttpContext(HttpContext));
            var role = getRoleHttpContext(HttpContext);

            if (updateAdvert.OwnerUserId != userId && role != RolesValues.ADMIN)
                return Forbid();

            advertRepository.Update(new Advert 
            { 
                Id = advert.Id, 
                Title = advert.Title, 
                Description = advert.Description 
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("delete-advert")]
        public IActionResult Delete(int id)
        {
            if (!advertRepository.TryGetById(id, out Advert updateAdvert))
                return NotFound();

            var userId = int.Parse(getUserIdHttpContext(HttpContext));
            var role = getRoleHttpContext(HttpContext);

            if (updateAdvert.OwnerUserId != userId && role != RolesValues.ADMIN)
                return Forbid();

            advertRepository.Delete(updateAdvert);

            return Ok();
        }


        private string getUserIdHttpContext(HttpContext context)
        {
            return context.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                                                .Select(c => c.Value)
                                                .SingleOrDefault();
        }

        private string getRoleHttpContext(HttpContext context)
        {
            return context.User.Claims.Where(c => c.Type == ClaimTypes.Role)
                                                .Select(c => c.Value)
                                                .SingleOrDefault();
        }
    }
}
