using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using registru_auto.Entities;
using registru_auto.ExternalModels;
using registru_auto.Services.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Controllers
{
    [Route("car")]
    [ApiController]
    [EnableCors]
    public class CarController : ControllerBase
    {
        private readonly ICarUnitOfWork _carUnit;
        private readonly IMapper _mapper;

        public CarController(ICarUnitOfWork carUnit,
            IMapper mapper)
        {
            _carUnit = carUnit ?? throw new ArgumentNullException(nameof(carUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Cars
        [HttpGet, Authorize]
        [Route("{id}", Name = "GetCar")]
        public IActionResult GetCar(Guid id)
        {
            var carEntity = _carUnit.Cars.Get(id);
            if (carEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarDTO>(carEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllCars")]
        public IActionResult GetAllCars()
        {
            var carEntities = _carUnit.Cars.Find(a => a.Deleted == false || a.Deleted == null);
            if (carEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CarDTO>>(carEntities));
        }


        [Route("add", Name = "Add a new car")]
        [HttpPost, Authorize]
        public IActionResult AddCar([FromBody] CarDTO car)
        {
            var carEntity = _mapper.Map<Cars>(car);
            _carUnit.Cars.Add(carEntity);

            _carUnit.Complete();

            _carUnit.Cars.Get(carEntity.ChassisSeries);

            return CreatedAtRoute("GetCar",
                new { id = carEntity.ChassisSeries },
                _mapper.Map<CarDTO>(carEntity));
        }
        #endregion Cars

        #region Owners
        [HttpGet, Authorize]
        [Route("Owner/{OwnerId}", Name = "GetOwner")]
        public IActionResult GetOwner(Guid ownerId)
        {
            var ownerEntity = _carUnit.Owners.Get(ownerId);
            if (ownerEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OwnerDTO>(ownerEntity));
        }

        [HttpGet, Authorize]
        [Route("owner", Name = "GetAllOwners")]
        public IActionResult GetAllOwners()
        {
            var ownerEntities = _carUnit.Owners.Find(o => o.Deleted == false || o.Deleted == null);
            if (ownerEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<OwnerDTO>>(ownerEntities));
        }

        [Route("owner/add", Name = "Add a new owner")]
        [HttpPost, Authorize]
        public IActionResult AddOwner([FromBody] OwnerDTO owner)
        {
            var ownerEntity = _mapper.Map<Owners>(owner);
            _carUnit.Owners.Add(ownerEntity);

            _carUnit.Complete();

            _carUnit.Owners.Get(ownerEntity.ID);

            return CreatedAtRoute("GetOwner",
                new { OwnerId = ownerEntity.ID },
                _mapper.Map<OwnerDTO>(ownerEntity));
        }

        [Route("owner/{ownerId}", Name = "Mark Owner as deleted")]
        [HttpPut, Authorize]
        public IActionResult MarkOwnerAsDeleted(Guid ownerId)
        {
            var owner = _carUnit.Owners.FindDefault(a => a.ID.Equals(ownerId) && (a.Deleted == false || a.Deleted == null));
            if (owner != null)
            {
                owner.Deleted = true;
                if (_carUnit.Complete() > 0)
                {
                    return Ok("Owner " + ownerId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Owners
    }
}
