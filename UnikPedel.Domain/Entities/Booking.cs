using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.DomainServices;

namespace UnikPedel.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public IServiceProvider? _serviceProvider { get; set; }
        [Required]

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }


        public int LejerId { get; set; }
        public Lejer Lejer { get; set; }

        public int LejemålId { get; set; }
        public Lejemål Lejemål { get; set; }



        [Timestamp]
        public byte[] Version { get; set; }

        //for ef
        private Booking()
        {

        }

        public Booking(IServiceProvider? serviceProvider, DateTime startTid, DateTime slutTid, int lejerId, int lejemålId)
        {
            if (startTid == default) throw new ArgumentOutOfRangeException(nameof(startTid), "Start dato skal være udfyldt");
            if (slutTid == default) throw new ArgumentOutOfRangeException(nameof(slutTid), "Slut dato skal være udfyldt");
            if (startTid >= slutTid)
                throw new Exception($"Slut dato/tid skal være senere end start (start, slut): {startTid}, {slutTid}");
            StartTid = startTid;
            SlutTid = slutTid;
            LejerId = lejerId;
            LejemålId = lejemålId;
            _serviceProvider = serviceProvider;

            if (IsOverlapping()) throw new Exception("Booking overlapper med eksisterende booking");

        }

        public   bool IsOverlapping()
        {

            var bookingDomainService = _serviceProvider?.GetService<IBookingDomainService>();
            if (bookingDomainService == null) throw new Exception("Implementation of IBookingDomainService was not found");

            return bookingDomainService.GetExsistingBookings()

                .Any(a => a.Id != Id && a.StartTid <= SlutTid && StartTid <= a.SlutTid);
        }

        public void Update(DateTime startTid, DateTime slutTid)
        {
            if (startTid == default) throw new ArgumentOutOfRangeException(nameof(startTid), "Start dato skal være udfyldt");
            if (slutTid == default) throw new ArgumentOutOfRangeException(nameof(slutTid), "Slut dato skal være udfyldt");
            if (startTid >= slutTid)
                throw new Exception($"Slut dato/tid skal være senere end start (start, slut): {startTid}, {slutTid}");

            StartTid = startTid;
            SlutTid = slutTid;
            if (IsOverlapping()) throw new Exception("Booking overlapper med eksisterende booking");
        }
    }
    }
    
   

