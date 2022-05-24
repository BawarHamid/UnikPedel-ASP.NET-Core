using Refit;

namespace UnikPedel.ApiInterface.MockData
{
    public class LejerMock
    {
        [Get("/Lejer/{id}")] Task<LejerResponse?> GetLejer([AliasAs("id")] Guid lejerId);
        [Put("/Lejer/{id}")] Task<LejerResponse?> UpdateLejer([AliasAs("id")] Guid lejerId, LejerUpdateRequest request);
        [Delete("/Lejer/{id}")] Task DeleteLejer([AliasAs("id")] Guid lejerId);
        [Get("/Lejemaal/{id}/Lejer")] Task<IEnumerable<LejerResponse>?> ListLejereOnLejemaal([AliasAs("id")] Guid lejemaalId);
        [Post("/Lejer")] Task<LejerResponse?> CreateLejer(LejerCreateRequest request);
    }
}
