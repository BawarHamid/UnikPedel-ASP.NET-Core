using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.BookingContract;
using UnikPedel.Application.BookingContract.BookingDto;
using UnikPedel.Contract.IServiceBooking;
using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase, IServiceBooking
    {
        private readonly IBookingCommand _bookingCommand;
        private readonly IBookingQuery _bookingQuery;
        private readonly IMapper _mapper;

        public BookingController(IBookingCommand bookingCommand, IBookingQuery bookingQuery, IMapper mapper)
        {
            _bookingCommand = bookingCommand;
            _bookingQuery = bookingQuery;
            _mapper = mapper;
        }


        // POST api/<BookingController> opretter en Booking.
        [HttpPost]
        public async Task CreateAsync([FromBody] BookingCreateDto booking)
        {
            var mapperBooking = _mapper.Map<BookingCommandDto>(booking);
            await _bookingCommand.CreateAsync(mapperBooking);
        }


        // DELETE api/<BookingController>/ sletter en bestemet booking udfra Id
        [HttpDelete("{Id}")]
        public async Task DeleteAsync(int Id)
        {
            await _bookingCommand.DeleteAsync(new BookingCommandDto { Id = Id });
        }
        //PUT api/<BookingController>/ når man laver update på en booking.
        [HttpPut]
        public async Task EditAsync([FromBody] BookingDto booking)
        {
            var result = _mapper.Map<BookingCommandDto>(booking);
            await _bookingCommand.EditAsync(result);
        }

        // GET api/<BookingController> henter en bestemt booking udfra Id
        [HttpGet("{Id}")]
        public async Task<BookingDto?> GetBookingAsync(int Id)
        {
            var booking = await _bookingQuery.GetBookingAsync(Id);
            if (booking is null) return null;
            return _mapper.Map<BookingDto>(booking);
        }


        // GET: api/<BookingController> henter en list med alle Booking
        [HttpGet]
        public async Task<IEnumerable<BookingDto>> GetBookingsAsync()
        {
            var booking = await _bookingQuery.GetBookingsAsync();
            if (booking == null) return null;
            return _mapper.Map<IEnumerable<BookingDto>>(booking);
        }

        

    }
}
