using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnikPedel.Application.BookingContract;
using UnikPedel.Application.BookingContract.BookingDto;

using UnikPedel.Contract.IServiceBooking.BookingDtos;

namespace UnikPedel.ApiInterface.Controllers
{
    [Route("api/BookingLejer")]
    [ApiController]
    public class BookingLejerController : Controller

    {
        private readonly IBookingQuery _bookingQuery;
        private readonly IMapper _mapper;
       
        public BookingLejerController(IBookingQuery bookingQuery,IMapper mapper)
        {
            _bookingQuery = bookingQuery;   
            _mapper = mapper;   
          

        }
        [HttpGet("{Id}")]
        public async Task<IEnumerable<BookingDto>> GetBookingForLejerAsync(int Id)
        {
            var bookings =  await _bookingQuery.GetBookingsForLejerAsync(Id);
           return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        
    }
}
