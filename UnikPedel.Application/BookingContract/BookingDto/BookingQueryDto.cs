namespace UnikPedel.Application.BookingContract.BookingDto;

public class BookingQueryDto
{
    public int Id { get; set; }
    public DateTime StartTid { get; set; }
    public DateTime SlutTid { get; set; }

    public int LejerId { get; set; }

    public int LejemaalId { get; set; }

}