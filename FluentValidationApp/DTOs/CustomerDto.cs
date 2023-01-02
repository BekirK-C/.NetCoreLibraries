namespace FluentValidationApp.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Eposta { get; set; }
        public int Yas { get; set; }
        public string FullName { get; set; }
        public string CreditCardNumber { get; set; }  // Otomatik mapping için önce class ismi ardından prop. ismi yazılmalıdır.
        public DateTime CreditCardValidDate { get; set; }

    }
}
